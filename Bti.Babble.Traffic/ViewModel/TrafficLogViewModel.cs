using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using System.Windows.Media;
using Bti.Babble.Traffic.Model;
using Bti.Babble.Traffic.Parser;

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
        private IBabbleEventRepository babbleEventRepository;
        ObservableCollection<BabbleEventViewModel> babbleEvents;
        BabbleEventTypeViewModels babbleTypes;

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
            this(new Model.Entity.TrafficLogRepository(), new Model.Mock.BabbleEventRepository())
        {
        }

        public TrafficLogViewModel(ITrafficLogRepository logRepository, IBabbleEventRepository babbleEventRepository)
        {
            this.logRepository = logRepository;
            this.babbleEventRepository = babbleEventRepository;
            this.babbleTypes = new BabbleEventTypeViewModels();
            this.logParser = new WkrnLogParser();
            ActiveDate = DateTime.Now;
            LoadLog();
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
            var log = this.logParser.Parse(ActiveDate);
        }

        #endregion 

        private void DateSelected(DateTime date)
        {
            this.ActiveDate = date;
        }

        private void EventSelected(TrafficEvent evt)
        {
            LoadBabbleEvents(evt);
            this.ActiveEvent = evt;
        }

        private void LoadBabbleEvents(TrafficEvent evt)
        {
            this.BabbleEvents = new ObservableCollection<BabbleEventViewModel>
                (this.babbleEventRepository.GetForTrafficEvent(evt).Select(o => new BabbleEventViewModel(o, babbleTypes.GetImageForType(o.Type))));
        }

        private void LoadLog()
        {
            this.log = this.logRepository.GetByDate(DateTime.Now);
        }
    }
}
