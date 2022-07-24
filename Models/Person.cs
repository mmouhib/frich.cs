using System.ComponentModel.DataAnnotations;

namespace frich.Models;

public class Person
{
    [Key] public int PersonId { get; set; }
    [Required] public string Username { get; set; } = default!;
    [Required] public string Email { get; set; } = default!;
    [Required] public string Password { get; set; } = default!;

    public List<Match> Matches { get; set; }
}