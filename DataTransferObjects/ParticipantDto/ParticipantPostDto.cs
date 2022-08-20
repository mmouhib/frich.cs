namespace frich.DataTransferObjects.ParticipantDto;

public class ParticipantPostDto
{
    public string Name { get; set; }

    public override string ToString()
    {
        return $" {this.GetType().Name}: {Name}";
    }
}