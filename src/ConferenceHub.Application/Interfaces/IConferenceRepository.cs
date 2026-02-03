using ConferenceHub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConferenceHub.Application.Interfaces
{
    public interface IConferenceRepository
    {
        Task<Conference> GetConferenceByPublicId(Guid conferencePublicId);

        Task<List<Conference>> GetConferences();

        Task CreateConference(Conference conference);
    }
}
