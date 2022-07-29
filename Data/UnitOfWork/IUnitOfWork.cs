namespace frich.Data.UnitOfWork;

//todo: not implemented!
public interface IUnitOfWork
{
    void Commit();
    void RejectChanges();
    void Dispose();
}
