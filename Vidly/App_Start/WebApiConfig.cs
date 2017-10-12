using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Filters;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Vidly.Controllers.Api.Filter;

namespace Vidly
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //does camecase notation in api from other notation
            var settings = config.Formatters.JsonFormatter.SerializerSettings;
            settings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            settings.Formatting = Formatting.Indented;
           config.Filters.Add(new ForceHttpsAttribute());
         //  config.Filters.Add(new CanManageRole());
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                name: "ShoppingApi",
                routeTemplate: "ShoppingCarts/api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
