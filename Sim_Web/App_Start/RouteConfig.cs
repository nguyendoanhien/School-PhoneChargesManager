using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Routing;
using Microsoft.AspNet.FriendlyUrls;

namespace Sim_Web
{
    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            var settings = new FriendlyUrlSettings();
            settings.AutoRedirectMode = RedirectMode.Permanent;
            routes.EnableFriendlyUrls(settings);

            routes.MapPageRoute("Home", "", "~/pages/TrangChu.aspx");
            routes.MapPageRoute("Customer", "khach-hang", "~/pages/KhachHang.aspx");
            routes.MapPageRoute("Sim", "sim", "~/pages/Sim.aspx");
            routes.MapPageRoute("Receipt", "hoa-don", "~/pages/HoaDon.aspx");
        }
    }
}
