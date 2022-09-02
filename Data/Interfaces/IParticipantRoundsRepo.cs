using frich.Entities;

namespace frich.Data.Interfaces;

public interface IParticipantRoundsRepo : IFrichBaseRepo<ParticipantRounds>
{
    ParticipantRounds GetById(int id, int id2);
    ParticipantRounds GetByParticipantId(int id);
    ParticipantRounds GetByRoundId(int id);
}
