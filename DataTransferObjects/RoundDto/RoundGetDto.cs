namespace frich.DataTransferObjects.RoundDto;

public class RoundGetDto : RoundPostDto
{
    public int RoundId { get; set; }

    public override string ToString()
    {
        return $"{this.GetType().Name}: {RoundNumber} / {HostScore} / {PersonId} / {MatchId} / {RoundId}";
    }
}