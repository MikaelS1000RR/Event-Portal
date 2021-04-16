using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Event_Portal.Models;

namespace Event_Portal.Repositories
{

  public interface IUserRepo
  {
    Task<User> GetUserAsync(Guid id);
    Task<IEnumerable<User>> GetUsersAsync();

    Task CreateUserAsync(User user);

    Task UpdateUserAsync(User user);

    Task DeleteUserAsync (Guid id);

   
  }
  
}