using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiApp.Cars.Dtos
{
    public class CarDto : EntityDto<int>
    {
        public BrandTypeDto BrandType { get; set; }

        public CarTypeDto CarType { get; set; }

        public int ProductionYear { get; set; }
    }
}
