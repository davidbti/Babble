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
                Image = this.Image,
                Link = this.Link,
                Message = this.Message,
                PubDate = this.PubDate,
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
                Image = o.Image,
                Link = o.Link,
                Message = o.Message,
                PubDate = o.PubDate,
                Type = o.Type,
                User = o.User
            };
        }
    }
}
