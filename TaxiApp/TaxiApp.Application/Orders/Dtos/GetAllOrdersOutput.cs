using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiApp.Orders.Dtos
{
    public class GetAllOrdersOutput
    {
        public IList<OrderDto> Orders { get; set; }
    }
}
