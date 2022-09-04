using frich.Data.Interfaces;
using frich.Entities;

namespace frich.Data.Repositories;

public class ParticipantRoundsRepo : IParticipantRoundsRepo
{
    private readonly FrichDbContext _context;

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

    public IEnumerable<ParticipantRounds> GetRoundsByParticipantId(int participantId)
    {
        var participantRounds = _context.ParticipantsRounds.ToList();
        return participantRounds.FindAll(val => val.ParticipantId == participantId);
    }

    public IEnumerable<ParticipantRounds> GetRoundsById(int participantId, int roundId)
    {
        var participantRounds = _context.ParticipantsRounds.ToList();
        return participantRounds.FindAll(
            val => val.ParticipantId == participantId && val.RoundId == roundId
        );
    }
}