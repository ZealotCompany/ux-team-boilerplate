﻿using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiApp.Orders.Dtos
{
    public class MakeOrderInput : IInputDto
    {
        public OrderDto Order { get; set; }

        
    }
}
