using Microsoft.EntityFrameworkCore;
using VendaVeiculosAPI.Filters;
using VendaVeiculosAPI.Models;
using VendaVeiculosAPI.Repositories.Interfaces;
using VendaVeiculosAPI.Utils;

namespace VendaVeiculosAPI.Repositories.Impl
{
    public class UsuarioRepository : BaseRepository<Usuario, UsuarioFilter>, IUsuarioRepository
    {
        public UsuarioRepository(Context context) : base(context){}

        public async Task<Usuario> GetByIdAsync(Guid id, CancellationToken token)
        {
            return await _context.Usuarios
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id, token);
        }

        public async Task<Usuario> GetByNameAsync(string name, CancellationToken token)
        {
            return await _context.Usuarios
               .AsNoTracking()
               .FirstOrDefaultAsync(c => c.Nome.ToUpper().Contains(name.ToUpper()), token);
        }

        public async Task<Usuario> ToggleAsync(Guid id, CancellationToken token)
        {
            Usuario _user = await _context.Usuarios.FirstOrDefaultAsync(c => c.Id == id, token);
            _user.Ativo = !_user.Ativo;
            _user.DataAlteracao = DateTimeHelpers.GetDateTimeNow();
            _context.Usuarios.Update(_user);
            return _user;
        }

        public async Task DeleteUserAsync(Guid id, CancellationToken token)
        {
            Usuario _user = await GetByIdAsync(id, token);
            _user.Ativo = false;
            _user.DataDelete = DateTimeHelpers.GetDateTimeNow();
            _context.Usuarios.Update(_user);
        }
    }
}
