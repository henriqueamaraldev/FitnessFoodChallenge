using Application.Configs;
using Cron.Service.configs;
using Repository.settings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.InjectApplicationDependecies();
builder.Services.InjectRepositoryDependecies();

builder.Services.Configure<ProductDbConfigs>(builder.Configuration.GetSection("Database"));

var app = builder.Build();

IHost host = Host.CreateDefaultBuilder(args).ConfigureServices((hostContext, services) =>
{
    services.AddCronAdapter(builder.Configuration);
})
    .UseWindowsService()
    .Build();

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
