using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AutoMapper;
using TaxiApp.Orders.Dtos;
using TaxiApp.Orders;
using TaxiApp.Cars;
using TaxiApp.Account;

namespace TaxiApp.Application.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public static void TestInitialize()
        {
            try
            {
                Mapper.AssertConfigurationIsValid();
            }
            catch (AutoMapperConfigurationException exp)
            {
                Console.WriteLine(exp);
            }

        }

        [TestMethod]
        public void TestOrderMapping()
        {
            try
            {
                DtoMappings.Map();
                Mapper.AssertConfigurationIsValid();
            }
            catch (AutoMapperConfigurationException exp)
            {
                Console.WriteLine(exp);
            }

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
    }
}
