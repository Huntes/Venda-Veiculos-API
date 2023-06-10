namespace VendaVeiculosAPI.Dto.Request
{
    public class CarroRequestDto
    {
        public string Nome { get; set; } = string.Empty;
        public string Marca { get; set; } = string.Empty;
        public string Modelo { get; set; } = string.Empty;
        public int Ano { get; set; }
        public int Status { get; set; }
        public double? Preco { get; set; }
        public string? Quilometragem { get; set; }
        public List<ArquivoRequestDto>? Fotos { get; set; }
    }
}
