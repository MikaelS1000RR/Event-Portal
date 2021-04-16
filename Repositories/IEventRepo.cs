using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Event_Portal.Models;

namespace Event_Portal.Repositories
{
  public interface IEventRepo
  {
    Task<Event> GetEventAsync(Guid id);
    Task<IEnumerable<Event>> GetEventsAsync();

    Task CreateEventAsync(Event myEvent);

    Task UpdateEventAsync(Event myEvent);

    Task DeleteEventAsync(Guid id);
  }
  
}