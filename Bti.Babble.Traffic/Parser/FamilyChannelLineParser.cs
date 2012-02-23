using System;
using Bti.Babble.Traffic.Model;

namespace Bti.Babble.Traffic.Parser
{
    class FamilyChannelLineParser : ILineParser
    {
        private DateColumn Date = new DateColumn() {StartPos = 6, Length = 6};
        private PrimaryColumn Primary = new PrimaryColumn() {StartPos = 12, Length = 3};
        private IntegerColumn SequenceId = new IntegerColumn() {StartPos = 18, Length = 3};
        private TimeSpanColumn StartTime = new TimeSpanColumn() {StartPos = 21, Length = 8};
        private TimeSpanColumn Duration = new TimeSpanColumn() {StartPos = 34, Length = 7};
        private StringColumn TargetDevice = new StringColumn() {StartPos = 46, Length = 5};
        private StringColumn TargetId = new StringColumn() {StartPos = 63, Length = 15};
        private StringColumn Description = new StringColumn() {StartPos = 80, Length = 88};

        public TrafficEvent Parse(string line)
        {
            TrafficEvent te = new TrafficEvent();
            //te.Date = Date.ParseMMDDYY(line);
            //te.Primary = Primary.ParseSEC(line);
            //te.SequenceId = SequenceId.Parse(line);
            //te.StartTime = StartTime.ParseSplit(line, ':');
            //te.Duration = Duration.ParseSplit(line, ':');
            //te.TargetDevice = TargetDevice.Parse(line);
            //te.TargetId = TargetId.Parse(line);
            te.Description = Description.Parse(line);
            te.Type = Classify(te);
            return te;
        }

        private TrafficEventType Classify(TrafficEvent te)
        {
            return TrafficEventType.None;
            //switch (te.TargetDevice)
            //{
            //    case "FLX3":
            //        return TrafficEventClassification.Show;
            //    case "DEKO4":
            //        return TrafficEventClassification.CG;
            //    case "SVR6C":
            //        if (te.TargetId.StartsWith("FPR"))
            //        {
            //            return TrafficEventClassification.Promo;
            //        }
            //        else
            //        {
            //            return TrafficEventClassification.Commercial;
            //        }
            //    default:
            //        return TrafficEventClassification.None;
            //}
        }
    }
}
