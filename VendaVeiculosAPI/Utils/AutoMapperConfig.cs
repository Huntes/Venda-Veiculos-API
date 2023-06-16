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
            CreateMap<Car, CarroResponseDto>()
                .ForMember(dest => dest.Fotos, opt => opt.MapFrom(src => 
                src.Arquivos.Select(c => new ArquivoResponseDto(c.Arquivo))));

            CreateMap<CarroArquivoRequestDto, CarroArquivo>();
            CreateMap<CarroArquivo, CarroArquivoResponseDto>();

            CreateMap<ArquivoRequestDto, Arquivo>()
                .ForMember(dest => dest.NomeArquivo, opt => opt.MapFrom(src => src.Nome))
                .ForMember(dest => dest.TipoArquivo, opt => opt.MapFrom(src => src.Tipo))
                .ForMember(dest => dest.Path, opt => opt.MapFrom(src => src.Path));

            CreateMap<Arquivo,  ArquivoResponseDto>();
        }
    }
}
