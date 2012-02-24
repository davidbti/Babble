using System;

namespace Bti.Babble.Traffic.Parser
{
    interface ILogParser
    {
        bool CanParse(DateTime date);
        Model.TrafficLog Parse(DateTime date);
    }
}
