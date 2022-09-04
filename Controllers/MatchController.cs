using AutoMapper;
using frich.Data.Interfaces;
using frich.Data.UnitOfWork;
using frich.Dto;
using frich.Entities;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace frich.Controllers;

[Route("api/matches")]
[ApiController]
public class MatchController : ControllerBase
{
    private readonly IMatchRepo _repository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public MatchController(IMatchRepo repo, IUnitOfWork uow, IMapper mapper)
    {
        _repository = repo;
        _unitOfWork = uow;
        _mapper = mapper;
    }

    [HttpGet]
    public ActionResult<IEnumerable<MatchGetDto>> GetAllMatches()
    {
        var matches = _repository.GetAll();
        if (matches.Any()) return Ok(_mapper.Map<IEnumerable<MatchGetDto>>(matches));
        return NotFound();
    }


    [HttpGet("{id}", Name = "GetMatchById")]
    public ActionResult<MatchGetDto> GetMatchById(int id)
    {
        var matchToGet = _repository.GetById(id);
        if (matchToGet == null) return NotFound();
        return Ok(_mapper.Map<MatchGetDto>(matchToGet));
    }

    [HttpPost]
    public ActionResult<PersonGetDto> AddMatch(MatchPostDto baseMatch)
    {
        var person = _mapper.Map<Match>(baseMatch);
        _repository.Add(person);
        _unitOfWork.Commit();

        MatchGetDto matchToReturn = _mapper.Map<MatchGetDto>(person);
        return CreatedAtRoute(nameof(GetMatchById), new { id = matchToReturn.MatchId }, matchToReturn);
    }

    [HttpPut("{id}")]
    public ActionResult UpdateMatch(int id, MatchPostDto matchToUpdate)
    {
        var match = _repository.GetById(id);
        if (match == null) return NotFound();

        _mapper.Map(matchToUpdate, match);
        _unitOfWork.Commit();

        return NoContent();
    }

    [HttpPatch("{id}")]
    public ActionResult PatchPerson(int id, JsonPatchDocument<MatchPostDto> patchMatchData)
    {
        var matchResultFromRepo = _repository.GetById(id);
        if (matchResultFromRepo == null) return NotFound();

        var matchToPatch = _mapper.Map<MatchPostDto>(matchResultFromRepo);
        patchMatchData.ApplyTo(matchToPatch, ModelState);

        if (!TryValidateModel(matchToPatch)) return ValidationProblem(ModelState);

        _mapper.Map(matchToPatch, matchResultFromRepo);
        _unitOfWork.Commit();
        return NoContent();
    }

    [HttpDelete]
    public ActionResult DeleteMatch(int id)
    {
        var matchToDelete = _repository.GetById(id);
        if (matchToDelete == null) return NotFound();
        _repository.Delete(matchToDelete);
        _unitOfWork.Commit();
        return NoContent();
    }
}