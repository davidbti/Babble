using System;
using Bti.Babble.Traffic.Model;

namespace Bti.Babble.Traffic
{
    interface ILineParser
    {
        TrafficEvent Parse(string line);
    }
}
