namespace VendaVeiculosAPI.Dto.Request
{
    public class ArquivoRequestDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Tipo { get; set; }
        public string Base64 { get; set; }
    }
}
