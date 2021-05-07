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
using Microsoft.IdentityModel.Tokens;

using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;

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

    private IConfiguration _config;
    IFirebaseClient client;



    public AuthController(IConfiguration myConfig)
    {

      _config = myConfig;
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
        var response = await client.SetTaskAsync("users/" + user.Id, user);
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
    public IActionResult GetLogin(Login login)
    {

     string GenerateToken(Login login){
     var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
      var mySigningCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

      var claims = new[]{
        new Claim(JwtRegisteredClaimNames.Email, login.Email),
        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())

      };

      
      var token = new JwtSecurityToken(
        issuer: _config["Jwt:Issuer"],
        audience: _config["Jwt:Audience"],
        claims,
        expires:DateTime.Now.AddMinutes(120),
        signingCredentials: mySigningCredentials
      );

   

      var encodeToken = new JwtSecurityTokenHandler().WriteToken(token);
      return encodeToken;
    }

      IActionResult response = Unauthorized();

        Guid Id=new Guid();


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
          Id = user.Value.Id;



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

        
          Console.WriteLine("Welcome " + currentUser.Email);
         

          var tokenStr = GenerateToken(currentUser);
   


        response = Ok(new { token = tokenStr });


        }
        else
        {
          Console.WriteLine("Bad credentials");
          
        }

        return response;

      }






    [Authorize]
    [HttpPost]
    [Route("/logout")]

    public string Logout()
    {

      CookieOptions options = new CookieOptions();
      options.Expires = DateTime.Now.AddDays(-2);
        Response.Cookies.Delete("jwt"); 
     
      return "You've been logged out ";
    }

    [Authorize]
    [HttpPost]
    [Route("/whoami")]

    public async Task<User> Whoami()
    {
      ClaimsPrincipal principal = HttpContext.User as
      ClaimsPrincipal;

      if (User.Identity.IsAuthenticated)
      {
        var Id = principal.Claims.Where(c => c.Type == ClaimTypes.Name).Select(c => c.Value).SingleOrDefault();
        Console.WriteLine("Unique key in whoami is " + Id);


        foreach (Claim claim in principal.Claims)
        {
          Console.WriteLine("Claim Value: " + claim.Value);
        }

        var response = await client.GetTaskAsync("users/" + Id);
         User user = response.ResultAs<User>();


        return user;


      }
      else
      {
        User user = new User();
        return user;
      }
    }



  }


}