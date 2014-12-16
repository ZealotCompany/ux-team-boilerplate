using System.Reflection;
using Abp.Modules;

namespace TaxiApp
{
    public class TaxiAppCoreModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
