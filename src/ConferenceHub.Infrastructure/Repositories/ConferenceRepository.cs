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


        public Task<Conference> GetConferenceByPublicId()
        {
            throw new NotImplementedException();
        }

        public async Task<List<Conference>> GetConferences()
        {
            var conferences = _context.Conference.ToList();
            return conferences;
        }
    }
}
