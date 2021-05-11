using System;
using System.Collections.Generic;

namespace Event_Portal.Models
{
  public record Event
  {


    public Guid Id { get; init; }
    public string Name { get; init; }
    public string Description { get; init; }

    public string Access { get; set; }
    public string Location { get; init; }

    public string ImgUrl{ get; set; }





    public DateTimeOffset StartDateTime { get; init; }
    public DateTimeOffset EndDateTime { get; init; }



    public String HostId { get; init; }   // if error occurs, change to int 

    public String HostName { get; init; }

    public List<User> JoinedUsers { get; init; } = new();
    public List<Guest> JoinedGuests { get; init; } = new();

  
  }
}