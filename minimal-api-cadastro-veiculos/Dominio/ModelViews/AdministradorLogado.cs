namespace minimal_api_cadastro_veiculos.Dominio.ModelViews;

public record AdministradorLogado
{
    public string Email { get; set; } = default!;
    public string Perfil { get; set; } = default!;
    public string Token { get; set; } = default!;

}