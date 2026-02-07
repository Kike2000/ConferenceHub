namespace ConferenceHub.Api.DTOs.Request
{
    public class UpdateRegistrationRequest
    {

        public Guid RegistrationId { get; set; }

        public Guid ParticipantId { get; set; }

        public Guid ConferenceId { get; set; }

        public bool Attendance { get; set; }
    }
}
