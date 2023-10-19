using Microsoft.EntityFrameworkCore;
using NLog;
using Repositories.EFCore;
using WebAPI.Extensions;

var builder = WebApplication.CreateBuilder(args);

LogManager.LoadConfiguration(String.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));
//Birleþtir ve bu uygulama nerde çalýþýyorsa onu al ve bu path'e bu config'i ekle.

// Add services to the container.

builder.Services.AddControllers().AddApplicationPart(typeof(Presentation.AssemblyRefence).Assembly).AddNewtonsoftJson();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureSqlContext(builder.Configuration); 
builder.Services.ConfigureRepositoryManager(); // parametresi this içerdiði için vermek zorunda deðilim.
builder.Services.ConfigureServiceManager();
builder.Services.ConfigureLoggerService();

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