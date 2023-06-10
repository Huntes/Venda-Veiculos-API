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
            CreateMap<Usuario, UsuarioResponseDto>()
                .ForMember(dest => dest.Senha, opt => opt.Ignore());

            CreateMap<CarroRequestDto, Car>().ReverseMap()
                .ForMember(dest => dest.Fotos, opt => opt.Ignore());
            CreateMap<Car, CarroResponseDto>();

            CreateMap<CarroArquivoRequestDto, CarroArquivo>();
            CreateMap<CarroArquivo, CarroArquivoResponseDto>();

            CreateMap<UsuarioArquivoRequestDto, UsuarioArquivo>();
            CreateMap<UsuarioArquivo, UsuarioArquivoResponseDto>();

            CreateMap<ArquivoRequestDto, Arquivo>()
                .ForMember(dest => dest.NomeArquivo, opt => opt.MapFrom(src => src.Nome))
                .ForMember(dest => dest.TipoArquivo, opt => opt.MapFrom(src => src.Tipo))
                .ForMember(dest => dest.Path, opt => opt.MapFrom(src => src.Base64));

            CreateMap<Arquivo,  ArquivoResponseDto>();
        }
    }
}
