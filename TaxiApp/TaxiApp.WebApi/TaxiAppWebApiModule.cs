using System.Reflection;
using Abp.Application.Services;
using Abp.Modules;
using Abp.WebApi;
using Abp.WebApi.Controllers.Dynamic.Builders;
using TaxiApp.Orders;

namespace TaxiApp
{
    [DependsOn(typeof(AbpWebApiModule), typeof(TaxiAppApplicationModule))]
    public class TaxiAppWebApiModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());

            //DynamicApiControllerBuilder
            //    .ForAll<IApplicationService>(typeof(TaxiAppApplicationModule).Assembly, "app")
            //    .Build();

            CreateWebApiProxiesForServices();
        }

        private static void CreateWebApiProxiesForServices()
        {
            DynamicApiControllerBuilder
                .For<IOrderAppService>("taxiapp/order")
                .Build();

        }
    }
}
