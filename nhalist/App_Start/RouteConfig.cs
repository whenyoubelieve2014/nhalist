﻿using System.Web.Http.OData.Builder;
using System.Web.Mvc;
using System.Web.Routing;
using NhaList.Models;

namespace NhaList
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute("Angular", "view/{name}/{routeParameter}",
                new {controller = "Home", action = "Index", routeParameter = UrlParameter.Optional}
                );

            routes.MapRoute("Default", "{controller}/{action}/{id}",
                new {controller = "Home", action = "Index", id = UrlParameter.Optional}
                );
        }
    }
}