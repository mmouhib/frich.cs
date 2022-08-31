using AutoMapper;
using frich.DataTransferObjects.ParticipantDto;
using frich.Entities;

namespace frich.Profiles;

public class ParticipantProfile : Profile
{
    public ParticipantProfile()
    {
        CreateMap<Participant, ParticipantGetDto>();
        CreateMap<Participant, ParticipantPostDto>();
        CreateMap<ParticipantPostDto, Participant>();
    }
}