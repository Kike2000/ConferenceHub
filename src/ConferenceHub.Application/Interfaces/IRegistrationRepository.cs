using ConferenceHub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConferenceHub.Application.Interfaces
{
    public interface IRegistrationRepository
    {
        Task CreateRegistration(Registration registration);

        Task<List<Registration>> GetRegistrations();

        Task<Registration> GetRegistrationByPublicId(Guid registrationPublicId);

        Task<bool> UpdateRegistration(Registration registration);

        Task<bool> DeleteRegistration(Registration registration);
    }
}
