using ConferenceHub.Api.DTOs.Request;
using ConferenceHub.Api.Mappings;
using ConferenceHub.Application.Services;
using ConferenceHub.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ConferenceHub.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConferencesController : ControllerBase
    {
        private readonly ConferenceService _conferenceService;
        public ConferencesController(ConferenceService conferenceService)
        {            
            _conferenceService = conferenceService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Conference>>> GetConferences()
        {
            return Ok(await _conferenceService.GetConferences());
        }

        [HttpGet("{conferenceId:guid}")]
        public IActionResult GetConferenceById(
            [FromRoute] Guid conferenceId)
        {
            return Ok(_conferenceService.GetConferenceByPublicId(conferenceId));
        }

        [HttpPost]
        public async Task<IActionResult> Create(
            [FromBody] CreateConferenceRequest request)
        {
            var conference = request.ToDomain();
            var id = await _conferenceService.CreateConference(conference);

            return Ok(id);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateConference(
            [FromBody] UpdateConferenceRequest updateConferenceRequest)
        {
            await _conferenceService.UpdateConference(updateConferenceRequest.ToDomain());
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveConference(
            [FromBody] Guid conferenceId)
        {
            await _conferenceService.DeleteConference(conferenceId);
            return Ok();
        }
    }
}
