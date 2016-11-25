using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ProjetAspNet
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "AspNetRoles",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "AspNetRoles", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "AspNetUserClaims",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "AspNetUserClaims", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "AspNetUserLogins",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "AspNetUserLogins", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "AspNetUsers",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "AspNetUsers", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Customers",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Customers", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Employee",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Employee", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "ExpanseReports",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "ExpanseReports", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Expanses",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Expanses", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "ExpanseTypes",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "ExpanseTypes", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Poles",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Poles", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Projects",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Projects", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Tvas",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Tvas", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "C__MigrationHistory",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "C__MigrationHistory", action = "Index", id = UrlParameter.Optional }
            );

        }
    }
}
