using Abp.Web.Mvc.Controllers;

namespace TaxiApp.Web.Controllers
{
    /// <summary>
    /// Derive all Controllers from this class.
    /// </summary>
    public abstract class TaxiAppControllerBase : AbpController
    {
        protected TaxiAppControllerBase()
        {
            LocalizationSourceName = TaxiAppConsts.LocalizationSourceName;
        }
    }
}