using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using minimal_api_cadastro_veiculos.Dominio.DTOs;
using minimal_api_cadastro_veiculos.Dominio.Interfaces;
using minimal_api_cadastro_veiculos.Dominio.Servicos;
using minimal_api_cadastro_veiculos.Infraestrura.Db;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IAdministradorServico, AdministradorServico>();

builder.Services.AddDbContext<DbContexto>(options => {
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("postgresql"),
        null
    );
});

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapPost("/login", ([FromBody] LoginDTO loginDTO, IAdministradorServico administradorServico) => {
    if(administradorServico.Login(loginDTO) != null)
        return Results.Ok("Login realizado com sucesso!");
    else
        return Results.Unauthorized();
});

app.Run();
