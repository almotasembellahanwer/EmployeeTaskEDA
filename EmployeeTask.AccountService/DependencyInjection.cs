using EmployeeTask.AccountService.Data;
using EmployeeTask.AccountService.Entities;
using EmployeeTask.AccountService.Repositories;
using EmployeeTask.AccountService.RepositoryContracts;
using EmployeeTask.AccountService.ServiceContracts;
using EmployeeTask.AccountService.Services;
using Mapster;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using SharedModels.DTO.GovernorateDTO;

namespace EmployeeTask.AccountService
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            string? connectionString = configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("Invalid connection string");
            services.AddDbContext<AccountDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });
            services.AddCors(options =>
            {
                options.AddPolicy("AllowBFF", builder =>
                    builder.WithOrigins("http://localhost:5078")
                           .AllowAnyMethod()
                           .AllowAnyHeader());
            });
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssemblies(typeof(Program).Assembly);
            });
            services.AddMassTransit(x =>
            {
                x.UsingRabbitMq();
            });

            //TypeAdapterConfig.GlobalSettings.Scan(typeof(Program).Assembly);
            //// Configuration for mapping from GovernorateAddRequest to Governorate
            //TypeAdapterConfig<GovernorateAddRequest, Governorate>.NewConfig()
            //    .Map(dest => dest.ArabicName, src => src.ArabicName)
            //    .Map(dest => dest.EnglishName, src => src.EnglishName);

            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IEmployeesService, EmployeesService>();

            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<IAddressesService, AddressesService>();

            services.AddScoped<IGovernorateRepository, GovernorateRepository>();
            services.AddScoped<IGovernoratesService, GovernoratesService>();
            services.AddControllers();

            services.AddSwaggerGen();

            return services;
        }
    }
}
