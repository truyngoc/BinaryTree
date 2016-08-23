using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Routing;
using Microsoft.AspNet.FriendlyUrls;

namespace BinaryTree
{
    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            var settings = new FriendlyUrlSettings();
            
            // thay cai nay de chay thu cai call ajax method
            //settings.AutoRedirectMode = RedirectMode.Permanent;
            settings.AutoRedirectMode = RedirectMode.Off;


            routes.EnableFriendlyUrls(settings);
        }
    }
}
