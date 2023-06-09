﻿using AutoMapper;
using VendaVeiculosAPI.Dto.Request;
using VendaVeiculosAPI.Dto.Response;
using VendaVeiculosAPI.Models;
using VendaVeiculosAPI.Repositories.Interfaces;
using VendaVeiculosAPI.Services.Interfaces;

namespace VendaVeiculosAPI.Services.Impl
{
    public class CarroArquivoService : BaseService<CarroArquivo, CarroArquivoRequestDto, CarroArquivoResponseDto>, ICarroArquivoService
    {
        private readonly ICarroArquivoRepository _carroArquivoRepository;
        private readonly ICarroRepository _carroRepository;
        private readonly IArquivoRepository _arquivoRepository; 

        public CarroArquivoService(ICarroArquivoRepository repository, ICarroRepository carroRepository, IArquivoRepository arquivoRepository, IMapper mapper) : base(mapper)
        {
            _carroArquivoRepository = repository;
            _carroRepository = carroRepository;
            _arquivoRepository = arquivoRepository;
        }

        public async Task<CarroArquivoResponseDto> CreateAsync(CarroArquivoRequestDto entity, CancellationToken token)
        {
            var Carro = await _carroRepository.GetByIdAsync(entity.IdCarro, token);
            if (Carro == null) { throw new NullReferenceException("O carro não foi encotnrado"); }

            var Arquivo = await _arquivoRepository.GetArquivoById(entity.IdArquivo, token);
            if (Arquivo == null) { throw new NullReferenceException("O carro não foi encotnrado"); }

            var CarroArquivo = ConverRequestDtoToModel(entity);
            await _carroArquivoRepository.CreateAsync(CarroArquivo, token);
            await _carroArquivoRepository.SaveChangesAsync(token)
                ;
            return ConvertModelToResponseDto(CarroArquivo);
        }

        public async Task DeleteCarroArquivo(Guid id, CancellationToken token)
        {
            await _carroArquivoRepository.DeleteCarroArquivo(id, token);
            await _carroArquivoRepository.SaveChangesAsync(token);
        }

        public async Task<List<CarroArquivoResponseDto>> GetArquivosByIdCarroAsync(Guid idCarro, CancellationToken token)
        {
            var _listCarroArquivos = await _carroArquivoRepository.GetArquivosByIdCarroAsync(idCarro, token);
            return ConvertModelToResponseDto(_listCarroArquivos);
        }

        public async Task<bool> ToggleAsync(Guid id, CancellationToken token)
        {
            return await _carroArquivoRepository.ToggleAsync(id, token);
        }
    }
}