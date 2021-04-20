using System;
using System.Collections.Generic;
using System.Linq;
using Event_Portal.Dtos;
using Event_Portal.Models;
using Event_Portal.Repositories;
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


    private readonly IUserRepo repository;

    public UsersController(IUserRepo repository)
    {
      this.repository = repository;
      client = new FireSharp.FirebaseClient(config);
      
    }

    // GET /users
    [HttpGet]
    public List<User>  GetUsers()
    {
    
      FirebaseResponse res = client.Get(@"users");
      Dictionary<string, User> data = JsonConvert.DeserializeObject<Dictionary<string, User>>(res.Body.ToString());
       var list=populateRTB(data);
      return list;

    }

  
    public List<User> populateRTB(Dictionary<string, User> record)
    {

      List<User> myList = new List<User>();
      foreach(var item in record)
      {
        //var info = "item is " + item.Value.FirstName;
        myList.Add(item.Value);
      }

      return myList;

    }

    

    // GET /users/{id}
    [HttpGet("{id}")]
    public async Task<UserDto> GetUser(String id) 
    {
      var response = await client.GetTaskAsync("users/" + id);

      if(client != null) 
      {
        Console.WriteLine("Connection is established.");
      }
      UserDto result = response.ResultAs<UserDto>();
     
      return result;
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