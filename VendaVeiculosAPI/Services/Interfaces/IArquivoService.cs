﻿using VendaVeiculosAPI.Dto.Request;
using VendaVeiculosAPI.Dto.Response;

namespace VendaVeiculosAPI.Services.Interfaces
{
    public interface IArquivoService
    {
        Task<List<ArquivoResponseDto>> GetAllArquivos(CancellationToken token);
        Task<ArquivoResponseDto> GetByIdAsync(Guid id, CancellationToken token);
        Task<ArquivoResponseDto> CreateAsync(ArquivoRequestDto entity, CancellationToken token);
        Task<List<ArquivoResponseDto>> CreateAsync(ArquivoRequestInsertDto entity, CancellationToken token);
        Task<List<ArquivoResponseDto>> CreateRange(List<ArquivoRequestDto> entity, CancellationToken token);
        Task<ArquivoResponseDto> UpdateAsync(Guid id, ArquivoRequestDto entity, CancellationToken token);
        Task<bool> ToggleAsync(Guid id, CancellationToken token);
        Task DeleteArquivo(Guid id, CancellationToken token);
    }
}
