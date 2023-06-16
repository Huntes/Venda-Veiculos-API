using Microsoft.EntityFrameworkCore;
using VendaVeiculosAPI.Models;
using VendaVeiculosAPI.Repositories.Interfaces;
using VendaVeiculosAPI.Utils;

namespace VendaVeiculosAPI.Repositories.Impl
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(Context context) : base(context){}

        public async Task<Usuario> GetByIdAsync(Guid id, CancellationToken token)
        {
            return await _context.Usuarios
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id, token);
        }

        public async Task<Usuario> GetByEmailAsync(string email, CancellationToken token)
        {
            return await _context.Usuarios
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Email.ToUpper() == email.ToUpper() && c.DataDelete == null && c.Ativo, token);
        }

        public async Task<Usuario> GetByNameAsync(string name, CancellationToken token)
        {
            return await _context.Usuarios
               .AsNoTracking()
               .FirstOrDefaultAsync(c => c.Nome.ToUpper() == name.ToUpper() && c.DataDelete == null && c.Ativo, token);
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

        public async Task<bool> ExistUsuario(string name, CancellationToken token)
        {
            return await _context.Usuarios.AnyAsync(c => c.Nome.ToUpper() == name.ToUpper() && c.Ativo && c.DataDelete == null, token);
        }


    }
}
