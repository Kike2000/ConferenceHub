using ConferenceHub.Api.DTOs.Request;
using ConferenceHub.Domain.Entities;

namespace ConferenceHub.Api.Mappings
{
    public static class RegistrationMappings
    {
        public static Registration ToDomain(this CreateRegistrationRequest createRegistrationRequest)
        {
            return new Registration
            { 
                ConferencePublicId = createRegistrationRequest.ConferencePublicId,
                ParticipantPublicId = createRegistrationRequest.ParticipantPublicId
            };
        }

        public static Registration ToDomain(this UpdateRegistrationRequest updateRegistrationRequest)
        {
            return new Registration
            {
                PublicId = updateRegistrationRequest.RegistrationId,
                ConferencePublicId = updateRegistrationRequest.ConferenceId,
                Attendance = updateRegistrationRequest.Attendance,
                ParticipantPublicId = updateRegistrationRequest.ParticipantId
            };
        }
    }
}
