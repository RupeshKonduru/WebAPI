using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace WebApi
{
    public class WebAPiRouting
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                name:"Demo",
                routeTemplate:"api/{controller}/{id}",
                defaults:new {id=RouteParameter.Optional}
                );
            config.Routes.MapHttpRoute(
                name: "Demo1",
                routeTemplate: "{controller}",
                defaults: new { id = RouteParameter.Optional }
                );
           

        }
    }
}