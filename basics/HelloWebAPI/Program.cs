var builder = WebApplication.CreateBuilder(args);

//Service(Container)
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
if (app.Environment.IsDevelopment()) //Production ortam�nda Swagger ile �al��mas�n� istemiyorum.
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();
