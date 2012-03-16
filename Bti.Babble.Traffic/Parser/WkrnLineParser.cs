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
            var te = new TrafficEvent();
            te.Time = Time.Parse(line);
            te.Length = Length.Parse(line);
            te.Item.Barcode = BarCode.Parse(line);
            var programid = ProgramId.Parse(line);
            te.Item.Isci = ISCI.Parse(line);
            te.Item.Description = Description.Parse(line);
            te.Item.Type = Classify(te, programid);
            te = Translate(te);
            return new Tuple<bool,TrafficEvent>(Validate(te), te);
        }

        private TrafficItemType Classify(TrafficEvent te, string programId)
        {
            if (IsProgram(programId)) return TrafficItemType.Program;
            if (IsStationId(te)) return TrafficItemType.Id;
            if (IsPromo(te)) return TrafficItemType.Promo;
            if (IsCommercial(te)) return TrafficItemType.Commercial;
            return TrafficItemType.None;
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
            if (string.Compare(te.Item.Description, " id", true) == 0)
            {
                return true;
            }
            return false;
        }

        private bool IsPromo(TrafficEvent te)
        {
            if (te.Item.Description.Contains(" promo", StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
            if (te.Item.Description.Contains("promo ", StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
            return false;
        }

        private bool IsCommercial(TrafficEvent te)
        {
            if (te.Item.Barcode.Length > 0)
            {
                int barcodeOut;
                if (int.TryParse(te.Item.Barcode, out barcodeOut))
                {
                    return true;
                }
            }
            return false;
        }

        private TrafficEvent Translate(TrafficEvent te)
        {
            if (te.Item.Type == TrafficItemType.Program)
            {
                var description = te.Item.Isci;
                description = description.Right(")");
                description = description.Left("/");
                te.Item.Description = description.Trim();
            }
            return te;
        }

        private TrafficItem Lookup(TrafficItem ti)
        {
            return ti;
        }

        private bool Validate(TrafficEvent te)
        {
            if (te.Item.Type == TrafficItemType.None) return false;
            return true;
        }
    }
}
