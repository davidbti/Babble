using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Bti.Babble.Traffic
{
    class BabbleEventViewModel : ObservableObject
    {
        private BabbleEvent activeEvent;
        readonly IBabbleEventRepository repository;
        ObservableCollection<BabbleEvent> events;

        public BabbleEvent ActiveEvent
        {
            get { return this.activeEvent; }
            set
            {
                this.activeEvent = value;
                RaisePropertyChanged("ActiveEvent");
            }
        }

        public ObservableCollection<BabbleEvent> Events
        {
            get { return this.events; }
            set
            {
                this.events = value;
                RaisePropertyChanged("Events");
            }
        }

        public BabbleEventViewModel() :
            this(new BabbleEventRepository())
        {
        }

        public BabbleEventViewModel(IBabbleEventRepository repository)
        {
            this.repository = repository;
            LoadEvents();
        }

        void LoadEvents()
        {
            this.events = new ObservableCollection<BabbleEvent>(this.repository.GetAll());
        }
    }
}
