using Abp.Application.Navigation;
using Abp.Localization;

namespace TaxiApp.Web
{
    /// <summary>
    /// This class defines menus for the application.
    /// It uses ABP's menu system.
    /// When you add menu items here, they are automatically appear in angular application.
    /// See .cshtml and .js files under App/Main/views/layout/header to know how to render menu.
    /// </summary>
    public class TaxiAppNavigationProvider : NavigationProvider
    {
        public override void SetNavigation(INavigationProviderContext context)
        {
            context.Manager.MainMenu
                .AddItem(
                    new MenuItemDefinition(
                        "Home",
                        new LocalizableString("HomePage", TaxiAppConsts.LocalizationSourceName),
                        url: "#/",
                        icon: "fa fa-home"
                        )
                ).AddItem(
                    new MenuItemDefinition(
                        "About",
                        new LocalizableString("About", TaxiAppConsts.LocalizationSourceName),
                        url: "#/about",
                        icon: "fa fa-info"
                        )
                ).AddItem(
                    new MenuItemDefinition(
                        "Order",
                        new LocalizableString("Order", TaxiAppConsts.LocalizationSourceName),
                        url: "#/make-order",
                        icon: "fa fa-info"
                        )
                ).AddItem(
                    new MenuItemDefinition(
                        "LoginQR",
                        new LocalizableString("LoginQR", TaxiAppConsts.LocalizationSourceName),
                        url: "#/login-qr",
                        icon: "fa fa-info"
                        )
                );
        }
    }
}
