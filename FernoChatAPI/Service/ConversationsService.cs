using FernoChatAPI.Models;
using FernoChatAPI.Repository;

namespace FernoChatAPI.Service
{
    public class ConversationsService
    {
        private readonly ConversationsRepository _conversationsRepository;

        public ConversationsService(ConversationsRepository conversationsRepository)
        {
            _conversationsRepository = conversationsRepository;
        }

        public List<Conversation> GetAllConversations()
        {
            return _conversationsRepository.GetAllConversations();
        }

        public Conversation GetConversationById(int conversationId)
        {
            return _conversationsRepository.GetConversationById(conversationId);
        }

        public void CreateConversation(Conversation conversation)
        {
            _conversationsRepository.CreateConversation(conversation);
        }

        public void UpdateConversation(Conversation conversation)
        {
            _conversationsRepository.UpdateConversation(conversation);
        }

        public void DeleteConversation(int conversationId)
        {
            _conversationsRepository.DeleteConversation(conversationId);
        }
    }
}
