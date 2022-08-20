namespace frich.DataTransferObjects.PersonDto;

// This class treats GET request
public class PersonGetDto : PersonSendDto
{
    public int PersonId { get; set; }

    public override string ToString()
    {
        return $" {this.GetType().Name}: {PersonId} / {Username} / {Email} / {Password}";
    }
}