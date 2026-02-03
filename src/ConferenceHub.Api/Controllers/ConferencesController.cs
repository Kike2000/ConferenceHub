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
        public IActionResult GetConference([FromRoute] Guid conferenceId)
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult AddConference([FromBody] string conferenceRequest)
        {
            return Ok();
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
