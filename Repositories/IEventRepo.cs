using System;
using System.Collections.Generic;
using Event_Portal.Models;

namespace Event_Portal.Repositories
{
  public interface IEventRepo
  {
    Event GetEvent(Guid id);
    IEnumerable<Event> GetEvents();
  }
  
}