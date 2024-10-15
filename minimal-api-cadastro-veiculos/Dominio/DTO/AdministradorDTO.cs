using minimal_api_cadastro_veiculos.Dominio.Enums;

namespace minimal_api_cadastro_veiculos.Dominio.DTOs;

public class AdministradorDTO
{
    public string Email { get; set; } = default;
    public string Senha { get; set; } = default;
    public Perfil Perfil { get; set; } = default;
};