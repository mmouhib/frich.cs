namespace frich.DataTransferObjects.MatchDto;

public class MatchPostDto
{
    public string MatchType { get; set; }
    public string MatchScore { get; set; }
    public DateOnly MatchDate { get; set; }
    public int Duration { get; set; }
    public int PersonId { get; set; }

    public override string ToString()
    {
        return $"{this.GetType().Name}: {MatchType} / {MatchScore} / {MatchDate} / {Duration} / {PersonId}";
    }
}