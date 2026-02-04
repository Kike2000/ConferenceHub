using System.ComponentModel.DataAnnotations;

namespace ConferenceHub.Api.DTOs.Request
{
    public class CreateConferenceRequest
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public DateTimeOffset StartDate { get; set; }

        [Required]
        public DateTimeOffset EndDate { get; set; }
    }
}
