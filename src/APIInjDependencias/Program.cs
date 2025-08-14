using APIInjDependencias.Implementations;
using APIInjDependencias.Interfaces;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<ITesteA, TesteA>();
builder.Services.AddTransient<ITesteB, TesteB>();
builder.Services.AddScoped<TesteC>();

builder.Services.AddControllers();
builder.Services.AddOpenApi();

var app = builder.Build();

app.MapOpenApi();
app.MapScalarApiReference(options =>
{
    options.Title = "API de Teste de Injecao de Dependencias";
    options.Theme = ScalarTheme.BluePlanet;
    options.DarkMode = true;
});

app.UseAuthorization();

app.MapControllers();

app.Run();
