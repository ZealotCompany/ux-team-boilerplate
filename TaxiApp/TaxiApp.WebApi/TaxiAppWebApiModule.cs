using System.Reflection;
using Abp.Application.Services;
using Abp.Modules;
using Abp.WebApi;
using Abp.WebApi.Controllers.Dynamic.Builders;

namespace TaxiApp
{
    [DependsOn(typeof(AbpWebApiModule), typeof(TaxiAppApplicationModule))]
    public class TaxiAppWebApiModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());

            DynamicApiControllerBuilder
                .ForAll<IApplicationService>(typeof(TaxiAppApplicationModule).Assembly, "app")
                .Build();
        }
    }
}
