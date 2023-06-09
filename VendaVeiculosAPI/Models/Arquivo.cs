using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace VendaVeiculosAPI.Models
{
    [Table("TB_ARQUIVO")]
    public class Arquivo : BaseModel
    {
        [Key, Column("ID")]
        public Guid Id { get; set; }

        [Column("NomeArquivo", TypeName = "NVARCHAR(500)")]
        public string NomeArquivo { get; set; }
        
        [Column("TipoArquivo", TypeName = "NVARCHAR(100)")]
        public string TipoArquivo { get; set; } 

        [Column("Arquivo", TypeName = "NVARCHAR(MAX)")]
        public string Path { get; set; }
    }
}
