using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects.DataClasses;

namespace Bti.Babble.Model.Entity
{
    partial class PollEvent
    {
        internal override Model.BabbleEvent ToModelObject()
        {
            if (this == null) return null;
            return new Model.PollEvent()
            {
                Id = this.Id,
                Image = this.Image,
                Large = this.Large,
                Message = this.Message,
                PollImage = this.PollImage,
                PubDate = this.PubDate,
                Question = this.Question,
                Responses = (from o in this.PollResponses select o.ToModelObject()).ToList(),
                Time = ConvertTimeToTimespan(this.Time),
                Type = this.Type,
                User = this.User,
                Votes = this.Votes
            };
        }

        internal static PollEvent ToEntityObject(Model.PollEvent o)
        {
            if (o == null) return null;
            return new PollEvent()
            {
                Id = o.Id,
                Image = o.Image,
                Large = o.Large,
                Message = o.Message,
                PollImage = o.PollImage,
                PubDate = o.PubDate,
                Question = o.Question,
                PollResponses = ToEntityCollection(o.Responses),
                Time = ConvertTimespanToTime(o.Time),
                Type = o.Type,
                User = o.User,
                Votes = o.Votes
            };
        }

        internal static EntityCollection<PollResponse> ToEntityCollection(List<Model.PollResponse> responses)
        {
            var collection = new EntityCollection<PollResponse>();
            foreach (var evt in responses)
            {
                var evtEntity = PollResponse.ToEntityObject(evt);
                collection.Add(evtEntity);
            }
            return collection;
        }
    }

    partial class PollResponse
    {
        internal Model.PollResponse ToModelObject()
        {
            if (this == null) return null;
            return new Model.PollResponse()
            {
                Id = this.Id,
                PollEventId = this.PollEventId,
                Text = this.Text,
                Votes = this.Votes
            };
        }

        internal static PollResponse ToEntityObject(Model.PollResponse o)
        {
            if (o == null) return null;
            return new PollResponse()
            {
                Id = o.Id,
                PollEventId = o.PollEventId,
                Text = o.Text,
                Votes = o.Votes
            };
        }
    }
}
