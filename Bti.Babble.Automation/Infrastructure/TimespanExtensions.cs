using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bti.Babble.Automation
{
    public static class TimespanExtensions
    {
        public static string DisplayAsString(this TimeSpan t)
        {
            return t.Hours.ToString("D2") + ":" + t.Minutes.ToString("D2") + ":" + t.Seconds.ToString("D2");
        }
    }
}
