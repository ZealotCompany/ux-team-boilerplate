using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace TaxiApp.Cars
{
    public class Car : Entity<int>
    {
        public virtual int? BrandTypeId { get; set; }

        [ForeignKey("BrandTypeId")]
        public virtual BrandType BrandType { get; set; }

        public virtual int? CarTypeId { get; set; }

        [ForeignKey("CarTypeId")]
        public virtual CarType CarType { get; set; }

        public virtual int ProductionYear { get; set; }

        public virtual string ImageUrl { get; set; }

    }
}
