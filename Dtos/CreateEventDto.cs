using System;
using System.ComponentModel.DataAnnotations;

namespace Event_Portal.Dtos
{
  public record CreateEventDto 
  {


    [Required]
    public string HostId { get; init; }

    [Required]
    public string Location { get; init; }

    [Required]
    public DateTimeOffset StartDateTime { get; init; }

    [Required]
    public DateTimeOffset EndDateTime { get; init; }
  }
}

