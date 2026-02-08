using ConferenceHub.Application.Interfaces;
using ConferenceHub.Application.Services;
using ConferenceHub.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System;

namespace ConferenceHub.Api.DependencyInjection
{
    public static class InfrastructureServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IConferenceRepository, ConferenceRepository>();
            services.AddScoped<IRegistrationRepository, RegistrationRepository>();
            return services;
        }
    }
}
