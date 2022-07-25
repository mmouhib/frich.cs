using AutoMapper;
using frich.Data;
using frich.DataTransferObjects.PersonDtos;
using frich.Models;
using Microsoft.AspNetCore.Mvc;

namespace frich.Controllers;

[Route("api/persons")]
[ApiController]
public class PersonController : ControllerBase
{
    private readonly IFrichRepo<Person> _repository;
    private readonly IMapper _mapper;

    public PersonController(IFrichRepo<Person> repo, IMapper mapper)
    {
        _repository = repo;
        _mapper = mapper;
    }

    [HttpGet]
    public ActionResult<IEnumerable<PersonGetDto>> GetAllPlayers()
    {
        //todo: treat no persons case
        var persons = _repository.GetAllPersons();
        return Ok(_mapper.Map<IEnumerable<PersonGetDto>>(persons));
    }

    [HttpGet("{id}")]
    public ActionResult<PersonGetDto> GetPersonById(int id)
    {
        var wantedPerson = _repository.GetPersonById(id);

        if (wantedPerson != null)
        {
            return _mapper.Map<PersonGetDto>(wantedPerson);
        }

        return NotFound();
    }
}