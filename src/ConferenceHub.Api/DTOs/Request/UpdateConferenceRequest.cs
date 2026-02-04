namespace ConferenceHub.Api.DTOs.Request
{
    public class UpdateConferenceRequest
    {
        public Guid ConferenceId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
