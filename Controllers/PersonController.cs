using AutoMapper;
using FluentValidation.Results;
using frich.Data.Interfaces;
using frich.DataTransferObjects.PersonDto;
using frich.Entities;
using frich.Validators.PersonValidators;
using Microsoft.AspNetCore.JsonPatch;
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

        if (persons.Any()) return Ok(_mapper.Map<IEnumerable<PersonGetDto>>(persons));

        // 'NotFound' and 'Ok' methods are from parent class ControllerBase
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

        var validator = new PersonValidator();

        ValidationResult validationResult = validator.Validate(basePerson);

        // todo: validate the rest of the models and Dtos

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
        var personResultFromRepo = _repository.GetById(id);
        if (personResultFromRepo == null) return NotFound();

        // Here we don't use the generic Map method because the source (personToUpdate) and the 
        // destination (personResultFromRepo) both contain data, but when using the generic form,
        // the variable inside the generic is new and will contain the new data.
        _mapper.Map(personToUpdate, personResultFromRepo);

        // Optional: this call is only made to follow conventions, and it does nothing,
        // the update is done in the Mapping in the previous line.
        _repository.Update(personResultFromRepo);

        _repository.SaveMigrations();

        return NoContent();
    }

    [HttpPatch("{id}")]
    public ActionResult PatchPerson(int id, JsonPatchDocument<PersonUpdateDto> patchData)
    {
        var personResultFromRepo = _repository.GetById(id);
        if (personResultFromRepo == null) return NotFound();

        var personToPatch = _mapper.Map<PersonUpdateDto>(personResultFromRepo);

        patchData.ApplyTo(personToPatch, ModelState);

        if (!TryValidateModel(personToPatch)) return ValidationProblem(ModelState);

        _mapper.Map(personToPatch, personResultFromRepo);

        _repository.SaveMigrations();

        _repository.Update(personResultFromRepo);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public ActionResult DeletePerson(int id)
    {
        var personToDelete = _repository.GetById(id);
        if (personToDelete == null) return NotFound();

        _repository.Delete(personToDelete);
        _repository.SaveMigrations();


        return NoContent();
    }
}