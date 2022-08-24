using frich.Data.Interfaces;
using frich.Entities;

namespace frich.Data.Repositories;

public class MatchRepo : IMatchRepo
{
    private readonly FrichDbContext _context;

    public MatchRepo(FrichDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Match> GetAll()
    {
        return _context.Matches.ToList();
    }

    public Match GetById(int id)
    {
        return _context.Matches.FirstOrDefault(match => match.MatchId == id);
    }

    public void Add(Match match)
    {
        if (match == null) throw new ArgumentNullException(nameof(match));

        _context.Add(match);
    }

    public void Delete(Match match)
    {
        if (match == null) throw new ArgumentNullException(nameof(match));

        _context.Matches.Remove(match);
    }

    public void Update(Match match)
    {
    }
}