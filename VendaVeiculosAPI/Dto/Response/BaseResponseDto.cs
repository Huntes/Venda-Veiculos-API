using System.ComponentModel.DataAnnotations.Schema;

namespace VendaVeiculosAPI.Dto.Response
{
    public class BaseResponseDto
    {
        public DateTime DataCriacao { get; set; }
        public DateTime? DataAlteracao { get; set; }
        public DateTime? DataDelete { get; set; }
        public bool Ativo { get; set; }
    }
}
