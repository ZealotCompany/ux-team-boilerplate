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
        public void TestMappingFromFullOrderDtoToOrder()
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
                ServiceType = Cars.CarType.Taxi,
                OrderDate = DateTime.Now,
                SuggestedPrice = 10.0m,
                MinimalCarProductionYear = 2010
            };

            Order order = Mapper.Map<Order>(orderDto);
            Assert.IsNotNull(order);
            Assert.AreEqual(orderDto.MinimalCarProductionYear, order.MinimalCarProductionYear);

            Console.WriteLine("Hello");
        }

        [TestMethod]
        public void TestMappingEmptyDtoToOrder()
        {

        }

        [TestMethod]
        public void TestMappingFromEntityToDto()
        {
            Order order = new Order()
            {
                Id = 100,
                MinimalCarProductionYear = 2010,
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
                ServiceType = CarType.Taxi,
                SuggestedPrice = 10.0m
            };

            OrderDto dto = order.MapTo<OrderDto>();

            Assert.IsNotNull(dto);
            Assert.AreEqual(dto.SuggestedPrice, order.SuggestedPrice);
            Assert.AreEqual(order.MinimalCarProductionYear, dto.MinimalCarProductionYear);
        }
    }
}
