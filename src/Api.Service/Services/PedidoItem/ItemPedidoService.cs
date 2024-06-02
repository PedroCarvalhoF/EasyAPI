using Api.Domain.Dtos.PedidoDtos;
using Api.Domain.Entities.Pedido;
using Api.Domain.Interfaces.Services.Pedido;
using AutoMapper;
using Domain.Dtos;
using Domain.Dtos.ItemPedido;
using Domain.Dtos.PedidoItem;
using Domain.Entities.ItensPedido;
using Domain.Entities.PedidoSituacao.Ferramentas;
using Domain.Entities.Produto;
using Domain.Interfaces;
using Domain.Interfaces.Repository;
using Domain.Interfaces.Repository.Pedido;
using Domain.Interfaces.Repository.PontoVendaUser;
using Domain.Interfaces.Services.ItemPedido;
using Domain.Models.ItemPedidoModels;
using System.Diagnostics;

namespace Service.Services.ItemPedidoService
{
    public class ItemPedidoService : IItemPedidoService
    {
        private readonly IItemPedidoRepository? _implementacao;
        private readonly IRepository<ItemPedidoEntity>? _repository;
        private readonly IMapper? _mapper;

        private readonly IRepository<ProdutoEntity> _produtoRepository;
        private readonly IRepository<PedidoEntity> _pedidoRepository;
        private readonly IPedidoRepository _pedidoImplementacao;
        private readonly IUsuarioPontoVendaRepository _usuarioPontoVendaRepository;
        private readonly IPedidoService _pedidoService;

        public ItemPedidoService(IItemPedidoRepository? implementacao,
                                 IRepository<ItemPedidoEntity>? repository,
                                 IMapper? mapper,
                                 IRepository<ProdutoEntity> produtoRepository,
                                 IRepository<PedidoEntity> pedidoRepository,
                                 IPedidoRepository pedidoImplementacao,
                                 IUsuarioPontoVendaRepository usuarioPontoVendaRepository,
                                 IPedidoService pedidoService)
        {
            _implementacao = implementacao;
            _repository = repository;
            _mapper = mapper;
            _produtoRepository = produtoRepository;
            _pedidoRepository = pedidoRepository;
            _usuarioPontoVendaRepository = usuarioPontoVendaRepository;
            _pedidoService = pedidoService;
            _pedidoImplementacao = pedidoImplementacao;
        }
        public async Task<ResponseDto<List<ItemPedidoDto>>> GetAll()
        {
            var response = new ResponseDto<List<ItemPedidoDto>>();

            try
            {
                var entity = await _implementacao!.GetAll();
                if (entity == null || entity.Count() == 0)
                {
                    response.EntitiesNull();
                    return response;
                }

                var dtos = _mapper.Map<List<ItemPedidoDto>>(entity);
                return response.Retorno(dtos);
            }
            catch (Exception ex)
            {
                return response.Erro(ex);
            }
        }
        public async Task<ResponseDto<List<ItemPedidoDto>>> Get(Guid id)
        {
            var response = new ResponseDto<List<ItemPedidoDto>>();

            try
            {
                var entity = await _implementacao!.Get(id);
                if (entity == null)
                {
                    response.EntitiesNull();
                    return response;
                }

                var dto = _mapper.Map<ItemPedidoDto>(entity);
                response.Dados = new List<ItemPedidoDto>() { dto };
                return response.ConsultaOk();
            }
            catch (Exception ex)
            {
                return response.Erro(ex);
            }
        }
        public async Task<ResponseDto<List<ItemPedidoDto>>> GetByIdPedido(Guid idPedido)
        {
            var response = new ResponseDto<List<ItemPedidoDto>>();

            try
            {
                var entity = await _implementacao!.GetByIdPedido(idPedido);
                if (entity == null)
                {
                    response.EntitiesNull();
                    return response;
                }

                var dto = _mapper.Map<ItemPedidoDto>(entity);
                response.Dados.Add(dto);
                return response.ConsultaOk();
            }
            catch (Exception ex)
            {
                return response.Erro(ex);
            }
        }
        public async Task<ResponseDto<List<ItemPedidoDto>>> InserirItemNoPedido(ItemPedidoDtoCreate itemPedidoCreate)
        {
            var response = new ResponseDto<List<ItemPedidoDto>>();

            if (itemPedidoCreate.UsuarioPontoVendaEntityId == Guid.Empty)
            {
                return response.Erro("Usuário não localizado");
            }

            try
            {
                var model = _mapper.Map<ItemPedidoModel>(itemPedidoCreate);
                model.GerarItemPedido();

                //verificar se produto existe
                var produtoExits = await _produtoRepository.ExistAsync(itemPedidoCreate.ProdutoEntityId);
                if (!produtoExits)
                {
                    return response.Erro("Produto não localizado");
                }

                // verificar se pedido existe e se esta aberto
                var pedidoExists = await _pedidoRepository.ExistAsync(itemPedidoCreate.PedidoEntityId);
                if (!pedidoExists)
                {
                    return response.Erro("Pedido não localizado");
                }

                var pedido = await _pedidoRepository.SelectAsync(itemPedidoCreate.PedidoEntityId);

                //NAO ALTERAR GUID!!!!!!!
                if (pedido.SituacaoPedidoEntityId == Guid.Parse("11b17cc5-c8b1-48f9-b9fd-886339441328"))
                {
                    return response.Erro("Não é possivel inserir item em um pedido cancelado.");
                }

                //verificar se usuario ponto de venda existe

                var user = await _usuarioPontoVendaRepository.GetByIdUser(itemPedidoCreate.UsuarioPontoVendaEntityId);
                if (user == null)
                {
                    return response.Erro("Usuário não localizado.");
                }

                var entity = _mapper.Map<ItemPedidoEntity>(model);

                var entityResult = await _repository!.InsertAsync(entity);

                if (entityResult == null)
                {
                    response.ErroCadastro();
                    return response;
                }

                var result = await _implementacao!.Get(entityResult.Id);

                if (result == null)
                {
                    response.ErroCadastro();
                    return response;
                }

                //APOS INSERIR ITEM - PRECISA ALTUALIZAR VALOR DO PEDIDO
                var pedidoAtualizar = await _pedidoService.AtualizarValorPedido(itemPedidoCreate.PedidoEntityId);

                if (pedidoAtualizar == null)
                {
                    return response.Erro("Erro CRITICO. Inconsistência no sistema. Item do pedido foi inserido com sucesso, porém ao atualizar valor do pedido não foi possível.");
                }
                if (!pedidoAtualizar.Status)
                {
                    return response.Erro("Erro CRITICO. Inconsistência no sistema. Item do pedido foi inserido com sucesso, porém ao atualizar valor do pedido não foi possível.");
                }


                var dto = _mapper.Map<ItemPedidoDto>(result);

                response.Dados = new List<ItemPedidoDto>() { dto };
                response.CadastroOk();

                return response;
            }
            catch (Exception ex)
            {
                return response.Erro(ex);
            }
        }
        public async Task<ResponseDto<List<PedidoDto>>> InserirItemNoPedidoReturnPedido(ItemPedidoDtoCreate itemPedidoCreate)
        {

            var response = new ResponseDto<List<PedidoDto>>();

            if (itemPedidoCreate.UsuarioPontoVendaEntityId == Guid.Empty)
            {
                return response.Erro("Usuário não localizado");
            }

            try
            {
                Stopwatch stop = Stopwatch.StartNew();

                var model = _mapper.Map<ItemPedidoModel>(itemPedidoCreate);
                model.GerarItemPedido();


                //verificar se produto existe
                var produtoExits = await _produtoRepository.ExistAsync(itemPedidoCreate.ProdutoEntityId);
                if (!produtoExits)
                {
                    return response.Erro("Produto não localizado");
                }

                // verificar se pedido existe e se esta aberto
                var pedidoExists = await _pedidoRepository.ExistAsync(itemPedidoCreate.PedidoEntityId);
                if (!pedidoExists)
                {
                    return response.Erro("Pedido não localizado");
                }

                var pedido = await _pedidoRepository.SelectAsync(itemPedidoCreate.PedidoEntityId);
                //NAO ALTERAR GUID!!!!!!!
                if (pedido.SituacaoPedidoEntityId == GuidSituacaoPedido.SituacaoCanceladoID)
                {
                    return response.Erro("Não é possivel inserir item em um pedido cancelado.");
                }

                //verificar se usuario ponto de venda existe

                var user = await _usuarioPontoVendaRepository.GetByIdUser(itemPedidoCreate.UsuarioPontoVendaEntityId);
                if (user == null)
                {
                    return response.Erro("Usuário não localizado.");
                }

                var entity = _mapper.Map<ItemPedidoEntity>(model);

                var entityResult = await _repository!.InsertAsync(entity);

                if (entityResult == null)
                {
                    response.ErroCadastro();
                    return response;
                }

                var result = await _implementacao!.Get(entityResult.Id);

                if (result == null)
                {
                    response.ErroCadastro();
                    return response;
                }

                //APOS INSERIR ITEM - PRECISA ALTUALIZAR VALOR DO PEDIDO
                var pedidoAtualizar = await _pedidoService.AtualizarValorPedido(itemPedidoCreate.PedidoEntityId);

                if (pedidoAtualizar == null)
                {
                    return response.Erro("Erro CRITICO. Inconsistência no sistema. Item do pedido foi inserido com sucesso, porém ao atualizar valor do pedido não foi possível.");
                }
                if (!pedidoAtualizar.Status)
                {
                    return response.Erro("Erro CRITICO. Inconsistência no sistema. Item do pedido foi inserido com sucesso, porém ao atualizar valor do pedido não foi possível.");
                }


                stop.Stop();

                Console.WriteLine($"time: {stop.ElapsedMilliseconds}");

                return pedidoAtualizar.AlteracaoOk("Item inserido com sucesso. Retorno com PedidoAtualizado");


            }
            catch (Exception ex)
            {
                return response.Erro(ex);
            }
        }
        public async Task<ResponseDto<List<ItemPedidoDto>>> EditarObservacao(ItemPedidoDtoEditarObservacao observacao)
        {
            var response = new ResponseDto<List<ItemPedidoDto>>();

            try
            {
                var entity = await _repository.SelectAsync(observacao.Id);
                if (entity == null)
                {
                    return response.EntitiesNull();
                }

                entity.ObservacaoItem = observacao.ObservacaoItem;

                var entityUpdate = await _repository.UpdateAsync(entity);
                if (entityUpdate == null)
                {
                    return response.EntitiesNull();
                }

                var resultUpdateDto = await Get(entityUpdate.Id);
                if (resultUpdateDto.Status)
                {
                    response.Mensagem = "Observação alterada";
                    return response;
                }

                return response.ErroUpdate();

            }
            catch (Exception ex)
            {
                return response.Erro(ex);
            }
        }
        public async Task<ResponseDto<List<ItemPedidoDto>>> CancelarItemPedido(Guid id)
        {
            var response = new ResponseDto<List<ItemPedidoDto>>();

            try
            {
                var entity = await _repository!.SelectAsync(id);

                if (entity == null)
                {
                    return response.EntitiesNull();
                }


                var model = _mapper.Map<ItemPedidoModel>(entity);

                if (!model.Habilitado)
                    return response.Erro("Item do pedido ja está cancelado");

                model.CancelarItemPedido();
                var entityUpdate = _mapper.Map<ItemPedidoEntity>(model);

                var entityUpdateResult = await _repository!.UpdateAsync(entityUpdate);
                if (entityUpdateResult == null)
                {
                    response.ErroCadastro();
                    return response;
                }

                //APOS INSERIR ITEM - PRECISA ALTUALIZAR VALOR DO PEDIDO
                var pedidoAtualizar = await _pedidoService.AtualizarValorPedido(entity.PedidoEntityId);

                if (pedidoAtualizar == null)
                {
                    return response.Erro("Erro CRITICO. Inconsistência no sistema. Item do pedido foi removido com sucesso, porém ao atualizar valor do pedido não foi possível.");
                }
                if (!pedidoAtualizar.Status)
                {
                    return response.Erro("Erro CRITICO. Inconsistência no sistema. Item do pedido foi removido com sucesso, porém ao atualizar valor do pedido não foi possível.");
                }

                var result = await _implementacao!.Get(entityUpdateResult.Id);

                if (result == null)
                {
                    response.ErroCadastro();
                    return response;
                }

                var dto = _mapper.Map<ItemPedidoDto>(result);
                return response.Retorno(new List<ItemPedidoDto>() { dto });
            }
            catch (Exception ex)
            {
                return response.Erro(ex);
            }
        }
        public async Task<ResponseDto<List<PedidoDto>>> CancelarItemReturnPedido(Guid idItemPedido)
        {
            try
            {
                var itemExists = await _repository.ExistAsync(idItemPedido);
                if (!itemExists)
                {
                    return new ResponseDto<List<PedidoDto>>().ErroConsulta("Item não localizado");
                }

                var item_selecionado = await _repository.SelectAsync(idItemPedido);

                var model = _mapper.Map<ItemPedidoModel>(item_selecionado);
                model.CancelarItemPedido();
                var entity = _mapper.Map<ItemPedidoEntity>(model);

                var result = await _repository.UpdateAsync(entity);
                if (result == null)
                {
                    return new ResponseDto<List<PedidoDto>>().Erro("Não foi possível cancacelar item do pedido");
                }

                var atualizaPedido = await _pedidoService.AtualizarValorPedido(result.PedidoEntityId);

                if (atualizaPedido.Status)
                    return atualizaPedido;

                return new ResponseDto<List<PedidoDto>>().Erro("Não foi possível realizar operação");
            }
            catch (Exception ex)
            {
                return new ResponseDto<List<PedidoDto>>().Erro(ex);
            }
        }
        public async Task<ResponseDto<List<PedidoDto>>> RemoverAllItensByIdPedido(Guid idPedido)
        {
            try
            {
                var pedidoExit = await _pedidoRepository.ExistAsync(idPedido);
                if (!pedidoExit)
                {
                    return new ResponseDto<List<PedidoDto>>().ErroConsulta("Pedido não localizado");
                }

                var pedido = await _pedidoImplementacao.Get(idPedido);

                if (pedido.SituacaoPedidoEntityId == GuidSituacaoPedido.SituacaoFechadoID
                || pedido.SituacaoPedidoEntityId == GuidSituacaoPedido.SituacaoCanceladoID)
                {
                    return new ResponseDto<List<PedidoDto>>()
                        .ErroConsulta("Pedido deve estar aberto para remover os itens");
                }

                if (!pedido.ItensPedidoEntities.Any())
                {
                    return new ResponseDto<List<PedidoDto>>().ErroConsulta("Pedido não contém itens para ser removido");
                }

                var result = await _repository.DeleteAsync(pedido.ItensPedidoEntities);

                if (result > 0)
                {
                    var pedidoAtualizado = await _pedidoService.AtualizarValorPedido(idPedido);
                    if (pedidoAtualizado.Status)
                    {
                        pedidoAtualizado.Mensagem = "Itens removidos com sucesso.Pedido atualizado de retorno   ";
                        return pedidoAtualizado;
                    }

                    return new ResponseDto<List<PedidoDto>>().DeleteOK("Itens removidos");
                }

                return new ResponseDto<List<PedidoDto>>().Erro("Não foi possível realizar operação");

            }
            catch (Exception ex)
            {
                return new ResponseDto<List<PedidoDto>>().Erro(ex);
            }
        }
    }
}