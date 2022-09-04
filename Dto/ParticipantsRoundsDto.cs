namespace frich.Dto;

public class ParticipantRoundsPostDto
{
    public int Score { get; set; }
}

public class ParticipantRoundsGetDto : ParticipantRoundsPostDto
{
    public int RoundId { get; set; }
    public int ParticipantId { get; set; }
}