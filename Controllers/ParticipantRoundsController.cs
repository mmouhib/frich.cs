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

    [HttpGet("{participantId}/rounds/{roundId}")]
    public ActionResult GetRound(int participantId, int roundId)
    {
        var data = _repository.GetRoundsById(participantId, roundId);
        if (data == null) return NotFound();
        return Ok(_mapper.Map<ParticipantRoundsGetDto>(data));
    }

    // todo: add patch and put requests support.

    [HttpDelete("{participantId}/rounds/{roundId}")]
    public ActionResult<IEnumerable<ParticipantRoundsGetDto>> DeleteRound(int participantId, int roundId)
    {
        var data = _repository.GetRoundsById(participantId, roundId);
        if (data == null) return NotFound();
        _repository.Delete(data);
        _unitOfWork.Commit();
        return NoContent();
    }
}