﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bti.Babble.Model
{
    public interface IBabbleEventRepository
    {
        List<BabbleEvent> GetEvents(int count);
        List<BabbleEvent> GetEventsSince(int id);
        void DeleteOldEvents();
        void Save(BabbleEvent evt);
    }
}