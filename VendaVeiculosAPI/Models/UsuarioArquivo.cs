using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VendaVeiculosAPI.Models
{
    [Table("USUARIO_ARQUIVO")]
    public class UsuarioArquivo : BaseModel
    {
        [Key, Column("ID")]
        public Guid Id { get; set; }

        [Required ,ForeignKey("UsuarioId")]
        public Usuario Usuario { get; set; }

        [Required, ForeignKey("ArquivoId")]
        public Arquivo Arquivo { get; set; }
        public UsuarioArquivo() { }
        public UsuarioArquivo(Usuario usuario, Arquivo arquivo)
        {
            this.Usuario = usuario;
            this.Arquivo = arquivo;
        }
    }
}
