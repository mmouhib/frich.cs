namespace frich.DataTransferObjects.PersonDto;

//this class is the form of results of get requests
//on Person entity
public class PersonGetDto
{
    public int PersonId { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}