﻿using Microsoft.EntityFrameworkCore;
using VendaVeiculosAPI.Filters;
using VendaVeiculosAPI.Models;
using VendaVeiculosAPI.Repositories.Interfaces;
using VendaVeiculosAPI.Utils;

namespace VendaVeiculosAPI.Repositories.Impl
{
    public class CarroArquivoRepository : BaseRepository<CarroArquivo, CarroArquivoFilter>, ICarroArquivoRepository
    {
        public CarroArquivoRepository(Context context) : base(context){}

        public async Task<List<CarroArquivo>> GetArquivosByIdCarroAsync(Guid idCarro, CancellationToken token)
        {
            return await _context.CarroArquivos.Where(c => c.Carro.Id == idCarro).ToListAsync(token);
        }

        public async Task<bool> ToggleAsync(Guid id, CancellationToken token)
        {
            CarroArquivo _carroArquivo = await _context.CarroArquivos
                .FirstOrDefaultAsync(c => c.Id == id, token) ?? throw new NullReferenceException("Arquivo não encontrado");

            _carroArquivo.Ativo = !_carroArquivo.Ativo;
            _carroArquivo.DataAlteracao = DateTimeHelpers.GetDateTimeNow();
            _context.CarroArquivos.Update(_carroArquivo);
            return _carroArquivo.Ativo;
        }

        public async Task DeleteCarroArquivo(Guid id, CancellationToken token)
        {
            CarroArquivo _carroArquivo = await _context.CarroArquivos
                .FirstOrDefaultAsync(c => c.Id == id, token) ?? throw new NullReferenceException("Arquivo não encontrado");

            _carroArquivo.Ativo = false;
            _carroArquivo.DataDelete = DateTimeHelpers.GetDateTimeNow();
            _context.CarroArquivos.Update(_carroArquivo);
        }
    }
}
