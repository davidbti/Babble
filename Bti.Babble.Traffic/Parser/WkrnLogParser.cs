using System;
using System.IO;
using Bti.Babble.Traffic.Model;

namespace Bti.Babble.Traffic.Parser
{
    public class WkrnLogParser : ILogParser
    {
        private ILineParser lineParser = new WkrnLineParser();
        private int eventLine = 0;
        private int eventStartLine = 1;
        
        private DateColumn Date = new DateColumn() { StartPos = 7, Length = 6 };
        private StringColumn Station = new StringColumn() { StartPos = 13, Length = 4 };

        public WkrnLogParser()
        {
        }

        public bool CanParse(DateTime date)
        {
            return File.Exists(GetFileForDate(date));
        }

        public string GetFileForDate(DateTime date)
        {
            var fileName = "WKRN" + date.Day.ToString("D2") + date.Month.ToString("D2") + date.Day.ToString("D2") + date.Year.ToString().Substring(2, 2) + ".log";
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Traffic Logs", fileName);
        }

        public TrafficLog Parse(DateTime date)
        {
            var file = GetFileForDate(date);
            var lines = File.ReadAllLines(file.ToString());
            var logline = lines[0];
            TrafficLog log = new TrafficLog().ToInitializedObject();
            log.Station = Station.Parse(logline);
            log.Date = Date.ParseMMDDYY(logline);
            log.ParseDate = DateTime.Now;
            foreach (var line in lines)
            {
                eventLine += 1;
                if (eventLine <= eventStartLine) continue;
                log.Events.Add(lineParser.Parse(line));
            }
            return log;
        }
    }
}
