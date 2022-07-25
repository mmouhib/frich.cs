namespace frich.Data;

public interface IFrichRepo<TEntity>
{
    IEnumerable<TEntity> GetAllPersons();
    TEntity GetPersonById(int id);
    void AddPerson(TEntity entityInstance);
    void DeletePerson(TEntity entityInstance);
    void EditPerson(TEntity entityInstance);
}