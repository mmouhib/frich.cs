using frich.Models;

namespace frich.Data;

public class SqlFrichRepo : IFrichRepo<Person>
{
    private readonly FrichDbContext _context;

    public SqlFrichRepo(FrichDbContext context)
    {
        _context = context;
    }

    public bool SaveMigrations()
    {
        return _context.SaveChanges() >= 0;
    }

    public IEnumerable<Person> GetAllPersons()
    {
        return _context.Persons.ToList();
    }

    public Person GetPersonById(int id)
    {
        return _context.Persons.FirstOrDefault(person => person.PersonId == id);
    }

    public void AddPerson(Person person)
    {
        try
        {
            _context.Add(person);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public void DeletePerson(Person person)
    {
        throw new NotImplementedException();
    }

    public void EditPerson(Person person)
    {
        throw new NotImplementedException();
    }
}