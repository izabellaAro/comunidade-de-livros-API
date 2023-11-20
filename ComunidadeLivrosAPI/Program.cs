using ComunidadeLivros.Application.Services;
using ComunidadeLivros.Application.Services.Impl;
using ComunidadeLivros.DataAccess.Repositories;
using ComunidadeLivros.DataAccess.Repositories.Impl;
using ComunidadeLivrosAPI.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("LivroConnection");
builder.Services.AddDbContext<LivroContext>(opts => opts.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

builder.Services.AddScoped<IAutorRepository, AutorRepository>();
builder.Services.AddScoped<IGeneroRepository, GeneroRepository>();
builder.Services.AddScoped<ILivroRepository, LivroRepository>();
builder.Services.AddScoped<IResenhaRepository, ResenhaRepository>();

// Add services to the container.
builder.Services.AddScoped<IAutorService, AutorService>();
builder.Services.AddScoped<IGeneroService, GeneroService>();
builder.Services.AddScoped<ILivroService, LivroService>();
builder.Services.AddScoped<IResenhaService, ResenhaService>();

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
