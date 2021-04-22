using System;
using System.Collections.Generic;
using System.Linq;
using Event_Portal.Dtos;
using Event_Portal.Models;
using Microsoft.AspNetCore.Mvc;

using Newtonsoft.Json;
using FireSharp;
using FireSharp.Config;
using FireSharp.Response;
using FireSharp.Interfaces;
using System.Threading.Tasks;

namespace Event_Portal.Controllers
{



  [ApiController]
  [Route("/auth")]
    public class AuthController : ControllerBase
    {


    IFirebaseConfig config = new FirebaseConfig
    {
      AuthSecret = "JVGSRZVMU5Iw6TtGygVyEPUf41Zk40viN3UxWR76",
      BasePath = "https://geshdo-events-dev-default-rtdb.europe-west1.firebasedatabase.app/"
    };

    IFirebaseClient client;

    User userIncall = new User();

    public AuthController()
  {


    client = new FireSharp.FirebaseClient(config);
  }


    [HttpPost]
    public void GetLogin(Login login)
    {


      Console.WriteLine("Reached here");


      


      Login currentUser = new()
      {
      
        Email = login.Email,
        Password = login.Password
   
    };

      FirebaseResponse res = client.Get(@"users");
      Dictionary<string, User> listUser = JsonConvert.DeserializeObject<Dictionary<string, User>>(res.Body.ToString());

      /*
        1.  if statement to check if user is already logged in. 
      

      */

        if(userIncall != null) {

        Console.WriteLine("userIncall is working");

        foreach (var user in listUser)
      {

        var userEmail = user.Value.Email;
        var userPassword = user.Value.Password;

          

        if (userEmail == currentUser.Email)
        {
          if (userPassword == currentUser.Password)
          {
            Console.WriteLine("Welcome " + userEmail);
          }   
            // Try to solve if else problem. if userEmail && 
            // userPassord is wrong, then give ERROR
    

      }  
          
        }
           
    
        
      }

    }
    
        
    }


}