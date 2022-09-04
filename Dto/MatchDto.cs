namespace frich.Dto;

public class MatchPostDto
{
    public MatchPostDto()
    {
        MatchDate = DateTime.Now.ToUniversalTime();
    }

    public string MatchType { get; set; }
    public DateTime MatchDate { get; set; }
    public int Duration { get; set; }
    public int PersonId { get; set; }
}

public class MatchGetDto : MatchPostDto
{
    public int MatchId { get; set; }
}