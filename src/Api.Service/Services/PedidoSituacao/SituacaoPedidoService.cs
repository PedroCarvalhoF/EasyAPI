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
            ResponseDto<List<SituacaoPedidoDto>> resposta = new ResponseDto<List<SituacaoPedidoDto>>();
            resposta.Dados = new List<SituacaoPedidoDto>();
            try
            {
                IEnumerable<SituacaoPedidoEntity> entities = await _repository.SelectAsync();
                if (entities == null)
                {
                    resposta.Status = false;
                    resposta.Mensagem = $"Nenhuma situação de pedido localizada.";
                    return resposta;
                }

                List<SituacaoPedidoDto> dtos = _mapper.Map<List<SituacaoPedidoDto>>(entities);
                resposta.Dados = dtos;

                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Status = false;
                resposta.Mensagem = $"Erro.Detalhes:{ex.Message}";
                return resposta;
            }
        }
        public async Task<ResponseDto<List<SituacaoPedidoDto>>> Get(Guid id)
        {
            ResponseDto<List<SituacaoPedidoDto>> resposta = new ResponseDto<List<SituacaoPedidoDto>>();
            resposta.Dados = new List<SituacaoPedidoDto>();
            try
            {
                SituacaoPedidoEntity entity = await _repository.SelectAsync(id);
                if (entity == null)
                {
                    resposta.Status = false;
                    resposta.Mensagem = $"Nenhuma situação de pedido localizada com este id {id}.";
                    return resposta;
                }

                SituacaoPedidoDto dto = _mapper.Map<SituacaoPedidoDto>(entity);
                resposta.Dados.Add(dto);
                resposta.Mensagem = $"Localizado com sucesso.";

                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Status = false;
                resposta.Mensagem = $"Erro.Detalhes:{ex.Message}";
                return resposta;
            }
        }

        public async Task<ResponseDto<List<SituacaoPedidoDto>>> Get(string descricao)
        {
            ResponseDto<List<SituacaoPedidoDto>> resposta = new ResponseDto<List<SituacaoPedidoDto>>();
            resposta.Dados = new List<SituacaoPedidoDto>();
            try
            {
                IEnumerable<SituacaoPedidoEntity> entities = await _implementacao.Get(descricao);
                if (entities == null)
                {
                    resposta.Status = false;
                    resposta.Mensagem = $"Nenhuma situação de pedido localizada com está descrição: {descricao}.";
                    return resposta;
                }

                List<SituacaoPedidoDto> dtos = _mapper.Map<List<SituacaoPedidoDto>>(entities);
                resposta.Dados = dtos;
                resposta.Mensagem = $"Consulta realizada com sucesso!";

                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Status = false;
                resposta.Mensagem = $"Erro.Detalhes:{ex.Message}";
                return resposta;
            }
        }

        public async Task<ResponseDto<List<SituacaoPedidoDto>>> Create(SituacaoPedidoDtoCreate create)
        {
            ResponseDto<List<SituacaoPedidoDto>> resposta = new ResponseDto<List<SituacaoPedidoDto>>();
            resposta.Dados = new List<SituacaoPedidoDto>();
            try
            {
                SituacaoPedidoModel model = _mapper.Map<SituacaoPedidoModel>(create);
                SituacaoPedidoEntity entity = _mapper.Map<SituacaoPedidoEntity>(model);

                SituacaoPedidoEntity resultCreate = await _repository.InsertAsync(entity);

                if (resultCreate == null)
                {
                    resposta.Status = false;
                    resposta.Mensagem = $"Não foi possível cadastrar";
                    return resposta;

                }

                ResponseDto<List<SituacaoPedidoDto>> created = await Get(resultCreate.Id);
                if (!created.Status)
                {
                    created.Mensagem = "Não foi possíve realizar cadastrado";
                    created.Status = false;
                    return created;
                }
                created.Mensagem = "Situação cadastrada com sucesso!";
                return created;

            }
            catch (Exception ex)
            {
                resposta.Status = false;
                resposta.Mensagem = $"Erro.Detalhes:{ex.Message}";
                return resposta;
            }

        }

        public async Task<ResponseDto<List<SituacaoPedidoDto>>> Update(SituacaoPedidoDtoUpdate update)
        {
            ResponseDto<List<SituacaoPedidoDto>> resposta = new ResponseDto<List<SituacaoPedidoDto>>();
            resposta.Dados = new List<SituacaoPedidoDto>();
            try
            {
                SituacaoPedidoModel model = _mapper.Map<SituacaoPedidoModel>(update);
                SituacaoPedidoEntity entity = _mapper.Map<SituacaoPedidoEntity>(model);
                SituacaoPedidoEntity resultUpdate = await _repository.UpdateAsync(entity);
                if (resultUpdate == null)
                {
                    resposta.Status = false;
                    resposta.Mensagem = "Não foi possível realizar alteração.";
                    return resposta;
                }

                resposta = await Get(resultUpdate.Id);
                resposta.Mensagem = $"Situação alterada com sucesso!";

                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Status = false;
                resposta.Mensagem = $"Erro.Detalhes:{ex.Message}";
                return resposta;
            }
        }
        public async Task<ResponseDto<List<SituacaoPedidoDto>>> Desabilitar(Guid id)
        {
            ResponseDto<List<SituacaoPedidoDto>> resposta = new ResponseDto<List<SituacaoPedidoDto>>();
            resposta.Dados = new List<SituacaoPedidoDto>();
            try
            {
                bool result = await _repository.DesabilitarHabilitar(id);
                if (result)
                {
                    resposta.Status = true;
                    resposta.Mensagem = "Situação Desabilitada";
                    return resposta;
                }
                else
                {
                    resposta.Status = false;
                    resposta.Mensagem = "Não foi possível desabilitar";
                    return resposta;
                }
            }
            catch (Exception ex)
            {
                resposta.Status = false;
                resposta.Mensagem = $"Erro.Detalhes:{ex.Message}";
                return resposta;
            }
        }
    }
}
