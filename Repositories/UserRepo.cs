using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Event_Portal.Models;


namespace Event_Portal.Repositories

{


  public class UserRepo : IUserRepo
  {
    private readonly List<User> users = new()
    {
      new User
      {

        Id = Guid.NewGuid(),
        FirstName = "Patrick",
        LastName = "Star",
        Email = "patrick.star@bikinibottom.com",
        Password = "123",

        CreatedEvents = {
            
        }



  },

      new User
      {

        Id = Guid.NewGuid(),
        FirstName = "Mr",
        LastName = "Krabs",
        Email = "mr.krabs@krustykrabs.com",
        Password = "123",

      }

    };
    public async Task<IEnumerable<User>> GetUsersAsync()
    {
      return await Task.FromResult(users);
    }

    public async Task<User> GetUserAsync(Guid id)
    {

      var user = users.Where(user => user.Id == id).SingleOrDefault();
      return await Task.FromResult(user);

    }

    public async Task CreateUserAsync(User user)
    {
      users.Add(user);
      await Task.CompletedTask;
    }

    public async Task UpdateUserAsync(User user)
    {
      var index = users.FindIndex(existingUser => existingUser.Id == user.Id);
      users[index] = user;
      await Task.CompletedTask;
    }

    public async Task DeleteUserAsync (Guid id)
    {
      var index = users.FindIndex(existingUser => existingUser.Id == id);
      users.RemoveAt(index);
      await Task.CompletedTask;
    }



  }
}