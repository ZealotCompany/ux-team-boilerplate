using Abp.Domain.Entities;
using System;
using System.Collections.Generic;

namespace TaxiApp.EntityFramework.Models
{
    public class BrandType : Entity<int>
    {
        public virtual string Name { get; set; }
    }
}
