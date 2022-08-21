using frich.Data.Interfaces;
using frich.Entities;

namespace frich.Data.Repositories;

public class RoundRepo : IRoundRepo
{
    private readonly FrichDbContext _context;

    public RoundRepo(FrichDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Round> GetAll()
    {
        return _context.Rounds.ToList();
    }

    public Round GetById(int id)
    {
        return _context.Rounds.FirstOrDefault(round => round.RoundId == id);
    }

    public void Add(Round round)
    {
        if (round == null) throw new ArgumentNullException(nameof(round));

        _context.Add(round);
    }

    public void Delete(Round entityInstance)
    {
        if (entityInstance == null) throw new ArgumentNullException(nameof(entityInstance));

        _context.Rounds.Remove(entityInstance);
    }

    public void Update(Round entityInstance)
    {
    }
}