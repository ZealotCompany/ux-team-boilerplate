using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiApp.Account;
using TaxiApp.Orders.Dtos;

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
            Order order = AutoMapper.Mapper.Map<MakeOrderInput, Order>(input);
            //Order order = new Order()
            //{
            //    LocationFrom = new Location()
            //    {
            //        Place = input.LocationFrom
            //    },
            //    LocationTo = new Location()
            //    {
            //        Place = input.LocationTo
            //    },
            //    Gender = input.Gender == Account.Dtos.UserDto.GenderTypeDto.Male ? 
            //                    User.GenderType.Male :
            //                    User.GenderType.Female

            //};

            _ordersRepository.MakeOrder(order);
            
            return new MakeOrderOutput()
            {
                Success = true
            };
        }
    }
}
