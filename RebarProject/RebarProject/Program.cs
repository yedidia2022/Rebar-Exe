using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Driver.Core.Configuration;
using RebarProject.Models;
using RebarProject.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<ShakeStoreDataBaseSettings>(
    builder.Configuration.GetSection(nameof(ShakeStoreDataBaseSettings)));

builder.Services.AddSingleton<IShakeStoreDataBaseSettings>(sp =>
    sp.GetRequiredService<IOptions<ShakeStoreDataBaseSettings>>().Value);

builder.Services.AddSingleton<IMongoClient>(s =>
        new MongoClient(builder.Configuration.GetValue<string>("ShakeStoreDataBaseSettings:ConnectionString")));

builder.Services.AddScoped<IShakeService, ShakeService>();


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
