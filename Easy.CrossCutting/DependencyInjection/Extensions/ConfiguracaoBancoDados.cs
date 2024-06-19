﻿using Easy.Domain.Entities.User;
using Easy.InfrastructureData.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Easy.CrossCutting.DependencyInjection.Extensions
{
    public static class ConfiguracaoBancoDados
    {
        public static void Configurar(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            MySqlServerVersion serverVersion = new MySqlServerVersion(new Version(8, 0, 29));
            
            string? connectionString = configuration.GetConnectionString("DefaultConnection");
           
            //var serverVersionAutoDetec = ServerVersion.AutoDetect(connectionString);
            
            if (connectionString == "desenvolvimento")
            {
                string? desenvolvimento = "Server=localhost;Port=3306;DataBase=desenvolvimento;Uid=root;password=010203;";
                serviceCollection.
                AddDbContext<MyContext>(options =>
                             options.UseMySql(desenvolvimento, serverVersion));


            }

            serviceCollection.AddIdentityCore<UserEntity>()
           .AddRoles<RoleEntity>()
           .AddRoleManager<RoleManager<RoleEntity>>()
           .AddSignInManager<SignInManager<UserEntity>>()
           .AddRoleValidator<RoleValidator<RoleEntity>>()
           .AddEntityFrameworkStores<MyContext>()
           .AddDefaultTokenProviders();
        }
    }
}