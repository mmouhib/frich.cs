using AutoMapper;
using frich.DataTransferObjects.MatchDto;
using frich.DataTransferObjects.ParticipantDto;
using frich.Entities;

namespace frich.Profiles;

public class ParticipantProfile:Profile
{
	public ParticipantProfile()
	{
		CreateMap<Participant, ParticipantGetDto>();
        CreateMap<ParticipantPostDto, Participant>();
        CreateMap<Participant, ParticipantPostDto>();
    }
}
