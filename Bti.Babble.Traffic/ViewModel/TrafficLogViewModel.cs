using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using System.Windows.Media;

namespace Bti.Babble.Traffic
{
    class TrafficLogViewModel : ObservableObject
    {
        private TrafficLog log;
        readonly ITrafficLogRepository logRepository;
        private TrafficEvent activeEvent;
        private TrafficEvent selectedEvent;
        readonly IBabbleEventRepository babbleEventRepository;
        ObservableCollection<BabbleEventViewModel> babbleEvents;
        BabbleEventClassificationImages babbleImages;

        public TrafficEvent ActiveEvent
        {
            get { return this.activeEvent; }
            set
            {
                this.activeEvent = value;
                RaisePropertyChanged("ActiveEvent");
            }
        }

        public ObservableCollection<BabbleEventViewModel> BabbleEvents
        {
            get { return this.babbleEvents; }
            set
            {
                this.babbleEvents = value;
                RaisePropertyChanged("BabbleEvents");
            }
        }

        public TrafficEvent SelectedEvent
        {
            get { return this.selectedEvent; }
            set
            {
                this.selectedEvent = value;
                RaisePropertyChanged("SelectedEvent");
                EventSelected(value);
            }
        }

        public TrafficLog Log
        {
            get { return this.log; }
            set
            {
                this.log = value;
                RaisePropertyChanged("Log");
            }
        }

        public TrafficLogViewModel() :
            this(new TrafficLogRepository(), new BabbleEventRepository())
        {
        }

        public TrafficLogViewModel(ITrafficLogRepository logRepository, IBabbleEventRepository babbleEventRepository)
        {
            this.logRepository = logRepository;
            this.babbleEventRepository = babbleEventRepository;
            this.babbleImages = new BabbleEventClassificationImages();
            LoadLog();
        }

        void EventSelected(TrafficEvent evt)
        {
            LoadBabbleEvents(evt);
            this.ActiveEvent = evt;
        }

        void LoadBabbleEvents(TrafficEvent evt)
        {
            this.BabbleEvents = new ObservableCollection<BabbleEventViewModel>
                (this.babbleEventRepository.GetForTrafficEvent(evt).Select(o => new BabbleEventViewModel(o, babbleImages)));
        }

        void LoadLog()
        {
            this.log = this.logRepository.GetByDate(DateTime.Now);
        }
    }
}
