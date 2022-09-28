using AutoMapper;
using frich.Data.Interfaces;
using frich.Data.UnitOfWork;
using frich.Dto;
using frich.Entities;
using Microsoft.AspNetCore.JsonPatch;
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

    [HttpDelete("{participantId}/rounds/{roundId}")]
    public ActionResult<IEnumerable<ParticipantRoundsGetDto>> DeleteRound(int participantId, int roundId)
    {
        var data = _repository.GetRoundsById(participantId, roundId);
        if (data == null) return NotFound();
        _repository.Delete(data);
        _unitOfWork.Commit();
        return NoContent();
    }

    [HttpPut("{participantId}/rounds/{roundId}")]
    public ActionResult UpdateRound(int participantId, int roundId, ParticipantRoundsPostDto requestBody)
    {
        var dataFromRepo = _repository.GetRoundsById(participantId, roundId);
        if (dataFromRepo == null) return NotFound();

        _mapper.Map(requestBody, dataFromRepo);
        _unitOfWork.Commit();

        return NoContent();
    }

    [HttpPatch("{participantId}/rounds/{roundId}")]
    public ActionResult PatchParticipantRounds(int participantId, int roundId,
        JsonPatchDocument<ParticipantRoundsPostDto> requestBody)
    {
        var dataFromRepo = _repository.GetRoundsById(participantId, roundId);
        if (dataFromRepo == null) return NotFound();

        var mappedData = _mapper.Map<ParticipantRoundsPostDto>(dataFromRepo);
        if (!TryValidateModel(mappedData)) return ValidationProblem(ModelState);

        requestBody.ApplyTo(mappedData, ModelState);

        _mapper.Map(mappedData, dataFromRepo);
        _unitOfWork.Commit();

        return NoContent();
    }
}