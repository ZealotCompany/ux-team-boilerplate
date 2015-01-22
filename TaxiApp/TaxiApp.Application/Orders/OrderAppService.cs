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

        private readonly OrderDtoMapper _mapper;

        public OrderAppService(IOrdersRepository orderRepository, OrderDtoMapper mapper)
        {
            this._ordersRepository = orderRepository;
            this._mapper = mapper;
        }

        public MakeOrderOutput MakeOrder(MakeOrderInput input)
        {
            Order order = _mapper.Map(input.Order);
            
            _ordersRepository.MakeOrder(order);
            
            return new MakeOrderOutput() { Success = true };
        }

        public GetAllOrdersOutput GetAllOrders()
        {
            return new GetAllOrdersOutput() { Orders = _ordersRepository.GetAllList().MapIList<Order, OrderDto>() };
        }
    }
}
