using Microsoft.EntityFrameworkCore;
using minimal_api_cadastro_veiculos.Dominio.Entidades;

namespace minimal_api_cadastro_veiculos.Infraestrura.Db;

public class DbContexto : DbContext
{
    private readonly IConfiguration _configuracaoAppSettings;
    public DbContexto(IConfiguration configuracaoAppSettings)
    {
        _configuracaoAppSettings = configuracaoAppSettings;
    }
    public DbSet<Administrador> Administradores { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Administrador>().HasData(
            new Administrador {
                id = 1,
                Email = "administrador@teste.com",
                Senha = "123456",
                Perfil = "Adm" 
            }
        );
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if(!optionsBuilder.IsConfigured)
        {
            var stringConexao = _configuracaoAppSettings.GetConnectionString("postgresql")?.ToString();
            if(!string.IsNullOrEmpty(stringConexao))
            {
                optionsBuilder.UseNpgsql(stringConexao);
            }
        }
    }

}