using System;
using System.IO;
using Bti.Babble.Traffic.Model;

namespace Bti.Babble.Traffic.Parser
{
    public class WkrnLogParser
    {
        private ILineParser lineParser = new FamilyChannelLineParser();
        private int eventLine = 0;
        private int eventStartLine = 1;
        
        private DateColumn Date = new DateColumn() { StartPos = 8, Length = 6 };
        private StringColumn Station = new StringColumn() { StartPos = 14, Length = 4 };

        public WkrnLogParser()
        {
        }

        public TrafficLog Parse(string path)
        {
            var filename = Path.GetFileName(path);
            var lines = File.ReadAllLines(path.ToString());
            var logline = lines[0];
            TrafficLog log = new TrafficLog().ToInitializedObject();
            log.Station = Station.Parse(logline);
            log.Date = Date.ParseMMDDYY(logline);
            log.ParseDate = DateTime.Now;
            foreach (var line in lines)
            {
                eventLine += 1;
                if (eventLine < eventStartLine) continue;
                log.Events.Add(lineParser.Parse(line));
            }
            return log;
        }
    }
}
