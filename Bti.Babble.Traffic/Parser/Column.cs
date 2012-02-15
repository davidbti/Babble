using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bti.Babble.Traffic
{
    class Column
    {
        public int StartPos { get; set; }
        public int Length { get; set; }
    }

    class StringColumn : Column
    {
        public String Parse(string line)
        {
            return line.Substring(StartPos, Length).Trim();
        }
    }

    class DateColumn : Column
    {
        public DateTime ParseMMDDYY(string line)
        {
            string dateval = line.Substring(StartPos, Length);
            int year = 2000 + Int32.Parse(dateval.Substring(4, 2));
            int month = Int32.Parse(dateval.Substring(0, 2));
            int day = Int32.Parse(dateval.Substring(2, 2));
            return new DateTime(year, month, day);
        }
    }

    class PrimaryColumn : Column
    {
        public bool ParseSEC(string line)
        {
            string classval = line.Substring(StartPos, Length);
            if (classval == "SEC")
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }

    class IntegerColumn : Column
    {
        public int Parse(string line)
        {
            var stringval = line.Substring(StartPos, Length).Trim();
            if (stringval.Length == 0) return 0;
            return int.Parse(stringval);
        }
    }

    class TimeSpanColumn : Column
    {
        public TimeSpan ParseSplit(string line, char splitchar)
        {
            string spanval = line.Substring(StartPos, Length);
            var spanvalsplit = spanval.Split(splitchar);
            if (spanvalsplit.Length != 3) return new TimeSpan(0, 0, 0);
            int hour = Int32.Parse( spanvalsplit[0]);
            int minute = Int32.Parse(spanvalsplit[1]);
            int second = Int32.Parse(spanvalsplit[2]);
            return new TimeSpan(hour, minute, second);
        }
    }
}
