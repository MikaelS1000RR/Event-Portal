using System;
using System.Collections.Generic;
using System.Linq;
using Event_Portal.Dtos;
using Event_Portal.Models;
using Event_Portal.Repositories;
using Microsoft.AspNetCore.Mvc;

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

    private readonly IUserRepo repository;

    public UsersController(IUserRepo repository)
    {
      this.repository = repository;

      client = new FireSharp.FirebaseClient(config);


      
    }

    // GET /users
    [HttpGet]
    public IEnumerable<UserDto> GetUsers()
    {
       var users = repository.GetUsers().Select(user => user.AsDto());

      if (client != null)
      {
        Console.WriteLine("Connection is established.");
      }

       return users;
    
    }

    // GET /users/{id}
    [HttpGet("{id}")]
    public ActionResult<UserDto> GetUser(Guid id) 
    {
      var user = repository.GetUser(id);

      if(user is null) 
      {
        return NotFound();
      }

      return user.AsDto();
    }

      // POST /users
     [HttpPost] 
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


      var response = await client.PushTaskAsync("users", user);
      User result = response.ResultAs<User>();

      Console.WriteLine("Pushed new user");


    

      return user;


      //return CreatedAtAction(nameof(GetUser), new { id = user.Id}, user.AsDto());

    }

    // PUT /users/{id}
    [HttpPut("{id}")]
    public async Task<UpdateUserDto> UpdateUser(String id, UpdateUserDto userDto)
    {
     // var existingUser = repository.GetUser(id);

    /*  if(existingUser == null)
      {
         await Task.CompletedTask;   // Try to make NotFound() work 
      }
*/
      UpdateUserDto updatedUser = new UpdateUserDto
      {
        FirstName = userDto.FirstName,
        LastName = userDto.LastName,
        Email = userDto.Email,
        Password = userDto.Password,
      };


      var response = await client.UpdateTaskAsync("users/" + id, updatedUser);  
      User result = response.ResultAs<User>();

      Console.WriteLine("Pushed new user");

      

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