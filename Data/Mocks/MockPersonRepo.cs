using frich.Data.Interfaces;
using frich.Entities;

namespace frich.Data.Mocks;

public class MockPersonRepo : IPersonRepo
{
    public bool SaveMigrations()
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Person> GetAll()
    {
        return new List<Person>
        {
            new()
            {
                PersonId = 1,
                Username = "mouhib",
                Email = "m@m.m",
                Password = "12346"
            },

            new()
            {
                PersonId = 2,
                Username = "ouni",
                Email = "o.o@o",
                Password = "145236"
            }
        };
    }

    public Person GetById(int id)
    {
        return new Person
        {
            PersonId = 1,
            Username = "mouhib",
            Email = "aaa",
            Password = ""
        };
    }

    public void Add(Person person)
    {
        throw new NotImplementedException();
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