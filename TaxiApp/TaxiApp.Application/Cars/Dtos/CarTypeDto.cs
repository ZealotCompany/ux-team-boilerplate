using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiApp.Cars.Dtos
{
    public class CarTypeDto : EntityDto<int>
    {
        public string Name { get; set; }
    }
}
