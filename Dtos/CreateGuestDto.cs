using System.ComponentModel.DataAnnotations;

namespace Event_Portal.Dtos
{
    public class CreateGuestDto
    {
    [Required]
    public string GuestName { get; init; }
    }
}