namespace frich.Data.Interfaces;

public interface IFrichRepo<TEntity>
{
    IEnumerable<TEntity> GetAll();
    TEntity GetById(int id);
    void Add(TEntity entityInstance);
    void Delete(TEntity entityInstance);
    void Update(TEntity entityInstance);
}