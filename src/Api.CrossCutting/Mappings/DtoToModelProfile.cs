using Api.Domain.Dtos.CategoriaPrecoDtos;
using Api.Domain.Dtos.CategoriaProdutoDtos;
using Api.Domain.Dtos.PedidoDtos;
using Api.Domain.Dtos.PessoasDtos.PessoaTipoDtos;
using Api.Domain.Dtos.PontoVendaDtos;
using Api.Domain.Dtos.PrecoProdutoDtos;
using Api.Domain.Dtos.ProdutoMedidaDtos;
using Api.Domain.Models.CategoriaPreco;
using Api.Domain.Models.CategoriaProdutoModels;
using Api.Domain.Models.PedidoModels;
using Api.Domain.Models.PessoaModels.PessoaTipoModels;
using Api.Domain.Models.PontoVendaModels;
using Api.Domain.Models.PrecoProdutoModels;
using Api.Domain.Models.ProdutoMedidaModels;
using AutoMapper;
using Domain.Dtos.CategoriaProdutoDtos;
using Domain.Dtos.FormaPagamentoDtos;
using Domain.Dtos.ItemPedido;
using Domain.Dtos.PagamentoPedidoDtos;
using Domain.Dtos.PedidoSituacao;
using Domain.Dtos.PessoasDtos.PessoaDtos;
using Domain.Dtos.PontoVendaPeriodoVendaDtos;
using Domain.Dtos.ProdutoDtos;
using Domain.Dtos.ProdutoTipo;
using Domain.Models.FormaPagamentoModels;
using Domain.Models.ItemPedidoModels;
using Domain.Models.PagamentoPedidoModels;
using Domain.Models.PedidoSituacao;
using Domain.Models.PeriodoPontoVenda;
using Domain.Models.PessoaModels.PessoaModels;
using Domain.Models.ProdutoModels;
using Domain.Models.ProdutoTipo;

namespace Api.CrossCutting.Mappings
{
    public class DtoToModelProfile : Profile
    {
        public DtoToModelProfile()
        {

            CreateMap<SituacaoPedidoModel, SituacaoPedidoDto>().ReverseMap();
            CreateMap<SituacaoPedidoModel, SituacaoPedidoDtoCreate>().ReverseMap();
            CreateMap<SituacaoPedidoModel, SituacaoPedidoDtoUpdate>().ReverseMap();

            CreateMap<PrecoProdutoModel, PrecoProdutoDto>();
            CreateMap<PrecoProdutoModel, PrecoProdutoDtoCreate>();

            CreateMap<CategoriaProdutoModel, CategoriaProdutoDto>().ReverseMap();
            CreateMap<CategoriaProdutoModel, CategoriaProdutoDtoCreate>().ReverseMap();
            CreateMap<CategoriaProdutoModel, CategoriaProdutoDtoUpdate>().ReverseMap();

            CreateMap<ProdutoModel, ProdutoDto>().ReverseMap();
            CreateMap<ProdutoModel, ProdutoDtoCreate>().ReverseMap();

            CreateMap<ProdutoDto, ProdutoModel>();
            CreateMap<ProdutoDtoCreate, ProdutoModel>();
            CreateMap<ProdutoDtoUpdate, ProdutoModel>();


            // # PONTO DE VENDA #
            CreateMap<PontoVendaModel, PontoVendaDto>().ReverseMap();
            CreateMap<PontoVendaModel, PontoVendaDtoCreate>().ReverseMap();


            CreateMap<PedidoModel, PedidoDto>().ReverseMap();
            CreateMap<PedidoModel, PedidoDtoCreate>().ReverseMap();
            CreateMap<PedidoModel, PedidoDtoUpdate>().ReverseMap();

            CreateMap<CategoriaPrecoModel, CategoriaPrecoDto>().ReverseMap();
            CreateMap<CategoriaPrecoModel, CategoriaPrecoDtoCreate>().ReverseMap();
            CreateMap<CategoriaPrecoModel, CategoriaPrecoDtoUpdate>().ReverseMap();

            CreateMap<PrecoProdutoModel, PrecoProdutoDto>().ReverseMap();
            CreateMap<PrecoProdutoModel, PrecoProdutoDtoCreate>().ReverseMap();
            CreateMap<PrecoProdutoModel, PrecoProdutoDtoUpdate>().ReverseMap();

            CreateMap<ItemPedidoModel, ItemPedidoDto>().ReverseMap();
            CreateMap<ItemPedidoModel, ItemPedidoDtoCreate>().ReverseMap();
            CreateMap<ItemPedidoModel, ItemPedidoDtoUpdate>().ReverseMap();

            CreateMap<FormaPagamentoModel, FormaPagamentoDto>().ReverseMap();
            CreateMap<FormaPagamentoModel, FormaPagamentoDtoCreate>().ReverseMap();
            CreateMap<FormaPagamentoModel, FormaPagamentoDtoUpdate>().ReverseMap();

            CreateMap<PagamentoPedidoModel, PagamentoPedidoDto>().ReverseMap();
            CreateMap<PagamentoPedidoModel, PagamentoPedidoDtoCreate>().ReverseMap();

            CreateMap<PessoaTipoModel, PessoaTipoDto>().ReverseMap();

            CreateMap<PessoaDtoCreate, PessoasModel>()
               .ConstructUsing(dto => new PessoasModel(
                               dto.PrimeiroNome,
                               dto.SegundoNome,
                               dto.RgIE,
                               dto.CpfCnpj,
                               dto.Sexo,
                               dto.DataNascimentoFundacao,
                               dto.PessoaTipoEntityId));

            CreateMap<PessoaDtoUpdate, PessoasModel>()
              .ConstructUsing(dto => new PessoasModel(dto.Id, dto.PrimeiroNome, dto.SegundoNome, dto.RgIE, dto.CpfCnpj, dto.Sexo, dto.DataNascimentoFundacao, dto.PessoaTipoEntityId));

            CreateMap<ProdutoMedidaModel, ProdutoMedidaDto>().ReverseMap();
            CreateMap<ProdutoMedidaModel, ProdutoMedidaDtoCreate>().ReverseMap();
            CreateMap<ProdutoMedidaModel, ProdutoMedidaDtoUpdate>().ReverseMap();

            CreateMap<ProdutoTipoModel, ProdutoTipoDto>().ReverseMap();
            CreateMap<ProdutoTipoModel, ProdutoTipoDtoCreate>().ReverseMap();
            CreateMap<ProdutoTipoModel, ProdutoTipoDtoUpdate>().ReverseMap();

            CreateMap<ProdutoTipoModel, ProdutoTipoDto>().ReverseMap();
            CreateMap<ProdutoTipoModel, ProdutoTipoDtoCreate>().ReverseMap();
            CreateMap<ProdutoTipoModel, ProdutoTipoDtoUpdate>().ReverseMap();

            CreateMap<PeriodoPontoVendaModel, PeriodoPontoVendaDto>().ReverseMap();
            CreateMap<PeriodoPontoVendaModel, PeriodoPontoVendaDtoCreate>().ReverseMap();

        }

    }
}