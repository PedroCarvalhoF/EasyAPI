using AutoMapper;
using Domain.Dtos;
using Domain.Dtos.ItemPedido;
using Domain.Entities.ItensPedido;
using Domain.Interfaces;
using Domain.Interfaces.Repository;
using Domain.Interfaces.Services.ItemPedido;
using Domain.Models.ItemPedidoModels;

namespace Service.Services.ItemPedidoService
{
    public class ItemPedidoService : IItemPedidoService
    {
        private readonly IItemPedidoRepository? _implementacao;
        private readonly IRepository<ItemPedidoEntity>? _repository;
        private readonly IMapper? _mapper;

        public ItemPedidoService(IItemPedidoRepository? implementacao, IRepository<ItemPedidoEntity>? repository, IMapper? mapper)
        {
            _implementacao = implementacao;
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<ResponseDto<List<ItemPedidoDto>>> GetAll()
        {
            ResponseDto<List<ItemPedidoDto>> response = new ResponseDto<List<ItemPedidoDto>>();
            response.Dados = new List<ItemPedidoDto>();
            try
            {
                var entity = await _implementacao!.GetAll();
                if (entity == null)
                {
                    response.ErroConsulta("Registro não encontrado");
                    return response;
                }

                var dtos = _mapper.Map<List<ItemPedidoDto>>(entity);
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
        public async Task<ResponseDto<List<ItemPedidoDto>>> Get(Guid id)
        {
            ResponseDto<List<ItemPedidoDto>> response = new ResponseDto<List<ItemPedidoDto>>();
            response.Dados = new List<ItemPedidoDto>();
            try
            {
                var entity = await _implementacao!.Get(id);
                if (entity == null)
                {
                    response.ErroConsulta("Registro não encontrado");
                    return response;
                }

                var dto = _mapper.Map<ItemPedidoDto>(entity);
                response.Dados.Add(dto);

                return response;
            }
            catch (Exception ex)
            {
                response.ErroConsulta("Item Pedido: ", ex.Message);
                return response;
            }
        }
        public async Task<ResponseDto<List<ItemPedidoDto>>> GetByIdPedido(Guid idPedido)
        {
            ResponseDto<List<ItemPedidoDto>> response = new ResponseDto<List<ItemPedidoDto>>();
            response.Dados = new List<ItemPedidoDto>();
            try
            {
                var entity = await _implementacao!.GetByIdPedido(idPedido);
                if (entity == null)
                {
                    response.ErroConsulta("Registro não encontrado");
                    return response;
                }

                var dto = _mapper.Map<ItemPedidoDto>(entity);
                response.Dados.Add(dto);

                return response;
            }
            catch (Exception ex)
            {
                response.ErroConsulta("Item Pedido: ", ex.Message);
                return response;
            }
        }
        public async Task<ResponseDto<List<ItemPedidoDto>>> GerarItemPedido(ItemPedidoDtoCreate itemPedidoCreate)
        {
            ResponseDto<List<ItemPedidoDto>> response = new ResponseDto<List<ItemPedidoDto>>();
            response.Dados = new List<ItemPedidoDto>();
            try
            {
                var model = _mapper.Map<ItemPedidoModel>(itemPedidoCreate);

                model.GerarItemPedido();
                model.Calular();

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

                var dto = _mapper.Map<ItemPedidoDto>(result);

                response.CadastroOk();
                response.Dados.Add(dto);

                return response;
            }
            catch (Exception ex)
            {
                response.ErroConsulta("Item Pedido: ", ex.Message);
                return response;
            }
        }
        public async Task<ResponseDto<List<ItemPedidoDto>>> CancelarItemPedido(Guid id)
        {
            ResponseDto<List<ItemPedidoDto>> response = new ResponseDto<List<ItemPedidoDto>>();
            response.Dados = new List<ItemPedidoDto>();
            try
            {
                var entity = await _repository!.SelectAsync(id);

                if (entity == null)
                {

                    response.ErroConsulta("Não localizado item do pedido");
                    return response;
                }
                var model = _mapper.Map<ItemPedidoModel>(entity);

                model.CancelarItemPedido();


                var entityUpdate = _mapper.Map<ItemPedidoEntity>(model);

                var entityUpdateResult = await _repository!.UpdateAsync(entity);

                if (entityUpdateResult == null)
                {
                    response.ErroCadastro();
                    return response;
                }

                var result = await _implementacao!.Get(entityUpdateResult.Id);

                if (result == null)
                {
                    response.ErroCadastro();
                    return response;
                }

                var dto = _mapper.Map<ItemPedidoDto>(result);

                response.CadastroOk();
                response.Dados.Add(dto);

                return response;
            }
            catch (Exception ex)
            {
                response.ErroConsulta("Item Pedido: ", ex.Message);
                return response;
            }
        }


    }
}