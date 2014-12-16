using System.Data.Entity;
using System.Reflection;
using Abp.EntityFramework;
using Abp.Modules;
using TaxiApp.EntityFramework;

namespace TaxiApp
{
    [DependsOn(typeof(AbpEntityFrameworkModule), typeof(TaxiAppCoreModule))]
    public class TaxiAppDataModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = "Default";
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
            Database.SetInitializer<TaxiAppDbContext>(null);
        }
    }
}
