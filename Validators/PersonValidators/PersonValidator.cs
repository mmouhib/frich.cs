using FluentValidation;
using frich.Entities;

namespace frich.Validators.PersonValidators;

public class PersonValidator : AbstractValidator<Person>
{
    public PersonValidator()
    {
        RuleFor(person => person.Username).NotEmpty();
    }
}
