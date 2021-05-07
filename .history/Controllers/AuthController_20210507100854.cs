using System;
using System.Collections.Generic;
using System.Linq;
using Event_Portal.Dtos;
using Event_Portal.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
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
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authorization;
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

    IFirebaseClient client;

    private IConfiguration _config;




    public AuthController(IConfiguration MyConfig)
    {

      _config = MyConfig;

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


    [HttpPost, Route("login")]
    public IActionResult GetLogin([FromBody] Login login)
    {


      if (!User.Identity.IsAuthenticated)
      {
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

          IActionResult response = Unauthorized();
          var tokenStr = GenerateJSONWebToken(login);
          response = Ok(new { tokenStr });

          Console.WriteLine("Welcome " + currentUser.Email);
          var claims = new List<Claim>
        {
          new Claim(ClaimTypes.Email, currentUser.Email),
          new Claim(ClaimTypes.Name, Id.ToString())
      };

          var claimsIdentity = new ClaimsIdentity(claims, "Login");

          HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));


          return response;
        }
        else
        {
          Console.WriteLine("Bad credentials");
        }
        return Unauthorized();
      }



      else
      {
        Console.WriteLine("You are already logged in");
        return null;

      }
    }

    private string GenerateJSONWebToken(Login loginInfo)
    {
      var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
      var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

      var claims = new[]
      {
        new Claim(JwtRegisteredClaimNames.Sub, loginInfo.Email),
        new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
      };

      var token = new JwtSecurityToken(
        issuer: _config["Jwt:Issuer"],
        audience: _config["Jwt:Issuer"],
        claims,
        expires: DateTime.Now.AddMinutes(120),
        signingCredentials: credentials);

      var encodetoken = new JwtSecurityTokenHandler().WriteToken(token);
      return encodetoken; 

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


    [HttpPost("Post")]


    public string Post()

    {
    var identity = HttpContext.User.Identity as ClaimsIdentity;
    IList<Claim> claim = identity.Claims.ToList();
      var userName = claim[0].Value;
      return "Welcome To: " + userName;


    }

    public ActionResult<IEnumerable<string>> Get() 
    {
      return new 
    }

  }



}