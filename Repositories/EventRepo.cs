using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Event_Portal.Models;

namespace Event_Portal.Repositories
{

  public class EventRepo : IEventRepo
  {
    private readonly List<Event> events = new()
    {
      new Event
      {
        Id = Guid.NewGuid(),
        Location = "Köpemhamn",
        StartDateTime = DateTimeOffset.UtcNow,
        EndDateTime = DateTimeOffset.UtcNow,
        HostId = Guid.NewGuid(),
      },

      new Event
      {
        Id = Guid.NewGuid(),
        Location = "Lund",
        StartDateTime = DateTimeOffset.UtcNow,
        EndDateTime = DateTimeOffset.UtcNow,
        HostId = Guid.NewGuid()
      },


      new Event
      {
        Id = Guid.NewGuid(),
        Location = "Malmö",
        StartDateTime = DateTimeOffset.UtcNow,
        EndDateTime = DateTimeOffset.UtcNow,
        HostId = Guid.NewGuid()
      }
    };
    public async Task<IEnumerable<Event>> GetEventsAsync()
    {
      return await Task.FromResult(events);
    }

    public async Task<Event> GetEventAsync(Guid id)
    {
      var myEvent = events.Where(myEvent => myEvent.Id == id).SingleOrDefault();
      return await Task.FromResult(myEvent);
    }

    public async Task CreateEventAsync(Event myEvent)
    {
      events.Add(myEvent);
      await Task.CompletedTask;
    }

    public async Task UpdateEventAsync(Event myEvent)
    {
      var index = events.FindIndex(existingEvent => existingEvent.Id == myEvent.Id);
      events[index] = myEvent;
      await Task.CompletedTask;
    }

    public async Task DeleteEventAsync(Guid id)
    {
      var index = events.FindIndex(existingEvent => existingEvent.Id == id);
      events.RemoveAt(index);
      await Task.CompletedTask; 
    }
  }
}