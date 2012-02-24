using System;
using System.Xml.Linq;

namespace Bti.Babble.Traffic.Model.Mock
{
    class TrafficLogRepository : ITrafficLogRepository
    {
        public TrafficLog GetByDate(DateTime date)
        {
            var log = new TrafficLog().ToInitializedObject();
            log.Date = new DateTime(2012,02,13);
            log.ParseDate = DateTime.Now;
            log.Station = "WKRN";

            var e1 = new TrafficEvent()
            {
                Barcode = "",
                Type = TrafficEventType.Program,
                Description = "News 2 Early Morning",
                Length = new TimeSpan(0, 10, 0),
                Time = new TimeSpan(4, 0, 0)
            };
            log.Events.Add(e1);

            var e2 = new TrafficEvent()
            {
                Barcode = "53752",
                Type = TrafficEventType.Commercial,
                Description = "Centerstone",
                Length = new TimeSpan(0, 0, 15),
                Time = new TimeSpan(4, 10, 0)
            };
            log.Events.Add(e2);

            var e3 = new TrafficEvent()
            {
                Barcode = "50947",
                Type = TrafficEventType.Commercial,
                Description = "Belmont University",
                Length = new TimeSpan(0, 0, 30),
                Time = new TimeSpan(4, 10, 15)
            };
            log.Events.Add(e3);

            var e4 = new TrafficEvent()
            {
                Barcode = "52823",
                Type = TrafficEventType.Commercial,
                Description = "Great Southern Wood",
                Length = new TimeSpan(0, 0, 30),
                Time = new TimeSpan(4, 10, 45)
            };
            log.Events.Add(e4);

            var e5 = new TrafficEvent()
            {
                Barcode = "53874",
                Type = TrafficEventType.Commercial,
                Description = "Smiley Dental Associates",
                Length = new TimeSpan(0, 0, 30),
                Time = new TimeSpan(4, 10, 0)
            };
            log.Events.Add(e5);

            var e6 = new TrafficEvent()
            {
                Barcode = "",
                Type = TrafficEventType.Program,
                Description = "News 2 Early Morning",
                Length = new TimeSpan(0, 10, 0),
                Time = new TimeSpan(4, 11, 45)
            };
            log.Events.Add(e6);

            var e7 = new TrafficEvent()
            {
                Barcode = "81183",
                Type = TrafficEventType.Promo,
                Description = "WKRN NEWS 2 PROMO",
                Length = new TimeSpan(0, 10, 0),
                Time = new TimeSpan(4, 11, 45)
            };
            log.Events.Add(e7);

            return log;
        }
    }
}