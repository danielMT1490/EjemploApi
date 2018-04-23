using EjemploApi.Business.Facade.Logic.App_Start;
using EjemploApi.Business.Facade.Logic.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using Unity;
using Unity.Lifetime;

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
                name: "Version1Api",//Nombre de la version
                routeTemplate: "api/v1/{controller}/{action}/{id}",//ruta
                defaults: new { id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
              name: "Version2Api",
              routeTemplate: "api/v2/{controller}/{id}",
              defaults: new { id = RouteParameter.Optional }
          );
            //Remplazamos de busqueda de nombre de controlodor
            //config.Services.Replace(typeof(IHttpControllerSelector), new CustomControllerSelector((config)));

            //Inyecta al constructor del controller la instacia de la interfaz De Business
            var container = new UnityContainer();
            container.RegisterType<IUsuarioBlAsync, UsuarioBlAsync>(new HierarchicalLifetimeManager());
            config.DependencyResolver = new UnityResolver(container);
        }
    }
}
