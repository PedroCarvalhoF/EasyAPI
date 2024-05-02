using AutoMapper;
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
        private readonly IRepository<PeriodoPontoVendaEntity> _repository;
        private readonly IPeriodoPontoVendaRepository _implementacao;

        public PeriodoPontoVendaServices(IMapper mapper, IRepository<PeriodoPontoVendaEntity> repository, IPeriodoPontoVendaRepository implementacao)
        {
            _mapper = mapper;
            _repository = repository;
            _implementacao = implementacao;
        }

        public async Task<IEnumerable<PeriodoPontoVendaDto>> GetAll()
        {
            try
            {
                IEnumerable<PeriodoPontoVendaEntity> entities = await _repository.SelectAsync();
                IEnumerable<PeriodoPontoVendaDto> dtos = _mapper.Map<IEnumerable<PeriodoPontoVendaDto>>(entities);
                return dtos;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<PeriodoPontoVendaDto> Get(Guid id)
        {
            try
            {
                PeriodoPontoVendaEntity entity = await _repository.SelectAsync(id);
                PeriodoPontoVendaDto dto = _mapper.Map<PeriodoPontoVendaDto>(entity);
                return dto;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<PeriodoPontoVendaDto>> Get(string descricao)
        {
            try
            {
                IEnumerable<PeriodoPontoVendaEntity> entities = await _implementacao.Get(descricao);
                IEnumerable<PeriodoPontoVendaDto> dtos = _mapper.Map<IEnumerable<PeriodoPontoVendaDto>>(entities);
                return dtos;
            }
            catch (Exception)
            {

                throw;
            }
        }


        public async Task<PeriodoPontoVendaDto> Create(PeriodoPontoVendaDtoCreate create)
        {
            try
            {
                PeriodoPontoVendaEntity entity = _mapper.Map<PeriodoPontoVendaEntity>(create);
                PeriodoPontoVendaEntity result = await _repository.InsertAsync(entity);
                PeriodoPontoVendaDto dto = _mapper.Map<PeriodoPontoVendaDto>(result);
                return dto;
            }
            catch (Exception)
            {

                throw;
            }
        }


        public async Task<bool> Desabilitar(Guid id)
        {
            try
            {
                bool result = await _repository.DesabilitarHabilitar(id);
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
