using frich.Data.Interfaces;

namespace frich.Data.UnitOfWork;

public interface IUnitOfWork : IDisposable
{
    int Commit();
    void RejectChanges();
}