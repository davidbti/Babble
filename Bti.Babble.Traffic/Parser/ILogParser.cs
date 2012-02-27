using System;

namespace Bti.Babble.Traffic.Parser
{
    interface ILogParser
    {
        bool CanParse(DateTime date);
        Model.TrafficLog Parse(DateTime date, Action<int> statusCallback);
        void ParseAsync(DateTime date, Action<int> statusCallback, Action<Model.TrafficLog> resultCallback, Action<Exception> errorCallback);
    }
}
