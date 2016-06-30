﻿using Reclamation.TimeSeries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PiscesWebServices.CGI
{
    class HtmlFormatter: Formatter
    {
        bool m_printHeader = true;
        public HtmlFormatter(TimeInterval interval, bool printFlags, bool printHeader)
             : base(interval, printFlags)
         {
             m_printHeader = printHeader;
         }

         public override void WriteLine(string s)
         {
             Console.WriteLine(s);
         }

         public override void PrintRow(string t0, string[] vals, string[] flags)
         {
             StringBuilder sb = new StringBuilder(vals.Length * 8);
             WriteLine("<tr>");
             WriteLine("<td>" + t0 + "</td>");
             for (int i = 0; i < vals.Length; i++)
             {
                 WriteLine("<td>" + vals[i] + "</td>");
                 if( PrintFlags)
                     WriteLine("<td>" + flags[i] + "</td>");

             }
             WriteLine("</tr>");
         }

         public override string FormatNumber(object o)
         {
             var rval = "";
             if (o == DBNull.Value || o.ToString() == "")
                 rval = "";//.PadLeft(11);
             else
                 rval = Convert.ToDouble(o).ToString("F02");
             return rval;
         }


         public override string FormatFlag(object o)
         {
             if (o == DBNull.Value)
                 return "";
             else
                 return o.ToString();
         }

        public override string FormatDate(object o)
         {
             var rval = "";
             var t = Convert.ToDateTime(o);
             if (Interval == TimeInterval.Irregular || Interval == TimeInterval.Hourly)
                 rval = t.ToString("yyyy-MM-dd HH:mm");
             else
                 rval = t.ToString("yyyy-MM-dd");
             return rval;
         }
        public override void WriteSeriesHeader(SeriesList list)
        {
            WriteLine("<table  border=1>");

            if (m_printHeader)
            {
                WriteLine("<tr>");
                WriteLine("<td>DateTime</td>");
                for (int i = 0; i < list.Count; i++)
                {
                    TimeSeriesName tn = new TimeSeriesName(list[i].Table.TableName);
                    WriteLine("<td>" + tn.siteid + "_" + tn.pcode + "</td>");
                    if( PrintFlags )
                        WriteLine("<td>flag</td>");
                }
                WriteLine("</tr>");
            }

        }

        public override void WriteSeriesTrailer()
        {
            WriteLine("</table>");
        }
    }
}
