using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace frich.Entities;

public class Match
{
    [Key] public int MatchId { get; set; }
    [Required] public string MatchType { get; set; } = default!;
    [Required] public string MatchScore { get; set; } = default!;
    [Required] public DateOnly MatchDate { get; set; }
    [Required] public int Duration { get; set; }

    [Required] [ForeignKey("Person")] public int PersonId { get; set; }

    public List<Round> Rounds { get; set; }
}