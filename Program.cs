using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using VideoStreamAPI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();
builder.Services
    .AddVideoStreamClient()
    .AddRtspImageService()
    .AddVideoFilesProvider();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseCors(
    options => options
        .AllowAnyOrigin()
        .AllowAnyMethod()
);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
