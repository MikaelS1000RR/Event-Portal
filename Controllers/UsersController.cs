using System.Collections.Generic;
using Event_Portal.Models;
using Event_Portal.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Event_Portal.Controllers
{

  [ApiController]
  [Route("users")]
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
  }

}