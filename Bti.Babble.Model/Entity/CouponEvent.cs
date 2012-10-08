using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects.DataClasses;

namespace Bti.Babble.Model.Entity
{
    partial class CouponEvent
    {
        internal override Model.BabbleEvent ToModelObject()
        {
            if (this == null) return null;
            return new Model.CouponEvent()
            {
                Id = this.Id,
                Code = this.Code,
                Coupon = this.Coupon,
                Image = this.Image,
                Large = this.Large,
                Link = this.Link,
                Message = this.Message,
                PubDate = this.PubDate,
                Store = this.Store,
                Time = ConvertTimeToTimespan(this.Time),
                Type = this.Type,
                User = this.User
            };
        }

        internal static CouponEvent ToEntityObject(Model.CouponEvent o)
        {
            if (o == null) return null;
            return new CouponEvent()
            {
                Id = o.Id,
                Code = o.Code,
                Coupon = o.Coupon,
                Image = o.Image,
                Large = o.Large,
                Link = o.Link,
                Message = o.Message,
                PubDate = o.PubDate,
                Store = o.Store,
                Time = ConvertTimespanToTime(o.Time),
                Type = o.Type,
                User = o.User
            };
        }
    }
}
