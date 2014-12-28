using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiApp.Account;
using TaxiApp.Cars;
using TaxiApp.Cars.Dtos;
using TaxiApp.Orders;
using TaxiApp.Orders.Dtos;

namespace TaxiApp
{
    public static class DtoMappings
    {
        public static void Map()
        {
            //This code configures AutoMapper to auto map between Entities and DTOs.
            Mapper.CreateMap<OrderDto, Order>().ReverseMap();
            Mapper.CreateMap<CarDto, Car>().ReverseMap();
            Mapper.CreateMap<BrandTypeDto, BrandType>().ReverseMap();
            Mapper.CreateMap<CarTypeDto, CarType>().ReverseMap();
            Mapper.CreateMap<LocationDto, Location>().ReverseMap();
            //I specified mapping for AssignedPersonId since NHibernate does not fill Task.AssignedPersonId
            //If you will just use EF, then you can remove ForMember definition.
            
        }
    }
}
