using System;
using System.Collections.Generic;
using Event_Portal.Models;

namespace Event_Portal.Dtos
{
  public record UserDto
  {

    public Guid Id { get; init; }
    public string FirstName { get; init; }

    public string LastName { get; init; }

    public string Email { get; init; }

    public string Password { get; init; }

    public List<Event> CreatedEvents { get; init; } = new();

    public List<Event> JoinedEvents { get; init; } = new();


  }
}