using AutoMapper;
using frich.Data.Interfaces;
using frich.DataTransferObjects.PersonDto;
using frich.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Design;

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

        if (persons.Any()) return Ok(_mapper.Map<IEnumerable<PersonGetDto>>(persons));

        // 'NotFound' and 'Ok' methods are coming from parent (base) class ControllerBase
        return NotFound();
    }

    [HttpGet("{id}", Name = "GetPersonById")]
    public ActionResult<PersonGetDto> GetPersonById(int id)
    {
        var wantedPerson = _repository.GetById(id);

        if (wantedPerson != null) return _mapper.Map<PersonGetDto>(wantedPerson);

        return NotFound();
    }

    [HttpPost]
    public ActionResult<PersonGetDto> AddPerson(PersonPostDto basePerson)
    {
        Person mappedPerson = _mapper.Map<Person>(basePerson);
        _repository.Add(mappedPerson);
        _repository.SaveMigrations();

        PersonGetDto getResult = _mapper.Map<PersonGetDto>(mappedPerson);

        // CreatedAtRoute generates the request URI after making a POST request.
        return CreatedAtRoute(nameof(GetPersonById), new { id = getResult.PersonId }, getResult);
    }


    [HttpPut("{id}")]
    public ActionResult UpdatePerson(int id, PersonUpdateDto personToUpdate)
    {

        // Checks if the data sent in the request exists in the database before changing it.
        if (personToUpdate == null) return NotFound();

        var personResultFromRepo = _repository.GetById(id);

        // Here we don't use the generic Map method because the source and the destination 
        // (personToUpdate, personResultFromRepo) both contain data, but when using the generic form,
        // the variable inside the generic is new and will contain the new data.
        _mapper.Map(personToUpdate, personResultFromRepo);

        // Optional: this call is only made to follow conventions, and it does nothing,
        // the update is done in the Mapping in the previous line.
        _repository.Update(personResultFromRepo);

        _repository.SaveMigrations();

        return NoContent();
    }
}