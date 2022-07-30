namespace frich.DataTransferObjects.PersonDto;

//this class contains the common attributes and methods of POST and
//UPDATE Dto classes and will be inherited from both previous classes.
//this is done incase we want to add different attributes or methods to one
//of the child classes.
public class BasePersonPostUpdate
{
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}
