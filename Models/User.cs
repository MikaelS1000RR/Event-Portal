namespace Event_Portal.Models
{
  public class User
  {
    public string firstName { get; set; }

    public string lastName { get; set; }

    public string email { get; set; }

    private string password { get; set; }

    private int id { get; set; }




    public User(
        string firstName, string lastName, string email, string password, int id
    )
    {
      this.firstName = firstName;
      this.lastName = lastName;
      this.email = email;
      this.password = password;
      this.id = id;
    }

  }
}