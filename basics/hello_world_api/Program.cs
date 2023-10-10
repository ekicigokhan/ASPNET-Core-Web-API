var builder = WebApplication.CreateBuilder(args); //Bana bir tane inþa edici ver.

// Add services to the container.

builder.Services.AddControllers(); // Ýnþa edilip oluþturalan container'a servis kayýtlarý yapýyoruz..
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build(); // Build fonksiyonu bize bir WebApplication dönüyor.

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) //lounchSettigs.json dosyamýzla iliþkili kýsým.
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//Hangi servisler aktif olsun ?

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

//Ve çalýþtýr !

app.Run();
