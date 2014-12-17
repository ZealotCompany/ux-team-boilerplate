﻿using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaxiApp.EntityFramework.Models
{
    public class Bid : Entity<long>
    {
        public virtual long? OrderId { get; set; }
        
        public virtual int? DriverId { get; set; }

        [ForeignKey("DriverId")]
        public virtual Driver Driver { get; set; }
        
        public virtual decimal Price { get; set; }
    }
}
