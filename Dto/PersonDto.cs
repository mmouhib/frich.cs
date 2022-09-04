namespace frich.Dto;

public class PersonSendDto
{
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}

public class PersonGetDto : PersonSendDto
{
    public int PersonId { get; set; }
}