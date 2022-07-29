using frich.Models;
using frich.Data.Interfaces;

namespace frich.Data;

public class SqlFrichRepo : IPersonRepo
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

    public IEnumerable<Person> GetAll()
    {
        return _context.Persons.ToList();
    }

    public Person GetById(int id)
    {
        return _context.Persons.FirstOrDefault(person => person.PersonId == id);
    }

    public void Add(Person person)
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

    public void Delete(Person person)
    {
        throw new NotImplementedException();
    }

    public void Update(Person person)
    {
        throw new NotImplementedException();
    }
}