using frich.Data.Interfaces;

namespace frich.Data.UnitOfWork;

public interface IUnitOfWork : IDisposable
{
    IPersonRepo PersonRepository { get; set; }
    int Commit();
    void RejectChanges();
}
