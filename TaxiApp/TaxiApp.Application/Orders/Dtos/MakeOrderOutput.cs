using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TaxiApp.Orders.Dtos    
{
    public class MakeOrderOutput
    {
        public bool Success { get; set; }

        public MakeOrderOutput()
        {
            Success = false;
        }
    }
}
