namespace ConferenceHub.Api.DTOs.Request
{
    public class UpdateUserRequest
    {
        public Guid UserId { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }
    }
}
