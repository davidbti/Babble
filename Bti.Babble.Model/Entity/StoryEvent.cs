using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects.DataClasses;

namespace Bti.Babble.Model.Entity
{
    partial class StoryEvent
    {
        internal override Model.BabbleEvent ToModelObject()
        {
            if (this == null) return null;
            return new Model.StoryEvent()
            {
                Id = this.Id,
                Description = this.Description,
                Image = this.Image,
                Large = this.Large,
                Link = this.Link,
                Message = this.Message,
                PubDate = this.PubDate,
                StoryImage = this.StoryImage,
                StoryText = this.StoryText,
                Time = ConvertTimeToTimespan(this.Time),
                Title = this.Title,
                Type = this.Type,
                User = this.User
            };
        }

        internal static StoryEvent ToEntityObject(Model.StoryEvent o)
        {
            if (o == null) return null;
            return new StoryEvent()
            {
                Id = o.Id,
                Description = o.Description,
                Image = o.Image,
                Large = o.Large,
                Link = o.Link,
                Message = o.Message,
                PubDate = o.PubDate,
                StoryImage = o.StoryImage,
                StoryText = o.StoryText,
                Title = o.Title,
                Time = ConvertTimespanToTime(o.Time),
                Type = o.Type,
                User = o.User
            };
        }
    }
}
