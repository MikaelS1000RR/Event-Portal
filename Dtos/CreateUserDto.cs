namespace Event_Portal.Dtos
{
    public record CreateUserDto
    {
    public string FirstName { get; init; }

    public string LastName { get; init; }

    public string Email { get; init; }

    public string Password { get; init; }
    }
}