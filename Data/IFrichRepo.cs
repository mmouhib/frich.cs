using frich.Models;

namespace frich.Data;

public interface IFrichRepo
{
    IEnumerable<Person> GetAllPersons();
    Person GetPersonById(int id);
    void AddPerson(Person person);
    void DeletePerson(Person person);
    void EditPerson(Person person);
}