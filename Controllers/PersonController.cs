using AutoMapper;
using frich.Data.Interfaces;
using frich.DataTransferObjects.PersonDto;
using frich.Models;
using Microsoft.AspNetCore.Mvc;

namespace frich.Controllers;

[Route("api/persons")]
[ApiController]
public class PersonController : ControllerBase
{
    private readonly IPersonRepo _repository;
    private readonly IMapper _mapper;

    public PersonController(IPersonRepo repo, IMapper mapper)
    {
        _repository = repo;
        _mapper = mapper;
    }

    [HttpGet]
    public ActionResult<IEnumerable<PersonGetDto>> GetAllPlayers()
    {
        var persons = _repository.GetAll();

        if (persons.Any())
        {
            return Ok(_mapper.Map<IEnumerable<PersonGetDto>>(persons));
        }

        return NotFound();
    }

    [HttpGet("{id}")]
    public ActionResult<PersonGetDto> GetPersonById(int id)
    {
        var wantedPerson = _repository.GetById(id);

        if (wantedPerson != null)
        {
            return _mapper.Map<PersonGetDto>(wantedPerson);
        }

        return NotFound();
    }

    [HttpPost]
    public ActionResult<PersonGetDto> AddPerson(PersonPostDto person)
    {
        var mappedPerson = _mapper.Map<Person>(person);
        _repository.Add(mappedPerson);
        _repository.SaveMigrations();

        return Ok(mappedPerson);
    }
}