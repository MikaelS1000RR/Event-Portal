using System;
namespace Event_Portal.Models
{
  public record User
  {

    public Guid Id { get; init; }
    public string FirstName { get; init; }

    public string LastName { get; init; }

    public string Email { get; init; }

    public string Password { get; init; }


  }
}