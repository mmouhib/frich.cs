namespace frich.DataTransferObjects.ParticipantDto;

public class ParticipantGetDto
{
    public int ParticipantId { get; set; }

    public override string ToString()
    {
        return $" {this.GetType().Name}: {ParticipantId} / {Name}";
    }
}