using FluentValidation;
using frich.Dto;

namespace frich.Validators.PersonValidators;

public class PersonSendDtoValidator : AbstractValidator<PersonSendDto>
{
    public PersonSendDtoValidator()
    {
        RuleFor(person => person.Username).NotEmpty();
    }
}