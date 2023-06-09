using VendaVeiculosAPI.Models;

namespace VendaVeiculosAPI.Dto.Response
{
    public class CarroResponseDto
    {
        public Guid Id { get; set; }

        public string Nome { get; set; }

        public string Marca { get; set; }

        public string Modelo { get; set; }

        public string? Foto { get; set; }

        public int Ano { get; set; }

        public int Status { get; set; }

        public double? Preco { get; set; }

        public string? Quilometragem { get; set; }

        public Guid IDUsuarioCreate { get; set; }
        public List<Arquivo> Arquivos { get; set; }
    }
}
