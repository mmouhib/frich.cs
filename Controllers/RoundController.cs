using AutoMapper;
using frich.Data.Interfaces;
using frich.Data.UnitOfWork;
using frich.Dto;
using frich.Entities;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace frich.Controllers;

[Route("api/rounds")]
[ApiController]
public class RoundController : ControllerBase
{
    private readonly IRoundRepo _repository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public RoundController(IRoundRepo repo, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _repository = repo;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    [HttpGet]
    public ActionResult<IEnumerable<RoundGetDto>> GetAllRounds()
    {
        var rounds = _repository.GetAll();

        if (rounds.Any()) return Ok(_mapper.Map<IEnumerable<RoundGetDto>>(rounds));

        return NotFound();
    }

    [HttpGet("{id}", Name = "GetRoundById")]
    public ActionResult<RoundGetDto> GetRoundById(int id)
    {
        var round = _repository.GetById(id);
        if (round == null) return NotFound();
        return _mapper.Map<RoundGetDto>(round);
    }

    [HttpPost]
    public ActionResult<RoundPostDto> AddRound(RoundPostDto roundPostRequestBody)
    {
        var round = _mapper.Map<Round>(roundPostRequestBody);
        _repository.Add(round);
        _unitOfWork.Commit();

        RoundGetDto roundToReturn = _mapper.Map<RoundGetDto>(round);

        return CreatedAtRoute(nameof(GetRoundById), new { id = roundToReturn.RoundId }, roundToReturn);
    }

    [HttpPut("{id}")]
    public ActionResult UpdateRound(int id, RoundPostDto roundPutRequestBody)
    {
        var roundToUpdate = _repository.GetById(id);
        if (roundToUpdate == null) return NotFound();
        _mapper.Map(roundPutRequestBody, roundToUpdate);
        _unitOfWork.Commit();
        return NoContent();
    }

    [HttpPatch("{id}")]
    public ActionResult PatchRound(int id, JsonPatchDocument<RoundPostDto> roundPatchRequestBody)
    {
        Round roundFromDatabase = _repository.GetById(id);
        if (roundFromDatabase == null) return NotFound();

        var roundToPatch = _mapper.Map<RoundPostDto>(roundFromDatabase);

        roundPatchRequestBody.ApplyTo(roundToPatch, ModelState);

        if (!TryValidateModel(roundToPatch)) return ValidationProblem(ModelState);

        _mapper.Map(roundToPatch, roundFromDatabase);
        _unitOfWork.Commit();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteRound(int id)
    {
        var roundToDelete = _repository.GetById(id);
        if (roundToDelete == null) return NotFound();
        _repository.Delete(roundToDelete);
        _unitOfWork.Commit();
        return NoContent();
    }
}