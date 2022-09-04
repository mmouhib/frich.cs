namespace frich.Dto;

public class ParticipantPostDto
{
    public string ParticipantName { get; set; }
}

public class ParticipantGetDto : ParticipantPostDto
{
    public int ParticipantId { get; set; }
}