using System;
using System.Collections.Generic;

namespace Event_Portal.Models
{
  public record User
  {

    public Guid Id { get; init; }
    public string FirstName { get; init; }

    public string LastName { get; init; }

    public string Email { get; init; }

    public string Password { get; init; }

    public List<Event> CreatedEvents { get; init; } = new();

    public List<Event> JoinedEvents { get; init; } = new();
    public bool Key { get; internal set; }
  }
}