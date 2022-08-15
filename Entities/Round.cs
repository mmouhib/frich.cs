using System.ComponentModel.DataAnnotations;

namespace frich.Entities;

public class Round
{
    [Key] public int RoundId { get; set; }
    [Required] public int RoundNumber { get; set; }
    [Required] public int HostScore { get; set; }

    public List<ParticipantRoundScore> ParticipantRoundScores { get; set; }
}