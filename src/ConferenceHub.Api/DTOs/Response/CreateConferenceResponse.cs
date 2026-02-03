namespace ConferenceHub.Api.DTOs.Response
{
    public class CreateConferenceResponse
    {
        public Guid ConferenceId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
