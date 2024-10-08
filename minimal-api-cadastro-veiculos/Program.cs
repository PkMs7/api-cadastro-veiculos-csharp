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
app.MapGet("/", () => Results.Json(new Home())).WithTags("Home");
#endregion

#region Administradores
app.MapPost("/administradores/login", ([FromBody] LoginDTO loginDTO, IAdministradorServico administradorServico) => {
    if(administradorServico.Login(loginDTO) != null)
        return Results.Ok("Login realizado com sucesso!");
    else
        return Results.Unauthorized();
}).WithTags("Administradores");
#endregion

#region Veiculos

ErrosDeValidacao validarDTO(VeiculoDTO veiculoDTO)
{
    
    var validacao = new ErrosDeValidacao{
        Mensagens = new List<string>()
    };

    if(string.IsNullOrEmpty(veiculoDTO.Nome))
        validacao.Mensagens.Add("O nome do veículo precisa ser informado");

    if(string.IsNullOrEmpty(veiculoDTO.Marca))
        validacao.Mensagens.Add("A marca do veículo precisa ser informada");

    if(veiculoDTO == null)
        validacao.Mensagens.Add("O ano do veículo precisa ser cadastrado");

    return validacao;

}

app.MapPost("/veiculos", ([FromBody] VeiculoDTO veiculoDTO, IVeiculoServico veiculoServico) => {


    var validacao = validarDTO(veiculoDTO);
    if(validacao.Mensagens.Count > 0)
        return Results.BadRequest(validacao);

    var veiculo = new Veiculo{
        Nome = veiculoDTO.Nome,
        Marca = veiculoDTO.Marca,
        Ano = veiculoDTO.Ano
    };

    veiculoServico.Incluir(veiculo);

    return Results.Created($"/veiculo/{veiculo.id}", veiculo);
}).WithTags("Veiculos");

app.MapGet("/veiculos", ([FromQuery] int? pagina, IVeiculoServico veiculoServico) => {
    
    var veiculos = veiculoServico.Todos(pagina);

    return Results.Ok(veiculos);
}).WithTags("Veiculos");

app.MapGet("/veiculos/{id}", ([FromRoute] int id, IVeiculoServico veiculoServico) => {
    
    var veiculo = veiculoServico.BuscaPorId(id);

    if(veiculo == null) return Results.NotFound("Veiculo não cadastrado!");

    return Results.Ok(veiculo);
}).WithTags("Veiculos");

app.MapPut("/veiculos/{id}", ([FromRoute] int id, VeiculoDTO veiculoDTO, IVeiculoServico veiculoServico) => {
    
    var veiculo = veiculoServico.BuscaPorId(id);
    if(veiculo == null) return Results.NotFound("Veiculo não cadastrado!");


    var validacao = validarDTO(veiculoDTO);
    if(validacao.Mensagens.Count > 0)
        return Results.BadRequest(validacao);

    veiculo.Nome = veiculoDTO.Nome;
    veiculo.Marca = veiculoDTO.Marca;
    veiculo.Ano = veiculoDTO.Ano;

    veiculoServico.Atualizar(veiculo);

    return Results.Ok(veiculo);
}).WithTags("Veiculos");

app.MapDelete("/veiculos/{id}", ([FromRoute] int id, IVeiculoServico veiculoServico) => {
    
    var veiculo = veiculoServico.BuscaPorId(id);

    if(veiculo == null) return Results.NotFound("Veiculo não cadastrado!");

    veiculoServico.Excluir(veiculo);

    return Results.NoContent();
}).WithTags("Veiculos");
#endregion

app.UseSwagger();
app.UseSwaggerUI();

app.Run();
#endregion