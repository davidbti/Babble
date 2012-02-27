using System;
using System.Linq;
using System.Xml.Linq;

namespace Bti.Babble.Traffic.Model.Mock
{
    class TrafficLogRepository : ITrafficLogRepository
    {
        private IBabbleEventRepository repository = new BabbleEventRepository();

        public TrafficLog GetByDate(DateTime date)
        {
            var log = new TrafficLog();
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
            e1.BabbleEvents = repository.GetForTrafficEvent(e1).ToObservable();
            log.Events.Add(e1);

            var e2 = new TrafficEvent()
            {
                Barcode = "53752",
                Type = TrafficEventType.Commercial,
                Description = "Centerstone",
                Length = new TimeSpan(0, 0, 15),
                Time = new TimeSpan(4, 10, 0)
            };
            e2.BabbleEvents = repository.GetForTrafficEvent(e2).ToObservable();
            log.Events.Add(e2);

            var e3 = new TrafficEvent()
            {
                Barcode = "50947",
                Type = TrafficEventType.Commercial,
                Description = "Belmont University",
                Length = new TimeSpan(0, 0, 30),
                Time = new TimeSpan(4, 10, 15)
            };
            e3.BabbleEvents = repository.GetForTrafficEvent(e3).ToObservable();
            log.Events.Add(e3);

            var e4 = new TrafficEvent()
            {
                Barcode = "52823",
                Type = TrafficEventType.Commercial,
                Description = "Great Southern Wood",
                Length = new TimeSpan(0, 0, 30),
                Time = new TimeSpan(4, 10, 45)
            };
            e4.BabbleEvents = repository.GetForTrafficEvent(e4).ToObservable();
            log.Events.Add(e4);

            var e5 = new TrafficEvent()
            {
                Barcode = "53874",
                Type = TrafficEventType.Commercial,
                Description = "Smiley Dental Associates",
                Length = new TimeSpan(0, 0, 30),
                Time = new TimeSpan(4, 10, 0)
            };
            e5.BabbleEvents = repository.GetForTrafficEvent(e5).ToObservable();
            log.Events.Add(e5);

            var e6 = new TrafficEvent()
            {
                Barcode = "",
                Type = TrafficEventType.Program,
                Description = "News 2 Early Morning",
                Length = new TimeSpan(0, 10, 0),
                Time = new TimeSpan(4, 11, 45)
            };
            e6.BabbleEvents = repository.GetForTrafficEvent(e6).ToObservable();
            log.Events.Add(e6);

            var e7 = new TrafficEvent()
            {
                Barcode = "81183",
                Type = TrafficEventType.Promo,
                Description = "WKRN NEWS 2 PROMO",
                Length = new TimeSpan(0, 10, 0),
                Time = new TimeSpan(4, 11, 45)
            };
            e7.BabbleEvents = repository.GetForTrafficEvent(e7).ToObservable();
            log.Events.Add(e7);

            return log;
        }

        public void Save(Model.TrafficLog log)
        {

        }
    }
}