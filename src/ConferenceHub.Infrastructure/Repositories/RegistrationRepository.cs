using ConferenceHub.Domain.Entities;
using ConferenceHub.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace ConferenceHub.Infrastructure.Repositories
{
    public class RegistrationRepository
    {
        private readonly ApplicationDbContext _context;
        public RegistrationRepository(ApplicationDbContext context)
        {
           _context = context;
        }

        public async Task CreateRegistration(Registration registration)
        {
            _context.Registration.Add(registration);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Registration>> GetRegistrations()
        {
            return await _context.Registration.ToListAsync();
        }
        
        public async Task<Registration> GetRegistrationByPublicId(Guid registrationPublicId)
        {
            return await _context.Registration.AsNoTracking().FirstOrDefaultAsync(p => p.PublicId == registrationPublicId);
        }

        public async Task<bool> UpdateRegistration(Registration registration)
        {
            _context.Registration.Update(registration);
            return await _context.SaveChangesAsync() > 0;
        }
        public async Task<bool> DeleteRegistration(Registration registration)
        {
            _context.Registration.Remove(registration);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
