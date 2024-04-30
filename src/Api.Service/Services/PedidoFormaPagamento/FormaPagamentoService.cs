using AutoMapper;
using Domain.Dtos;
using Domain.Dtos.FormaPagamentoDtos;
using Domain.Entities.FormaPagamento;
using Domain.Interfaces;
using Domain.Interfaces.Repository.PedidoFormaPagamento;
using Domain.Interfaces.Services.FormaPagamento;
using Domain.Models.FormaPagamentoModels;

namespace Service.Services.FormaPagamento
{
    public class FormaPagamentoService : IFormaPagamentoService
    {
        private readonly IMapper _mapper;
        private readonly IFormaPagamentoRepository _implementacao;
        private readonly IRepository<FormaPagamentoEntity> _repository;

        public FormaPagamentoService(IMapper mapper, IFormaPagamentoRepository implementacao, IRepository<FormaPagamentoEntity> repository)
        {
            _mapper = mapper;
            _implementacao = implementacao;
            _repository = repository;
        }
        public async Task<ResponseDto<List<FormaPagamentoDto>>> GetAll()
        {
            ResponseDto<List<FormaPagamentoDto>> resposta = new ResponseDto<List<FormaPagamentoDto>>();
            resposta.Dados = new List<FormaPagamentoDto>();
            try
            {
                var entities = await _repository.SelectAsync();
                if (entities == null)
                {
                    resposta.Mensagem = "Nenhuma forma de pagamento localizada.";
                    resposta.Status = false;
                    return resposta;
                }

                var dtos = _mapper.Map<List<FormaPagamentoDto>>(entities);
                resposta.Dados = dtos;
                resposta.Mensagem = $"Formas de pagamentos localizadas: {dtos.Count}";

                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Status = false;
                resposta.Mensagem = $"Erro.Detalhes: {ex.Message}";
                return resposta;
            }
        }
        public async Task<ResponseDto<List<FormaPagamentoDto>>> GetById(Guid id)
        {
            ResponseDto<List<FormaPagamentoDto>> resposta = new ResponseDto<List<FormaPagamentoDto>>();
            resposta.Dados = new List<FormaPagamentoDto>();

            try
            {
                var entity = await _repository.SelectAsync(id);
                if (entity == null)
                {
                    resposta.Mensagem = $"Nenhuma forma de pagamento com este id: {id} localizado.";
                    resposta.Status = false;
                    return resposta;
                }

                var dto = _mapper.Map<FormaPagamentoDto>(entity);
                resposta.Dados.Add(dto);
                resposta.Mensagem = $"Forma de pagamento localizada.";

                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Status = false;
                resposta.Mensagem = $"Erro.Detalhes: {ex.Message}";
                return resposta;
            }
        }
        public async Task<ResponseDto<List<FormaPagamentoDto>>> Create(FormaPagamentoDtoCreate formaPagamentoDtoCreate)
        {
            ResponseDto<List<FormaPagamentoDto>> resposta = new ResponseDto<List<FormaPagamentoDto>>();
            resposta.Dados = new List<FormaPagamentoDto>();

            try
            {
                var model = _mapper.Map<FormaPagamentoModel>(formaPagamentoDtoCreate);
                var entity = _mapper.Map<FormaPagamentoEntity>(model);
                var resultCreate = await _repository.InsertAsync(entity);

                if (resultCreate == null)
                {
                    resposta.Status = false;
                    resposta.Mensagem = "Não foi possível cadastrar forma de pagamento";
                    return resposta;
                }

                var respostaCreate = await GetById(resultCreate.Id);

                respostaCreate.Mensagem = "Forma de pagamento cadastrada com sucesso!";
                respostaCreate.Status = true;

                return respostaCreate;
            }
            catch (Exception ex)
            {
                resposta.Status = false;
                resposta.Mensagem = $"Erro.Detalhes: {ex.Message}";
                return resposta;
            }
        }
        public async Task<ResponseDto<List<FormaPagamentoDto>>> Update(FormaPagamentoDtoUpdate formaPagamentoDtoUpdate)
        {
            ResponseDto<List<FormaPagamentoDto>> resposta = new ResponseDto<List<FormaPagamentoDto>>();
            resposta.Dados = new List<FormaPagamentoDto>();

            try
            {
                var model = _mapper.Map<FormaPagamentoModel>(formaPagamentoDtoUpdate);
                var entity = _mapper.Map<FormaPagamentoEntity>(model);
                var resultUpdate = await _repository.UpdateAsync(entity);

                if (resultUpdate == null)
                {
                    resposta.Status = false;
                    resposta.Mensagem = "Não foi possível realizar alteração";
                    return resposta;
                }

                var respostaCreate = await GetById(resultUpdate.Id);
                respostaCreate.Mensagem = $"Forma pagamento alterada com sucesso!";
                resposta.Status = true;

                return respostaCreate;
            }
            catch (Exception ex)
            {
                resposta.Status = false;
                resposta.Mensagem = $"Erro.Detalhes: {ex.Message}";
                return resposta;
            }
        }
        public async Task<ResponseDto<List<FormaPagamentoDto>>> DesabilitarHabilitar(Guid id)
        {
            ResponseDto<List<FormaPagamentoDto>> resposta = new ResponseDto<List<FormaPagamentoDto>>();
            resposta.Dados = new List<FormaPagamentoDto>();

            try
            {
                var result = await _repository.DesabilitarHabilitar(id);
                if (result)
                {
                    resposta.Mensagem = "Alteração realizada com sucesso!";
                    resposta.Status = true;
                    return resposta;
                }
                else
                {
                    resposta.Mensagem = "Não foi possível realizar alteração.";
                    resposta.Status = false;
                    return resposta;
                }
            }
            catch (Exception ex)
            {
                resposta.Status = false;
                resposta.Mensagem = $"Erro.Detalhes: {ex.Message}";
                return resposta;
            }
        }
    }
}
