using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TaxiApp.Cars
{
    public class CarType : Entity<int>
    {
        public virtual string Name { get; set; }
    }
}
