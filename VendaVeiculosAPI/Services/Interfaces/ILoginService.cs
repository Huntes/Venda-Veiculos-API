using VendaVeiculosAPI.Dto.Request;

namespace VendaVeiculosAPI.Services.Interfaces
{
    public interface ILoginService
    {
        Task<string> Login(UsuarioRequestDto entity, CancellationToken token);
    }
}
