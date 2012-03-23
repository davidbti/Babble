using System;
using Bti.Babble.Traffic.Model;

namespace Bti.Babble.Traffic
{
    interface ILineParser
    {
        Tuple<bool, TrafficEvent, TrafficItem> Parse(string line);
    }
}
