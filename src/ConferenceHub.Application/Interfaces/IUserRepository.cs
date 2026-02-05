using ConferenceHub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConferenceHub.Application.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> GetUsers();

        Task<User> GetUserByPublicId(Guid userPublicId);

        Task CreateUser(User user);

        Task<bool> UpdateUser(User user);

    }
}
