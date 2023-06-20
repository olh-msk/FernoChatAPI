using FernoChatAPI.Models;
using FernoChatAPI.Repository;

namespace FernoChatAPI.Service
{
    public class AttachmentsService
    {
        private readonly AttachmentsRepository _attachmentsRepository;

        public AttachmentsService(AttachmentsRepository attachmentsRepository)
        {
            _attachmentsRepository = attachmentsRepository;
        }

        public List<MessageAttachment> GetAllAttachments()
        {
            return _attachmentsRepository.GetAllAttachments();
        }

        public MessageAttachment GetAttachmentById(int attachmentId)
        {
            return _attachmentsRepository.GetAttachmentById(attachmentId);
        }

        public void CreateAttachment(MessageAttachment attachment)
        {
            _attachmentsRepository.CreateAttachment(attachment);
        }

        public void UpdateAttachment(MessageAttachment attachment)
        {
            _attachmentsRepository.UpdateAttachment(attachment);
        }

        public void DeleteAttachment(int attachmentId)
        {
            _attachmentsRepository.DeleteAttachment(attachmentId);
        }
    }
}
