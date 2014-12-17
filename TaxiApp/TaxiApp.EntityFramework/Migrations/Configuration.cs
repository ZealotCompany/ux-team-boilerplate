namespace TaxiApp.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using TaxiApp.EntityFramework.Common;
    using TaxiApp.EntityFramework.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<TaxiApp.EntityFramework.TaxiAppDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "TaxiApp";
        }

        protected override void Seed(TaxiApp.EntityFramework.TaxiAppDbContext context)
        {
            // This method will be called every time after migrating to the latest version.
            // You can add any seed data here...
            var brands = new List<BrandType>()
            {
                new BrandType()
                {
                    Name = "BMW"
                },
                new BrandType()
                {
                    Name = "Lada"
                },
                new BrandType()
                {
                    Name = "Mercedes"
                }
            };

            var cartypes = new List<CarType>()
            {
                new CarType()
                {
                    Name = "Sedan"
                },
                new CarType()
                {
                    Name = "Jeep"
                },
                new CarType()
                {
                    Name = "SmallTruck"
                },
                new CarType()
                {
                    Name = "MediumTrack"
                }
            };

            var cars = new List<Car>()
            {
                new Car ()
                {
                    BrandTypeId = brands[0].Id,
                    CarTypeId = cartypes[1].Id,
                    ImageUrl = "http://bmw.test.com",
                    ProductionYear = 2009
                },
                new Car ()
                {
                    BrandTypeId = brands[1].Id,
                    CarTypeId = cartypes[1].Id,
                    ImageUrl = "http://lada.test.com",
                    ProductionYear = 2006
                }
            };

            var drivers = new List<Driver>()
            {
                new Driver()
                {
                    UserName = "anara",
                    Gender = User.GenderType.Male,
                    Experience = 9,
                    BirthDate = new DateTime(1986, 9, 27),
                    EmailAddress = "anara.azadaliyev@gmail.com",
                    FirstName = "Anar",
                    LastName = "Azadaliyev",
                    Phone = "0703809463",
                    ImageUrl = "http://anar.test.com",
                    CarId = cars[0].Id
                },
                new Driver()
                {
                    UserName = "ismayilm",
                    Gender = User.GenderType.Male,
                    BirthDate = new DateTime(1988, 7, 26),
                    EmailAddress = "ismayilturksoy@gmail.com",
                    FirstName = "Ismayil",
                    LastName = "Nifteliyev",
                    Phone = "0709679710",
                    ImageUrl = "http://ismayil.test.com",
                    CarId = cars[1].Id
                }
            };

            

            var orders = new List<Order>()
            {
                new Order()
                {
                    Gender = User.GenderType.Female,
                    DriverExperience = 2,
                    LocationFrom = new Location()
                    {
                        Place = "Azadiq Metro"
                    },
                    LocationTo = new Location()
                    {
                        Place = "28 Mall"
                    }
                },
                new Order()
                {
                    LocationFrom = new Location()
                    {
                        Street = "Droqal",
                        City = "Baku"
                    },
                    LocationTo = new Location()
                    {
                        Street = "Inqlab",
                        City = "Masazir"
                    }
                }
            };

            var bids = new List<Bid>()
            {
                new Bid()
                {
                    OrderId = orders[1].Id,
                    DriverId = drivers[0].Id,
                    Price = 10
                },
                new Bid()
                {
                    OrderId = orders[1].Id,
                    DriverId = drivers[1].Id,
                    Price = 8
                }
            };
        }
    }
}
