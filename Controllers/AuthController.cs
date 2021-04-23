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
  public class AuthController : ControllerBase
  {


    IFirebaseConfig config = new FirebaseConfig
    {
      AuthSecret = "JVGSRZVMU5Iw6TtGygVyEPUf41Zk40viN3UxWR76",
      BasePath = "https://geshdo-events-dev-default-rtdb.europe-west1.firebasedatabase.app/"
    };

    IFirebaseClient client;



    public AuthController()
    {


      client = new FireSharp.FirebaseClient(config);
    }

    // POST /users
    [HttpPost]
    [Route("/register")]
    public async Task<User> CreateUser(CreateUserDto userDto)
    {
      User user = new()
      {
        Id = Guid.NewGuid(),
        FirstName = userDto.FirstName,
        LastName = userDto.LastName,
        Email = userDto.Email,
        Password = userDto.Password
      };

      FirebaseResponse res = client.Get(@"users");
      Dictionary<string, User> listUser = JsonConvert.DeserializeObject<Dictionary<string, User>>(res.Body.ToString());


      bool emailExists = false;

      foreach (var userReg in listUser)
      {

        var userEmail = userReg.Value.Email;
        if (userEmail == user.Email)
        {
          emailExists = true;
        }

      }
      if (!emailExists)
      {
        var response = await client.PushTaskAsync("users", user);
        User result = response.ResultAs<User>();

        Console.WriteLine("Pushed new user");

        return user;
      }

      else
      {
        Console.WriteLine("This email is already registered!");
        return null;
      }



    }


    [HttpPost]
    [Route("/login")]
    public User GetLogin(Login login)
    {


      Console.WriteLine("Reached here");





      Login currentUser = new()
      {

        Email = login.Email,
        Password = login.Password

      };

      FirebaseResponse res = client.Get(@"users");
      Dictionary<string, User> listUser = JsonConvert.DeserializeObject<Dictionary<string, User>>(res.Body.ToString());


      bool rightCredentials = false;
      User isLoggedIn = null;

      foreach (var user in listUser)
      {

        var userEmail = user.Value.Email;
        var userPassword = user.Value.Password;



        if (userEmail == currentUser.Email)
        {
          if (userPassword == currentUser.Password)
          {
            isLoggedIn = user.Value;
            rightCredentials = true;
          }


        }

      }
      if (rightCredentials == true)
      {
        Console.WriteLine("Welcome " + currentUser.Email);

      }
      else
      {
        Console.WriteLine("Bad credentials");
      }
      return isLoggedIn;





    }







  }


}