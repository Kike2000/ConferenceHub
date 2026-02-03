using System.ComponentModel.DataAnnotations;

namespace ConferenceHub.Api.DTOs.Request
{
    public class CreateConferenceRequest
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
