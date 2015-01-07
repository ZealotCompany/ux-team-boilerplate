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
        public static readonly int MinimalProductionYear = 1990;

        public virtual int? BrandTypeId { get; set; }

        [ForeignKey("BrandTypeId")]
        public virtual CarBrand BrandType { get; set; }

        public virtual CarType CarType { get; set; }

        public virtual int ProductionYear { get; set; }

        public virtual string ImageUrl { get; set; }
        
    }
}
