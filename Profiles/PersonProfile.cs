using AutoMapper;
using frich.DataTransferObjects.PersonDto;
using frich.Entities;

namespace frich.Profiles;

// This class maps the entity (Person) to the form that we want our result to be,
// which is 'PersonGetDto' in the 'Person' entity example.

public class PersonProfile : Profile
{
    public PersonProfile()
    {
        CreateMap<Person, PersonGetDto>();
        CreateMap<PersonSendDto, Person>();
        CreateMap<Person, PersonSendDto>();
    }
}