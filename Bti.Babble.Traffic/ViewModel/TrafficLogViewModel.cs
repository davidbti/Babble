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
        private ITrafficItemRepository itemRepository;
        private ITrafficLogRepository logRepository;
        private TrafficEvent selectedEvent;
        ObservableCollection<BabbleItemViewModel> babbleItems;
        BabbleItemTypeViewModels babbleTypes;
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

        public ObservableCollection<BabbleItemViewModel> BabbleItems
        {
            get { return this.babbleItems; }
            set
            {
                this.babbleItems = value;
                RaisePropertyChanged("BabbleItems");
            }
        }

        public BabbleItemTypeViewModels BabbleEventTypes
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
                if (this.selectedEvent != null)
                {
                    var items = new ObservableCollection<BabbleItem>();
                    foreach (var item in this.babbleItems)
                    {
                        items.Add(item.ToBabbleItem());
                    }
                    this.selectedEvent.Item.BabbleItems = items;
                    this.itemRepository.Save(this.selectedEvent.Item);
                }
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
            :this(new Model.Mock.TrafficLogRepository(), new Model.Mock.TrafficItemRepository())
        {
        }

        public TrafficLogViewModel(ITrafficLogRepository logRepository, ITrafficItemRepository itemRepository)
        {
            this.logRepository = logRepository;
            this.itemRepository = itemRepository;
            this.babbleTypes = new BabbleItemTypeViewModels();
            this.logParser = new WkrnLogParser(this.itemRepository);
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
            this.BabbleItems = new ObservableCollection<BabbleItemViewModel>();
            this.logParser.ParseAsync(ActiveDate, ImportProgressCallBack, ImportCompleteCallBack, ImportExceptionCallback);
        }

        private void ImportProgressCallBack(int progress)
        {
            this.ImportProgress = progress;
        }

        private void ImportCompleteCallBack(TrafficLog log)
        {
            if (this.log.Id > 0) { this.logRepository.Delete(this.log); }
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
            LoadBabbleItems(evt);
            this.ActiveEvent = evt;
        }

        private void LoadBabbleItems(TrafficEvent evt)
        {
            this.BabbleItems = new ObservableCollection<BabbleItemViewModel>
                (evt.Item.BabbleItems.Select(o => new BabbleItemViewModel(o, babbleTypes.GetImageForType(o.Type))));
        }

        private void LoadTrafficLog()
        {
            var log = this.logRepository.GetByDate(ActiveDate);
            if (log == null) 
            {
                log = new TrafficLog()
                {
                    Date = ActiveDate
                };
            }
            this.log = log;
            this.TrafficEvents = this.log.Events;
        }
    }
}
