using System;
using System.Web.Http;
using System.Web.Http.SelfHost;

namespace Administracion.Api
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var config = new HttpSelfHostConfiguration("http://localhost:4321");

            config.Routes.MapHttpRoute(
                "API Default", "api/{controller}/{action}/{id}",
                new { id = RouteParameter.Optional });

            using (HttpSelfHostServer server = new HttpSelfHostServer(config))
            {
                server.OpenAsync().Wait();
                Console.WriteLine("Press Enter to quit.");
                Console.ReadLine();
            }
        }
    }
}
