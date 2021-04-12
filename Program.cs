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

      // System.Diagnostics.Debug.WriteLine("Destination reached");


    }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    
                    User newUser = new User("Bob", "Rock", "bob.rock@gmail.com", "123",
                    1
                    );

                  Event newEvent = new Event(2, "Köpenhamn", "2021-04-20", "2021-04-30",
                  "08:00", "23:00", 1);



                  Console.WriteLine(newUser.firstName + " " +  newUser.lastName);
                  Console.WriteLine(newEvent.location + " " + newEvent.startDate);

                    
                  Console.WriteLine("Destination Reached");

                  newEvent.invitedList.Add(newUser);


                  Console.WriteLine("Invited new user: " + newUser.firstName);


                  Console.WriteLine("Event list: " + newEvent.invitedList[0]);

                  Console.WriteLine("End of the code");


                  

                });
    }
}
