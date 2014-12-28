using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiApp.Orders
{
    public interface IOrdersRepository : IRepository<Order, long>
    {
        void MakeOrder(Order order);
    }
}
