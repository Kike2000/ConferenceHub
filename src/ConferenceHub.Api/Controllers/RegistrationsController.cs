using ConferenceHub.Api.DTOs.Request;
using ConferenceHub.Api.Mappings;
using ConferenceHub.Application.Services;
using ConferenceHub.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ConferenceHub.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegistrationsController : ControllerBase
    {
        private readonly RegistrationService _registrationService;
        public RegistrationsController(RegistrationService registrationService)
        {
            _registrationService = registrationService;   
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Registration>>> GetRegistrations()
        {
            return Ok(await _registrationService.GetRegistrations());
        }

        [HttpGet("{registrationId:guid}")]
        public IActionResult GetRegistrationById(
            [FromRoute] Guid registrationId)
        {
            return Ok(_registrationService.GetRegistrationByPublicId(registrationId));
        }

        [HttpPost]
        public async Task<IActionResult> Create(
            [FromBody] CreateRegistrationRequest request)
        {
            var registration = request.ToDomain();
            var id = await _registrationService.CreateRegistration(registration);

            return Ok(id);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateRegistration(
            [FromBody] UpdateRegistrationRequest updateRegistrationRequest)
        {
            await _registrationService.UpdateRegistration(updateRegistrationRequest.ToDomain());
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveRegistration(
            [FromBody] Guid registrationId)
        {
            await _registrationService.DeleteRegistration(registrationId);
            return Ok();
        }
    }
}
