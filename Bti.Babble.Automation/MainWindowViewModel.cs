using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.ComponentModel;

namespace Bti.Babble.Automation
{
    class MainWindowViewModel : ObservableObject
    {
        private AutoServer server;

        public MainWindowViewModel()
        {
            this.server = new AutoServer();
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

        void Server_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "IsRunning":
                    this.OnPropertyChanged(e);
                    break;
                case "ElapsedTime":
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
