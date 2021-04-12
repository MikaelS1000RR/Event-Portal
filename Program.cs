using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Event_Portal.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Event_Portal
{
    public class Program
    {
        public static void Main(string[] args)
        {

      CreateHostBuilder(args).Build().Run();

      // System.Diagnostics.Debug.WriteLine("Destination reached");


    }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    
                    User myUser = new User("Bob", "Rock", "bob.rock@gmail.com", "123",
                    1
                    );
                    
                  Console.WriteLine(myUser.firstName);
                    Console.WriteLine("Destination Reached");




                });
    }
}
