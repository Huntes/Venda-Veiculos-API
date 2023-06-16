using Newtonsoft.Json;

namespace VendaVeiculosAPI.Dto.Request
{
    public class ArquivoRequestDto
    {
        public string Nome { get; set; }
        public string Tipo { get; set; }
        public string Path { get; set; }
    }
}
