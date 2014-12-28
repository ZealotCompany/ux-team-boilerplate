using Abp.Domain.Entities;
using System;
using System.Collections.Generic;

namespace TaxiApp.Cars
{
    public class BrandType : Entity<int>
    {
        public virtual string Name { get; set; }
    }
}
