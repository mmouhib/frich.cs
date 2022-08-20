using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace frich.Entities;

public class Round
{
    [Key] public int RoundId { get; set; }
    [Required] public int RoundNumber { get; set; }
    [Required] public int HostScore { get; set; }

    [Required] [ForeignKey("Person")] public int PersonId { get; set; }
    [Required] [ForeignKey("Match")] public int MatchId { get; set; }

    public List<ParticipantRoundScore> ParticipantRoundScores { get; set; }
}