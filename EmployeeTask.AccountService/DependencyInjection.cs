using EmployeeTask.AccountService.Data;
using EmployeeTask.AccountService.Repositories;
using EmployeeTask.AccountService.RepositoryContracts;
using EmployeeTask.AccountService.ServiceContracts;
using EmployeeTask.AccountService.Services;
using MassTransit;
using Microsoft.EntityFrameworkCore;

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
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IEmployeesService, EmployeesService>();

            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<IAddressesService, AddressesService>();
            services.AddControllers();

            services.AddSwaggerGen();

            return services;
        }
    }
}
