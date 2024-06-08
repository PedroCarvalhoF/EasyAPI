using AutoMapper;
using Domain.Dtos;
using Domain.Dtos.PontoVendaPeriodoVendaDtos;
using Domain.Entities.PontoVendaPeriodoVenda;
using Domain.Interfaces;
using Domain.Interfaces.Repository;
using Domain.Interfaces.Services.PeriodoPontoVenda;

namespace Service.Services.PeriodoPontoVenda
{
    public class PeriodoPontoVendaServices : IPeriodoPontoVendaService
    {
        private readonly IMapper _mapper;
        private readonly IBaseRepository<PeriodoPontoVendaEntity> _repository;
        private readonly IPeriodoPontoVendaRepository _implementacao;

        public PeriodoPontoVendaServices(IMapper mapper, IBaseRepository<PeriodoPontoVendaEntity> repository, IPeriodoPontoVendaRepository implementacao)
        {
            _mapper = mapper;
            _repository = repository;
            _implementacao = implementacao;
        }

        public async Task<ResponseDto<List<PeriodoPontoVendaDto>>> GetAll()
        {
            ResponseDto<List<PeriodoPontoVendaDto>> response = new ResponseDto<List<PeriodoPontoVendaDto>>();
            response.Dados = new List<PeriodoPontoVendaDto>();
            try
            {
                var entities = await _repository.SelectAsync();

                if (entities == null)
                {
                    response.ErroConsulta();
                    return response;
                }

                var dtos = _mapper.Map<List<PeriodoPontoVendaDto>>(entities);

                response.Dados = dtos;
                return response;
            }
            catch (Exception ex)
            {
                response.Erro(ex.Message);
                return response;
            }
        }
        public async Task<ResponseDto<List<PeriodoPontoVendaDto>>> Get(Guid id)
        {
            ResponseDto<List<PeriodoPontoVendaDto>> response = new ResponseDto<List<PeriodoPontoVendaDto>>();
            response.Dados = new List<PeriodoPontoVendaDto>();
            try
            {
                var entity = await _repository.SelectAsync(id);
                var dto = _mapper.Map<PeriodoPontoVendaDto>(entity);

                response.Dados.Add(dto);
                return response;
            }
            catch (Exception ex)
            {
                response.Erro(ex.Message);
                return response;
            }
        }
        public async Task<ResponseDto<List<PeriodoPontoVendaDto>>> Get(string descricao)
        {
            ResponseDto<List<PeriodoPontoVendaDto>> response = new ResponseDto<List<PeriodoPontoVendaDto>>();
            response.Dados = new List<PeriodoPontoVendaDto>();

            try
            {
                var entities = await _implementacao.Get(descricao);
                var dtos = _mapper.Map<List<PeriodoPontoVendaDto>>(entities);

                response.Dados = dtos;
                return response;
            }
            catch (Exception ex)
            {
                response.Erro(ex.Message);
                return response;
            }
        }
        public async Task<ResponseDto<List<PeriodoPontoVendaDto>>> Create(PeriodoPontoVendaDtoCreate create)
        {
            ResponseDto<List<PeriodoPontoVendaDto>> response = new ResponseDto<List<PeriodoPontoVendaDto>>();
            response.Dados = new List<PeriodoPontoVendaDto>();

            try
            {
                var entity = _mapper.Map<PeriodoPontoVendaEntity>(create);
                var result = await _repository.InsertAsync(entity);
                var dto = _mapper.Map<PeriodoPontoVendaDto>(result);

                response.Dados.Add(dto);
                return response;
            }
            catch (Exception ex)
            {
                response.Erro(ex.Message);
                return response;
            }
        }
        public async Task<ResponseDto<List<PeriodoPontoVendaDto>>> Desabilitar(Guid id)
        {
            ResponseDto<List<PeriodoPontoVendaDto>> response = new ResponseDto<List<PeriodoPontoVendaDto>>();
            response.Dados = new List<PeriodoPontoVendaDto>();

            try
            {
                var result = await _repository.DesabilitarHabilitar(id);
                if (result)
                {
                    response.AlteracaoOk();
                    return response;
                }
                else
                {
                    response.ErroUpdate();
                    return response;
                }
            }
            catch (Exception ex)
            {
                response.Erro(ex.Message);
                return response;
            }
        }
    }
}
