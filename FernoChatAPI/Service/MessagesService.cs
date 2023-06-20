using FernoChatAPI.Models;
using FernoChatAPI.Repository;

namespace FernoChatAPI.Service
{
    public class MessagesService
    {
        private readonly MessagesRepository _messagesRepository;

        public MessagesService(MessagesRepository messagesRepository)
        {
            _messagesRepository = messagesRepository;
        }

        public List<Message> GetAllMessages()
        {
            return _messagesRepository.GetAllMessages();
        }

        public Message GetMessageById(int messageId)
        {
            return _messagesRepository.GetMessageById(messageId);
        }

        public void CreateMessage(Message message)
        {
            _messagesRepository.CreateMessage(message);
        }

        public void UpdateMessage(Message message)
        {
            _messagesRepository.UpdateMessage(message);
        }

        public void DeleteMessage(int messageId)
        {
            _messagesRepository.DeleteMessage(messageId);
        }
    }
}
