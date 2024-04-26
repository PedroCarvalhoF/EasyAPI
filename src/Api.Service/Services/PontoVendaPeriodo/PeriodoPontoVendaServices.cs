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
                var entities = await _repository.SelectAsync();
                var dtos = _mapper.Map<IEnumerable<PeriodoPontoVendaDto>>(entities);
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
                var entity = await _repository.SelectAsync(id);
                var dto = _mapper.Map<PeriodoPontoVendaDto>(entity);
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
                var entities = await _implementacao.Get(descricao);
                var dtos = _mapper.Map<IEnumerable<PeriodoPontoVendaDto>>(entities);
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
                var entity = _mapper.Map<PeriodoPontoVendaEntity>(create);
                var result = await _repository.InsertAsync(entity);
                var dto = _mapper.Map<PeriodoPontoVendaDto>(result);
                return dto;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<PeriodoPontoVendaDto> Update(PeriodoPontoVendaDtoUpdate update)
        {
            try
            {
                var entity = _mapper.Map<PeriodoPontoVendaEntity>(update);
                var result = await _repository.UpdateAsync(entity);
                var dto = _mapper.Map<PeriodoPontoVendaDto>(result);


                return await Get(result.Id);
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
                var result = await _repository.DesabilitarHabilitar(id);
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
