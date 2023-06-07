using System.ComponentModel.DataAnnotations.Schema;

namespace VendaVeiculosAPI.Models
{
    public class BaseModel
    {
        [Column("DataCriacao")]
        public DateTime DataCriacao { get; set; }

        [Column("DataAlteracao")]
        public bool Ativo { get; set; }
    }
}
