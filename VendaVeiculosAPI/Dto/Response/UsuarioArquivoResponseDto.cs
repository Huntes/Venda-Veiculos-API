using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using VendaVeiculosAPI.Models;

namespace VendaVeiculosAPI.Dto.Response
{
    public class UsuarioArquivoResponseDto : BaseResponseDto
    {
        public Guid Id { get; set; }

        public Guid IdUsuario { get; set; }

        public Guid IdArquivo { get; set; }
    }
}
