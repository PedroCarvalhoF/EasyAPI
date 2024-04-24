using Api.Domain.Dtos.PedidoDtos;
using Api.Domain.Interfaces.Services.Pedido;
using AutoMapper;
using Domain.Dtos.ItemPedido;
using Domain.Entities.ItensPedido;
using Domain.Enuns;
using Domain.ExceptionsPersonalizadas;
using Domain.Interfaces;
using Domain.Interfaces.Services.ItemPedido;
using Domain.Models.ItemPedidoModels;
using Domain.Repository;

namespace Service.Services.ItemPedidoService
{
    public class ItemPedidoService : IItemPedidoService
    {
        private readonly IItemPedidoRepository repository;
        private readonly IRepository<ItemPedidoEntity> repositoryBase;
        private readonly IMapper mapper;
        private readonly IPedidoService _pedidoService;

        public ItemPedidoService(IItemPedidoRepository repository, IRepository<ItemPedidoEntity> repositoryBase, IMapper mapper, IPedidoService pedidoService)
        {
            this.repository = repository;
            this.repositoryBase = repositoryBase;
            this.mapper = mapper;
            _pedidoService = pedidoService;
        }

        public async Task<ItemPedidoDto> RegistrarItemPedido(ItemPedidoDtoCreate item)
        {
            try
            {
                ItemPedidoModels itemModel = new ItemPedidoModels(item.ProdutoEntityId, item.Quatidade, item.Preco, item.Desconto, item.ObservacaoItem, item.PedidoEntityId, item.UsuarioRestroId);

                ItemPedidoEntity entity = mapper.Map<ItemPedidoEntity>(itemModel);

                ItemPedidoEntity resultCreate = await repositoryBase.InsertAsync(entity);

                if (resultCreate != null)
                {
                    PedidoDto resutAttPedido = await _pedidoService.AtualizarValorPedido(resultCreate.PedidoEntityId);

                    ItemPedidoEntity itemPedido = await repository.GetByIdItemPedido(resultCreate.Id);


                    return mapper.Map<ItemPedidoDto>(itemPedido);
                }
                else
                    return new ItemPedidoDto();


            }
            catch (ModelsExceptions ex)
            {
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<PedidoDto> ResgistrarItemReturnPedido(ItemPedidoDtoCreate item)
        {
            try
            {
                ItemPedidoModels itemModel = new ItemPedidoModels(item.ProdutoEntityId, item.Quatidade, item.Preco, item.Desconto, item.ObservacaoItem, item.PedidoEntityId, item.UsuarioRestroId);

                ItemPedidoEntity entity = mapper.Map<ItemPedidoEntity>(itemModel);

                ItemPedidoEntity resultCreate = await repositoryBase.InsertAsync(entity);

                if (resultCreate != null)
                {
                    PedidoDto resutAttPedido = await _pedidoService.AtualizarValorPedido(resultCreate.PedidoEntityId);


                    resutAttPedido.ItemPedidoEntity = resutAttPedido.ItemPedidoEntity.OrderBy(item => item.CreateAt);


                    return mapper.Map<PedidoDto>(resutAttPedido);
                }
                else
                    return new PedidoDto();


            }
            catch (ModelsExceptions ex)
            {
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<ItemPedidoDto> CancelarItemPedido(Guid idItemPedido)
        {
            try
            {
                ItemPedidoEntity itemPedidoSelecionado = await repository.GetByIdItemPedido(idItemPedido);
                ItemPedidoModels model = mapper.Map<ItemPedidoModels>(itemPedidoSelecionado);

                model.CancelarItem();

                ItemPedidoEntity entity = mapper.Map<ItemPedidoEntity>(model);
                ItemPedidoEntity result = await repositoryBase.UpdateAsync(entity);

                if (result != null)
                {
                    ItemPedidoEntity itemResult = await repository.GetByIdItemPedido(idItemPedido);
                    PedidoDto resutAttPedido = await _pedidoService.AtualizarValorPedido(itemResult.PedidoEntityId);
                    return mapper.Map<ItemPedidoDto>(itemResult);
                }
                else
                {
                    throw new ModelsExceptions("Não foi possivel cancelar item do pedido");
                }
            }
            catch (ModelsExceptions ex)
            {
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<PedidoDto> CancelarItemPedidoReturnPedido(Guid idItemPedido)
        {
            try
            {
                ItemPedidoEntity itemPedidoSelecionado = await repository.GetByIdItemPedido(idItemPedido);
                ItemPedidoModels model = mapper.Map<ItemPedidoModels>(itemPedidoSelecionado);
                model.CancelarItem();
                ItemPedidoEntity entity = mapper.Map<ItemPedidoEntity>(model);
                ItemPedidoEntity result = await repositoryBase.UpdateAsync(entity);
                if (result != null)
                {
                    ItemPedidoEntity itemResult = await repository.GetByIdItemPedido(idItemPedido);

                    PedidoDto resutAttPedido = await _pedidoService.AtualizarValorPedido(itemResult.PedidoEntityId);

                    return mapper.Map<PedidoDto>(resutAttPedido);
                }
                else
                {
                    throw new ModelsExceptions("Não foi possivel cancelar item do pedido");
                }
            }
            catch (ModelsExceptions ex)
            {
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<ItemPedidoDto> GetByIdItemPedido(Guid idItemPedido)
        {
            try
            {
                ItemPedidoEntity entity = await repository.GetByIdItemPedido(idItemPedido);
                return mapper.Map<ItemPedidoDto>(entity);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public async Task<IEnumerable<ItemPedidoDto>> GetByIdProduto(Guid idProduto, bool fullConsulta = false)
        {
            try
            {
                IEnumerable<ItemPedidoEntity> entity = await repository.GetByIdProduto(idProduto, fullConsulta);
                return mapper.Map<IEnumerable<ItemPedidoDto>>(entity);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public async Task<IEnumerable<ItemPedidoDto>> GetBySituacaoItem(int situacaoItem, bool fullConsulta)
        {
            try
            {
                SituacaoItemPedidoEnum situacaoEnumSelecionada = SituacaoItemPedidoEnum.ItemRegistrado;

                switch (situacaoItem)
                {
                    case 1:
                        situacaoEnumSelecionada = SituacaoItemPedidoEnum.ItemRegistrado;
                        break;
                    case 3:
                        situacaoEnumSelecionada = SituacaoItemPedidoEnum.ItemCancelado;
                        break;
                    default:
                        break;
                }


                IEnumerable<ItemPedidoEntity> entity = await repository.SelectAsync(item => item.SituacaoItemPedidoEnum.Equals(situacaoEnumSelecionada), fullConsulta);

                return mapper.Map<IEnumerable<ItemPedidoDto>>(entity);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }


    }
}
