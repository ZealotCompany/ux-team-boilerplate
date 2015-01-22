using System.Reflection;
using Abp.Modules;
using Castle.MicroKernel.Registration;
using TaxiApp.Orders.Dtos;

namespace TaxiApp
{
    [DependsOn(typeof(TaxiAppCoreModule))]
    public class TaxiAppApplicationModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
            DtoMappings.Map();
        }
    }
}
