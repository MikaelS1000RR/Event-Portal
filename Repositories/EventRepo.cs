using System.Collections.Generic;
using Event_Portal.Models;
using System;
using System.Linq;

namespace Event_Portal.Repositories
{
  

  public class EventRepo : IEventRepo
  {
    private readonly List<Event> events = new()
    {
      new Event
      {
        Id = Guid.NewGuid(),
        Location = "Malmö",
        StartDateTime = DateTimeOffset.UtcNow,
        EndDateTime = DateTimeOffset.UtcNow,
        HostId = Guid.NewGuid()
      },

      new Event
      {
        Id = Guid.NewGuid(),
        Location = "Köpenhamn",
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
  }

}