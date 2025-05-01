using FitConnect.Aplicacao;
using FitConnect.Aplicacao.Interfaces;
using FitConnect.Dominio.Entidades;
using FitConnect.Repositorio.DataAccess;
using FitConnect.Repositorio.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<FitConnectContexto>(options => options
    .UseSqlServer("Server=NOTE-AFS\\SQLEXPRESS;Database=Fitconnect;TrustServerCertificate=True;Trusted_Connection=True;"));

// Add services to the container.
builder.Services.AddScoped<IUsuarioAplicacao, UsuarioAplicacao>();
builder.Services.AddScoped<ITreinoCompartilhadoAplicacao, TreinoCompartilhadoAplicacao>();
builder.Services.AddScoped<ITreinoAplicacao, TreinoAplicacao>();
builder.Services.AddScoped<IExercicioTreinoAplicacao, ExercicioTreinoAplicacao>();
builder.Services.AddScoped<IExercicioAplicacao, ExercicioAplicacao>();


builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
builder.Services.AddScoped<ITreinoCompartilhadoRepositorio, TreinoCompartilhadoRepositorio>();
builder.Services.AddScoped<ITreinoRepositorio, TreinoRepositorio>();
builder.Services.AddScoped<IExercicioTreinoRepositorio, ExercicioTreinoRepositorio>();
builder.Services.AddScoped<IExercicioRepositorio, ExercicioRepositorio>();

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
