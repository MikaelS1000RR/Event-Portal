using System;
using System.Collections.Generic;
using System.Linq;
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
    public IEnumerable<Event> GetEvents()
    {
      return events;
    }

    public Event GetEvent(Guid id)
    {
      return events.Where(myEvent => myEvent.Id == id).SingleOrDefault();
    }

    public void CreateEvent(Event myEvent)
    {
      events.Add(myEvent);
    }

    public void UpdateEvent(Event myEvent)
    {
      var index = events.FindIndex(existingEvent => existingEvent.Id == myEvent.Id);
      events[index] = myEvent;
    }

    public void DeleteItem(Guid id)
    {
      var index = events.FindIndex(existingEvent => existingEvent.Id == id);
      events.RemoveAt(index);
    }
  }
}