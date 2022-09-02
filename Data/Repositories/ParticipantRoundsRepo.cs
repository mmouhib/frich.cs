using frich.Data.Interfaces;
using frich.Entities;

namespace frich.Data.Repositories;

public class ParticipantRoundsRepo : IParticipantRoundsRepo
{
    private FrichDbContext _context;

    public ParticipantRoundsRepo(FrichDbContext context)
    {
        _context = context;
    }

    public void Add(ParticipantRounds entityInstance)
    {
        _context.Add(entityInstance);
    }

    public void Delete(ParticipantRounds entityInstance)
    {
        _context.Remove(entityInstance);
    }

    public IEnumerable<ParticipantRounds> GetAll()
    {
        return _context.ParticipantsRounds.ToList();
    }

    public ParticipantRounds GetById(int participantId, int roundId)
    {
        return _context.ParticipantsRounds.FirstOrDefault(data => data.ParticipantId == participantId && data.RoundId == roundId);
    }

    // this method is called like this because it is implemented from the
    // parent interface (IFrichBaseRepo) so it is identical to "GetByParticipantId".
    public ParticipantRounds GetById(int id)
    {
        return _context.ParticipantsRounds.FirstOrDefault(data => data.ParticipantId == id);
    }

    public ParticipantRounds GetByParticipantId(int id)
    {
        return GetById(id);
    }

    public ParticipantRounds GetByRoundId(int id)
    {
        return _context.ParticipantsRounds.FirstOrDefault(data => data.RoundId == id);
    }

    public void Update(ParticipantRounds entityInstance)
    {
    }
}
