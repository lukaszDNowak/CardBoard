using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Http;

namespace CardBoard.api
{
    public class Program
    {
        public static void Main(string[] args)
        {

            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            //.ConfigureServices(services => services.AddRouting())
            //.Configure(app => app.UseRouter(router =>
            //{
            //    router.MapGet("/hello", (req, res, data) => res.WriteAsync("Hello!"));

            //}
            //));
                .UseStartup<Startup>();
    }
}
