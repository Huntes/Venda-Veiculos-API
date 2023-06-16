using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using VendaVeiculosAPI.Models;

namespace VendaVeiculosAPI.Dto.Response
{
    public class ArquivoResponseDto : BaseResponseDto
    {
        public ArquivoResponseDto(Arquivo arquivo)
        {
            this.Id = arquivo.Id;
            this.NomeArquivo = arquivo.NomeArquivo;
            this.TipoArquivo = arquivo.TipoArquivo;
            this.Path = arquivo.Path;
        }

        public Guid Id { get; set; }
        public string NomeArquivo { get; set; }
        public string TipoArquivo { get; set; }
        public string Path { get; set; }
    }
}
