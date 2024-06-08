using Api.Domain.Dtos.CategoriaPrecoDtos;
using Api.Domain.Dtos.CategoriaProdutoDtos;
using Api.Domain.Dtos.PedidoDtos;
using Api.Domain.Dtos.PontoVendaDtos;
using Api.Domain.Dtos.PrecoProdutoDtos;
using Api.Domain.Dtos.ProdutoMedidaDtos;
using Api.Domain.Entities.CategoriaPreco;
using Api.Domain.Entities.Pedido;
using Api.Domain.Entities.PontoVenda;
using Api.Domain.Entities.PrecoProduto;
using Api.Domain.Entities.ProdutoMedida;
using AutoMapper;
using Domain.Dtos.CategoriaProdutoDtos;
using Domain.Dtos.FormaPagamentoDtos;
using Domain.Dtos.IdentityRole;
using Domain.Dtos.ItemPedido;
using Domain.Dtos.PagamentoPedidoDtos;
using Domain.Dtos.Pedido;
using Domain.Dtos.PedidoSituacao;
using Domain.Dtos.Pessoas.DadosBancarios;
using Domain.Dtos.Pessoas.PessoaDadosBancarios;
using Domain.Dtos.PessoasDtos.PessoaDtos;
using Domain.Dtos.PontoVendaPeriodoVendaDtos;
using Domain.Dtos.PontoVendaUser;
using Domain.Dtos.ProdutoDtos;
using Domain.Dtos.ProdutoTipo;
using Domain.Entities.CategoriaProduto;
using Domain.Entities.FormaPagamento;
using Domain.Entities.ItensPedido;
using Domain.Entities.PagamentoPedido;
using Domain.Entities.PedidoSituacao;
using Domain.Entities.Pessoa.Pessoas;
using Domain.Entities.PontoVendaPeriodoVenda;
using Domain.Entities.PontoVendaUser;
using Domain.Entities.Produto;
using Domain.Entities.ProdutoTipo;
using Domain.UserIdentity;
using Microsoft.AspNetCore.Identity;

namespace Api.CrossCutting.Mappings
{
    public class EntityToDtoProfile : Profile
    {
        public EntityToDtoProfile()
        {
            #region Pessoas
            CreateMap<PessoaDto, PessoaEntity>().ReverseMap();

            CreateMap<DadosBancariosDto, DadosBancariosEntity>().ReverseMap();
            CreateMap<PessoaDadosBancariosEntity, PessoaDadosBancariosDto>().ReverseMap();
            #endregion



            CreateMap<UsuarioPontoVendaDto, UsuarioPontoVendaEntity>().ReverseMap();
            CreateMap<UsuarioPontoVendaDtoCreate, UsuarioPontoVendaEntity>().ReverseMap();

            CreateMap<UserIdentityDto, IdentityUser>().ReverseMap();
            CreateMap<RoleDto, IdentityRole>().ReverseMap();
            //
            CreateMap<SituacaoPedidoDto, SituacaoPedidoEntity>().ReverseMap();
            //
            CreateMap<CategoriaProdutoDto, CategoriaProdutoEntity>().ReverseMap();
            CreateMap<CategoriaProdutoDtoCreateResult, CategoriaProdutoEntity>().ReverseMap();
            CreateMap<CategoriaProdutoDtoUpdateResult, CategoriaProdutoEntity>().ReverseMap();

            //
            CreateMap<ProdutoDto, ProdutoEntity>().ReverseMap();

            // ## PONTO  DE VENDA ##
            CreateMap<PontoVendaDto, PontoVendaEntity>().ReverseMap();

            CreateMap<PedidoDto, PedidoEntity>().ReverseMap();
            CreateMap<PedidoDtoClean, PedidoEntity>().ReverseMap();

            CreateMap<CategoriaPrecoDto, CategoriaPrecoEntity>().ReverseMap();
            CreateMap<CategoriaPrecoDtoCreate, CategoriaPrecoEntity>().ReverseMap();
            CreateMap<CategoriaPrecoDtoUpdate, CategoriaPrecoEntity>().ReverseMap();



            CreateMap<PrecoProdutoDto, PrecoProdutoEntity>().ReverseMap();
            CreateMap<PrecoProdutoDto, PrecoProdutoEntity>().ReverseMap();
            CreateMap<PrecoProdutoDto, PrecoProdutoEntity>().ReverseMap();


            CreateMap<ItemPedidoDto, ItemPedidoEntity>().ReverseMap();

            CreateMap<FormaPagamentoDto, FormaPagamentoEntity>().ReverseMap();

            CreateMap<PagamentoPedidoDto, PagamentoPedidoEntity>().ReverseMap();

            CreateMap<PessoaDto, PessoaEntity>().ReverseMap();

            //
            CreateMap<ProdutoMedidaDto, ProdutoMedidaEntity>().ReverseMap();
            CreateMap<ProdutoMedidaDtoCreate, ProdutoMedidaEntity>().ReverseMap();
            CreateMap<ProdutoMedidaDtoUpdate, ProdutoMedidaEntity>().ReverseMap();
            //
            CreateMap<ProdutoTipoDto, ProdutoTipoEntity>().ReverseMap();
            CreateMap<ProdutoTipoDtoCreate, ProdutoTipoEntity>().ReverseMap();
            CreateMap<ProdutoTipoDtoUpdate, ProdutoTipoEntity>().ReverseMap();

            CreateMap<PeriodoPontoVendaDto, PeriodoPontoVendaEntity>().ReverseMap();
            CreateMap<PeriodoPontoVendaDtoCreate, PeriodoPontoVendaEntity>().ReverseMap();
        }
    }
}
