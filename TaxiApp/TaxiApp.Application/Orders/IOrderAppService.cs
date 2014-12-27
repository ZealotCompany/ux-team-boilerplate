using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiApp.Orders.Dtos;

namespace TaxiApp.Orders
{
    public interface IOrderAppService : IApplicationService
    {
        MakeOrderOutput MakeOrder(MakeOrderInput input);
    }
}
