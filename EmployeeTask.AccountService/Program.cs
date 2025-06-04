using EmployeeTask.AccountService.Data;
using EmployeeTask.AccountService.Repositories;
using EmployeeTask.AccountService.RepositoryContracts;
using EmployeeTask.AccountService.ServiceContracts;
using EmployeeTask.AccountService.Services;
using MassTransit;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string? connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("Invalid connection string");
builder.Services.AddDbContext<AccountDbContext>(options =>
{
    options.UseSqlServer(connectionString);
});
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowBFF", builder =>
        builder.WithOrigins("http://localhost:5078")
               .AllowAnyMethod()
               .AllowAnyHeader());
});
builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssemblies(typeof(Program).Assembly);
});
builder.Services.AddMassTransit(x =>
{
    x.UsingRabbitMq();
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
app.UseCors("AllowBFF");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
