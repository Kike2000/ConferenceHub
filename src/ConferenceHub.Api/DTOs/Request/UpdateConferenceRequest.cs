using System.ComponentModel.DataAnnotations;

namespace ConferenceHub.Api.DTOs.Request
{
    public class UpdateConferenceRequest
    {
        [Required]
        public Guid ConferenceId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTimeOffset StartDate { get; set; }
        
        public DateTimeOffset EndDate { get; set; }

    }
}
