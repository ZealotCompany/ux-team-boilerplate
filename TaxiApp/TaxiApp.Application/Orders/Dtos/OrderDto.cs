using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiApp.Account;
using TaxiApp.Cars.Dtos;

namespace TaxiApp.Orders.Dtos
{
    public class OrderDto : EntityDto<long>
    {
        public DateTime OrderDate { get; set; }

        public decimal SuggestedPrice { get; set; }

        public LocationDto LocationFrom { get; set; }

        public LocationDto LocationTo { get; set; }

        public ServiceType ServiceType { get; set; }

        public User.GenderType Gender { get; set; }

        public int DriverExperience { get; set; }

        public CarDto CarDetails { get; set; }
    }
}
