using Microsoft.EntityFrameworkCore;
using DigitalMemory.WebApi.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<DigitalMemoryWebApiContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DigitalMemoryWebApiContext") ?? throw new InvalidOperationException("Connection string 'DigitalMemoryWebApiContext' not found.")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
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
