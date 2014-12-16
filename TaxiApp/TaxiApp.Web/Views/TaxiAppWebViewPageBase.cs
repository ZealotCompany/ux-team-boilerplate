using Abp.Web.Mvc.Views;

namespace TaxiApp.Web.Views
{
    public abstract class TaxiAppWebViewPageBase : TaxiAppWebViewPageBase<dynamic>
    {

    }

    public abstract class TaxiAppWebViewPageBase<TModel> : AbpWebViewPage<TModel>
    {
        protected TaxiAppWebViewPageBase()
        {
            LocalizationSourceName = TaxiAppConsts.LocalizationSourceName;
        }
    }
}