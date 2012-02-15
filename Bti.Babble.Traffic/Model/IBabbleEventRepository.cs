using System;
using System.Collections.Generic;

namespace Bti.Babble.Traffic
{
    public interface IBabbleEventRepository
    {
        IEnumerable<BabbleEvent> GetAll();
    }
}
