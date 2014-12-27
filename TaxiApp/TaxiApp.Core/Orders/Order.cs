using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using TaxiApp.Account;
using TaxiApp.Bids;
using TaxiApp.Cars;

namespace TaxiApp.Orders
{
    public enum ServiceType
    {
        Standard,
        Luxury
    }

    public class Order : Entity<long>
    {
        public virtual DateTime OrderDate { get; set; }

        public virtual decimal SuggestedPrice { get; set; }

        public virtual Location LocationFrom { get; set; }

        public virtual Location LocationTo { get; set; }

        public virtual ServiceType ServiceType { get; set; }

        public virtual ICollection<Bid> Bids { get; set; }

        public virtual User.GenderType Gender { get; set; }

        public virtual int DriverExperience { get; set; }
                            
        public virtual Car CarDetails { get; set; }

        [ForeignKey("ChosenBidId")]
        public virtual Bid ChosenBid { get; set; }

        public virtual long? ChosenBidId { get; set; }
    }
}