using FernoChatAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FernoChatAPI.Repository
{
    public class ConversationsRepository
    {
        private readonly DatabaseContext _dbContext;

        public ConversationsRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Conversation> GetAllConversations()
        {
            return _dbContext.Conversations.Include(c => c.CreatedByUser).ToList();
        }

        public Conversation GetConversationById(int conversationId)
        {
            return _dbContext.Conversations.Include(c => c.CreatedByUser).FirstOrDefault(c => c.ConversationId == conversationId);
        }

        public void CreateConversation(Conversation conversation)
        {
            _dbContext.Conversations.Add(conversation);
            _dbContext.SaveChanges();
        }

        public void UpdateConversation(Conversation conversation)
        {
            _dbContext.Conversations.Update(conversation);
            _dbContext.SaveChanges();
        }

        public void DeleteConversation(int conversationId)
        {
            var conversation = _dbContext.Conversations.FirstOrDefault(c => c.ConversationId == conversationId);
            if (conversation != null)
            {
                _dbContext.Conversations.Remove(conversation);
                _dbContext.SaveChanges();
            }
        }
    }
}
