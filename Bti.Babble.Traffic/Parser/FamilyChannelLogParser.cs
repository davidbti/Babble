using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Bti.Babble.Traffic
{
    public class FamilyChannelLogParser
    {
        private ILineParser lineParser = new FamilyChannelLineParser();
        private int eventLine = 0;
        private int eventStartLine = 3;

        public FamilyChannelLogParser()
        {
        }

        public TrafficLog Parse(string path)
        {
            var filename = Path.GetFileName(path);
            int year = 2000 + Int32.Parse(filename.Substring(1,2));
            int month = ParseMonth(filename.Substring(3,3));
            int day = Int32.Parse(filename.Substring(6,2));
            TrafficLog log = new TrafficLog().ToInitializedObject();
            log.Station = "FAM";
            log.Date = new DateTime(year, month, day);
            log.ReadDate = DateTime.Now;
            foreach (var line in File.ReadAllLines(path.ToString()))
            {
                eventLine += 1;
                if (eventLine < eventStartLine) continue;
                log.Events.Add(lineParser.Parse(line));
            }
            return log;
        }

        private int ParseMonth(string fileName)
        {
            switch (fileName.ToUpper())
            {
                case "AUG" :
                    return 8;
            }
            return 0;
        }
    }
}
