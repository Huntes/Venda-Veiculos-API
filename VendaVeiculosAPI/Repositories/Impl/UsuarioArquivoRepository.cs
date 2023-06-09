using Microsoft.EntityFrameworkCore;
using VendaVeiculosAPI.Filters;
using VendaVeiculosAPI.Models;
using VendaVeiculosAPI.Repositories.Interfaces;
using VendaVeiculosAPI.Utils;

namespace VendaVeiculosAPI.Repositories.Impl
{
    public class UsuarioArquivoRepository : BaseRepository<UsuarioArquivo, UsuarioFilter>, IUsuarioArquivoRepository
    {
        public UsuarioArquivoRepository(Context context) : base(context){}

        public async Task<List<UsuarioArquivo>> GetArquivosByIdUsuarioAsync(Guid idUsuario, CancellationToken token)
        {
            return await _context.UsuarioArquivos
                .Where(c => c.Usuario.Id == idUsuario).ToListAsync(token);
        }

        public async Task<bool> ToggleAsync(Guid id, CancellationToken token)
        {
            UsuarioArquivo _usuarioArquivo = await _context.UsuarioArquivos
                .FirstOrDefaultAsync(c => c.Id == id, token) ?? throw new NullReferenceException("Arquivo não encontrado");

            _usuarioArquivo.Ativo = !_usuarioArquivo.Ativo;
            _usuarioArquivo.DataAlteracao = DateTimeHelpers.GetDateTimeNow();
            _context.UsuarioArquivos.Update(_usuarioArquivo);
            return _usuarioArquivo.Ativo;
        }

        public async Task DeleteUsuarioArquivo(Guid id, CancellationToken token)
        {
            UsuarioArquivo _usuarioArquivo = await _context.UsuarioArquivos
                .FirstOrDefaultAsync(c => c.Id == id, token) ?? throw new NullReferenceException("Arquivo não encontrado");

            _usuarioArquivo.Ativo = false;
            _usuarioArquivo.DataDelete = DateTimeHelpers.GetDateTimeNow();
            _context.UsuarioArquivos.Update(_usuarioArquivo);

        }
    }
}
