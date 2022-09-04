using AutoMapper;
using frich.Data.Interfaces;
using frich.Data.UnitOfWork;
using frich.DataTransferObjects.ParticipantRoundsDto;
using frich.Entities;
using Microsoft.AspNetCore.Mvc;

namespace frich.Controllers;

[Route("api/participants")]
[ApiController]
public class ParticipantRoundsController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IParticipantRoundsRepo _repository;

    public ParticipantRoundsController(IMapper mapper, IUnitOfWork uow, IParticipantRoundsRepo repo)
    {
        _mapper = mapper;
        _unitOfWork = uow;
        _repository = repo;
    }

    [HttpGet("{participantId}/rounds")]
    public ActionResult<IEnumerable<ParticipantRoundsGetDto>> GetRoundByParticipant(int participantId)
    {
        var data = _repository.GetRoundsByParticipantId(participantId);
        if (!data.Any()) return NotFound();
        return Ok(_mapper.Map<IEnumerable<ParticipantRoundsGetDto>>(data));
    }

    [HttpPost("{participantId}/rounds/{roundId}", Name = "AddRound")]
    public ActionResult<ParticipantRoundsGetDto> AddRound(int participantId, int roundId,
        ParticipantRoundsPostDto requestBody)
    {
        var dataToAdd = new ParticipantRounds()
            { ParticipantId = participantId, RoundId = roundId, Score = requestBody.Score };

        _repository.Add(dataToAdd);
        _unitOfWork.Commit();

        var returnResult = _mapper.Map<ParticipantRoundsGetDto>(dataToAdd);

        return CreatedAtRoute(
            nameof(AddRound),
            new { participantId = returnResult.ParticipantId, roundId = returnResult.RoundId },
            returnResult
        );
    }

    // todo: add get method by both participantId and roundId
}