using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using VendaVeiculosAPI.Models;
using System.Text.Json.Serialization;

namespace VendaVeiculosAPI.Dto.Response
{
    public class UsuarioResponseDto : BaseResponseDto
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public int TipoUser { get; set; }
    }
}
