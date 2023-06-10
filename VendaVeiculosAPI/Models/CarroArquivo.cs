using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VendaVeiculosAPI.Models
{
    [Table("TB_CARRO_ARQUIVO")]
    public class CarroArquivo : BaseModel
    {
        [Key, Column("ID")]
        public Guid Id { get; set; }

        [Column("CarroId")]
        public Guid CarroId { get; set; }

        [ForeignKey("CarroId")]
        public Car Carro { get; set; }

        [Column("ArquivoId")]
        public Guid ArquivoId { get; set; }

        [ForeignKey("ArquivoId")]
        public Arquivo Arquivo { get; set; }

        public CarroArquivo() { }
        public CarroArquivo(Car carro, Arquivo arquivo)
        {
            this.Carro = carro;
            this.Arquivo = arquivo;
        }
    }
}
