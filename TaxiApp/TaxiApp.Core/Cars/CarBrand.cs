using Abp.Domain.Entities;
using System;
using System.Collections.Generic;

namespace TaxiApp.Cars
{
    public class CarBrand : Entity<int>
    {
        public virtual string Name { get; set; }
    }
}
