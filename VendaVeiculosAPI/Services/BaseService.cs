using AutoMapper;
using VendaVeiculosAPI.Models;

namespace VendaVeiculosAPI.Services
{
    public class BaseService<Model, RequestDto, ResponseDto>
        where Model: class
        where RequestDto: class
        where ResponseDto: class
    {
        protected readonly IMapper _mapper;

        public BaseService(IMapper mapper)
        {
            _mapper = mapper;
        }

        protected Model ConverRequestDtoToModel(RequestDto dto) => _mapper.Map<Model>(dto);
        protected ICollection<Model> ConvertRequestDtoToModel(ICollection<RequestDto> dto) => _mapper.Map<ICollection<Model>>(dto);
        protected ResponseDto ConvertModelToResponseDto(Model model) => _mapper.Map<ResponseDto>(model); 

        protected PagedList<ResponseDto> ConvertModelToPagedListResponse(PagedList<Model> pagedList)
        {
            return new PagedList<ResponseDto>
            {
                Data = _mapper.Map<List<ResponseDto>>(pagedList.Data),
                Total = pagedList.Total,
                Pages = pagedList.Pages,
            };
        }
    }
}
