using Microsoft.EntityFrameworkCore;
using NLog;
using Repositories.EFCore;
using Services.Contracts;
using WebAPI.Extensions;

var builder = WebApplication.CreateBuilder(args);

LogManager.LoadConfiguration(String.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));
//Birle�tir ve bu uygulama nerde �al���yorsa onu al ve bu path'e bu config'i ekle.

// Add services to the container.

builder.Services.AddControllers(config =>
{
    config.RespectBrowserAcceptHeader = true; //default : false yani */* olay�. Art�k �P'a a����z :)
    config.ReturnHttpNotAcceptable = true; // �imdi 406 NotAcceptable hatas� alaca��z.
})
    .AddXmlDataContractSerializerFormatters()
    .AddApplicationPart(typeof(Presentation.AssemblyRefence).Assembly)
    .AddNewtonsoftJson();
// typeof : Presentation.AssemblyRefence'a ait t�m bilgiler Controller'a eklendi.
// Elimizdeki verilerin Type'�n� yani t�r�yle ilgili bilgileri elde atmek i�in kullan�r�z.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureSqlContext(builder.Configuration); 
builder.Services.ConfigureRepositoryManager(); // parametresi this i�erdi�i i�in vermek zorunda de�ilim.
builder.Services.ConfigureServiceManager();
builder.Services.ConfigureLoggerService();
builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();

//YAPILANDIRMA 
//Uygulamay� elde eettikten sonra ihtiya� duydu�umuz bir servisi GetRequiredServices ifadesi ile alabildi�imizi g�rd�k.

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
    app.UseHsts(); //Detaylar� sonra incelenecek.
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();