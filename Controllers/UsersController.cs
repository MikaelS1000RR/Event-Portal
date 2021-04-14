using System;
using System.Collections.Generic;
using Event_Portal.Models;
using Event_Portal.Repositories;
using Microsoft.AspNetCore.Mvc;


namespace Event_Portal.Controllers
{

  [ApiController]
  [Route("api/users")]
  public class UsersController : ControllerBase
  {
    private readonly UserRepo repository;

    public UsersController()
    {
      repository = new UserRepo();
    }

    // GET /users
    [HttpGet]
    public IEnumerable<User> GetUsers()
    {
      var users = repository.GetUsers();
      return users;
    }

    // GET /users/{id}
    [HttpGet("{id}")]
    public User GetUser(Guid id) 
    {
      var user = repository.GetUser(id);
      return user;
    }

  }
 
}