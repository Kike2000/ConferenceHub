namespace ConferenceHub.Api.DTOs.Request
{
    public class CreateRegistrationRequest
    {
        public Guid ParticipantPublicId { get; set; }

        public Guid ConferencePublicId { get; set; }
    }
}
