using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;

namespace Bti.Babble.Traffic
{
    public class BabbleEventTypeViewModel : ObservableObject
    {
        private ImageSource image;
        private string name;

        public ImageSource Image
        {
            get { return this.image; }
            set
            {
                this.image = value;
                RaisePropertyChanged("Image");
            }
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                this.name = value;
                RaisePropertyChanged("Name");
            }
        }

        public BabbleEventTypeViewModel()
            : this("", null)
        {
        }

        public BabbleEventTypeViewModel(string name, ImageSource image)
        {
            this.name = name;
            this.image = image;
        }

        public override bool Equals(System.Object obj)
        {
            // If parameter is null return false.
            if (obj == null)
            {
                return false;
            }

            // If parameter cannot be cast to Point return false.
            BabbleEventTypeViewModel p = obj as BabbleEventTypeViewModel;
            if ((System.Object)p == null)
            {
                return false;
            }

            // Return true if the fields match:
            return (Name == p.Name);
        }

        public bool Equals(BabbleEventTypeViewModel p)
        {
            // If parameter is null return false:
            if ((object)p == null)
            {
                return false;
            }

            // Return true if the fields match:
            return (Name == p.Name);
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        public static bool operator ==(BabbleEventTypeViewModel a, BabbleEventTypeViewModel b)
        {
            // If both are null, or both are same instance, return true.
            if (System.Object.ReferenceEquals(a, b))
            {
                return true;
            }

            // If one is null, but not both, return false.
            if (((object)a == null) || ((object)b == null))
            {
                return false;
            }

            // Return true if the fields match:
            return a.Name == b.Name;
        }

        public static bool operator !=(BabbleEventTypeViewModel a, BabbleEventTypeViewModel b)
        {
            return !(a == b);
        }
    }
}
