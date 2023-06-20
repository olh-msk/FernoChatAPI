using FernoChatAPI.Models;
using FernoChatAPI.Repository;

namespace FernoChatAPI.Service
{
    public class ParticipantService
    {
        private readonly ParticipantRepository _participantRepository;

        public ParticipantService(ParticipantRepository participantRepository)
        {
            _participantRepository = participantRepository;
        }

        public List<Participant> GetAllParticipants()
        {
            return _participantRepository.GetAllParticipants();
        }

        public Participant GetParticipantById(int participantId)
        {
            return _participantRepository.GetParticipantById(participantId);
        }

        public void CreateParticipant(Participant participant)
        {
            _participantRepository.CreateParticipant(participant);
        }

        public void UpdateParticipant(Participant participant)
        {
            _participantRepository.UpdateParticipant(participant);
        }

        public void DeleteParticipant(int participantId)
        {
            _participantRepository.DeleteParticipant(participantId);
        }
    }
}
