namespace frich.DataTransferObjects.RoundDto;

public class RoundPostDto
{
    public int RoundNumber { get; set; }
    public int HostScore { get; set; }
    public int PersonId { get; set; }
    public int MatchId { get; set; }

    public override string ToString()
    {
        return $"{this.GetType().Name}: {RoundNumber} / {HostScore} / {PersonId} / {MatchId}";
    }
}