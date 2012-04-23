using System;
using System.Collections.ObjectModel;

namespace Bti.Babble.Metro.Model
{
    class BabbleEventGroup
    {
        public string Title { get; set; }
        public ObservableCollection<BabbleEvent> Events { get; set; }
    }
}
