﻿using System;
using System.Collections.Generic;
using System.Linq;
using Reclamation.Core;
using System.Data;
using System.IO;
using Reclamation.TimeSeries.Hydromet;
using System.Configuration;

namespace Reclamation.TimeSeries.AgriMet
{
    /// <summary>
    /// Generates Estimated Crop Water Use Charts
    /// </summary>
    public class CropChartGenerator
    {

        /// <summary>
        /// Creates Daily and Summary Crop Reports 
        /// </summary>
        /// <param name="cbttList">list of cbtt to create charts for</param>
        /// <param name="year">year used to filter database of crop dates</param>
        /// <param name="date">terminate date (or if null use etr terminate date)</param>
        public static void CreateCropReports(int year, string outputDirectory)
        {
            CropDatesDataSet.CropDatesDataTable  cropTable= new CropDatesDataSet.CropDatesDataTable();

            cropTable = CropDatesDataSet.GetCropDataTable(year,false); 

            var cbttList = (from row in cropTable.AsEnumerable() // get list of cbtt
                            select row.cbtt).Distinct().ToArray();
            if (cbttList.Length > 1)
            {// for performance query hydromet only once.
                var cache = new HydrometDataCache();
                // boii, abei
                // boii et, abei et
                var s = String.Join(" ETRS,", cbttList) + " ETRS";
                var cbttPcode = s.Split(',');
                DateTime t1 = new DateTime(year, 1, 1);
                DateTime t2 = new DateTime(year, 12, 31);
                if (t2 > DateTime.Now.Date)
                    t2 = DateTime.Now.Date;

                cache.Add(cbttPcode, t1, t2, HydrometHost.PN, TimeSeries.TimeInterval.Daily);
                HydrometDailySeries.Cache = cache; ;
            }

            DateTime t = DateTime.Now.Date;

            for (int i = 0; i < cbttList.Length; i++)
            {

                var cropDates = cropTable.Where(x => x.cbtt == cbttList[i]
                     && !x.IsterminatedateNull()
                     && !x.IsstartdateNull()
                     && !x.IsfullcoverdateNull()).ToArray();

                if (cropDates.Length == 0)
                    continue;
                
                ValidateCropDates(cbttList[i], cropDates);

                var terminateDate = TerminateDate(cbttList[i], cropDates);

                    if ( terminateDate < DateTime.Now)
                        t = terminateDate.AddDays(1);
                    else
                        t = DateTime.Now.Date;
                
                // Generates Daily and Summary Crop Charts
                var dailyChart = CreateDailyReport(cbttList[i], t, cropDates);
                var sumChart = CreateSummaryReport(cbttList[i], t, cropDates);


                //string header = "AgriMet is excited to announce a partnership with Washington State University to icorporate AgriMet data into WSU's Irrigation Scheduler. To customize crop consumptive water use specific to your field or fields, visit http://weather.wsu.edu/is/";

                
                var fnDaily = Path.Combine(outputDirectory, cbttList[i].ToLower() + "ch.txt");
                var fnSum = Path.Combine(outputDirectory, cbttList[i].ToLower() + t.Year.ToString().Substring(2) + "et.txt");

                WriteCropFile(dailyChart, fnDaily);
                WriteCropFile(sumChart,fnSum);

                

            }
            Console.WriteLine(" Daily and Summary Crop Charts Saved for "+cbttList.Length+" sites");

        }

        private static void WriteCropFile( List<string> data, string fnDaily)
        {
            string fn = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            fn = Path.Combine(fn, "crop_header.txt");
            if (File.Exists(fn))
            {
                //Console.WriteLine("reading "+fn);
                var lines  =File.ReadAllLines(fn);
                data.InsertRange(0, lines);
            }

           // data.Insert(0, header);
            File.WriteAllLines(fnDaily, data.ToArray());
        }

        private static DateTime TerminateDate(string cbtt, CropDatesDataSet.CropDatesRow[] cropDates)
        {
            // lookup terminate date for reference crop ET.
            var query = (from row in cropDates.AsEnumerable()
                         where row.cropname.ToLower() == "etr"
                         select row.terminatedate).ToArray();

            if (query.Length > 1)
            {
                throw new Exception("Error: multiple Etr defined for " +  cbtt);
            }
            if (query.Length == 0)
            {
                throw new Exception("Error: no Etr found for " +  cbtt);
            }
            var terminateDate = query[0];
            return terminateDate;
        }

        // Checks that ETr Start and Terminate Dates are the extremes for the station
        private static void ValidateCropDates(string cbtt, CropDatesDataSet.CropDatesRow[] cropDates)
        {

            string msg = "";
            for (int j = 0; j < cropDates.Count(); j++)
            {
                var row = cropDates[j];

                if (row.startdate > row.fullcoverdate)
                    msg += "\nError: StartDate > FullCoverDate   " + cbtt + " " + row.cropname;


                if (row.startdate >= row.fullcoverdate && row.cropname.Trim().ToLower() != "etr")
                    msg += "\nError: StartDate >= FullCoverDate   " + cbtt+ " "+row.cropname;


                if (row.fullcoverdate >= row.terminatedate)
                    msg += "\nError: FullCoverDate >= TerminateDate  " + cbtt + " " + row.cropname;

                if (row.terminatedate > cropDates[0].terminatedate)
                {
                    msg += "\nError: " + cbtt + ":" + row.cropname +
                        "\nTerminate Date goes past ETr Terminate Date.  " + cbtt + " " + row.cropname;
                }
                if (row.startdate < cropDates[0].startdate)
                {
                    msg +="\nError: " + cbtt + ":" + row.cropname +
                        " Start Date comes before ETr Start Date.  " + cbtt + " " + row.cropname;
                }
            }

            if (msg.Trim() != "")
                throw new Exception(msg);

        }


        /// <summary>
        /// Creates Daily Crop Water Use Charts
        /// </summary>
        /// <param name="cbtt"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        private static List<string> CreateDailyReport(string cbtt, DateTime t,
            CropDatesDataSet.CropDatesRow[] cropRow)
        {
            var rval = new List<string>();

            //var cropRow = CropDatesDataSet.GetCropFiles(t.Year, cbtt);

            // Produces Crop Chart heading
            rval.Add("");
            rval.Add(" ************************************************************************");
            rval.Add(" *                                                                      *");
            rval.Add(" *" + "  " + "ESTIMATED CROP WATER USE - " + t.ToString("MMM dd, yyyy") + "   " + cbtt + "\t\t\t" + "*");
            rval.Add(" *                                                                      *");
            rval.Add(" ************************************************************************");
            rval.Add(" *           *        DAILY        *      *     *     *      *    *     *");
            rval.Add(" *           * CROP WATER USE-(IN) * DAILY*     *     *      *  7 *  14 *");
            rval.Add(" * CROP START*  PENMAN ET  -  " + t.ToString("MMM") + "  * FORE *COVER* TERM* SUM  * DAY* DAY *");
            rval.Add(" *       DATE*---------------------* CAST * DATE* DATE*  ET  * USE* USE *");

            rval.Add(" *           *"
                        + t.AddDays(-4).Day.ToString().PadLeft(4)
                            + t.AddDays(-3).Day.ToString().PadLeft(5)
                            + t.AddDays(-2).Day.ToString().PadLeft(5)
                            + t.AddDays(-1).Day.ToString().PadLeft(5)
                        + "  *      *     *     *      *    *     *");

            var et = new HydrometDailySeries(cbtt, "ETRS");
            //var et = new KimberlyPenmanEtSeries(cbtt);

            // Below is the calculation to determine how many days to read back. Set to calculate based on ETr Start Date.
            var etStartDate = cropRow[0].startdate.DayOfYear;
            var etTodayDate = t.DayOfYear;
            int numDaysRead = etTodayDate - etStartDate - 1;
            et.Read(t.AddDays(-numDaysRead), t.AddDays(-1));

            // For-Loop to populate chart
            for (int i = 0; i < cropRow.Length; i++)
            {
                rval.Add(" *-----------*---------------------*------*------------------*----------*");
                var row = cropRow[i];
                string s = " * " + row.cropname.PadRight(4) + " " + row.startdate.ToString("MM/dd").PadLeft(4) + "*"
                // Calculates Daily Crop ET values
                + " " + CropCurves.ETCropDaily(numDaysRead, 4, et, row).PadLeft(4)
                + " " + CropCurves.ETCropDaily(numDaysRead, 3, et, row).PadLeft(4)
                + " " + CropCurves.ETCropDaily(numDaysRead, 2, et, row).PadLeft(4)
                + " " + CropCurves.ETCropDaily(numDaysRead, 1, et, row).PadLeft(4)
                // Today's forecast is the average of previous 3 days
                + " * " + (CropCurves.EtSummation(3, et, row, numDaysRead) / 3).ToString("F2").PadLeft(3)
                + " *" + row.fullcoverdate.ToString("MM/dd").PadRight(4) + "*" + row.terminatedate.ToString("MM/dd").PadLeft(4)
                // Cumulative summation from Crop Start Date to today
                + "* " + CropCurves.EtSummation(numDaysRead, et, row, numDaysRead).ToString("F1").PadLeft(4) + " * "
                // 7 and 14 day use 
                + CropCurves.EtSummation(7, et, row, numDaysRead).ToString("F1") + "* "
                + CropCurves.EtSummation(14, et, row, numDaysRead).ToString("F1") + " *";

                rval.Add(s);
            }

            rval.Add(" ************************************************************************");
            return rval;

        }


        /// <summary>
        /// Creates Summary Crop Water Use Charts
        /// </summary>
        /// <param name="cbtt"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        private static List<string> CreateSummaryReport(string cbtt, DateTime t,
            CropDatesDataSet.CropDatesRow[] cropRow)
        {
            var rval = new List<string>();

            //var cropRow = CropDatesDataSet.GetCropFiles(t.Year, cbtt); 

            var et = new HydrometDailySeries(cbtt, "ETRS");
            //var et = new KimberlyPenmanEtSeries(cbtt);

            // Below is the calculation to determine how many days to read back. Set to calculate based on ETr Start Date.
            var etStartDate = cropRow[0].startdate.DayOfYear;
            var etTodayDate = t.DayOfYear;
            int numDaysRead = etTodayDate - etStartDate;
            et.Read(t.AddDays(-numDaysRead), t.AddDays(-1));

            // Produces Summary Chart heading. 
            rval.Add("                        " + " " + cbtt + " - " + "ET SUMMARY" + " - " + t.ToString("yyyy") + " ");
            string s1 = " DATE "; string s2 = "     "; string s5 = " ----";
            for (int i = 0; i < cropRow.Length; i++)
            {
                var row = cropRow[i];
                s1 = s1 + row.cropname.PadRight(5);
                //s2 = s2 + " " + row.UIDX.ToString("F0").PadLeft(3) + " ";
                s2 = s2 + " " + "".PadLeft(3) + " ";
                s5 = s5 + " " + "----";
            }
            rval.Add(s2);
            rval.Add(s1);
            rval.Add(s5 + " ");

            // Populates Summary Chart by generating strings of ET values.
            string dateString = " ";
            for (int dateIndex = 1; dateIndex < numDaysRead; dateIndex++)
            {
                var t1 = et[dateIndex].DateTime;
                dateString = " " + t1.ToString("MM/dd").PadLeft(4);
                string valueString = "";
                for (int cropIndex = 0; cropIndex < cropRow.Length; cropIndex++)
                {
                    var row = cropRow[cropIndex];
                    var etValue = CropCurves.WaterUse(t1, et[dateIndex].Value, row);
                    if (t1 < cropRow[cropIndex].startdate
                        || t1 > cropRow[cropIndex].terminatedate)
                    {
                        valueString += "  -- ";
                    }
                    else
                    {
                        valueString += etValue.ToString("F2").PadLeft(5);
                    }
                }
                rval.Add(dateString + valueString);
            }
            return rval;
        }
    }
}



