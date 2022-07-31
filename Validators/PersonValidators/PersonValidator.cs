using FluentValidation;
using frich.DataTransferObjects.PersonDto;
using frich.Entities;


namespace frich.Validators.PersonValidators
{
    public class PersonValidator : AbstractValidator<PersonPostDto>
    {
        public PersonValidator()
        {
            RuleFor(person => person.Username).NotEmpty();
        }
    }
}
