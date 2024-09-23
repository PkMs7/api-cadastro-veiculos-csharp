using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace minimal_api_cadastro_veiculos.Dominio.Entidades;

public class Veiculo
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int id { get; set; } = default;

    [Required]
    [StringLength(150)]
    public string Nome { get; set; } = default;

    [Required]
    [StringLength(100)]
    public string Marca { get; set; } = default;

    [Required]
    [StringLength(10)]
    public int Ano { get; set; } = default;
}