using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bti.Babble.Traffic
{
    public static class StringExtensions
    {
        public static string Left(this string s, string delimiter)
        {
            var pos = s.IndexOf(delimiter);
            if (pos < 1) return s;
            return s.Substring(0, pos);
        }

        public static string Right(this string s, string delimiter)
        {
            var pos = s.IndexOf(delimiter);
            if (pos < 1) return s;
            return s.Substring(pos + 1);
        }
    }
}
