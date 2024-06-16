using Application.Results;
using Application.UseCases.Commands.PontoVenda.Periodo;
using Application.UseCases.Tools;
using AutoMapper;
using Domain.Dtos;
using Domain.Entities.PontoVendaPeriodoVenda;
using Domain.Interfaces;
using Domain.Interfaces.Repository;
using Domain.UserIdentity.Masters;

namespace Application.UseCases.Handlers.PontoVenda.Periodo
{
    public class PeriodoPontoVendaServiceHandler : IServiceHandler<PeriodoCreateCommand, PeriodoUpdateCommand>
    {
        private readonly IBaseRepository<PeriodoPontoVendaEntity> _repository;
        private readonly IPeriodoPontoVendaRepository _implementacao;
        private readonly IMapper _mapper;
        public PeriodoPontoVendaServiceHandler(IBaseRepository<PeriodoPontoVendaEntity> repository, IPeriodoPontoVendaRepository implementacao, IMapper mapper)
        {
            _repository = repository;
            _implementacao = implementacao;
            _mapper = mapper;
        }

        public async Task<RequestResult> GetAll(UserMasterUserDtoCreate users)
        {
            try
            {
                var entities = await _implementacao.GetAll(users);
                if (entities == null || !entities.Any())
                    return new RequestResult().IsNullOrCountZero();

                return new RequestResult().Ok(_mapper.Map<IEnumerable<PeriodoPontoVendaView>>(entities));
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<RequestResult> GetById(Guid id, UserMasterUserDtoCreate users)
        {
            try
            {
                var entity = await _implementacao.GetById(id, users);
                if (entity == null)
                    return new RequestResult().BadRequest("Não localizado");

                return new RequestResult().Ok(_mapper.Map<PeriodoPontoVendaView>(entity));
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public async Task<RequestResult> Create(PeriodoCreateCommand command, UserMasterUserDtoCreate users)
        {
            var entity = EntityMapper.ParseEndereco(command, users);
            if (!entity.Valida)
                return new RequestResult().EntidadeInvalida();

            var entityCreateResult = await _repository.InsertAsync(entity);

            if (entityCreateResult == null)
                return new RequestResult().BadCreate("Não foi possível criar o período solicitado");

            return new RequestResult().Ok(entityCreateResult);
        }
        public Task<RequestResult> Update(PeriodoUpdateCommand command, UserMasterUserDtoCreate users)
        {
            throw new NotImplementedException();
        }
    }
}
