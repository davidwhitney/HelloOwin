using System;
using HelloOwin.Middleware;
using Microsoft.Owin.Hosting;
using Owin;

namespace HelloOwin
{
    public class Program
    {
        private static void Main()
        {
            using (WebApp.Start<Startup>("http://localhost:8080/"))
            {
                Console.WriteLine("Started Katana host");
                Console.ReadKey();
            }
        }
    }

    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.Use<MiddlewareDemo>();
        }
    }
}