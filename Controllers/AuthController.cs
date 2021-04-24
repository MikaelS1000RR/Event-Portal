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
using Event_Portal.Auth;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;

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
        Password = PasswordHash.HashPassword(userDto.Password)
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


      if (!User.Identity.IsAuthenticated)
      {
        string uniquekey = "";


        Login currentUser = new()
        {

          Email = login.Email,
          Password = login.Password,

        };

        FirebaseResponse res = client.Get(@"users");
        Dictionary<string, User> listUser = JsonConvert.DeserializeObject<Dictionary<string, User>>(res.Body.ToString());


        bool rightCredentials = false;
        User isLoggedIn = null;

        foreach (var user in listUser)
        {

          var userEmail = user.Value.Email;
          var userPassword = user.Value.Password;
          uniquekey = user.Key;



          if (userEmail == currentUser.Email)
          {
            if (PasswordHash.ValidatePassword(currentUser.Password, userPassword))
            {
              isLoggedIn = user.Value;
              rightCredentials = true;
              break;
            }


          }

        }
        if (rightCredentials == true)
        {

          Console.WriteLine("Unique key after foreach is " + uniquekey);
          Console.WriteLine("Welcome " + currentUser.Email);
          var claims = new List<Claim>
        {
          new Claim(ClaimTypes.Email, currentUser.Email),
          new Claim(ClaimTypes.Name, uniquekey)
      };

          var claimsIdentity = new ClaimsIdentity(claims, "Login");

          HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));



        }
        else
        {
          Console.WriteLine("Bad credentials");
        }
        return isLoggedIn;
      }



      else
      {
        Console.WriteLine("You are already logged in");
        return null;

      }
    }

    [HttpPost]
    [Route("/logout")]

    public async Task<string> Logout()
    {
      await HttpContext.SignOutAsync();
      return "You've been logged out ";
    }

    [HttpPost]
    [Route("/whoami")]

    public string Whoami()
    {
      ClaimsPrincipal principal = HttpContext.User as
      ClaimsPrincipal;

      if (User.Identity.IsAuthenticated)
      {
        var key = principal.Claims.Where(c => c.Type == ClaimTypes.Name).Select(c => c.Value).SingleOrDefault();
        Console.WriteLine("Unique key in whoami is " + key);


        foreach (Claim claim in principal.Claims)
        {
          Console.WriteLine("Claim Value: " + claim.Value);
        }

        return key;


      }
      else
      {
        return "User is unauthenticated";
      }
    }



  }


}