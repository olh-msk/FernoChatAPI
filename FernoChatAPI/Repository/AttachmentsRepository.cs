using FernoChatAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FernoChatAPI.Repository
{
    public class AttachmentsRepository
    {
        private readonly DatabaseContext _dbContext;

        public AttachmentsRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<MessageAttachment> GetAllAttachments()
        {
            return _dbContext.Attachments.ToList();
        }

        public MessageAttachment GetAttachmentById(int attachmentId)
        {
            return _dbContext.Attachments.Find(attachmentId);
        }

        public void CreateAttachment(MessageAttachment attachment)
        {
            _dbContext.Attachments.Add(attachment);
            _dbContext.SaveChanges();
        }

        public void UpdateAttachment(MessageAttachment attachment)
        {
            _dbContext.Entry(attachment).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public void DeleteAttachment(int attachmentId)
        {
            var attachment = _dbContext.Attachments.Find(attachmentId);
            if (attachment != null)
            {
                _dbContext.Attachments.Remove(attachment);
                _dbContext.SaveChanges();
            }
        }
    }
}
