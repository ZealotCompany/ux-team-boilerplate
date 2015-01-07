﻿using Abp.EntityFramework;
using System.Data.Entity;
using TaxiApp.Bids;
using TaxiApp.Cars;
using TaxiApp.Drivers;
using TaxiApp.Orders;

namespace TaxiApp.EntityFramework
{
    public class TaxiAppDbContext : AbpDbContext
    {
        //TODO: Define an IDbSet for each Entity...

        //Example:
        //public virtual IDbSet<User> Users { get; set; }
        public virtual IDbSet<Driver> Drivers { get; set; }
        public virtual IDbSet<Car> Cars { get; set; }
        public virtual IDbSet<Order> Orders { get; set; }
        public virtual IDbSet<Bid> Bids { get; set; }
        public virtual IDbSet<CarBrand> CarBrands { get; set; }

        /* NOTE: 
         *   Setting "Default" to base class helps us when working migration commands on Package Manager Console.
         *   But it may cause problems when working Migrate.exe of EF. If you will apply migrations on command line, do not
         *   pass connection string name to base classes. ABP works either way.
         */
        public TaxiAppDbContext()
            : base("Default")
        {

        }

        /* NOTE:
         *   This constructor is used by ABP to pass connection string defined in TaxiAppDataModule.PreInitialize.
         *   Notice that, actually you will not directly create an instance of TaxiAppDbContext since ABP automatically handles it.
         */
        public TaxiAppDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }
    }

    //Example:
    //public class User : Entity
    //{
    //    public string Name { get; set; }

    //    public string Password { get; set; }
    //}
}
