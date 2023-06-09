using AutoMapper;
using VendaVeiculosAPI.Dto.Request;
using VendaVeiculosAPI.Dto.Response;
using VendaVeiculosAPI.Models;

namespace VendaVeiculosAPI.Utils
{
    public class AutoMapperConfig :Profile
    {
        public AutoMapperConfig() 
        {
            CreateMap<UsuarioRequestDto, Usuario>().ReverseMap();
            CreateMap<Usuario, UsuarioResponseDto>();

            CreateMap<CarroRequestDto, Car>();
            CreateMap<Car, CarroResponseDto>();

            CreateMap<CarroArquivoRequestDto, CarroArquivo>();
            CreateMap<CarroArquivo, CarroArquivoResponseDto>();

            CreateMap<UsuarioArquivoRequestDto, UsuarioArquivo>();
            CreateMap<UsuarioArquivo, UsuarioArquivoResponseDto>();

            CreateMap<ArquivoRequestDto,  Arquivo>();
            CreateMap<Arquivo,  ArquivoResponseDto>();
        }
    }
}
