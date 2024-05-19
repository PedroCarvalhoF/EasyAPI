using AutoMapper;
using Domain.Dtos.ItemPedido;
using Domain.Models.ItemPedidoModels;

namespace CrossCutting.Mappings.PedidoItem
{
    class ItemPedidoProfile : Profile
    {
        ItemPedidoProfile()
        {
            //create
            CreateMap<ItemPedidoDtoCreate, ItemPedidoModel>()
                .ConvertUsing(model => new ItemPedidoModel
                (
                    model.PedidoEntityId,
                    model.Quatidade,
                    model.Preco,
                    model.Desconto,
                    model.ObservacaoItem,
                    model.UsuarioPontoVendaEntityId,
                    model.PedidoEntityId
                ));




            CreateMap<ItemPedidoModel, ItemPedidoDto>().ReverseMap();

            CreateMap<ItemPedidoModel, ItemPedidoDtoUpdate>().ReverseMap();
        }

    }
}
