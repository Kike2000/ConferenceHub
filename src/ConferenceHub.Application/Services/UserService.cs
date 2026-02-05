using ConferenceHub.Application.Interfaces;
using ConferenceHub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConferenceHub.Application.Services
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await _userRepository.GetUsers();
        }

        public async Task<User> GetUserByPublicId(Guid userPublicId)
        {
            return await _userRepository.GetUserByPublicId(userPublicId);
        }

        public async Task<bool> UpdateUser(User user)
        {
            var userEntity = await _userRepository.GetUserByPublicId(user.PublicId);
            if (userEntity == null)
            {
                return false;
            }

            var result = await _userRepository.UpdateUser(user);
            return result;
        }

        public async Task<bool> DeleteUser(Guid userPublicId)
        {
            var userEntity = await _userRepository.GetUserByPublicId(userPublicId);
            if (userEntity == null)
            {
                return false;
            }
            
            userEntity.IsActive = false;
            var result = await _userRepository.UpdateUser(userEntity);

            return result;

        }
    }
}
