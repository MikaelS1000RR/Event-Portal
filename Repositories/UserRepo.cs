using System;
using System.Collections.Generic;
using System.Linq;
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
    public IEnumerable<User> GetUsers()
    {
      return users;
    }

    public User GetUser(Guid id)
    {

      return users.Where(user => user.Id == id).SingleOrDefault();

    }

    public void CreateUser(User user)
    {
      users.Add(user);
    }

    public void UpdateUser(User user)
    {
      var index = users.FindIndex(existingUser => existingUser.Id == user.Id);
      users[index] = user; 
    }
  }
}