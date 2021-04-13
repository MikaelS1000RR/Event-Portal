using System; 
namespace Event_Portal.Models
{
  public record User
  {

    public Guid Id { get;  init; }
    public string FirstName { get; init; }

    public string LastName { get; init; }

    public string Email { get; init; }

    private string Password { get; init; }

    // private int Id { get; init; }


    /*public User(
        string firstName, string lastName, string email, string password, int id
    )
    {
      this.firstName = firstName;
      this.lastName = lastName;
      this.email = email;
      this.password = password;
      this.id = id;
    } */

  }
}