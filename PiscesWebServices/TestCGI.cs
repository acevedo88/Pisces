﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Reclamation.Core;
using Reclamation.TimeSeries;

namespace PiscesWebServices
{
    [TestFixture]    
    class TestCGI
    {
        public static void Main()
        {
            TestCGI t = new TestCGI();
            t.CsvTest();
        }

        [Test]
        public void CsvTest()
        {

            string payload = "parameter=mddo ch,wcao q&syer=2015&smnth=4&sdy=1&eyer=2015&emnth=4&edy=1&format=2";
            //Program.Main(new string[] { "--cgi=instant", "--payload=?"+payload });

            TimeSeriesDatabase db = TimeSeriesDatabase.InitDatabase(new Arguments(new string[]{}));
            CsvTimeSeriesWriter c = new CsvTimeSeriesWriter(db);
            var fn = FileUtility.GetTempFileName(".txt");
            c.Run(payload,fn);

            var fnhyd0 = FileUtility.GetTempFileName(".txt");
            Web.GetFile("http://www.usbr.gov/pn-bin/webdaycsv.pl?" + payload, fnhyd0);

            var diff = TextFile.Compare(new TextFile(fn), new TextFile(fnhyd0));

            foreach (var item in diff)
            {
                Console.WriteLine();
            }
        }

        [Test]
        public void DumpTest()
        {
            Program.Main(new string[] { "--cgi=sites" });
        }
    }
}
