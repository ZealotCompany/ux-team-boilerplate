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
                    Id = 1,
                    Name = "BMW"
                },
                new BrandType()
                {
                    Id = 2,
                    Name = "Lada"
                },
                new BrandType()
                {
                    Id = 3,
                    Name = "Mercedes"
                }
            };
            context.BrandTypes.AddOrUpdate(brand => brand.Name, brands.ToArray());

            var cartypes = new List<CarType>()
            {
                new CarType()
                {
                    Id = 1,
                    Name = "Sedan"
                },
                new CarType()
                {
                    Id = 2,
                    Name = "Jeep"
                },
                new CarType()
                {
                    Id = 3,
                    Name = "SmallTruck"
                },
                new CarType()
                {
                    Id = 4,
                    Name = "MediumTrack"
                }
            };
            context.CarTypes.AddOrUpdate(cartype => cartype.Name, cartypes.ToArray());

            var cars = new List<Car>()
            {
                new Car ()
                {
                    Id = 1,
                    BrandTypeId = brands[0].Id,
                    CarTypeId = cartypes[1].Id,
                    ImageUrl = "http://bmw.test.com",
                    ProductionYear = 2009
                },
                new Car ()
                {
                    Id = 2,
                    BrandTypeId = brands[1].Id,
                    CarTypeId = cartypes[1].Id,
                    ImageUrl = "http://lada.test.com",
                    ProductionYear = 2006
                }
            };
            context.Cars.AddOrUpdate(car => car.Id, cars.ToArray());

            var drivers = new List<Driver>()
            {
                new Driver()
                {
                    Id = 1,
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
                    Id = 2,
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
            context.Drivers.AddOrUpdate(driver => driver.Id, drivers.ToArray());

            var orders = new List<Order>()
            {
                new Order()
                {
                    Id = 1,
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
                    Id = 2,
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
            context.Orders.AddOrUpdate(order => order.Id);

            var bids = new List<Bid>()
            {
                new Bid()
                {
                    Id = 1,
                    OrderId = orders[1].Id,
                    DriverId = drivers[0].Id,
                    Price = 10
                },
                new Bid()
                {
                    Id = 2,
                    OrderId = orders[1].Id,
                    DriverId = drivers[1].Id,
                    Price = 8
                }
            };
            context.Bids.AddOrUpdate(bid => bid.Id, bids.ToArray());
        }
    }
}
