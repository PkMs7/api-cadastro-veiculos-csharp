using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using minimal_api_cadastro_veiculos.Dominio.DTOs;
using minimal_api_cadastro_veiculos.Dominio.Entidades;
using minimal_api_cadastro_veiculos.Dominio.Interfaces;
using minimal_api_cadastro_veiculos.Dominio.ModelViews;
using minimal_api_cadastro_veiculos.Dominio.Servicos;
using minimal_api_cadastro_veiculos.Infraestrura.Db;

#region Builder
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IAdministradorServico, AdministradorServico>();
builder.Services.AddScoped<IVeiculoServico, VeiculoServico>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DbContexto>(options => {
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("postgresql"),
        null
    );
});
#endregion

#region App
var app = builder.Build();

#region Home
app.MapGet("/", () => Results.Json(new Home()));
#endregion

#region Administradores
app.MapPost("/administradores/login", ([FromBody] LoginDTO loginDTO, IAdministradorServico administradorServico) => {
    if(administradorServico.Login(loginDTO) != null)
        return Results.Ok("Login realizado com sucesso!");
    else
        return Results.Unauthorized();
});
#endregion

#region Veiculos
app.MapPost("/veiculos", ([FromBody] VeiculoDTO veiculoDTO, IVeiculoServico veiculoServico) => {
    
    var veiculo = new Veiculo{
        Nome = veiculoDTO.Nome,
        Marca = veiculoDTO.Marca,
        Ano = veiculoDTO.Ano
    };

    veiculoServico.Incluir(veiculo);

    return Results.Created($"/veiculo/{veiculo.id}", veiculo);
});
#endregion

app.UseSwagger();
app.UseSwaggerUI();

app.Run();
#endregion