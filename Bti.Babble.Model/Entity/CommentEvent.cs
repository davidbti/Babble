using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects.DataClasses;

namespace Bti.Babble.Model.Entity
{
    partial class CommentEvent
    {
        internal override Model.BabbleEvent ToModelObject()
        {
            if (this == null) return null;
            return new Model.CommentEvent()
            {
                Id = this.Id,
                Image = this.Image,
                Message = this.Message,
                PubDate = this.PubDate,
                Type = this.Type,
                User = this.User
            };
        }

        internal static CommentEvent ToEntityObject(Model.CommentEvent o)
        {
            if (o == null) return null;
            return new CommentEvent()
            {
                Id = o.Id,
                Image = o.Image,
                Message = o.Message,
                PubDate = o.PubDate,
                Type = o.Type,
                User = o.User
            };
        }
    }
}
