using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaxiApp.EntityFramework.Models
{
    [ComplexType]
    public class Location
    {
        public virtual string City { get; set; }
        
        public virtual string Street { get; set; }
        
        public virtual string Place { get; set; }
    }
}
