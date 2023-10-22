using Microsoft.EntityFrameworkCore;
using NLog;
using Repositories.EFCore;
using Services.Contracts;
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

//YAPILANDIRMA 
//Uygulamayý elde eettikten sonra ihtiyaç duyduðumuz bir servisi GetRequiredServices ifadesi ile alabildiðimizi gördük.

var logger = app.Services.GetRequiredService<ILoggerService>();
app.ConfigureExceptionHandler(logger);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

if (app.Environment.IsProduction())
{
    app.UseHsts(); //Detaylarý sonra incelenecek.
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();