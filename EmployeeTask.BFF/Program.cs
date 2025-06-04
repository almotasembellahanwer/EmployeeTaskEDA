using EmployeeTask.BFF.HttpClients;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddHttpClient<AccountServiceClient>(client =>
{
    client.BaseAddress = new Uri($"http://localhost:5297/");
});
builder.Services.AddHttpClient<AggregatorServiceClient>(client =>
{
    client.BaseAddress = new Uri($"http://localhost:5224/");
});
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
