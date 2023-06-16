namespace VendaVeiculosAPI.Dto.Request
{
    public class ArquivoRequestInsertDto
    {
        public Guid IdCarro { get; set; }
        public List<ArquivoRequestDto>? Arquivos { get; set; }
    }
}
