namespace frich.DataTransferObjects.PersonDto;

public class PersonUpdateDto : BasePersonDto
{
    public override string ToString()
    {
        return $"PersonUpdateDto: {Username} / {Email} / {Password}";
    }
}
