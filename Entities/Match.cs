using System.ComponentModel.DataAnnotations;

namespace frich.Entities;

public class Match
{
    [Key] public int MatchId { get; set; }
    [Required] public string MatchType { get; set; } = default!;
    [Required] public string MatchScore { get; set; } = default!;
    [Required] public DateOnly MatchDate { get; set; }
    [Required] public int Duration { get; set; }
}