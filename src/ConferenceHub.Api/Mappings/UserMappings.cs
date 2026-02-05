using ConferenceHub.Api.DTOs.Request;
using ConferenceHub.Domain.Entities;

namespace ConferenceHub.Api.Mappings
{
    public static class UserMappings
    {
        public static User ToDomain(this CreateUserRequest createUserRequest)
        {
            return new User
            {
                Name = createUserRequest.Name,
                Email = createUserRequest.Email,
            };
        }

        public static User ToDomain(this UpdateUserRequest updateUserRequest)
        {
            return new User
            {
                PublicId = updateUserRequest.UserId,
                Name = updateUserRequest.Name,
                Email = updateUserRequest.Email,
            };
        }
    }
}
