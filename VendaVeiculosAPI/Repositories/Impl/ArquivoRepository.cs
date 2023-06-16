using Microsoft.EntityFrameworkCore;
using VendaVeiculosAPI.Models;
using VendaVeiculosAPI.Repositories.Interfaces;
using VendaVeiculosAPI.Utils;

namespace VendaVeiculosAPI.Repositories.Impl
{
    public class ArquivoRepository : BaseRepository<Arquivo>, IArquivoRepository
    {
        public ArquivoRepository(Context context) : base(context){}

        public async Task<Arquivo> GetArquivoById(Guid id, CancellationToken token)
        {
            return await _context.Arquivos
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id, token);
        }

        public async Task<Arquivo> GetByName(string name, CancellationToken token)
        {
            return await _context.Arquivos
                .AsTracking()
                .FirstOrDefaultAsync(c => c.NomeArquivo.ToUpper() == name.ToUpper() && c.DataDelete == null && c.Ativo, token);
        }

        public async Task<bool> ToggleAsync(Guid id, CancellationToken token)
        {
            Arquivo _arq = await _context.Arquivos.FirstOrDefaultAsync(c => c.Id == id, token) 
                ?? throw new NullReferenceException("Arquivo não encontrado");

            _arq.Ativo = !_arq.Ativo;
            _arq.DataAlteracao = DateTimeHelpers.GetDateTimeNow();
            _context.Arquivos.Update(_arq);
            return _arq.Ativo;
        }

        public async Task DeleteArquivo(Guid id, CancellationToken token)
        {
            Arquivo _arq = await _context.Arquivos.FirstOrDefaultAsync(c => c.Id == id, token)
                ?? throw new NullReferenceException("Arquivo não encontrado");

            _arq.Ativo = false;
            _arq.DataDelete = DateTimeHelpers.GetDateTimeNow();
            _context.Arquivos.Update(_arq);
        }
    }
}
