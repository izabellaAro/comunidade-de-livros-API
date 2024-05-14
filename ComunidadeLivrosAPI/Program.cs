using ComunidadeLivros.Application.Services;
using ComunidadeLivros.Application.Services.Impl;
using ComunidadeLivros.Application.Settings;
using ComunidadeLivros.DataAccess.Repositories;
using ComunidadeLivros.DataAccess.Repositories.Impl;
using ComunidadeLivrosAPI.Data;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("LivroConnection");
builder.Services.AddDbContext<LivroContext>(opts => opts.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

IConfiguration config = builder.Configuration;
builder.Services.Configure<AWSSettings>(config.GetSection(nameof(AWSSettings)));

builder.Services.AddScoped<IAutorRepository, AutorRepository>();
builder.Services.AddScoped<IGeneroRepository, GeneroRepository>();
builder.Services.AddScoped<ILivroRepository, LivroRepository>();
builder.Services.AddScoped<IResenhaRepository, ResenhaRepository>();

// Add services to the container.
builder.Services.AddScoped<IAutorService, AutorService>();
builder.Services.AddScoped<IGeneroService, GeneroService>();
builder.Services.AddScoped<ILivroService, LivroService>();
builder.Services.AddScoped<IResenhaService, ResenhaService>();
builder.Services.AddScoped<IAmazonS3Service, AmazonS3Service>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder => builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());
});

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

app.UseCors("CorsPolicy");

app.Run();
