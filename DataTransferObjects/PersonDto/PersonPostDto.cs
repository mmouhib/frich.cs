namespace frich.DataTransferObjects.PersonDto;

public class PersonPostDto : BasePersonDto
{
    public override string ToString()
    {
        return $"PersonPostDto: {Username} / {Email} / {Password}";
    }
}