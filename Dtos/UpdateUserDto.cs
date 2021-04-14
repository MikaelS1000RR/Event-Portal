using System.ComponentModel.DataAnnotations;

namespace Event_Portal.Dtos
{
    public record UpdateUserDto
    {


   [Required]
    public string FirstName { get; init; }

    [Required]
    public string LastName { get; init; }

    [Required]
    public string Email { get; init; }

    [Required]
    public string Password { get; init; }
    }
}