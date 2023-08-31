using Microsoft.EntityFrameworkCore;
using DigitalMemory.WebApi.Data;
using DigitalMemory.WebApi.Dtos;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<DigitalMemoryWebApiContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DigitalMemoryWebApiContext") ?? throw new InvalidOperationException("Connection string 'DigitalMemoryWebApiContext' not found.")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
// builder.Services.AddEndpointsApiExplorer();
// The call to AddEndpointsApiExplorer shown in the preceding example is
// required only for minimal APIs. For more information, see this StackOverflow
// post: https://stackoverflow.com/a/71933535.
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(DiaryDto).Assembly);

var app = builder.Build();
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
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
