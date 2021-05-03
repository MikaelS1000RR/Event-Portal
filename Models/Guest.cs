using System;
using System.Collections.Generic;

namespace Event_Portal.Models
{
  public class Guest
  {
    public Guid Id { get; init; }


    public string GuestName { get; init; }

    public List<Event> JoinedEvents { get; init; } = new();

  }
}