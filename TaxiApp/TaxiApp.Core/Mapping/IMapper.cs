using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiApp.Mapping
{
    public interface IMapper<TSource, TTarget>
    {
        TTarget Map(TSource source);

        TSource Map(TTarget source);
    }
}
