﻿namespace frich.DataTransferObjects.PersonDto;

// This class treats GET request
public class PersonGetDto
{
    public int PersonId { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

    public override string ToString()
    {
        return $" {this.GetType().Name}: {PersonId} / {Username} / {Email} / {Password}";
    }
}