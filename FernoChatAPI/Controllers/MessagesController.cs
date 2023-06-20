using FernoChatAPI.Models;
using FernoChatAPI.Service;
using Microsoft.AspNetCore.Mvc;

namespace FernoChatAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly MessagesService _messagesService;

        public MessagesController(MessagesService messagesService)
        {
            _messagesService = messagesService;
        }

        [HttpGet]
        public ActionResult<List<Message>> GetAllMessages()
        {
            var messages = _messagesService.GetAllMessages();
            return Ok(messages);
        }

        [HttpGet("{id}")]
        public ActionResult<Message> GetMessageById(int id)
        {
            var message = _messagesService.GetMessageById(id);
            if (message != null)
            {
                return Ok(message);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult CreateMessage([FromBody] Message message)
        {
            if (message == null)
            {
                return BadRequest();
            }

            message.CreatedAt = DateTime.Now;

            _messagesService.CreateMessage(message);

            return CreatedAtAction(nameof(GetMessageById), new { id = message.MessageId }, message);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateMessage(int id, [FromBody] Message messageData)
        {
            var existingMessage = _messagesService.GetMessageById(id);
            if (existingMessage == null)
            {
                return NotFound();
            }

            existingMessage.MessageContent = messageData.MessageContent;

            _messagesService.UpdateMessage(existingMessage);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMessage(int id)
        {
            var existingMessage = _messagesService.GetMessageById(id);
            if (existingMessage == null)
            {
                return NotFound();
            }

            _messagesService.DeleteMessage(id);

            return NoContent();
        }
    }
}
