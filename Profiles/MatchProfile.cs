using AutoMapper;
using frich.Dto;
using frich.Entities;

namespace frich.Profiles;

public class MatchProfile : Profile
{
    public MatchProfile()
    {
        CreateMap<Match, MatchGetDto>();
        CreateMap<MatchPostDto, Match>();
        CreateMap<Match, MatchPostDto>();
    }
}