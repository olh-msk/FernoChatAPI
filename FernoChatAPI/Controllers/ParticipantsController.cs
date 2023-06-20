using FernoChatAPI.Models;
using FernoChatAPI.Service;
using Microsoft.AspNetCore.Mvc;

namespace FernoChatAPI.Controllers
{
    [ApiController]
    [Route("api/participants")]
    public class ParticipantsController : ControllerBase
    {
        private readonly ParticipantService _participantService;

        public ParticipantsController(ParticipantService participantService)
        {
            _participantService = participantService;
        }

        [HttpGet]
        public ActionResult<List<Participant>> GetAllParticipants()
        {
            var participants = _participantService.GetAllParticipants();
            return Ok(participants);
        }

        [HttpGet("{participantId}")]
        public ActionResult<Participant> GetParticipantById(int participantId)
        {
            var participant = _participantService.GetParticipantById(participantId);
            if (participant == null)
            {
                return NotFound();
            }
            return Ok(participant);
        }

        [HttpPost]
        public ActionResult CreateParticipant(Participant participant)
        {
            _participantService.CreateParticipant(participant);
            return Ok();
        }

        [HttpPut("{participantId}")]
        public ActionResult UpdateParticipant(int participantId, Participant participant)
        {
            if (participantId != participant.ParticipantId)
            {
                return BadRequest();
            }
            _participantService.UpdateParticipant(participant);
            return Ok();
        }

        [HttpDelete("{participantId}")]
        public ActionResult DeleteParticipant(int participantId)
        {
            _participantService.DeleteParticipant(participantId);
            return Ok();
        }
    }
}
