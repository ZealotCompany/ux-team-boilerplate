using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiApp.Account;
using TaxiApp.Cars;
using TaxiApp.Cars.Dtos;

namespace TaxiApp.Orders.Dtos
{
    public class OrderDto : EntityDto<long>
    {
        public DateTime OrderDate { get; set; }

        public decimal? SuggestedPrice { get; set; }

        [Required]
        public LocationDto LocationFrom { get; set; }

        [Required]
        public LocationDto LocationTo { get; set; }

        public CarType ServiceType { get; set; }

        public User.GenderType? Gender { get; set; }

        public int? DriverExperience { get; set; }
        
        public int? MinimalCarProductionYear { get; set; }
    }
}
