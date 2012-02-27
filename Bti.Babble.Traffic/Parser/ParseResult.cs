using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bti.Babble.Traffic.Parser
{
    public class ParseResult<T>
    {
        readonly T _package;
        readonly Exception _error;

        public T Package { get { return _package; } }
        public Exception Error { get { return _error; } }

        public ParseResult(T package, Exception error)
        {
            _package = package;
            _error = error;
        }
    }
}
