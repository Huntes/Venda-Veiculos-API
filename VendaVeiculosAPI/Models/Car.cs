using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VendaVeiculosAPI.Models
{
    [Table("TB_CARRO")]
    public class Car : BaseModel
    {
        [Key, Column("ID")]
        public Guid Id { get; set; }

        [Required, Column("Nome", TypeName = "VARCHAR(500)")]
        public string Nome { get; set; }

        [Required, Column("Marca", TypeName = "VARCHAR(100)")]
        public string Marca { get; set; }

        [Required, Column("Modelo", TypeName = "VARCHAR(500)")]
        public string Modelo { get; set; }

        [Required, Column("Ano")]
        public int Ano { get; set; }

        [Column("Status")]
        public int Status { get; set; }

        [Column("Preco", TypeName = "DECIMAL(10,2)")]
        public double? Preco { get; set; }

        [Column("Quilometragem", TypeName = "VARCHAR(500)")]
        public string? Quilometragem { get; set; }

        public virtual ICollection<CarroArquivo> Arquivos { get; set; }

        public Car()
        {
            this.Nome = string.Empty;
            this.Modelo = string.Empty;
            this.Marca = string.Empty;
        }

        public Car(string Nome, string Marca, string Modelo, int Ano, string? quilometragem) : base()
        {
            this.Nome = Nome;
            this.Marca = Marca;
            this.Modelo = Modelo;
            this.Ano = Ano;
            this.Quilometragem = quilometragem;
        }
    }
}
