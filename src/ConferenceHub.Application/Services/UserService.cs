using ConferenceHub.Application.Interfaces;
using ConferenceHub.Domain.Entities;


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

        public async Task<Guid> CreateUser(User user)
        {
            user.PublicId = Guid.NewGuid();
            await _userRepository.CreateUser(user);

            return user.PublicId;
        }

        public async Task<bool> UpdateUser(User user)
        {
            var userEntity = await _userRepository.GetUserByPublicId(user.PublicId);
            if (userEntity == null)
            {
                return false;
            }

            userEntity.Name = user.Name;
            userEntity.Email = user.Email;
            var result = await _userRepository.UpdateUser(userEntity);

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
