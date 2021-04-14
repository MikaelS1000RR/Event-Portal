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
    private readonly IUserRepo repository;

    public UsersController(IUserRepo repository)
    {
      this.repository = repository;
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
    public ActionResult<User> GetUser(Guid id) 
    {
      var user = repository.GetUser(id);

      if(user is null) 
      {
        return NotFound();
      }

      return user;
    }

  }
 
} 