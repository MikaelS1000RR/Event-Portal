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
    public ActionResult<UserDto> CreateUser(CreateUserDto userDto)
    {
      User user = new()
      {
        Id = Guid.NewGuid(),
        FirstName = userDto.FirstName,
        LastName = userDto.LastName,
        Email = userDto.Email,
        Password = userDto.Password
      };

      repository.CreateUser(user);

      return CreatedAtAction(nameof(GetUser), new { id = user.Id}, user.AsDto());

    }

    // PUT /users/{id}
    [HttpPut("{id}")]
    public ActionResult UpdateUser(Guid id, UpdateUserDto userDto)
    {
      var existingUser = repository.GetUser(id);

      if(existingUser is null)
      {
        return NotFound();
      }

      User updatedUser = existingUser with
      {
        FirstName = userDto.FirstName,
        LastName = userDto.LastName,
        Email = userDto.Email,
        Password = userDto.Password,
      };

      repository.UpdateUser(updatedUser);

      return NoContent();

    }

    // DELETE /users/{id}
    [HttpDelete("{id}")]
    public ActionResult DeleteUser(Guid id) {

      var existingUser = repository.GetUser(id);

      if (existingUser is null)
      {
        return NotFound();
      }

      repository.DeleteUser(id);

      return NoContent();
    }



  
    
 
   }


 
} 