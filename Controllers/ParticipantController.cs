using AutoMapper;
using frich.Data.Interfaces;
using frich.Data.UnitOfWork;
using frich.DataTransferObjects.ParticipantDto;
using frich.Entities;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace frich.Controllers;

[Route("api/participants")]
[ApiController]
public class ParticipantController:ControllerBase
{
	private IMapper _mapper;
	private IUnitOfWork _unitOfWork;
	private IParticipantRepo _repository;

	public ParticipantController(IMapper mapper, IUnitOfWork uow, IParticipantRepo repo)
	{
		_mapper = mapper;
		_unitOfWork = uow;
		_repository = repo;
	}

	[HttpGet]
	public ActionResult<IEnumerable<ParticipantGetDto>> GetAllParticipants()
	{
		var participants = _repository.GetAll();
		if (participants.Any()) return Ok(_mapper.Map<IEnumerable<ParticipantGetDto>>(participants));
		return NotFound();
	}

	[HttpGet("{id}",Name = "GetParticipantById")]
	public ActionResult<ParticipantGetDto> GetParticipantById(int id)
	{
		var participantToGet = _repository.GetById(id);
		if (participantToGet == null) return NotFound();
		return Ok(_mapper.Map<ParticipantGetDto>(participantToGet));
	}

	[HttpPost]
	public ActionResult<ParticipantPostDto> AddParticipant(ParticipantPostDto reqBody)
	{
		var participant = _mapper.Map<Participant>(reqBody);
		_repository.Add(participant);
		_unitOfWork.Commit();
		var participantToReturn = _mapper.Map<ParticipantGetDto>(participant);
		return CreatedAtRoute(nameof(GetParticipantById), new { id = participant.ParticipantId }, participantToReturn);
	}

	[HttpPut("{id}")]
	public ActionResult UpdateParticipant(int id, ParticipantPostDto participantToUpdate)
	{
		var participant = _repository.GetById(id);
		if (participantToUpdate == null) return NotFound();
		_mapper.Map(participantToUpdate, participant);
		_unitOfWork.Commit();
		return NoContent();
	}

	[HttpPatch("{id}")]
	public ActionResult PatchPerson(int id, JsonPatchDocument<ParticipantPostDto> patchReqBody)
	{
		var participant = _repository.GetById(id);
		if (participant == null) return NotFound();

		var participantToUpdate = _mapper.Map<ParticipantPostDto>(participant);
		patchReqBody.ApplyTo(participantToUpdate, ModelState);

		_mapper.Map(participantToUpdate, participant);
		_unitOfWork.Commit();
		return NoContent();
	}

	[HttpDelete]
	public ActionResult DeleteParticipant(int id)
	{
		var participant = _repository.GetById(id);
		if (participant == null) return NotFound();
		_repository.Delete(participant);
		_unitOfWork.Commit();
		return NoContent();
	}
}
