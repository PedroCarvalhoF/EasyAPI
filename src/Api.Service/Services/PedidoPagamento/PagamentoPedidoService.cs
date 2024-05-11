using AutoMapper;
using Domain.Dtos;
using Domain.Dtos.PagamentoPedidoDtos;
using Domain.Dtos.PedidoPagamento;
using Domain.Entities.PagamentoPedido;
using Domain.Interfaces;
using Domain.Interfaces.Repository.PedidoPagamento;
using Domain.Interfaces.Services.PagamentoPedido;
using Domain.Models.PagamentoPedidoModels;

namespace Service.Services.PagamentoPedidoServices
{
    public class PagamentoPedidoService : IPagamentoPedidoService
    {
        private readonly IMapper _mapper;
        private readonly IPagamentoPedidoRepository _implementacao;
        private readonly IRepository<PagamentoPedidoEntity> _repository;


        public PagamentoPedidoService(IMapper mapper,
                                      IPagamentoPedidoRepository pagamentoPedidoRepository,
                                      IRepository<PagamentoPedidoEntity> repository)
        {
            _mapper = mapper;
            _implementacao = pagamentoPedidoRepository;
            _repository = repository;
        }



        public async Task<ResponseDto<List<PagamentoPedidoDto>>> GetAll()
        {
            ResponseDto<List<PagamentoPedidoDto>> response = new ResponseDto<List<PagamentoPedidoDto>>();
            response.Dados = new List<PagamentoPedidoDto>();
            try
            {
                var entity = await _implementacao.GetAll();
                if (entity == null)
                {
                    response.ErroConsulta();
                    return response;
                }

                var dtos = _mapper.Map<List<PagamentoPedidoDto>>(entity);
                response.Dados = dtos;
                response.ConsultaOk(dtos.Count());
                return response;
            }
            catch (Exception ex)
            {
                response.ErroConsulta("Item Pedido: ", ex.Message);
                return response;
            }
        }

        public async Task<ResponseDto<List<PagamentoPedidoDto>>> GetPagamentoPedidoByIdPedido(Guid pedidoId)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseDto<List<PagamentoPedidoDto>>> CreatePagamentoPedido(PagamentoPedidoDtoCreate pgPedido)
        {
            ResponseDto<List<PagamentoPedidoDto>> response = new ResponseDto<List<PagamentoPedidoDto>>();
            response.Dados = new List<PagamentoPedidoDto>();
            try
            {
                var model = _mapper.Map<PagamentoPedidoModel>(pgPedido);
                var entity = _mapper.Map<PagamentoPedidoEntity>(model);

                var exists = await _implementacao.Exists(pgPedido.PedidoEntityId, pgPedido.FormaPagamentoEntityId);

                if (exists == null)
                {
                    var create = await _repository.InsertAsync(entity);

                    if (create == null)
                    {
                        response.ErroCadastro();
                        return response;
                    }

                    var resultCreate = await _repository.SelectAsync(create.Id);
                    var dto = _mapper.Map<PagamentoPedidoDto>(resultCreate);
                    response.Dados.Add(dto);
                    response.CadastroOk();
                }
                else
                {
                    // exists.ValorPago = pgPedido.ValorPago; DEVE SER FEITO NA MODEL!!!!!! AJUSTAR DEPOIS
                    exists.ValorPago = pgPedido.ValorPago;

                    var update = await _repository.UpdateAsync(exists);

                    if (update == null)
                    {
                        response.ErroUpdate();
                        return response;
                    }

                    var resultUpdate = await _repository.SelectAsync(update.Id);
                    var dto = _mapper.Map<PagamentoPedidoDto>(resultUpdate);
                    response.Dados.Add(dto);
                    response.CadastroOk();
                }

                return response;


            }
            catch (Exception ex)
            {
                response.ErroConsulta("Item Pedido: ", ex.Message);
                return response;
            }
        }
        public async Task<ResponseDto<List<PagamentoPedidoDto>>> UpdatePagamentoPedido(PagamentoPedidoDtoUpdate pgUpdate)
        {
            throw new NotImplementedException();
        }
    }
}