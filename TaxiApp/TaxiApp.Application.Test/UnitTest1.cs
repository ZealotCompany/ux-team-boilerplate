using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AutoMapper;
using TaxiApp.Orders.Dtos;
using TaxiApp.Orders;
using TaxiApp.Cars;
using TaxiApp.Account;
using TaxiApp.Mapping;

namespace TaxiApp.Application.Test
{
    [TestClass]
    public class UnitTest1
    {
        [ClassInitialize()]
        public static void TestInitialize(TestContext context)
        {
            DtoMappings.Map();
        }

        [TestMethod]
        public void TestOrderMapping()
        {
            OrderDto orderDto = new OrderDto()
            {
                LocationFrom = new LocationDto()
                {
                    Place = "Baku"
                },
                LocationTo = new LocationDto()
                {
                    Place = "Masazir"
                },
                Gender = User.GenderType.Male,
                DriverExperience = 2,
                ServiceType = ServiceType.Standard,
                OrderDate = DateTime.Now,
                SuggestedPrice = 10.0m,
                CarDetails = new Cars.Dtos.CarDto()
                {
                    BrandType = new Cars.Dtos.BrandTypeDto()
                    {
                        Name = "BMW"
                    },
                    CarType = new Cars.Dtos.CarTypeDto()
                    {
                        Name = "Jeep"
                    },
                    ProductionYear = 2010
                }
            };

            Order order = Mapper.Map<Order>(orderDto);

            Console.WriteLine("Hello");
        }

        [TestMethod]
        public void TestMappingFromEntityToDto()
        {
            Order order = new Order()
            {
                Id = 100,
                CarDetails = new Car()
                {
                    BrandType = new BrandType()
                    {
                        Id = 1,
                        Name = "BMW"
                    },
                    BrandTypeId = 1,
                    CarType = new CarType()
                    {
                        Id = 2,
                        Name = "Jeep"
                    },
                    CarTypeId = 2,
                    ProductionYear = 2010,
                    ImageUrl = "http://car.image.com",
                },
                ChosenBid = new Bids.Bid()
                {
                    Id = 22,
                    Driver = new Drivers.Driver()
                    {
                        Id = 5,
                        FirstName = "Anar",
                        LastName = "Azadaliyev"
                    },
                    DriverId = 5,
                    OrderId = 100,
                },
                ChosenBidId = 22,
                DriverExperience = 9,
                Gender = User.GenderType.Male,
                LocationFrom = new Location()
                {
                    Place = "Baku"
                },
                LocationTo = new Location()
                {
                    Place = "Masazir"
                },
                OrderDate = DateTime.Now,
                ServiceType = ServiceType.Standard,
                SuggestedPrice = 10.0m
            };

            OrderDto dto = order.MapTo<OrderDto>();

            Assert.IsNotNull(dto);
            Assert.AreEqual(dto.SuggestedPrice, order.SuggestedPrice);
        }
    }
}
