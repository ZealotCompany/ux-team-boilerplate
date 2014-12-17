using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaxiApp.EntityFramework.Models
{
    public class Driver : User
    {
        public virtual int Experience { get; set; }

        public virtual string ImageUrl { get; set; }

        public virtual string LicenseNumber { get; set; }

        public virtual ServiceType ServiceType { get; set; }

        public virtual int CarId { get; set; }

        [ForeignKey("CarId")]
        public virtual Car Car { get; set; }

        public Driver()
        {
            this.ServiceType = Models.ServiceType.Standard;
            this.Experience = 0;
        }
    }
}