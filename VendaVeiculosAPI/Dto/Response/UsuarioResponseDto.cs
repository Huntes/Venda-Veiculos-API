using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using VendaVeiculosAPI.Models;

namespace VendaVeiculosAPI.Dto.Response
{
    public class UsuarioResponseDto
    {
        public Guid Id { get; set; }

        public string Email { get; set; }

        public string Nome { get; set; }

        public string Senha { get; set; }

        public int TipoUser { get; set; }
    }
}
