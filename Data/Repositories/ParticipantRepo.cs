using frich.Data.Interfaces;
using frich.Dto;
using frich.Entities;

namespace frich.Data.Repositories;

public class ParticipantRepo : IParticipantRepo
{
    public readonly FrichDbContext _context;

    public ParticipantRepo(FrichDbContext context)
    {
        _context = context;
    }

    public void Add(Participant entityInstance)
    {
        if (entityInstance == null) throw new ArgumentNullException(nameof(entityInstance));
        _context.Add(entityInstance);
    }

    public void Delete(Participant entityInstance)
    {
        _context.Remove(entityInstance);
    }

    public IEnumerable<Participant> GetAll()
    {
        return _context.Participants.ToList();
    }

    public Participant GetById(int id)
    {
        return _context.Participants.FirstOrDefault(participant => participant.ParticipantId == id);
    }

    public void Update(Participant entityInstance)
    {
    }
}