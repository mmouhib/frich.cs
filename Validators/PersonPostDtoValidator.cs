using FluentValidation;
using frich.Dto;

namespace frich.Validators;

public class PersonPostDtoValidator : AbstractValidator<PersonSendDto>
{
    public PersonPostDtoValidator()
    {
        RuleFor(person => person.Username)
            .NotEmpty()
            .NotNull()
            .Matches(RegexDef.UsernameRegex);
        
        RuleFor(person => person.Email)
            .NotEmpty()
            .NotNull()
            .Matches(RegexDef.EmailRegex);
        
        RuleFor(person => person.Password)
            .NotEmpty()
            .NotNull()
            .Matches(RegexDef.PasswordRegex);
        
    }
}