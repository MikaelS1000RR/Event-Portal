using System;
using System.ComponentModel.DataAnnotations;

namespace Event_Portal.Dtos
{
  public record UpdateEventDto 
  {

    [Required]
    public string Location { get; init; }

    [Required]
    public DateTimeOffset StartDateTime { get; init; } 
    [Required]
    public DateTimeOffset EndDateTime { get; init; }

  }
}