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
          Password = user.Password, 
          createdEvents = user.createdEvents
        };
      }
    }

    public static EventDto AsDto2(this Event myEvent) 
    {
      return new EventDto
      {
        Id = myEvent.Id,
        Location = myEvent.Location,
        StartDateTime = myEvent.StartDateTime,
        EndDateTime = myEvent.EndDateTime,
        HostId = myEvent.HostId
      };
    }
  }
}