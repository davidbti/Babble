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
        private Queue<BabbleEvent> events;
        private bool isRepeat;
        private bool isRunning;
        private BabbleEvent nextEvent;
        private int repeatMilliseconds;
        private IBabbleEventRepository repository;
        private DateTime repeatTime;
        private DateTime startTime;
        private Thread thread;

        public bool IsRepeat
        {
            get { return this.isRepeat; }
            set
            {
                this.isRepeat = value;
                RaisePropertyChanged("IsRepeat");
            }
        }

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

        public BabbleEvent NextEvent
        {
            get { return this.nextEvent; }
            set
            {
                this.nextEvent = value;
                RaisePropertyChanged("NextEvent");
            }
        }

        public int RepeatMilliseconds
        {
            get { return this.repeatMilliseconds; }
            set
            {
                this.repeatMilliseconds = value;
                RaisePropertyChanged("RepeatMilliseconds");
            }
        }

        public AutoServer(IBabbleEventRepository repository)
        {
            if (repository == null)
            {
                throw new ArgumentNullException("repository");
            }
            this.repository = repository;
        }

        private void Automate()
        {
            try
            {
                while (true)
                {
                    AutomateSchedule();
                    if (! this.isRepeat) 
                    {
                        this.IsRunning = false;
                        return; 
                    }
                    this.repeatTime = DateTime.Now;
                    DeleteOldEvents();
                    WaitForRepeat();
                }
            }
            catch (ThreadInterruptedException ex) { }
        }

        private void AutomateSchedule()
        {
            ReadEventsFromSchedule();
            this.startTime = DateTime.Now;
            NextEvent = events.Dequeue();
            while (events.Count > 0)
            {
                ElapsedTime = DateTime.Now.Subtract(this.startTime);
                if (ElapsedTime >= this.nextEvent.Time)
                {
                    repository.Save(NextEvent);
                    NextEvent = events.Dequeue();
                }
                Thread.Sleep(100);
            }
            while (ElapsedTime < this.nextEvent.Time)
            {
                Thread.Sleep(100);
                ElapsedTime = DateTime.Now.Subtract(this.startTime);
            }
            repository.Save(NextEvent);
        }

        private void DeleteOldEvents()
        {
            this.repository.DeleteOldEvents();
        }

        private void ReadEventsFromSchedule()
        {
            this.events = new Queue<BabbleEvent>();
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
                        this.events.Enqueue(evt);
                    }
                }
            }
        }

        public void Start()
        {
            this.IsRunning = true;
            this.ElapsedTime = new TimeSpan();
            this.thread = new Thread(new ThreadStart(this.Automate));
            this.thread.Start();
        }

        public void Stop()
        {
            this.thread.Interrupt();
            this.IsRunning = false;
        }

        private void WaitForRepeat()
        {
            while (true)
            {
                var repeatElapsed = DateTime.Now.Subtract(this.repeatTime);
                var repeatSpan = TimeSpan.FromMilliseconds(this.repeatMilliseconds);
                if (repeatElapsed >= repeatSpan)
                {
                    return;
                }
                Thread.Sleep(100);
            }
        }
    }
}
