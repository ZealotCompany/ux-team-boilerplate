using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TaxiApp.Orders;
using TaxiApp.Orders.Dtos;

namespace TaxiApp.Web.Controllers
{
    public class OrdersController : ApiController
    {
        private IOrderAppService _orderService;

        public OrdersController(IOrderAppService orderService)
        {
            this._orderService = orderService;
        }

        [HttpPost]
        public MakeOrderOutput MakeOrder(MakeOrderInput input)
        {
            return _orderService.MakeOrder(input);
        }
    }
}
