using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Event_Portal.Dtos;
using Event_Portal.Models;
using Event_Portal.Repositories;
using Microsoft.AspNetCore.Mvc;


namespace Event_Portal.Controllers
{

  [ApiController]
  [Route("/users")]
  public class UsersController : ControllerBase
  {
    private readonly IUserRepo repository;

    public UsersController(IUserRepo repository)
    {
      this.repository = repository; 
    }

    // GET /users
    [HttpGet]
    public async Task<IEnumerable<UserDto>> GetUsersAsync()
    {
       var users = (await repository.GetUsersAsync())
                    .Select(user => user.AsDto());
       return users;
    
    }

    // GET /users/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<UserDto>> GetUserAsync(Guid id) 
    {
      var user = await repository.GetUserAsync(id);

      if(user is null) 
      {
        return NotFound();
      }

      return user.AsDto();
    }

      // POST /users
     [HttpPost] 
    public async Task<ActionResult<UserDto>> CreateUserAsync(CreateUserDto userDto)
    {
      User user = new()
      {
        Id = Guid.NewGuid(),
        FirstName = userDto.FirstName,
        LastName = userDto.LastName,
        Email = userDto.Email,
        Password = userDto.Password
      };

      await repository.CreateUserAsync(user);

      return CreatedAtAction(nameof(GetUserAsync), new { id = user.Id}, user.AsDto());

    }

    // PUT /users/{id}
    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateUserAsync(Guid id, UpdateUserDto userDto)
    {
      var existingUser = await repository.GetUserAsync(id);

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

      await repository.UpdateUserAsync(updatedUser);

      return NoContent();

    }

    // DELETE /users/{id}
    [HttpDelete("{id}")]
    public  async Task<ActionResult> DeleteUserAsync(Guid id) {

      var existingUser = await repository.GetUserAsync(id);

      if (existingUser is null)
      {
        return NotFound();
      }

      await repository.DeleteUserAsync (id);

      return NoContent();
    }



  
    
 
   }


 
} 