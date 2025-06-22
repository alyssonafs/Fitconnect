using System.Text;
using FitConnect.Aplicacao;
using FitConnect.Aplicacao.Interfaces;
using FitConnect.Dominio.Entidades;
using FitConnect.Repositorio.DataAccess;
using FitConnect.Repositorio.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true)
    .AddEnvironmentVariables();


// Add services to the container.
builder.Services.AddScoped<IUsuarioAplicacao, UsuarioAplicacao>();
builder.Services.AddScoped<ITreinoCompartilhadoAplicacao, TreinoCompartilhadoAplicacao>();
builder.Services.AddScoped<ITreinoAplicacao, TreinoAplicacao>();
builder.Services.AddScoped<IExercicioTreinoAplicacao, ExercicioTreinoAplicacao>();
builder.Services.AddScoped<IExercicioAplicacao, ExercicioAplicacao>();
builder.Services.AddScoped<IAuthServiceAplicacao, AuthServiceAplicacao>();


builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
builder.Services.AddScoped<ITreinoCompartilhadoRepositorio, TreinoCompartilhadoRepositorio>();
builder.Services.AddScoped<ITreinoRepositorio, TreinoRepositorio>();
builder.Services.AddScoped<IExercicioTreinoRepositorio, ExercicioTreinoRepositorio>();
builder.Services.AddScoped<IExercicioRepositorio, ExercicioRepositorio>();

//Adicione os serviços

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins("http://localhost:3000")
        .SetIsOriginAllowedToAllowWildcardSubdomains()
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer("Bearer", options =>
    {
        var config = builder.Configuration.GetSection("Jwt");
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = config["Issuer"],
            ValidAudience = config["Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Key"]))
        };
    });

builder.Services.AddControllers();
builder.Services.AddAuthorization();

builder.Services.AddDbContext<FitConnectContexto>(options => options
    .UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
