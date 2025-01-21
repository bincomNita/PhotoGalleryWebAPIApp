using Microsoft.EntityFrameworkCore;
using PhotoGalleryWebAPIApp.Data;
using PhotoGalleryWebAPIApp.Interface;
using PhotoGalleryWebAPIApp.Repositiories;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

var connstring = builder.Configuration.GetConnectionString("Default");
builder.Services.AddSqlServer<PhotoGalleryDbContext>(connstring, opts=>opts.EnableRetryOnFailure());
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped<IPhotoGalleryRepository,PhotoGalleryRepository>();
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
