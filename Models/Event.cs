using System;
namespace Event_Portal.Models
{
  public record Event
  {


    public Guid Id { get; init; }
    public string Location { get; init; }

    /*public string StartDate { get; init; }

    public string EndDate { get; init; }

    private string StartTime { get; init; }
    private string EndTime { get; init; } */

      public DateTimeOffset StartDateTime { get; init; }
    public DateTimeOffset EndDateTime { get; init; }

     public Guid  HostId { get; init; }   // if error occurs, change to int 

    

  }
}