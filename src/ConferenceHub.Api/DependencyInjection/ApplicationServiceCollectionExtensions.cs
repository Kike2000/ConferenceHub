using ConferenceHub.Application.Interfaces;
using ConferenceHub.Application.Services;
using ConferenceHub.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System;

namespace ConferenceHub.Api.DependencyInjection
{
    public static class ApplicationServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<ConferenceService>();
            services.AddScoped<UserService>();
            services.AddScoped<RegistrationService>();

            return services;
        }
    }
}
