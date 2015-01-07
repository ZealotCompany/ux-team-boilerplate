using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using TaxiApp.Account;
using TaxiApp.Bids;
using TaxiApp.Cars;
using TaxiApp.Customers;

namespace TaxiApp.Orders
{
    
    public class Order : Entity<long>
    {
        #region Enums
        public enum StatusType 
        {
            /// <summary>
            /// When the order created, the status is new
            /// </summary>
            New,

            /// <summary>
            /// If the order is accepted by the consumer and the driver
            /// </summary>
            Accepted,

            /// <summary>
            /// Drivers didn't make any bids
            /// </summary>
            Declined,

            /// <summary>
            /// If the consumer canceled, or didn't response to the order
            /// </summary>
            Canceled
        }

        public enum StateType
        {
            Open,

            WaitForClientAcceptance,
            
            Close
        }

        #endregion

        #region Core Order members
        public virtual DateTime OrderDate { get; set; }

        public virtual Location LocationFrom { get; set; }

        public virtual Location LocationTo { get; set; }

        public virtual decimal? SuggestedPrice { get; set; }

        public virtual StatusType Status { get; set; }

        public virtual StateType State { get; set; }

        public virtual int? PassangersCount { get; set; }

        public virtual string Description { get; set; }

        #endregion

        #region Consumer Related members
        public virtual string PhoneNumber { get; set; }

        public virtual int? ConsumerId { get; set; }

        [ForeignKey("ConsumerId")]
        public virtual Consumer Consumer { get; set; }
        #endregion

        #region Driver Related members

        public virtual User.GenderType Gender { get; set; }

        public virtual int? DriverExperience { get; set; }

        #endregion

        #region Car Related members

        public virtual int? MinimalCarProductionYear { get; set; }

        public virtual CarType ServiceType { get; set; }

        #endregion

        #region Bid Related members

        [ForeignKey("ChosenBidId")]
        public virtual Bid ChosenBid { get; set; }

        public virtual long? ChosenBidId { get; set; }

        public virtual ICollection<Bid> Bids { get; set; }

        #endregion

        public Order()
        {
            this.ServiceType = Cars.CarType.Taxi;
            this.Status = Order.StatusType.New;
            this.State = Order.StateType.Open;
        }
    }
}