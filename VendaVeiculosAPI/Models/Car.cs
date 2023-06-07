using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VendaVeiculosAPI.Models
{
    [Table("TB_CAR")]
    public class Car : BaseModel
    {
        [Key, Column("ID")]
        public Guid Id { get; set; }

        [Column("Nome", TypeName = "VARCHAR(500)")]
        public string Nome { get; set; }

        [Column("Marca", TypeName = "VARCHAR(100)")]
        public string Marca { get; set; }

        [Column("Modelo", TypeName = "VARCHAR(500)")]
        public string Modelo { get; set; }

        [Column("Foto", TypeName = "VARCHAR(500)")]
        public string Foto { get; set; }

        public Car(string Nome, string Marca, string Modelo, string Foto)
        {
            this.Nome = Nome;
            this.Marca = Marca;
            this.Modelo = Modelo;
            this.Foto = Foto;
        }
    }
}
