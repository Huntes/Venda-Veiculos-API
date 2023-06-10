using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace VendaVeiculosAPI.Dto.Response
{
    public class ArquivoResponseDto : BaseResponseDto
    {
        public Guid Id { get; set; }
        public string NomeArquivo { get; set; }
        public string TipoArquivo { get; set; }
        public string Path { get; set; }
    }
}
