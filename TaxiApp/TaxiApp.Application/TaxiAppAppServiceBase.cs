using Abp.Application.Services;

namespace TaxiApp
{
    /// <summary>
    /// Derive your application services from this class.
    /// </summary>
    public abstract class TaxiAppAppServiceBase : ApplicationService
    {
        protected TaxiAppAppServiceBase()
        {
            LocalizationSourceName = TaxiAppConsts.LocalizationSourceName;
        }
    }
}