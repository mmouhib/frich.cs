using AutoMapper;
using frich.DataTransferObjects.PersonDtos;
using frich.Models;

namespace frich.Profiles;

// This class maps the entity (Person) to the form that we want our result to be,
// which is 'PersonGetDto' in the 'Person' entity example.

public class PersonProfile : Profile
{
    public PersonProfile()
    {
        CreateMap<Person, PersonGetDto>();
    }
}