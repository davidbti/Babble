using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Xml;
using Bti.Babble.Model;

namespace Bti.Babble.Automation
{
    class AutoServer : ObservableObject
    {
        private TimeSpan elapsedTime;
        private bool isRunning;
        private DateTime startTime;
        private Thread thread;
        private List<BabbleEvent> events;

        public bool IsRunning
        {
            get { return this.isRunning; }
            set
            {
                this.isRunning = value;
                RaisePropertyChanged("IsRunning");
            }
        }

        public TimeSpan ElapsedTime
        {
            get { return this.elapsedTime; }
            set
            {
                this.elapsedTime = value;
                RaisePropertyChanged("ElapsedTime");
            }
        }

        public AutoServer()
        {
        }

        private void Automate()
        {
            try
            {
                ReadEventsFromSchedule();    
                while (true)
                {
                    ElapsedTime = DateTime.Now.Subtract(this.startTime);
                    Thread.Sleep(100);
                }
            }
            catch (ThreadInterruptedException ex) { }
        }

        private void ReadEventsFromSchedule()
        {
            var settings = new XmlReaderSettings();
            settings.IgnoreWhitespace = true;
            settings.IgnoreComments = true;
            var root = Path.GetDirectoryName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);
            var schedulepath = Path.Combine(root, "schedule.xml");
            using (var reader = XmlReader.Create(schedulepath, settings))
            {
                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element && reader.LocalName == "event")
                    {
                        var evt = BabbleEvent.CreateFromXmlReader(reader);
                    }
                }
            }
        }

        public void Start()
        {
            this.IsRunning = true;
            this.ElapsedTime = new TimeSpan();
            this.thread = new Thread(new ThreadStart(this.Automate));
            this.startTime = DateTime.Now;
            this.thread.Start();
        }

        public void Stop()
        {
            this.thread.Interrupt();
            this.IsRunning = false;
        }
    }
}
