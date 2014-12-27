using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiApp.Account;

namespace TaxiApp.Orders.Dtos
{
    public enum ServiceTypeDto
    {
        Standard,
        Luxury
    }

    public class OrderDto : EntityDto<long>
    {
        public DateTime OrderDate { get; set; }

        public decimal SuggestedPrice { get; set; }

        public LocationDto LocationFrom { get; set; }

        public LocationDto LocationTo { get; set; }

        public ServiceTypeDto ServiceType { get; set; }

        public User.GenderType Gender { get; set; }

        public int DriverExperience { get; set; }
    }
}
