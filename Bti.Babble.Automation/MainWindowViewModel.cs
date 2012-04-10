using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.ComponentModel;
using Bti.Babble.Model;

namespace Bti.Babble.Automation
{
    class MainWindowViewModel : ObservableObject
    {
        private AutoServer server;

        public MainWindowViewModel()
            :this(new Model.Mock.BabbleEventRepository())
        {
        }

        public MainWindowViewModel(IBabbleEventRepository repository)
        {
            this.server = new AutoServer(repository);
            this.server.PropertyChanged += new PropertyChangedEventHandler(Server_PropertyChanged);
        }

        public bool IsRunning
        {
            get { return server.IsRunning; }
        }

        public string ElapsedTime
        {
            get { return this.server.ElapsedTime.DisplayAsString(); }
        }

        public BabbleEvent NextEvent
        {
            get { return this.server.NextEvent; }
        }

        public bool IsRepeat
        {
            get { return this.server.IsRepeat; }
            set { this.server.IsRepeat = value; }
        }

        public int RepeatMilliseconds
        {
            get { return this.server.RepeatMilliseconds; }
            set { this.server.RepeatMilliseconds = value; }
        }

        void Server_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "IsRepeat":
                    this.OnPropertyChanged(e);
                    break;
                case "IsRunning":
                    this.OnPropertyChanged(e);
                    break;
                case "ElapsedTime":
                    this.OnPropertyChanged(e);
                    break;
                case "NextEvent":
                    this.OnPropertyChanged(e);
                    break;
                case "RepeatMilliseconds":
                    this.OnPropertyChanged(e);
                    break;
            }
        }

        #region Commands

        public ICommand StartCommand
        {
            get { return new RelayCommand(StartExecute, CanStartExecute); }
        }

        private Boolean CanStartExecute()
        {
            return !(IsRunning);
        }

        private void StartExecute()
        {
            if (!CanStartExecute()) return;
            this.server.Start();
        }

        public ICommand StopCommand
        {
            get { return new RelayCommand(StopExecute, CanStopExecute); }
        }

        private Boolean CanStopExecute()
        {
            return (IsRunning);
        }

        private void StopExecute()
        {
            if (!CanStopExecute()) return;
            this.server.Stop();
        }

        #endregion
    }
}
