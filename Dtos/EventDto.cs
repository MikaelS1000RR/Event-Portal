using System;
using System.Collections.Generic;
using Event_Portal.Models;

namespace Event_Portal.Dtos
{
 
  public record EventDto 
  {
    public Guid Id { get; init; }
    public string Location { get; init; }
    public DateTimeOffset StartDateTime { get; set; }
    public DateTimeOffset EndDateTime { get; set; }

    public string HostId { get; init; }
    public List<User> JoinedUsers { get; init; } = new();
  }

}