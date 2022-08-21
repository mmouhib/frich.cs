using AutoMapper;
using frich.DataTransferObjects.RoundDto;
using frich.Entities;

namespace frich.Profiles;

public class RoundProfile : Profile
{
    public RoundProfile()
    {
        CreateMap<Round, RoundGetDto>();
        CreateMap<RoundPostDto, Round>();
        CreateMap<Round, RoundPostDto>();
    }
}