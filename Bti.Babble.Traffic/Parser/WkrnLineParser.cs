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
        private IntegerColumn ProgramNumber = new IntegerColumn() { StartPos = 66, Length = 2 };
        private StringColumn ISCI = new StringColumn() {StartPos = 69, Length = 30};
        private StringColumn Advertiser = new StringColumn() {StartPos = 131, Length = 100};

        public Tuple<bool, TrafficEvent, TrafficItem> Parse(string line)
        {
            var te = new TrafficEvent();
            te.Time = Time.Parse(line);
            te.Length = Length.Parse(line);
            te.Barcode = BarCode.Parse(line);
            te.ProgramNumber = ProgramNumber.Parse(line);
            te.Isci = ISCI.Parse(line);
            te.SegmentNumber = ParseSegment(te);
            te.Advertiser = Advertiser.Parse(line);
            var ti = CreateFromTrafficEvent(te);
            var isvalid = Validate(te, ti);
            return new Tuple<bool,TrafficEvent,TrafficItem>(isvalid, te, ti);
        }

        private TrafficItem CreateFromTrafficEvent(TrafficEvent te)
        {
            var ti = new TrafficItem();
            ti.Type = Classify(te);
            switch (ti.Type)
            {
                case TrafficItemType.Commercial :
                    ti.Description = te.Advertiser;
                    break;

                case TrafficItemType.Program :
                    var description = te.Isci;
                    description = description.RightFor(")", 23);
                    description = description.Left("N/R");
                    description = description.Left("/");
                    ti.Description = description.Trim();
                    break;

                case TrafficItemType.Promo :
                    ti.Description = te.Advertiser;
                    ti.Description2 = te.Isci;
                    break;
            }
            return ti;
        }

        private TrafficItemType Classify(TrafficEvent te)
        {
            if (IsProgram(te)) return TrafficItemType.Program;
            if (IsPromo(te)) return TrafficItemType.Promo;
            if (IsCommercial(te)) return TrafficItemType.Commercial;
            return TrafficItemType.None;
        }

        private bool IsProgram(TrafficEvent te)
        {
            return (te.ProgramNumber > 0);
        }

        private bool IsPromo(TrafficEvent te)
        {
            if (te.Advertiser.Contains(" promo", StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
            if (te.Advertiser.Contains("promo ", StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
            if (te.Advertiser.Contains(" id", StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
            if (te.Advertiser.Contains("id ", StringComparison.OrdinalIgnoreCase))
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

        private int ParseSegment(TrafficEvent te)
        {
            var segment = te.Isci;
            if (!segment.Contains("(Seg")) return 0;
            segment = segment.Right("(Seg");
            segment = segment.Left(")");
            int segnum = 0;
            int.TryParse(segment, out segnum);
            return segnum;
        }

        private bool Validate(TrafficEvent te, TrafficItem ti)
        {
            if (te.Isci.Length == 0) return false;
            if (te.Barcode.Length == 0) return false;
            if (ti.Type == TrafficItemType.Program)
            {
                if (te.SegmentNumber == 0) return false;
            }
            if (ti.Type == TrafficItemType.None) return false;
            if (ti.Description.Length == 0) return false;
            return true;
        }
    }
}
