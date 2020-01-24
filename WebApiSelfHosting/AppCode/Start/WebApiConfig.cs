using System.Web.Http;

namespace WebApiSelfHosting
{
    static class WebApiConfig
    {
        static internal T RegisterRoutes<T>(this T config)
            where T : HttpConfiguration
        {
            config.Routes.MapHttpRoute(
                     "default", "api/{controller}/{id}",
                     new { id = RouteParameter.Optional });

            return config;
        }
    }
}
