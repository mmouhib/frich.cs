namespace frich.DataTransferObjects.PersonDto;

// This class treats POST/PUT requests
public class PersonSendDto
{
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

    public override string ToString()
    {
        return $"{this.GetType().Name}: {Username} / {Email} / {Password}";
    }
}