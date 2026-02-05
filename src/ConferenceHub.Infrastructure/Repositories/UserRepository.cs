using ConferenceHub.Application.Interfaces;
using ConferenceHub.Domain.Entities;
using ConferenceHub.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace ConferenceHub.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateUser(User user)
        {
            _context.User.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task<List<User>> GetUsers()
        {
            return await _context.User.ToListAsync();
        }

        public async Task<User> GetUserByPublicId(Guid userPublicId)
        {
            return await _context.User.AsNoTracking().FirstOrDefaultAsync(p => p.PublicId == userPublicId);
        }

        public async Task<bool> UpdateUser(User user)
        {
            _context.User.Update(user);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}