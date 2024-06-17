using Api.Domain.Dtos.PontoVendaDtos;
using Api.Domain.Entities.PontoVenda;
using Application.UseCases.Commands.PontoVenda;
using Application.UseCases.Tools;
using Application.UseCases.Tools.ViewsFromEntities;
using AutoMapper;
using Domain.Dtos;
using Domain.Interfaces;
using Domain.Interfaces.Repository.PontoVenda;
using Domain.UserIdentity.Masters;

namespace Application.UseCases.Handlers.PontoVenda
{
    public class PontoVendaServiceHandler : IServiceHandler<PontoVendaCreateCommand, PontoVendaEncerrarCommand>
    {
        private readonly IPontoVendaRepository _implementacao;
        private readonly IBaseRepository<PontoVendaEntity> _repository;
        private readonly IMapper _mapper;

        public PontoVendaServiceHandler(IPontoVendaRepository implementacao, IBaseRepository<PontoVendaEntity> repository, IMapper mapper)
        {
            _implementacao = implementacao;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<RequestResult> GetAll(UserMasterUserDtoCreate users)
        {
            try
            {
                var entities = await _implementacao.GetAll(users);
                if (entities == null || !entities.Any())
                    return new RequestResult().IsNullOrCountZero();

                return new RequestResult().Ok(PontoVendaFromEntities.ListPontoVendaView(entities));
            }
            catch (Exception ex)
            {
                return new RequestResult().BadRequest(ex.Message);
            }
        }

        public async Task<RequestResult> GetById(Guid id, UserMasterUserDtoCreate users)
        {
            try
            {
                var entity = await _implementacao.GetById(id, users);
                if (entity == null)
                    return new RequestResult().IsNullOrCountZero();

                return new RequestResult().Ok(_mapper.Map<PontoVendaDto>(entity));
            }
            catch (Exception ex)
            {
                return new RequestResult().BadRequest(ex.Message);
            }
        }
        public async Task<RequestResult> Create(PontoVendaCreateCommand command, UserMasterUserDtoCreate users)
        {
            try
            {
                var entity = EntityMapper.ParcePontoVenda(command, users);
                if (!entity.Validada)
                    return new RequestResult().EntidadeInvalida();

                var entityCreateResult = await _repository.InsertAsync(entity);

                if (entityCreateResult == null)
                    return new RequestResult().BadCreate("Não foi possível criar ponto de venda");

                return new RequestResult().Ok(entityCreateResult);
            }
            catch (Exception ex)
            {
                return new RequestResult().BadRequest(ex.Message);
            }


        }
        public async Task<RequestResult> Update(PontoVendaEncerrarCommand command, UserMasterUserDtoCreate users)
        {
            try
            {
                var entity = await _implementacao.GetById(command.Id, users);
                entity.EncerrarPontoVendaEntity();

                if (!entity.Validada)
                    return new RequestResult().EntidadeInvalida();

                return new RequestResult().Ok("Ponto de venda encerrado com sucesso.");
                
            }
            catch (Exception ex)
            {
                return new RequestResult().BadRequest(ex.Message);
            }
        }
    }
}
