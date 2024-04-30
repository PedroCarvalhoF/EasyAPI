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
using Domain.Models.ProdutoTipo;

namespace Api.CrossCutting.Mappings
{
    public class ModelToEntityProfile : Profile
    {
        public ModelToEntityProfile()
        {
            //
            CreateMap<PerfilUsuarioModel, PerfilUsuarioEntity>().ReverseMap();
            //
            CreateMap<CategoriaProdutoModel, CategoriaProdutoEntity>().ReverseMap();

            CreateMap<ProdutoModel, ProdutoEntity>().ReverseMap();

            CreateMap<PontoVendaModel, PontoVendaEntity>().ReverseMap();

            CreateMap<PedidoModel, PedidoEntity>().ReverseMap();

            CreateMap<CategoriaPrecoModel, CategoriaPrecoEntity>().ReverseMap();

            CreateMap<PrecoProdutoModel, PrecoProdutoEntity>().ReverseMap();

            CreateMap<ItemPedidoModel, ItemPedidoEntity>().ReverseMap();

            CreateMap<FormaPagamentoModel, FormaPagamentoEntity>().ReverseMap();

            CreateMap<PagamentoPedidoModel, PagamentoPedidoEntity>().ReverseMap();

            CreateMap<PessoaTipoModel, PessoaTipoEntity>().ReverseMap();

            CreateMap<PessoasModel, PessoaEntity>().ReverseMap();

            CreateMap<ProdutoMedidaModel, ProdutoMedidaEntity>().ReverseMap();

            CreateMap<ProdutoTipoModel, ProdutoTipoEntity>().ReverseMap();

            CreateMap<PeriodoPontoVendaModel, PeriodoPontoVendaModel>().ReverseMap();

        }
    }
}