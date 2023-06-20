using FernoChatAPI.Models;
using FernoChatAPI.Service;
using Microsoft.AspNetCore.Mvc;

namespace FernoChatAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttachmentsController : ControllerBase
    {
        private readonly AttachmentsService _attachmentsService;

        public AttachmentsController(AttachmentsService attachmentsService)
        {
            _attachmentsService = attachmentsService;
        }

        // GET: api/attachments
        [HttpGet]
        public ActionResult<List<MessageAttachment>> GetAllAttachments()
        {
            var attachments = _attachmentsService.GetAllAttachments();
            return Ok(attachments);
        }

        // GET: api/attachments/{attachmentId}
        [HttpGet("{attachmentId}")]
        public ActionResult<MessageAttachment> GetAttachmentById(int attachmentId)
        {
            var attachment = _attachmentsService.GetAttachmentById(attachmentId);
            if (attachment == null)
            {
                return NotFound();
            }
            return Ok(attachment);
        }

        // POST: api/attachments
        [HttpPost]
        public IActionResult CreateAttachment([FromBody] MessageAttachment attachment)
        {
            _attachmentsService.CreateAttachment(attachment);
            return Ok();
        }

        // PUT: api/attachments/{attachmentId}
        [HttpPut("{attachmentId}")]
        public IActionResult UpdateAttachment(int attachmentId, [FromBody] MessageAttachment attachment)
        {
            if (attachmentId != attachment.AttachmentId)
            {
                return BadRequest();
            }
            _attachmentsService.UpdateAttachment(attachment);
            return Ok();
        }

        // DELETE: api/attachments/{attachmentId}
        [HttpDelete("{attachmentId}")]
        public IActionResult DeleteAttachment(int attachmentId)
        {
            _attachmentsService.DeleteAttachment(attachmentId);
            return Ok();
        }
    }
}
