using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using TaxiApp.Drivers;

namespace TaxiApp.Bids
{
    public class Bid : Entity<long>, IHasCreationTime
    {
        public enum BidState 
        {
            /// <summary>
            /// Used when the driver made a bid and the order is open for bids
            /// </summary>
            Open,

            /// <summary>
            /// When the Driver removes the order from the orders list
            /// </summary>
            Removed,

            /// <summary>
            /// When the Bid was not accepted by the consumer
            /// </summary>
            Closed,

            /// <summary>
            /// The bid was accepted by the consumer
            /// </summary>
            Accepted
        }

        public virtual DateTime CreationTime { get; set; }

        public virtual long? OrderId { get; set; }
        
        public virtual int? DriverId { get; set; }

        [ForeignKey("DriverId")]
        public virtual Driver Driver { get; set; }
        
        public virtual decimal Price { get; set; }

        public virtual BidState State { get; set; }

        public Bid()
        {
            this.State = BidState.Open;
            this.CreationTime = DateTime.Now;
        }

    }
}
