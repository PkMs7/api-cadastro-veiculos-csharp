using minimal_api_cadastro_veiculos.Dominio.DTOs;
using minimal_api_cadastro_veiculos.Dominio.Entidades;

namespace minimal_api_cadastro_veiculos.Dominio.Interfaces;

public interface IVeiculoServico
{
    List<Veiculo> Todos(int pagina, string? nome, string? marca);
    Veiculo? BuscaPorId(int id);
    void Incluir(Veiculo veiculo);
    void Atualizar(Veiculo veiculo);
    void Excluir(Veiculo veiculo);

}