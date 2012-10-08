using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects.DataClasses;

namespace Bti.Babble.Model.Entity
{
    partial class InfoEvent
    {
        internal override Model.BabbleEvent ToModelObject()
        {
            if (this == null) return null;
            return new Model.InfoEvent()
            {
                Id = this.Id,
                Description = this.Description,
                Image = this.Image,
                InfoImage = this.InfoImage,
                Large = this.Large,
                Link = this.Link,
                Message = this.Message,
                PubDate = this.PubDate,
                Time = ConvertTimeToTimespan(this.Time),
                Title = this.Title,
                Type = this.Type,
                User = this.User
            };
        }

        internal static InfoEvent ToEntityObject(Model.InfoEvent o)
        {
            if (o == null) return null;
            return new InfoEvent()
            {
                Id = o.Id,
                Description = o.Description,
                Image = o.Image,
                InfoImage = o.InfoImage,
                Large = o.Large,
                Link = o.Link,
                Message = o.Message,
                PubDate = o.PubDate,
                Time = ConvertTimespanToTime(o.Time),
                Title = o.Title,
                Type = o.Type,
                User = o.User
            };
        }
    }
}
