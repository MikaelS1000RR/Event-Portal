using System;
using System.Collections.Generic;

namespace Event_Portal.Models
{
  public record Event
  {


    public Guid Id { get; init; }
    public string Location { get; init; }

    public DateTimeOffset StartDateTime { get; set; }
    public DateTimeOffset EndDateTime { get; set; }

    public String HostId { get; init; }   // if error occurs, change to int 

    public List<User> JoinedUsers { get; init; } = new();

  
  }
}