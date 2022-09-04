using AutoMapper;
using frich.Dto;
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