using System;
using System.Linq;
using System.IO;
using Bti.Babble.Traffic.Model;
using System.Threading.Tasks;
using System.Threading;

namespace Bti.Babble.Traffic.Parser
{
    class WkrnLogParser : ILogParser
    {
        private ITrafficItemRepository itemRepository;
        private ILineParser lineParser = new WkrnLineParser();
        private DateColumn Date = new DateColumn() { StartPos = 7, Length = 6 };
        private StringColumn Station = new StringColumn() { StartPos = 13, Length = 4 };

        public WkrnLogParser(ITrafficItemRepository itemRepository)
        {
            if (itemRepository == null)
            {
                throw new ArgumentNullException("itemRepository");
            }
            this.itemRepository = itemRepository;
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

        public TrafficLog Parse(DateTime date, Action<int> statusCallback)
        {
            var file = GetFileForDate(date);
            var lines = File.ReadAllLines(file.ToString());
            double linesCount = lines.Count();
            var logline = lines[0];
            TrafficLog log = new TrafficLog();
            log.Station = Station.Parse(logline);
            log.Date = Date.ParseMMDDYY(logline);
            log.ParseDate = DateTime.Now;
            double eventLine = 0;
            int eventStartLine = 1;
            var currentProgram = new TrafficItem();
            foreach (var line in lines)
            {
                eventLine += 1;
                if (eventLine <= eventStartLine) continue;
                var result = lineParser.Parse(line);
                var valid = result.Item1;
                var evt = result.Item2;
                if (valid)
                {
                    if (evt.Item.Type == TrafficItemType.Program)
                    {
                        if (evt.Segment == 1)
                        {
                            currentProgram = evt.Item;
                        }
                        else
                        {
                            evt.Item.Description = currentProgram.Description;
                        }
                    }
                    var item = this.itemRepository.GetByItemProperties(evt.Item);
                    if (item == null)
                    {
                        evt.Item.BabbleItems = BabbleEventGenerator.Generate(log, evt).ToObservable();
                    }
                    else
                    {
                        evt.Item = item;
                    }
                    this.itemRepository.Save(evt.Item);
                    log.Events.Add(evt);
                }
                double done = (eventLine / linesCount) * 100;
                statusCallback((int)done);
            }
            return log;
        }

        public void ParseAsync(DateTime date, Action<int> statusCallback, Action<TrafficLog> resultCallback, Action<Exception> errorCallback)
        {
            Task<ParseResult<TrafficLog>> task =
                Task.Factory.StartNew(() =>
                {
                    try
                    {
                        return new ParseResult<TrafficLog>(this.Parse(date, statusCallback), null);
                    }
                    catch (Exception ex)
                    {
                        return new ParseResult<TrafficLog>(null, ex);
                    }
                });

            task.ContinueWith(r =>
            {
                if (r.Result.Error != null)
                {
                    errorCallback(r.Result.Error);
                }
                else
                {
                    resultCallback(r.Result.Package);
                }
            }, CancellationToken.None, TaskContinuationOptions.None,
                TaskScheduler.FromCurrentSynchronizationContext());

        }
    }
}
