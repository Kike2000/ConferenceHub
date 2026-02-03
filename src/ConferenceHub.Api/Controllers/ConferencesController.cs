using ConferenceHub.Api.DTOs.Request;
using ConferenceHub.Api.DTOs.Response;
using ConferenceHub.Api.Mappings;
using ConferenceHub.Application.Services;
using ConferenceHub.Domain.Entities;
using Microsoft.AspNetCore.Http;
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
            return Ok(_conferenceService.GetConferences());
        }

        [HttpGet("{conferenceId:guid}")]
        public IActionResult GetConferenceById([FromRoute] Guid conferenceId)
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
        public IActionResult UpdateConference([FromBody]string updateConferenceRequest)
        {
            return Ok();
        }

        [HttpDelete]
        public IActionResult RemoveConference([FromBody] Guid conferenceId)
        {
            return Ok();
        }
    }
}
