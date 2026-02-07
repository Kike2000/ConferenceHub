using ConferenceHub.Application.Interfaces;
using ConferenceHub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConferenceHub.Application.Services
{
    public class ConferenceService
    {
        private readonly IConferenceRepository _conferenceRepository;

        public ConferenceService(IConferenceRepository conferenceRepository)
        {
            _conferenceRepository = conferenceRepository;
        }

        public async Task<List<Conference>> GetConferences()
        {
            return await _conferenceRepository.GetConferences();
        }

        public async Task<Conference> GetConferenceByPublicId(Guid conferencePublicId)
        {
            return await _conferenceRepository.GetConferenceByPublicId(conferencePublicId);
        }

        public async Task<Guid> CreateConference(Conference conference)
        {
            conference.PublicId = Guid.NewGuid();
            await _conferenceRepository.CreateConference(conference);

            return conference.PublicId;
        }

        public async Task<bool> UpdateConference(Conference conference)
        {
            var conferenceEntity = await _conferenceRepository.GetConferenceByPublicId(conference.PublicId);
            if (conferenceEntity == null)
            {
                return false;
            }
            conference.ConferenceId = conferenceEntity.ConferenceId;

            var result = await _conferenceRepository.UpdateConference(conference);
            return result;
        }

        public async Task<bool> DeleteConference(Guid conferencePublicId)
        {
            var conferenceEntity = await _conferenceRepository.GetConferenceByPublicId(conferencePublicId);
            if (conferenceEntity == null)
            {
                return false;
            }

            var result = await _conferenceRepository.DeleteConference(conferenceEntity);
            return result;
        }

    }
}
