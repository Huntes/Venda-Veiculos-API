using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using VendaVeiculosAPI.Models;

namespace VendaVeiculosAPI.Dto.Response
{
    public class CarroArquivoResponseDto
    {
        public Guid Id { get; set; }

        public Guid IdCarro { get; set; }

        public Guid IdArquivo { get; set; }
    }
}
