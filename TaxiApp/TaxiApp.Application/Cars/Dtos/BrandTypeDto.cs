using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TaxiApp.Cars.Dtos
{
    public class BrandTypeDto : EntityDto<int>
    {
        public string Name { get; set; }
    }
}
