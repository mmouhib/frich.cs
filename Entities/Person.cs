using System.ComponentModel.DataAnnotations;

namespace frich.Entities;

public class Person
{
    [Key] public int PersonId { get; set; }
    [Required] public string Username { get; set; } = default!;
    [Required] public string Email { get; set; } = default!;
    [Required] public string Password { get; set; } = default!;

    public List<Match> Matches { get; set; }

    public List<Round> Rounds { get; set; }


    public override string ToString()
    {
        return $"Person: {PersonId} / {Username} / {Email} / {Password}";
    }
}