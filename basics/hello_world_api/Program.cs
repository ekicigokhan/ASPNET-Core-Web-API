var builder = WebApplication.CreateBuilder(args); //Bana bir tane in�a edici ver.

// Add services to the container.

builder.Services.AddControllers(); // �n�a edilip olu�turalan container'a servis kay�tlar� yap�yoruz..
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build(); // Build fonksiyonu bize bir WebApplication d�n�yor.

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) //lounchSettigs.json dosyam�zla ili�kili k�s�m.
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//Hangi servisler aktif olsun ?

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

//Ve �al��t�r !

app.Run();
