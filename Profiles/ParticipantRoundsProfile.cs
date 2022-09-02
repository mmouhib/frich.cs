using AutoMapper;
using frich.DataTransferObjects.ParticipantRoundsDto;
using frich.Entities;

namespace frich.Profiles;

public class ParticipantRoundsProfile:Profile
{
	public ParticipantRoundsProfile()
	{
		CreateMap<ParticipantRounds, ParticipantRoundsGetDto>();
        CreateMap<ParticipantRounds, ParticipantRoundsPostDto>();
        CreateMap<ParticipantRoundsPostDto, ParticipantRounds>();
    }
}
