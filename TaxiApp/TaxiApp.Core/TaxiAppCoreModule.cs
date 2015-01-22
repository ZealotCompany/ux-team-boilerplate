using System.Reflection;
using Abp.Modules;
using Castle.MicroKernel.Registration;

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
