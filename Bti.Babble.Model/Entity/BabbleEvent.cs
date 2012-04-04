using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects.DataClasses;

namespace Bti.Babble.Model.Entity
{
    partial class BabbleEvent
    {
        internal virtual Model.BabbleEvent ToModelObject() 
        {
            if (this == null) return null;
            return new Model.BabbleEvent()
            {
                Id = this.Id,
                Image = this.Image,
                Message = this.Message,
                PubDate = this.PubDate,
                Type = this.Type,
                User = this.User
            };
        }
    }
}
