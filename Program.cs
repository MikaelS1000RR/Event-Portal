using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Event_Portal.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using System.Collections;
namespace Event_Portal
{
  public class Program
  {
    public static void Main(string[] args)
    {

      CreateHostBuilder(args).Build().Run();

    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
              webBuilder.UseStartup<Startup>();

            });
  }
}
