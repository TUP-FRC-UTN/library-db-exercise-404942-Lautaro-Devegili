using LibraryProj.Context;
using LibraryProj.Services;
using LibraryProj.Services.Impl;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ILibroService, LibroService>();

builder.Services.AddDbContext<libraryDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("dbAfuera"));
});


var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<libraryDbContext>();
    dbContext.Database.Migrate();
}


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(options => {
    options.AllowAnyOrigin();
    options.AllowAnyHeader();
    options.AllowAnyMethod();

});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
