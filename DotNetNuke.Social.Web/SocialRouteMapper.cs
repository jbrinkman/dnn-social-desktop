using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Text;

namespace DotNetNuke.Social.Web
{
    public class SocialRouteMapper : DotNetNuke.Web.Services.IServiceRouteMapper
    {
        public void RegisterRoutes(DotNetNuke.Web.Services.IMapRoute mapRouteManager)
        {
            mapRouteManager.MapRoute("SocialWeb", "{controller}.ashx/{action}", new[] { "SocialWeb" });

        }
    }
}
