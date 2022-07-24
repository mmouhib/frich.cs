using frich.Data;
using frich.Models;
using Microsoft.AspNetCore.Mvc;

namespace frich.Controllers;

[Route("api/persons")]
[ApiController]
public class PersonController : ControllerBase
{
    private readonly IFrichRepo _repository;

    public PersonController(IFrichRepo repo)
    {
        _repository = repo;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Person>> GetAllPlayers()
    {
        return Ok(_repository.GetAllPersons());
    }
}