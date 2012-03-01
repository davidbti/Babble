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
        private DateTime activeDate;
        private TrafficEvent activeEvent;
        private int importProgress;
        private bool isImporting;
        private TrafficLog log;
        private ILogParser logParser;
        private ITrafficLogRepository logRepository;
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

        public bool CanAddBabbleEvents
        {
            get { return (this.activeEvent != null); }
        }

        public int ImportProgress
        {
            get { return this.importProgress; }
            set
            {
                this.importProgress = value;
                RaisePropertyChanged("ImportProgress");
            }
        }

        public bool IsImporting
        {
            get { return this.isImporting; }
            set
            {
                this.isImporting = value;
                RaisePropertyChanged("IsImporting");
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
            this.logRepository = logRepository;
            this.babbleTypes = new BabbleEventTypeViewModels();
            this.logParser = new WkrnLogParser();
            DateTime now = DateTime.Now;
            ActiveDate = new DateTime(now.Year, now.Month, now.Day);
            LoadTrafficLog();
        }

        #region Commands

        public ICommand PreviousCommand
        {
            get { return new RelayCommand(PreviousExecute, CanPreviousExecute); }
        }

        private Boolean CanPreviousExecute()
        {
            if (IsImporting) return false;
            return true;
        }

        private void PreviousExecute()
        {
            if (!CanPreviousExecute()) return;
            ActiveDate = activeDate.Subtract(new TimeSpan(24, 0, 0));
            LoadTrafficLog();
        }

        public ICommand NextCommand
        {
            get { return new RelayCommand(NextExecute, CanNextExecute); }
        }

        private Boolean CanNextExecute()
        {
            if (IsImporting) return false;
            return true;
        }

        private void NextExecute()
        {
            if (!CanNextExecute()) return;
            ActiveDate = activeDate.Add(new TimeSpan(24, 0, 0));
            LoadTrafficLog();
        }

        public ICommand ImportCommand
        {
            get { return new RelayCommand(ImportExecute, CanImportExecute); }
        }

        private Boolean CanImportExecute()
        {
            if (IsImporting) return false;
            return this.logParser.CanParse(ActiveDate);
        }

        private void ImportExecute()
        {
            if (!CanImportExecute()) return;
            this.IsImporting = true;
            this.ImportProgress = 0;
            this.TrafficEvents = new ObservableCollection<TrafficEvent>();
            this.BabbleEvents = new ObservableCollection<BabbleEventViewModel>();
            this.logParser.ParseAsync(ActiveDate, ImportProgressCallBack, ImportCompleteCallBack, ImportExceptionCallback);
        }

        private void ImportProgressCallBack(int progress)
        {
            this.ImportProgress = progress;
        }

        private void ImportCompleteCallBack(TrafficLog log)
        {
            this.logRepository.Delete(this.log);
            this.logRepository.Save(log);
            LoadTrafficLog();
            this.IsImporting = false;
            this.ImportProgress = 0;
        }

        private void ImportExceptionCallback(Exception ex)
        {
            throw ex;
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

        private void LoadTrafficLog()
        {
            var log = this.logRepository.GetByDate(ActiveDate);
            if (log == null) { log = new TrafficLog(); }
            this.log = log;
            this.TrafficEvents = this.log.Events;
        }
    }
}
