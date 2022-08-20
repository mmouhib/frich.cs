namespace frich.DataTransferObjects.MatchDto;

public class MatchGetDto : MatchPostDto
{
    public int MatchId { get; set; }


    public override string ToString()
    {
        return $"{this.GetType().Name}: {MatchType} / {MatchScore} / {MatchDate} / {Duration} / {PersonId}";
    }
}