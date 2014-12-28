using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiApp.Account;
using TaxiApp.Orders.Dtos;
using TaxiApp.Mapping;

namespace TaxiApp.Orders
{
    public class OrderAppService : TaxiAppAppServiceBase, IOrderAppService
    {
        private readonly IOrdersRepository _ordersRepository;

        public OrderAppService(IOrdersRepository orderRepository)
        {
            this._ordersRepository = orderRepository;
        }

        public MakeOrderOutput MakeOrder(MakeOrderInput input)
        {
            Order order = input.Order.MapTo<Order>();
            
            _ordersRepository.MakeOrder(order);
            
            return new MakeOrderOutput() { Success = true };
        }

        public GetAllOrdersOutput GetAllOrders()
        {
            return new GetAllOrdersOutput() { Orders = _ordersRepository.GetAllList().MapIList<Order, OrderDto>() };
        }
    }
}
