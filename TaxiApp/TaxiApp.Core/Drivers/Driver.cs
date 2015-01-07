using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using TaxiApp.Account;
using TaxiApp.Cars;
using TaxiApp.Orders;

namespace TaxiApp.Drivers
{
    public class Driver : User
    {
        public virtual int Experience { get; set; }

        public virtual string ImageUrl { get; set; }

        public virtual string LicenseNumber { get; set; }

        public virtual Cars.CarType ServiceType { get; set; }

        public virtual int CarId { get; set; }

        [ForeignKey("CarId")]
        public virtual Car Car { get; set; }

        public Driver()
        {
            this.ServiceType = Cars.CarType.Taxi;
            this.Experience = 0;
        }
    }
}