using System.ComponentModel.DataAnnotations;

namespace Event_Portal.Dtos
{
  public record CreateEventDto 
  {

    [Required]
    public string Location { get; init; }

  }
}