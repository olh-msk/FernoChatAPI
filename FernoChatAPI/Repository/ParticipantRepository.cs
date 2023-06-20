using FernoChatAPI.Models;

namespace FernoChatAPI.Repository
{
    public class ParticipantRepository
    {
        private readonly DatabaseContext _dbContext;

        public ParticipantRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Participant> GetAllParticipants()
        {
            return _dbContext.Participants.ToList();
        }

        public Participant GetParticipantById(int participantId)
        {
            return _dbContext.Participants.FirstOrDefault(p => p.ParticipantId == participantId);
        }

        public void CreateParticipant(Participant participant)
        {
            _dbContext.Participants.Add(participant);
            _dbContext.SaveChanges();
        }

        public void UpdateParticipant(Participant participant)
        {
            _dbContext.Participants.Update(participant);
            _dbContext.SaveChanges();
        }

        public void DeleteParticipant(int participantId)
        {
            var participant = _dbContext.Participants.FirstOrDefault(p => p.ParticipantId == participantId);
            if (participant != null)
            {
                _dbContext.Participants.Remove(participant);
                _dbContext.SaveChanges();
            }
        }
    }
}
