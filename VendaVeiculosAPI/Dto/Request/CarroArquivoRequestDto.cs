using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using VendaVeiculosAPI.Models;

namespace VendaVeiculosAPI.Dto.Request
{
    public class CarroArquivoRequestDto
    {
        public Guid Id { get; set; }

        public Guid IdCarro { get; set; }

        public Guid IdArquivo { get; set; }

    }
}
