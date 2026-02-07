using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConferenceHub.Domain.Entities
{
    public partial class Registration
    {
        public int RegistrationId { get; set; }

        public Guid PublicId { get; set; }

        public Guid ParticipantPublicId { get; set; }

        public Guid ConferencePublicId { get; set; }

        public DateTime? RegistrationTime { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public bool Attendance { get; set; } = true;
    }

}
