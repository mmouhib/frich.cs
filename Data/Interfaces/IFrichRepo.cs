namespace frich.Data;

public interface IFrichRepo<TEntity>
{
    bool SaveMigrations();
    IEnumerable<TEntity> GetAll();
    TEntity GetById(int id);
    void Add(TEntity entityInstance);
    void Delete(TEntity entityInstance);
    void Edit(TEntity entityInstance);
}