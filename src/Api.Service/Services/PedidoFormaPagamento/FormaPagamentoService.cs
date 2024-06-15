using AutoMapper;
using Domain.Dtos;
using Domain.Dtos.FormaPagamentoDtos;
using Domain.Entities.FormaPagamento;
using Domain.Interfaces;
using Domain.Interfaces.Repository.PedidoFormaPagamento;
using Domain.Interfaces.Services.FormaPagamento;
using Domain.UserIdentity.Masters;

namespace Service.Services.FormaPagamento
{
    public class FormaPagamentoService : IFormaPagamentoService
    {
        private readonly IMapper _mapper;
        private readonly IFormaPagamentoRepository _implementacao;
        private readonly IBaseRepository<FormaPagamentoEntity> _repository;

        public FormaPagamentoService(IMapper mapper, IFormaPagamentoRepository implementacao, IBaseRepository<FormaPagamentoEntity> repository)
        {
            _mapper = mapper;
            _implementacao = implementacao;
            _repository = repository;
        }
        public async Task<RequestResult> GetAll(UserMasterUserDtoCreate user)
        {
            try
            {
                var entities = await _implementacao.GetAll(user);
                if (entities == null || entities.Count() == 0)
                    return new RequestResult().IsNullOrCountZero();

                var dtos = _mapper.Map<IEnumerable<FormaPagamentoDto>>(entities);
                return new RequestResult().Ok(dtos);
            }
            catch (Exception ex)
            {
                return new RequestResult().BadRequest(ex.Message);
            }
        }
        public async Task<RequestResult> Create(FormaPagamentoDtoCreate formaPagamentoDtoCreate, UserMasterUserDtoCreate user)
        {
            try
            {
                var entity = new FormaPagamentoEntity(formaPagamentoDtoCreate, user);
                var entityResult = await _repository.InsertAsync(entity);

                if (entityResult == null)
                    return new RequestResult().BadCreate();

                return new RequestResult().Ok(_mapper.Map<FormaPagamentoDto>(entityResult));

            }
            catch (Exception ex)
            {
                return new RequestResult().BadRequest(ex.Message);
            }
        }
        public async Task<RequestResult> Update(FormaPagamentoDtoUpdate formaPagamentoDtoUpdate, UserMasterUserDtoCreate user)
        {
            try
            {
                var entity = new FormaPagamentoEntity(formaPagamentoDtoUpdate, user);

                if (!entity.isBaseValida)
                    return new RequestResult().BadRequest("Não foi possível realizar Update.");

                var entityResult = await _repository.UpdateAsync(entity);

                if (entityResult == null)
                    return new RequestResult().BadUpdate();
          

                return new RequestResult().Ok(_mapper.Map<FormaPagamentoDto>(entityResult));
            }
            catch (Exception ex)
            {
                return new RequestResult().BadRequest(ex.Message);
            }
        }
    }
}
