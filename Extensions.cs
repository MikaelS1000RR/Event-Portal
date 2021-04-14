using Event_Portal.Dtos;
using Event_Portal.Models;

namespace Event_Portal
{
  public static class Extensions 
  {
    public static UserDto AsDto(this User user)
    {
      {
        return new UserDto
        {
          Id = user.Id,
          FirstName = user.FirstName,
          LastName = user.LastName,
          Email = user.Email,
          Password = user.Password
        };
      }
    }
  }
}