using EmployeeTask.Aggregator.AddressConsumer;
using EmployeeTask.Aggregator.AreaConsumer;
using EmployeeTask.Aggregator.Data;
using EmployeeTask.Aggregator.DistrictConsumer;
using EmployeeTask.Aggregator.EmployeeConsumer;
using EmployeeTask.Aggregator.GovernorateConsumer;
using EmployeeTask.Aggregator.IRepositoryContracts;
using EmployeeTask.Aggregator.Repositories;
using EmployeeTask.Aggregator.ServiceContracts;
using EmployeeTask.Aggregator.Services;
using MassTransit;
using Microsoft.EntityFrameworkCore;

namespace EmployeeTask.Aggregator
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            string? connectionString = configuration.GetConnectionString("DefaultConnection")
                    ?? throw new InvalidOperationException("Invalid connection string");
            services.AddDbContext<AggregatorDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssemblies(typeof(Program).Assembly);
            });
            services.AddMassTransit(x =>
            {
                x.AddConsumers(typeof(Program).Assembly);

                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host("rabbitmq://localhost");

                    cfg.ReceiveEndpoint("employee-added-event", e =>
                    {
                        e.ConfigureConsumer<EmployeeAddedConsumer>(context);
                        e.UseMessageRetry(r => r.Interval(3, 1000));
                    });
                    cfg.ReceiveEndpoint("employee-updated-event", e =>
                    {
                        e.ConfigureConsumer<EmployeeUpdatedConsumer>(context);
                        e.UseMessageRetry(r => r.Interval(3, 1000));
                    });
                    cfg.ReceiveEndpoint("employee-deleted-event", e =>
                    {
                        e.ConfigureConsumer<EmployeeDeletedConsumer>(context);
                        e.UseMessageRetry(r => r.Interval(3, 1000));
                    });
                    cfg.ReceiveEndpoint("address-added-event", e =>
                    {
                        e.ConfigureConsumer<AddressAddedConsumer>(context);
                        e.UseMessageRetry(r => r.Interval(3, 1000));
                    });
                    cfg.ReceiveEndpoint("address-updated-event", e =>
                    {
                        e.ConfigureConsumer<AddressUpdatedConsumer>(context);
                        e.UseMessageRetry(r => r.Interval(3, 1000));
                    });
                    cfg.ReceiveEndpoint("address-deleted-event", e =>
                    {
                        e.ConfigureConsumer<AddressDeletedConsumer>(context);
                        e.UseMessageRetry(r => r.Interval(3, 1000));
                    });

                    cfg.ReceiveEndpoint("governorate-added-event", e =>
                    {
                        e.ConfigureConsumer<GovernorateAddedConsumer>(context);
                        e.UseMessageRetry(r => r.Interval(3, 1000));
                    });
                    cfg.ReceiveEndpoint("governorate-updated-event", e =>
                    {
                        e.ConfigureConsumer<GovernorateUpdatedConsumer>(context);
                        e.UseMessageRetry(r => r.Interval(3, 1000));
                    });
                    cfg.ReceiveEndpoint("governorate-deleted-event", e =>
                    {
                        e.ConfigureConsumer<GovernorateDeletedConsumer>(context);
                        e.UseMessageRetry(r => r.Interval(3, 1000));
                    });

                    cfg.ReceiveEndpoint("area-added-event", e =>
                    {
                        e.ConfigureConsumer<AreaAddedConsumer>(context);
                        e.UseMessageRetry(r => r.Interval(3, 1000));
                    });
                    cfg.ReceiveEndpoint("area-updated-event", e =>
                    {
                        e.ConfigureConsumer<AreaUpdatedConsumer>(context);
                        e.UseMessageRetry(r => r.Interval(3, 1000));
                    });
                    cfg.ReceiveEndpoint("area-deleted-event", e =>
                    {
                        e.ConfigureConsumer<AreaDeletedConsumer>(context);
                        e.UseMessageRetry(r => r.Interval(3, 1000));
                    });

                    cfg.ReceiveEndpoint("district-added-event", e =>
                    {
                        e.ConfigureConsumer<DistrictAddedConsumer>(context);
                        e.UseMessageRetry(r => r.Interval(3, 1000));
                    });
                    cfg.ReceiveEndpoint("district-updated-event", e =>
                    {
                        e.ConfigureConsumer<DistrictUpdatedConsumer>(context);
                        e.UseMessageRetry(r => r.Interval(3, 1000));
                    });
                    cfg.ReceiveEndpoint("district-deleted-event", e =>
                    {
                        e.ConfigureConsumer<DistrictDeletedConsumer>(context);
                        e.UseMessageRetry(r => r.Interval(3, 1000));
                    });
                });
            });
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IEmployeesService, EmployeesService>();

            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<IAddressesService, AddressesService>();

            services.AddScoped<IGovernorateRepository, GovernorateRepository>();
            services.AddScoped<IGovernoratesService, GovernoratesService>();

            services.AddScoped<IAreaRepository, AreaRepository>();
            services.AddScoped<IAreasService, AreasService>();


            services.AddScoped<IDistrictRepository, DistrictRepository>();
            services.AddScoped<IDistrictsService, DistrictsService>();
            services.AddControllers();
            services.AddSwaggerGen();

            return services;
        }
    }
}
