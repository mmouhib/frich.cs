using AutoMapper;
using frich.Data.Interfaces;
using frich.Data.UnitOfWork;
using frich.DataTransferObjects.ParticipantDto;
using frich.Entities;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace frich.Controllers;

[Route("api/participants")]
[Controller]
public class PatricipantController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IParticipantRepo _repository;

    public PatricipantController(IMapper mapper, IUnitOfWork uow, IParticipantRepo repo)
    {
        _mapper = mapper;
        _unitOfWork = uow;
        _repository = repo;
    }

    [HttpGet]
    public ActionResult<IEnumerable<ParticipantGetDto>> GetAllParticipants()
    {
        var participants = _repository.GetAll();
        if (!participants.Any()) return NotFound();
        return Ok(_mapper.Map<IEnumerable<ParticipantGetDto>>(participants));
    }

    [HttpGet("{id}")]
    public ActionResult<ParticipantGetDto> GetParticipantById(int id)
    {
        var participant = _repository.GetById(id);
        if (participant == null) return NotFound();
        return Ok(_mapper.Map<ParticipantGetDto>(participant));
    }

    [HttpPost]
    public ActionResult<ParticipantGetDto> AddParticipant(ParticipantPostDto postRequestBody)
    {
        var participantToAdd = _mapper.Map<Participant>(postRequestBody);
        _repository.Add(participantToAdd);
        _unitOfWork.Commit();
        var dataToReturn = _mapper.Map<ParticipantGetDto>(participantToAdd);
        return CreatedAtRoute(nameof(GetParticipantById), new {id = dataToReturn.ParticipantId}, dataToReturn);
    }

    [HttpPut("{id}")]
    public ActionResult UpdateParticipant(int id, ParticipantPostDto putRequestBody)
    {
        var participantResultFromRepo = _repository.GetById(id);
        if (participantResultFromRepo == null) return NotFound();

        _mapper.Map(putRequestBody, participantResultFromRepo);
        _repository.Update(participantResultFromRepo);
        _unitOfWork.Commit();
        return NoContent();
    }

    [HttpPatch("{id}")]
    public ActionResult PatchParticipant(int id, JsonPatchDocument<ParticipantPostDto> patchRequestBody)
    {
        var participantResultFromRepo = _repository.GetById(id);
        if (participantResultFromRepo == null) return NotFound();

        var participantToPatch = _mapper.Map<ParticipantPostDto>(participantResultFromRepo);

        patchRequestBody.ApplyTo(participantToPatch, ModelState);
        if (!TryValidateModel(participantToPatch)) return ValidationProblem(ModelState);
        _mapper.Map(participantToPatch, participantResultFromRepo);
        _unitOfWork.Commit();
        _repository.Update(participantResultFromRepo);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteParticipant(int id)
    {
        var participantToDelete = _repository.GetById(id);
        if (participantToDelete == null) return NotFound();
        _repository.Delete(participantToDelete);
        _unitOfWork.Commit();
        return NoContent();
    }
}