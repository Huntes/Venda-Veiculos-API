using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VendaVeiculosAPI.Enum;

namespace VendaVeiculosAPI.Models
{
    [Table("TB_USUARIO")]
    public class Usuario : BaseModel
    {
        [Key, Column("ID")]
        public Guid Id { get; set; }

        [Column("Email", TypeName = "VARCHAR(100)")]
        public string Email { get; set; }

        [Column("Nome", TypeName = "VARCHAR(500)")]
        public string Nome { get; set; }

        [Column("Senha", TypeName = "VARCHAR(MAX)")]
        public string Senha { get; set; }

        [Column("TipoUsuario")]
        public int TipoUser { get; set; }
    }
}
