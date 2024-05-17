using AutoMapper;
using Domain.Dtos;
using Domain.Dtos.PedidoSituacao;
using Domain.Entities.PedidoSituacao;
using Domain.Interfaces;
using Domain.Interfaces.Repository.PedidoSituacao;
using Domain.Interfaces.Services.PedidoSituacao;
using Domain.Models.PedidoSituacao;

namespace Service.Services.PedidoSituacao
{
    public class SituacaoPedidoService : ISituacaoPedidoService
    {
        private readonly IRepository<SituacaoPedidoEntity> _repository;
        private readonly IMapper _mapper;
        private readonly ISituacaoPedidoRepository _implementacao;

        public SituacaoPedidoService(IRepository<SituacaoPedidoEntity> repository, IMapper mapper, ISituacaoPedidoRepository implementacao)
        {
            _repository = repository;
            _mapper = mapper;
            _implementacao = implementacao;
        }
        public async Task<ResponseDto<List<SituacaoPedidoDto>>> GetAll()
        {
            var resposta = new ResponseDto<List<SituacaoPedidoDto>>();

            try
            {
                var entities = await _repository.SelectAsync();

                if (entities == null || entities.Count() == 0)
                {
                    return resposta.EntitiesNull();
                }

                return resposta.Retorno(_mapper.Map<List<SituacaoPedidoDto>>(entities));
            }
            catch (Exception ex)
            {
                return resposta.Erro(ex);
            }
        }
        public async Task<ResponseDto<List<SituacaoPedidoDto>>> Get(Guid id)
        {
            var resposta = new ResponseDto<List<SituacaoPedidoDto>>();
            try
            {
                var entity = await _repository.SelectAsync(id);
                if (entity == null)
                {
                    return resposta.EntitiesNull();
                }

                var dto = _mapper.Map<SituacaoPedidoDto>(entity);
                resposta.Dados = new List<SituacaoPedidoDto>() { dto };

                return resposta.ConsultaOk();
            }
            catch (Exception ex)
            {
                return resposta.Erro(ex);
            }
        }

        public async Task<ResponseDto<List<SituacaoPedidoDto>>> Get(string descricao)
        {
            var resposta = new ResponseDto<List<SituacaoPedidoDto>>();

            try
            {
                var entities = await _implementacao.Get(descricao);

                if (entities == null || entities.Count() == 0)
                {
                    return resposta.EntitiesNull();
                }

                return resposta.Retorno(_mapper.Map<List<SituacaoPedidoDto>>(entities));
            }
            catch (Exception ex)
            {
                return resposta.Erro(ex);
            }
        }

        public async Task<ResponseDto<List<SituacaoPedidoDto>>> Create(SituacaoPedidoDtoCreate create)
        {
            var resposta = new ResponseDto<List<SituacaoPedidoDto>>();

            try
            {
                var model = _mapper.Map<SituacaoPedidoModel>(create);
                var entity = _mapper.Map<SituacaoPedidoEntity>(model);

                var resultCreate = await _repository.InsertAsync(entity);

                if (resultCreate == null)
                {
                    return resposta.EntitiesNull();
                }

                var verificaCreate = await Get(resultCreate.Id);

                if (verificaCreate.Status)
                {
                    return verificaCreate.CadastroOk();
                }
                else
                {
                    return verificaCreate.ErroCadastro();
                }
            }
            catch (Exception ex)
            {
                return resposta.Erro(ex);
            }
        }

        public async Task<ResponseDto<List<SituacaoPedidoDto>>> Update(SituacaoPedidoDtoUpdate update)
        {
            var resposta = new ResponseDto<List<SituacaoPedidoDto>>();

            try
            {
                var model = _mapper.Map<SituacaoPedidoModel>(update);
                var entity = _mapper.Map<SituacaoPedidoEntity>(model);
                var resultUpdate = await _repository.UpdateAsync(entity);

                if (resultUpdate == null)
                {
                    return resposta.EntitiesNull();
                }

                resposta = await Get(resultUpdate.Id);
                if (resposta.Status)
                    return resposta.UpdateOk();
                else
                    return resposta.ErroUpdate();
            }
            catch (Exception ex)
            {
                return resposta.Erro(ex);
            }
        }
        public async Task<ResponseDto<List<SituacaoPedidoDto>>> Desabilitar(Guid id)
        {
            var resposta = new ResponseDto<List<SituacaoPedidoDto>>();

            try
            {
                bool result = await _repository.DesabilitarHabilitar(id);
                
                if (result)
                {
                    return resposta.AlteracaoOk();
                }
                else
                {
                    return resposta.ErroUpdate();
                }
            }
            catch (Exception ex)
            {
                return resposta.Erro(ex);
            }
        }
    }
}
