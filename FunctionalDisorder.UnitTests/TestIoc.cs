using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
using Domain.Repository_interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence;
using Persistence.Repositories;
using Services.Abstractions.Service_interfaces;
using Services.Mappers;
using Services.Services;
using System;
using System.Collections.Generic;

namespace FunctionalDisorder.Logic.UnitTests.Setup
{
    public class TestIoc
    {
        public IServiceProvider ServiceProvider { get; set; }
        public IMapper Mapper { get; set; }
        public IConfiguration Configuration { get; set; }

        public static TestIoc Create()
        {
            var services = InitServices();

            var serviceProvider = services.BuildServiceProvider();

            return new TestIoc
            {
                Mapper = serviceProvider.GetRequiredService<IMapper>(),
                ServiceProvider = serviceProvider
            };
        }

        private static ServiceCollection InitServices()
        {
            var services = new ServiceCollection();

            services.AddDbContext<ApplicationContext>(o =>
                o.UseInMemoryDatabase(Guid.NewGuid().ToString()));

            RegisterConfiguration(services);

            services.AddScoped<IServiceManager, ServiceManager>();
            services.AddScoped<IRepositoryManager, RepositoryManager>();

            services.AddSingleton(provider => new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ApiToEntityProfile());
                cfg.AddProfile(new EntityToViewProfile());
                cfg.AddExpressionMapping();
                cfg.AllowNullCollections = true;
            }).CreateMapper());

            return services;
        }

        private static void RegisterConfiguration(IServiceCollection services)
        {
            var myConfiguration = new Dictionary<string, string>
            {
                {"EncryptionSecretKey", "abcdefghijklmnmoabcdefghijklmnmo"}
            };

            IConfiguration builder = new ConfigurationBuilder().AddInMemoryCollection(myConfiguration).Build();

            services.AddSingleton(builder);
        }
    }
}
