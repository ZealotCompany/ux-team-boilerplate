using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiApp.Mapping;

namespace TaxiApp.Orders.Dtos
{
    public class OrderDtoMapper : IMapper<Order, OrderDto>
    {
        public Order Map(OrderDto source)
        {
            var order = new Order()
            {
                OrderDate = source.OrderDate,
                SuggestedPrice = source.SuggestedPrice,
                LocationFrom = new Location()
                {
                    City = source.LocationFrom.City,
                    Street = source.LocationFrom.Street,
                    Place = source.LocationFrom.Place,
                },
                LocationTo = new Location()
                {
                    City = source.LocationFrom.City,
                    Street = source.LocationFrom.Street,
                    Place = source.LocationFrom.Place,
                },
                ServiceType = source.ServiceType,
                Gender = source.Gender,
                DriverExperience = source.DriverExperience,
                MinimalCarProductionYear = source.MinimalCarProductionYear
            };

            return order;
        }

        public OrderDto Map(Order source)
        {
            var dto = new OrderDto()
            {
                OrderDate = source.OrderDate,
                SuggestedPrice = source.SuggestedPrice,
                LocationFrom = new LocationDto()
                {
                    City = source.LocationFrom.City,
                    Street = source.LocationFrom.Street,
                    Place = source.LocationFrom.Place,
                },
                LocationTo = new LocationDto()
                {
                    City = source.LocationFrom.City,
                    Street = source.LocationFrom.Street,
                    Place = source.LocationFrom.Place,
                },
                ServiceType = source.ServiceType,
                Gender = source.Gender,
                DriverExperience = source.DriverExperience,
                MinimalCarProductionYear = source.MinimalCarProductionYear
            };

            return dto;
        }

    }
}
