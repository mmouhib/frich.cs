using System.ComponentModel.DataAnnotations;

namespace frich.DataTransferObjects.ParticipantRoundsDto;

public class ParticipantRoundsGetDto
{
    public int RoundId { get; set; }
    public int ParticipantId { get; set; }
    public int Score { get; set; }
}
