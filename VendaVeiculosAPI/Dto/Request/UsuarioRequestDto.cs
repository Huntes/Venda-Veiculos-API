namespace VendaVeiculosAPI.Dto.Request
{
    public class UsuarioRequestDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set;}
        public string Tipo { get; set;}
    }
}
