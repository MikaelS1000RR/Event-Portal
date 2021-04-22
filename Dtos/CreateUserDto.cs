using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Event_Portal.Models;

namespace Event_Portal.Dtos
{
  public record CreateUserDto
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