using System;
using System.Collections.Generic;

namespace Event_Portal.Models
{
  public record Guest
  {
    public Guid Id { get; init; }


    public string GuestName { get; init; }

 

  }
}