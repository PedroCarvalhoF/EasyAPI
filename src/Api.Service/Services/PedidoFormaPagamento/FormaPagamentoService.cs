using AutoMapper;
using Domain.Dtos;
using Domain.Dtos.FormaPagamentoDtos;
using Domain.Entities.FormaPagamento;
using Domain.Interfaces;
using Domain.Interfaces.Repository.PedidoFormaPagamento;
using Domain.Interfaces.Services.FormaPagamento;
using Domain.Models.FormaPagamentoModels;
using Domain.UserIdentity.MasterUsers;

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
        public async Task<RequestResult> GetAll(UserMasterUserEntity user)
        {

            try
            {
                var entities = await _repository.SelectAsync(user);
                if (entities == null)
                {
                    return new RequestResult().BadRequest("Nenhum resultado encontrado");
                }

                var dtos = _mapper.Map<IEnumerable<FormaPagamentoDto>>(entities);
                return new RequestResult().Ok(dtos);
            }
            catch (Exception ex)
            {
                return new RequestResult().BadRequest(ex.Message);
            }
        }
        public async Task<ResponseDto<List<FormaPagamentoDto>>> GetById(Guid id, UserMasterUserEntity user)
        {
            var resposta = new ResponseDto<List<FormaPagamentoDto>>();

            try
            {
                var entity = await _repository.SelectAsync(id, user);
                if (entity == null)
                {
                    return resposta.EntitiesNull();
                }

                var dto = _mapper.Map<FormaPagamentoDto>(entity);
                resposta.Dados = new List<FormaPagamentoDto> { dto };
                return resposta;
            }
            catch (Exception ex)
            {
                return resposta.Erro(ex);
            }
        }
        public async Task<ResponseDto<List<FormaPagamentoDto>>> GetByDescricao(string descricao, UserMasterUserEntity user)
        {
            var resposta = new ResponseDto<List<FormaPagamentoDto>>();

            try
            {
                var entities = await _implementacao.GetByDescricao(descricao);
                if (entities == null)
                {
                    return resposta.EntitiesNull();
                }

                if (entities.Count() == 0)
                {
                    return resposta.EntitiesNull();
                }

                var dto = _mapper.Map<List<FormaPagamentoDto>>(entities);
                return resposta.Retorno(dto);

            }
            catch (Exception ex)
            {
                return resposta.Erro(ex);
            }
        }
        public async Task<ResponseDto<List<FormaPagamentoDto>>> Create(FormaPagamentoDtoCreate formaPagamentoDtoCreate, UserMasterUserEntity user)
        {
            var resposta = new ResponseDto<List<FormaPagamentoDto>>();
            try
            {

                var model = _mapper.Map<FormaPagamentoModel>(formaPagamentoDtoCreate);
                var entity = _mapper.Map<FormaPagamentoEntity>(model);
                var resultCreate = await _repository.InsertAsync(entity, user);

                if (resultCreate == null)
                {
                    return resposta.EntitiesNull();
                }

                var respostaCreate = await GetById(resultCreate.Id, user);

                if (respostaCreate.Status)
                {
                    return respostaCreate.CadastroOk();
                }
                else
                {
                    return resposta.ErroCadastro();
                }

            }
            catch (Exception ex)
            {
                return resposta.Erro(ex);
            }
        }
        public async Task<ResponseDto<List<FormaPagamentoDto>>> Update(FormaPagamentoDtoUpdate formaPagamentoDtoUpdate, UserMasterUserEntity user)
        {
            var resposta = new ResponseDto<List<FormaPagamentoDto>>();

            try
            {
                var model = _mapper.Map<FormaPagamentoModel>(formaPagamentoDtoUpdate);
                var entity = _mapper.Map<FormaPagamentoEntity>(model);
                var resultUpdate = await _repository.UpdateAsync(entity, user);

                if (resultUpdate == null)
                {
                    return resposta.EntitiesNull();
                }

                var respostaCreate = await GetById(resultUpdate.Id, user);
                if (respostaCreate.Status)
                    return respostaCreate;
                else
                    return respostaCreate.ErroUpdate();
            }
            catch (Exception ex)
            {
                return resposta.Erro(ex);
            }
        }
        public async Task<ResponseDto<List<FormaPagamentoDto>>> DesabilitarHabilitar(Guid id, UserMasterUserEntity user)
        {
            var resposta = new ResponseDto<List<FormaPagamentoDto>>();

            try
            {
                bool result = await _repository.DesabilitarHabilitar(id, user);
                if (result)
                    return resposta.AlteracaoOk();
                else
                    return resposta.ErroUpdate();
            }
            catch (Exception ex)
            {
                return resposta.Erro(ex);
            }
        }
    }
}
