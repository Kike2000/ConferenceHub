using ConferenceHub.Api.DTOs.Request;
using ConferenceHub.Api.DTOs.Response;
using ConferenceHub.Domain.Entities;

namespace ConferenceHub.Api.Mappings
{
    public static class ConferenceMappings
    {
        public static Conference ToDomain(this CreateConferenceRequest createConferenceRequest)
        {
            return new Conference 
            {
                Name = createConferenceRequest.Name,
                Description = createConferenceRequest.Description,
            };
        }

        public static Conference ToDomain(this UpdateConferenceRequest updateConferenceRequest) 
        {
            return new Conference
            {
                Name = updateConferenceRequest.Name,
                Description = updateConferenceRequest.Description,
                PublicId = updateConferenceRequest.ConferenceId
            };
        }
    }
}
