using Api.Domain.Entities.CategoriaPreco;
using Api.Domain.Entities.Pedido;
using Api.Domain.Entities.Pessoa.PessoaTipo;
using Api.Domain.Entities.PontoVenda;
using Api.Domain.Entities.PrecoProduto;
using Api.Domain.Entities.ProdutoMedida;
using Api.Domain.Models.CategoriaPreco;
using Api.Domain.Models.CategoriaProdutoModels;
using Api.Domain.Models.PedidoModels;
using Api.Domain.Models.PessoaModels.PessoaTipoModels;
using Api.Domain.Models.PontoVendaModels;
using Api.Domain.Models.PrecoProdutoModels;
using Api.Domain.Models.ProdutoMedidaModels;
using AutoMapper;
using Domain.Entities.CategoriaProduto;
using Domain.Entities.FormaPagamento;
using Domain.Entities.ItensPedido;
using Domain.Entities.PagamentoPedido;
using Domain.Entities.Pessoa.Pessoas;
using Domain.Entities.Produto;
using Domain.Entities.ProdutoTipo;
using Domain.Entities.UsuarioSistema;
using Domain.Models.FormaPagamentoModels;
using Domain.Models.ItemPedidoModels;
using Domain.Models.PagamentoPedidoModels;
using Domain.Models.PerfilUsuario;
using Domain.Models.PeriodoPontoVenda;
using Domain.Models.PessoaModels.PessoaModels;
using Domain.Models.ProdutoModels;

namespace Api.CrossCutting.Mappings
{
    public class ModelToEntityProfile : Profile
    {
        public ModelToEntityProfile()
        {
            //
            CreateMap<PerfilUsuarioModels, PerfilUsuarioEntity>().ReverseMap();
            //
            CreateMap<CategoriaProdutoModel, CategoriaProdutoEntity>().ReverseMap();

            CreateMap<ProdutoModels, ProdutoEntity>().ReverseMap();

            CreateMap<PontoVendaModels, PontoVendaEntity>().ReverseMap();

            CreateMap<PedidoModels, PedidoEntity>().ReverseMap();

            CreateMap<CategoriaPrecoModels, CategoriaPrecoEntity>().ReverseMap();

            CreateMap<PrecoProdutoModels, PrecoProdutoEntity>().ReverseMap();

            CreateMap<ItemPedidoModels, ItemPedidoEntity>().ReverseMap();

            CreateMap<FormaPagamentoModels, FormaPagamentoEntity>().ReverseMap();

            CreateMap<PagamentoPedidoModels, PagamentoPedidoEntity>().ReverseMap();

            CreateMap<PessoaTipoModels, PessoaTipoEntity>().ReverseMap();

            CreateMap<PessoasModels, PessoaEntity>().ReverseMap();

            CreateMap<ProdutoMedidaModel, ProdutoMedidaEntity>().ReverseMap();

            CreateMap<ProdutoTipoModels, ProdutoTipoEntity>().ReverseMap();

            CreateMap<PeriodoPontoVendaModels, PeriodoPontoVendaModels>().ReverseMap();

        }
    }
}