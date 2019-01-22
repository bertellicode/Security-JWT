﻿using Microsoft.Extensions.DependencyInjection;
using Security.Application.Interfaces;
using Security.Application.Services;
using Security.Domain.Core.Interfaces;
using Security.Domain.Users.Interfaces.Repositories;
using Security.Domain.Users.Interfaces.Services;
using Security.Domain.Users.Services;
using Security.Infra.CrossCutting.JWT.Configurations;
using Security.Infra.CrossCutting.JWT.Interfaces;
using Security.Infra.Data.Repositories;
using Security.Infra.Data.UoW;

namespace Security.Infra.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {

            // Application
            services.AddScoped<IUserAppService, UserAppService>();

            // Services
            services.AddScoped<IUserService, UserService>();

            // Infra - Data
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            //services.AddScoped<SecurityContext>();
            services.AddScoped<IUserRepository, UserRepository>();

            // Infra - JWT
            services.AddScoped<ICredentialsConfiguration, CredentialsConfiguration>();
            services.AddScoped<ITokenConfiguration, TokenConfiguration>();

        }
    }
}