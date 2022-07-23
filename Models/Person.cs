namespace frich.Models;

public class Person
{
    public int PersonId { get; set; }
    public string Username { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string Password { get; set; } = default!;
}