using EjemploApi.Business.Facade.Logic.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Dispatcher;

namespace EjemploApi.Business.Facade.Logic
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Configuración y servicios de API web

            // Rutas de API web
            config.MapHttpAttributeRoutes();
            //versionado de apis
            config.Routes.MapHttpRoute(
                name: "Version1Api",
                routeTemplate: "api/v1/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
              name: "Version2Api",
              routeTemplate: "api/v2/{controller}/{id}",
              defaults: new { id = RouteParameter.Optional }
          );
            //Remplazamos de busqueda de nombre de controlodor
            config.Services.Replace(typeof(IHttpControllerSelector), new CustomControllerSelector((config)));
        }
    }
}
