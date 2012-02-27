using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using System.Windows.Media;
using Bti.Babble.Traffic.Model;
using Bti.Babble.Traffic.Parser;
using System.Configuration;

namespace Bti.Babble.Traffic
{
    class TrafficLogViewModel : ObservableObject
    {
        private TrafficLog log;
        private ILogParser logParser;
        private ITrafficLogRepository logRepository;
        private DateTime activeDate;
        private TrafficEvent activeEvent;
        private TrafficEvent selectedEvent;
        ObservableCollection<BabbleEventViewModel> babbleEvents;
        BabbleEventTypeViewModels babbleTypes;
        ObservableCollection<TrafficEvent> trafficEvents;

        public DateTime ActiveDate
        {
            get { return this.activeDate; }
            set
            {
                this.activeDate = value;
                RaisePropertyChanged("ActiveDate");
            }
        }

        public TrafficEvent ActiveEvent
        {
            get { return this.activeEvent; }
            set
            {
                this.activeEvent = value;
                RaisePropertyChanged("ActiveEvent");
                RaisePropertyChanged("CanAddBabbleEvents");
            }
        }

        public bool CanAddBabbleEvents
        {
            get { return (this.activeEvent != null); }
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

        public BabbleEventTypeViewModels BabbleEventTypes
        {
            get { return this.babbleTypes; }
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

        public ObservableCollection<TrafficEvent> TrafficEvents
        {
            get { return this.trafficEvents; }
            set
            {
                this.trafficEvents = value;
                RaisePropertyChanged("TrafficEvents");
            }
        }

        public TrafficLogViewModel()
            :this(new Model.Mock.TrafficLogRepository())
        {
        }

        public TrafficLogViewModel(ITrafficLogRepository logRepository)
        {
            //string connection = ConfigurationManager.ConnectionStrings["BabbleContainer"].ConnectionString;
            this.logRepository = logRepository;
            this.babbleTypes = new BabbleEventTypeViewModels();
            this.logParser = new WkrnLogParser();
            ActiveDate = DateTime.Now;
            LoadTrafficEvents();
        }

        #region Commands

        public ICommand PreviousCommand
        {
            get { return new RelayCommand(PreviousExecute, CanPreviousExecute); }
        }

        private Boolean CanPreviousExecute()
        {
            return true;
        }

        private void PreviousExecute()
        {
            if (!CanPreviousExecute()) return;
            ActiveDate = activeDate.Subtract(new TimeSpan(24, 0, 0));
        }

        public ICommand NextCommand
        {
            get { return new RelayCommand(NextExecute, CanNextExecute); }
        }

        private Boolean CanNextExecute()
        {
            return true;
        }

        private void NextExecute()
        {
            if (!CanNextExecute()) return;
            ActiveDate = activeDate.Add(new TimeSpan(24, 0, 0));
        }

        public ICommand ImportCommand
        {
            get { return new RelayCommand(ImportExecute, CanImportExecute); }
        }

        private Boolean CanImportExecute()
        {
            return this.logParser.CanParse(ActiveDate);
        }

        private void ImportExecute()
        {
            if (!CanImportExecute()) return;
            this.TrafficEvents = new ObservableCollection<TrafficEvent>();
            this.BabbleEvents = new ObservableCollection<BabbleEventViewModel>();
            //this.log = this.logParser.Parse(ActiveDate);
            //this.logRepository.Save(log);
            //LoadLog();
        }

        #endregion 

        private void DateSelected(DateTime date)
        {
            this.ActiveDate = date;
        }

        private void EventSelected(TrafficEvent evt)
        {
            if (evt == null)
            {
                this.ActiveEvent = null;
                return;
            }
            LoadBabbleEvents(evt);
            this.ActiveEvent = evt;
        }

        private void LoadBabbleEvents(TrafficEvent evt)
        {
            this.BabbleEvents = new ObservableCollection<BabbleEventViewModel>
                (evt.BabbleEvents.Select(o => new BabbleEventViewModel(o, babbleTypes.GetImageForType(o.Type))));
        }

        private void LoadTrafficEvents()
        {
            this.log = this.logRepository.GetByDate(ActiveDate);
            this.TrafficEvents = this.log.Events;
        }
    }
}
