using ConferenceHub.Application.Interfaces;
using ConferenceHub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConferenceHub.Application.Services
{
    public class RegistrationService
    {
        private readonly IRegistrationRepository _registrationRepository;
        public RegistrationService(IRegistrationRepository registrationRepository)
        {
            _registrationRepository = registrationRepository;
        }

        public async Task<List<Registration>> GetRegistrations()
        {
            return await _registrationRepository.GetRegistrations();
        }

        public async Task<Registration> GetRegistrationByPublicId(Guid registrationPublicId)
        {
            return await _registrationRepository.GetRegistrationByPublicId(registrationPublicId);
        }

        public async Task<Guid> CreateRegistration(Registration registration)
        {
            registration.PublicId = Guid.NewGuid();
            registration.RegistrationTime = DateTime.Now;
            await _registrationRepository.CreateRegistration(registration);

            return registration.PublicId;
        }

        public async Task<bool> UpdateRegistration(Registration registration)
        {
            var registrationEntity = await _registrationRepository.GetRegistrationByPublicId(registration.PublicId);
            if (registrationEntity == null)
            {
                return false;
            }
            registration.RegistrationId = registrationEntity.RegistrationId;
            registration.UpdatedAt = DateTime.Now;

            var result = await _registrationRepository.UpdateRegistration(registration);
            return result;
        }

        public async Task<bool> DeleteRegistration(Guid registrationPublicId)
        {
            var registrationEntity = await _registrationRepository.GetRegistrationByPublicId(registrationPublicId);
            if (registrationEntity == null)
            {
                return false;
            }

            var result = await _registrationRepository.DeleteRegistration(registrationEntity);
            return result;
        }
    }
}
