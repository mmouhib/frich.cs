namespace frich.Dto;

public class RoundPostDto
{
    public int RoundNumber { get; set; }
    public int HostScore { get; set; }
    public int PersonId { get; set; }
    public int MatchId { get; set; }
}

public class RoundGetDto : RoundPostDto
{
    public int RoundId { get; set; }
}