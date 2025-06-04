using EmployeeTask.Aggregator.Consumers.AddressConsumer;
using EmployeeTask.Aggregator.Consumers.EmployeeConsumer;
using EmployeeTask.Aggregator.Data;
using EmployeeTask.Aggregator.IRepositoryContracts;
using EmployeeTask.Aggregator.Repositories;
using EmployeeTask.Aggregator.ServiceContracts;
using EmployeeTask.Aggregator.Services;
using MassTransit;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string? connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("Invalid connection string");
builder.Services.AddDbContext<AggregatorDbContext>(options =>
{
    options.UseSqlServer(connectionString);
});
builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssemblies(typeof(Program).Assembly);
});
builder.Services.AddMassTransit(x =>
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

    });
});
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IEmployeesService, EmployeesService>();

builder.Services.AddScoped<IAddressRepository, AddressRepository>();
builder.Services.AddScoped<IAddressesService, AddressesService>();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
