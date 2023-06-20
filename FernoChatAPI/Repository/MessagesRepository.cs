using FernoChatAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FernoChatAPI.Repository
{
    public class MessagesRepository
    {
        private readonly DatabaseContext _dbContext;

        public MessagesRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Message> GetAllMessages()
        {
            return _dbContext.Messages.ToList();
        }

        public Message GetMessageById(int messageId)
        {
            return _dbContext.Messages.Find(messageId);
        }

        public void CreateMessage(Message message)
        {
            _dbContext.Messages.Add(message);
            _dbContext.SaveChanges();
        }

        public void UpdateMessage(Message message)
        {
            _dbContext.Entry(message).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public void DeleteMessage(int messageId)
        {
            var message = _dbContext.Messages.Find(messageId);
            if (message != null)
            {
                _dbContext.Messages.Remove(message);
                _dbContext.SaveChanges();
            }
        }
    }
}
