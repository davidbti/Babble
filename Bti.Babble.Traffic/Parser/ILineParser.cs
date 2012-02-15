using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bti.Babble.Traffic
{
    interface ILineParser
    {
        TrafficEvent Parse(string line);
    }
}
