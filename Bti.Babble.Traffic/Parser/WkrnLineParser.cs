using System;
using Bti.Babble.Traffic;
using Bti.Babble.Traffic.Model;

namespace Bti.Babble.Traffic.Parser
{
    class WkrnLineParser : ILineParser
    {
        private TimeSpanColumn Time = new TimeSpanColumn() {StartPos = 10, Length = 6};
        private TimeSpanColumn Length = new TimeSpanColumn() {StartPos = 23, Length = 6};
        private StringColumn BarCode = new StringColumn() {StartPos = 45, Length = 5};
        private StringColumn ProgramId = new StringColumn() { StartPos = 66, Length = 2 };
        private StringColumn ISCI = new StringColumn() {StartPos = 69, Length = 30};
        private StringColumn Description = new StringColumn() {StartPos = 131, Length = 100};

        public Tuple<bool, TrafficEvent> Parse(string line)
        {
            TrafficEvent te = new TrafficEvent();
            te.Time = Time.Parse(line);
            te.Length = Length.Parse(line);
            te.Barcode = BarCode.Parse(line);
            var programid = ProgramId.Parse(line);
            te.Isci = ISCI.Parse(line);
            te.Description = Description.Parse(line);
            te.Type = Classify(te, programid);
            te = Translate(te);
            return new Tuple<bool,TrafficEvent>(Validate(te), te);
        }

        private TrafficEventType Classify(TrafficEvent te, string programId)
        {
            if (IsProgram(programId)) return TrafficEventType.Program;
            if (IsStationId(te)) return TrafficEventType.Id;
            if (IsPromo(te)) return TrafficEventType.Promo;
            if (IsCommercial(te)) return TrafficEventType.Commercial;
            return TrafficEventType.None;
        }

        private bool IsProgram(string programId)
        {
            if (programId.Length > 0)
            {
                int programIdOut;
                if (int.TryParse(programId, out programIdOut))
                {
                    return true;
                }
            }
            return false;
        }

        private bool IsStationId(TrafficEvent te)
        {
            if (string.Compare(te.Description, " id", true) == 0)
            {
                return true;
            }
            return false;
        }

        private bool IsPromo(TrafficEvent te)
        {
            if (string.Compare(te.Description, " promo", true) == 0)
            {
                return true;
            }
            if (string.Compare(te.Description, "promo ", true) == 0)
            {
                return true;
            }
            return false;
        }

        private bool IsCommercial(TrafficEvent te)
        {
            if (te.Barcode.Length > 0)
            {
                int barcodeOut;
                if (int.TryParse(te.Barcode, out barcodeOut))
                {
                    return true;
                }
            }
            return false;
        }

        private TrafficEvent Translate(TrafficEvent te)
        {
            if (te.Type == TrafficEventType.Program)
            {
                var description = te.Isci;
                description = description.Right(")");
                description = description.Left("/");
                te.Description = description.Trim();
            }
            return te;
        }

        private bool Validate(TrafficEvent te)
        {
            return true;
        }
    }
}
