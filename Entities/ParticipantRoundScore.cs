using System.ComponentModel.DataAnnotations;

namespace frich.Entities;

public class ParticipantRoundScore
{
    [Key] public int ParticipantId { get; set; }
    [Key] public int RoundId { get; set; }
    [Required] public int Score { get; set; }

    public Participant Participant { get; set; }
    public Round Round { get; set; }
}