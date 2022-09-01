using System.ComponentModel.DataAnnotations;

namespace frich.Entities;

public class Participant
{
    [Key] public int ParticipantId { get; set; }
    [Required] public string participantName { get; set; }
}
