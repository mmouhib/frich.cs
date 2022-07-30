namespace frich.DataTransferObjects.PersonDto;

//this class is the form of results of get requests
//on Person entity
public class PersonGetDto : BasePersonDto
{
    public int PersonId { get; set; }

    public override string ToString()
    {
        return $"PersonGetDto: {PersonId} / {Username} / {Email} / {Password}";
    }
}