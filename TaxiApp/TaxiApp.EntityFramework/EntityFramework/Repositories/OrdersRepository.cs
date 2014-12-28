using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiApp.Orders;

namespace TaxiApp.EntityFramework.Repositories
{
    public class OrdersRepository : TaxiAppRepositoryBase<Order, long>, IOrdersRepository
    {
        public void MakeOrder(Order order)
        {
            Order newOrder = base.Insert(order);
            Context.SaveChanges();
        }
    }
}
