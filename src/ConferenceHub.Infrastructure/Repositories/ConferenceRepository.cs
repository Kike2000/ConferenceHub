using ConferenceHub.Application.Interfaces;
using ConferenceHub.Domain.Entities;
using ConferenceHub.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConferenceHub.Infrastructure.Repositories
{
    public class ConferenceRepository : IConferenceRepository
    {
        private readonly ApplicationDbContext _context;
        public ConferenceRepository(ApplicationDbContext context)
        {
            _context = context;            
        }

        public async Task<Conference> GetConferenceByPublicId(Guid conferencePublicId)
        {
            return await _context.Conference.AsNoTracking().FirstOrDefaultAsync(p => p.PublicId == conferencePublicId);
        }

        public async Task<List<Conference>> GetConferences()
        {
            return _context.Conference.ToList();
        }

        public async Task CreateConference(Conference conference)
        {
            _context.Conference.Add(conference);
            _context.SaveChanges();
        }

        public async Task<bool> UpdateConference(Conference conference)
        {
            _context.Conference.Update(conference);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteConference(Conference conference)
        {
            _context.Conference.Remove(conference);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
