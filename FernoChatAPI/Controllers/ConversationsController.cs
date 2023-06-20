using FernoChatAPI.Models;
using FernoChatAPI.Service;
using Microsoft.AspNetCore.Mvc;

namespace FernoChatAPI.Controllers
{
    [ApiController]
    [Route("api/conversations")]
    public class ConversationsController : ControllerBase
    {
        private readonly ConversationsService _conversationsService;

        public ConversationsController(ConversationsService conversationsService)
        {
            _conversationsService = conversationsService;
        }

        [HttpGet]
        public IActionResult GetAllConversations()
        {
            List<Conversation> conversations = _conversationsService.GetAllConversations();
            return Ok(conversations);
        }

        [HttpGet("{conversationId}")]
        public IActionResult GetConversationById(int conversationId)
        {
            Conversation conversation = _conversationsService.GetConversationById(conversationId);
            if (conversation == null)
            {
                return NotFound();
            }
            return Ok(conversation);
        }

        [HttpPost]
        public IActionResult CreateConversation(Conversation conversation)
        {
            conversation.CreatedAt = DateTime.Now;
            _conversationsService.CreateConversation(conversation);
            return CreatedAtAction(nameof(GetConversationById), new { conversationId = conversation.ConversationId }, conversation);
        }

        [HttpPut("{conversationId}")]
        public IActionResult UpdateConversation(int conversationId, Conversation conversation)
        {
            var existingConversation = _conversationsService.GetConversationById(conversationId);
            if (existingConversation == null)
            {
                return NotFound();
            }
            existingConversation.ConversationName = conversation.ConversationName;
            _conversationsService.UpdateConversation(existingConversation);
            return NoContent();
        }

        [HttpDelete("{conversationId}")]
        public IActionResult DeleteConversation(int conversationId)
        {
            var existingConversation = _conversationsService.GetConversationById(conversationId);
            if (existingConversation == null)
            {
                return NotFound();
            }
            _conversationsService.DeleteConversation(conversationId);
            return NoContent();
        }
    }
}
