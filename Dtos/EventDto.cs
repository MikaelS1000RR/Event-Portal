using System;

namespace Event_Portal.Dtos
{
 
  public record EventDto 
  {
    public Guid Id { get; init; }
    public string Location { get; init; }
    public DateTimeOffset StartDateTime { get; set; }
    public DateTimeOffset EndDateTime { get; set; }

    public Guid HostId { get; init; }  
  }

}