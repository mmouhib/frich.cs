using System.ComponentModel.DataAnnotations;

namespace frich.Entities;

public class ParticipantRounds
{
    [Key] public int RoundId { get; set; }
    [Key] public int ParticipantId { get; set; }
    [Required] public int Score { get; set; }
    public Round Round { get; set; }
    public Participant Participant { get; set; }
}
