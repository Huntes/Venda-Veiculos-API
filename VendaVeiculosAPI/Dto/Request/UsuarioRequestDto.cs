using Newtonsoft.Json;

namespace VendaVeiculosAPI.Dto.Request
{
    public class UsuarioRequestDto
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set;}
        public int Tipo { get; set;}
    }
}
