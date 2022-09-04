using frich.Entities;

namespace frich.Data.Interfaces;

public interface IParticipantRoundsRepo
{
    public void Add(ParticipantRounds entityInstance);
    public void Delete(ParticipantRounds entityInstance);
    public IEnumerable<ParticipantRounds> GetAll();

    public IEnumerable<ParticipantRounds> GetRoundsById(int firstId, int secondId);
    public IEnumerable<ParticipantRounds> GetRoundsByParticipantId(int id);
}