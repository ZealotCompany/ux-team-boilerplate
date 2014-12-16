using System.Reflection;
using Abp.Modules;

namespace TaxiApp
{
    [DependsOn(typeof(TaxiAppCoreModule))]
    public class TaxiAppApplicationModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
