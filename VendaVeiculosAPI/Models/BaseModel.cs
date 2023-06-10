using System.ComponentModel.DataAnnotations.Schema;
using VendaVeiculosAPI.Utils;

namespace VendaVeiculosAPI.Models
{
    public class BaseModel
    {
        [Column("DataCriacao")]
        public DateTime DataCriacao { get; set; } = DateTimeHelpers.GetDateTimeNow();
        [Column("DataAlteracao")]
        public DateTime? DataAlteracao { get; set; } 
        [Column("DataDelete")]
        public DateTime? DataDelete { get; set; }
        [Column("Ativo")]
        public bool Ativo { get; set; } = true;
    }
}
