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
                Mapper.CreateMap<Order, MakeOrderOutput>();
                Mapper.AssertConfigurationIsValid();
            }
            catch (AutoMapperConfigurationException exp)
            {
                Console.WriteLine(exp);
            }

        }
    }
}
