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
  [Route("/users")]


  public class UsersController : ControllerBase
  {

    IFirebaseConfig config = new FirebaseConfig
    {
      AuthSecret = "JVGSRZVMU5Iw6TtGygVyEPUf41Zk40viN3UxWR76",
      BasePath = "https://geshdo-events-dev-default-rtdb.europe-west1.firebasedatabase.app/"
    };

    IFirebaseClient client;




    public UsersController()
    {
      
      client = new FireSharp.FirebaseClient(config);
      
    }

    // GET /users
    [Authorize]
    [HttpGet]
    public IEnumerable<SecureUserDto>  GetUsers()
    {
    
      FirebaseResponse res = client.Get(@"users");
      Dictionary<string, SecureUserDto> data = JsonConvert.DeserializeObject<Dictionary<string, SecureUserDto>>(res.Body.ToString());
      // Used Linq instead of foreach loop
       var list = data.Select(x => x.Value);
      
      return list;

    }    

    // GET /users/{id}
    [HttpGet("{id}")]
    public async Task<SecureUserDto> GetUser(String id) 
    {
      var response = await client.GetTaskAsync("users/" + id);

      if(client != null) 
      {
        Console.WriteLine("Connection is established.");
      }
      SecureUserDto result = response.ResultAs<SecureUserDto>();
     
      return result;
    }

      
    // PUT /users/{id}
    [HttpPut("{id}")]
    public async Task<UpdateUserDto> UpdateUser(String id, UpdateUserDto userDto)
    {

      UpdateUserDto updatedUser = new UpdateUserDto
      {
        FirstName = userDto.FirstName,
        LastName = userDto.LastName,
        Email = userDto.Email,
        Password = userDto.Password,
      };


      var response = await client.UpdateTaskAsync("users/" + id, updatedUser);  
      User result = response.ResultAs<User>();

      Console.WriteLine("Updated user's information.");

      

      return updatedUser;

    }

    // DELETE /users/{id}
    [HttpDelete("{id}")]
    public  async Task<String> DeleteUser(String id) {

      var response = await client.DeleteTaskAsync("users/" + id);

      return "This user has been removed.";

    }

 
   }


 
} 