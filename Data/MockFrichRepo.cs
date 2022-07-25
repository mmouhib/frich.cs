using frich.Models;

namespace frich.Data;

public class MockFrichRepo : IFrichRepo<Person>
{
    public IEnumerable<Person> GetAllPersons()
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

    public Person GetPersonById(int id)
    {
        return new Person
        {
            PersonId = 1,
            Username = "mouhib",
            Email = "aaa",
            Password = ""
        };
    }

    public void AddPerson(Person person)
    {
        throw new NotImplementedException();
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