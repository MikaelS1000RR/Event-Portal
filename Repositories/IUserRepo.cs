using System;
using System.Collections.Generic;
using Event_Portal.Models;

namespace Event_Portal.Repositories
{

  public interface IUserRepo
  {
    User GetUser(Guid id);
    IEnumerable<User> GetUsers();

    void CreateUser(User user);

    void UpdateUser(User user);

    void DeleteUser(Guid id);

    void AddEventsToCreatedEvents(Event myEvent, User user);
  }
  
}