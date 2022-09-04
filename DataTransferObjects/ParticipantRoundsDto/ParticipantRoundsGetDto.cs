using System.ComponentModel.DataAnnotations;

namespace frich.DataTransferObjects.ParticipantRoundsDto;

public class ParticipantRoundsGetDto : ParticipantRoundsPostDto
{
    public int RoundId { get; set; }
    public int ParticipantId { get; set; }
}