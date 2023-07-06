using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using adventure_time_api.Data;
using adventure_time_api.Repository;
using adventure_time_api.Repository.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddEntityFrameworkSqlServer()
.AddDbContext<CharacterDBContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DataBase"))
);

builder.Services.AddScoped<CharacterLoader, CharacterRepository>();

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
