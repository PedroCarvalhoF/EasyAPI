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
using Domain.Dtos.PerfilUsuario;
using Domain.Dtos.PessoasDtos.PessoaDtos;
using Domain.Dtos.PontoVendaPeriodoVendaDtos;
using Domain.Dtos.ProdutoDtos;
using Domain.Dtos.ProdutoTipo;
using Domain.Models.FormaPagamentoModels;
using Domain.Models.ItemPedidoModels;
using Domain.Models.PagamentoPedidoModels;
using Domain.Models.PerfilUsuario;
using Domain.Models.PeriodoPontoVenda;
using Domain.Models.PessoaModels.PessoaModels;
using Domain.Models.ProdutoModels;

namespace Api.CrossCutting.Mappings
{
    public class DtoToModelProfile : Profile
    {
        public DtoToModelProfile()
        {

            CreateMap<PerfilUsuarioModels, PerfilUsuarioDto>().ReverseMap();
            CreateMap<PerfilUsuarioModels, PerfilUsuarioDtoCreate>().ReverseMap();
            CreateMap<PerfilUsuarioModels, PerfilUsuarioDtoUpdate>().ReverseMap();

            CreateMap<PrecoProdutoModels, PrecoProdutoDto>();
            CreateMap<PrecoProdutoModels, PrecoProdutoDtoCreate>();    

            CreateMap<CategoriaProdutoModel, CategoriaProdutoDto>().ReverseMap();
            CreateMap<CategoriaProdutoModel, CategoriaProdutoDtoCreate>().ReverseMap();
            CreateMap<CategoriaProdutoModel, CategoriaProdutoDtoUpdate>().ReverseMap();

            CreateMap<ProdutoModels, ProdutoDto>().ReverseMap();
            CreateMap<ProdutoModels, ProdutoDtoCreate>().ReverseMap();

            CreateMap<ProdutoDto, ProdutoModels>();
            CreateMap<ProdutoDtoCreate, ProdutoModels>();
            CreateMap<ProdutoDtoUpdate, ProdutoModels>();


            // # PONTO DE VENDA #
            CreateMap<PontoVendaModels, PontoVendaDto>().ReverseMap();
            CreateMap<PontoVendaModels, PontoVendaDtoCreate>().ReverseMap();
           

            CreateMap<PedidoModels, PedidoDto>().ReverseMap();
            CreateMap<PedidoModels, PedidoDtoCreate>().ReverseMap();
            CreateMap<PedidoModels, PedidoDtoUpdate>().ReverseMap();

            CreateMap<CategoriaPrecoModels, CategoriaPrecoDto>().ReverseMap();
            CreateMap<CategoriaPrecoModels, CategoriaPrecoDtoCreate>().ReverseMap();
            CreateMap<CategoriaPrecoModels, CategoriaPrecoDtoUpdate>().ReverseMap();

            CreateMap<PrecoProdutoModels, PrecoProdutoDto>().ReverseMap();
            CreateMap<PrecoProdutoModels, PrecoProdutoDtoCreate>().ReverseMap();
            CreateMap<PrecoProdutoModels, PrecoProdutoDtoUpdate>().ReverseMap();

            CreateMap<ItemPedidoModels, ItemPedidoDto>().ReverseMap();
            CreateMap<ItemPedidoModels, ItemPedidoDtoCreate>().ReverseMap();
            CreateMap<ItemPedidoModels, ItemPedidoDtoUpdate>().ReverseMap();

            CreateMap<FormaPagamentoModels, FormaPagamentoDto>().ReverseMap();
            CreateMap<FormaPagamentoModels, FormaPagamentoDtoCreate>().ReverseMap();
            CreateMap<FormaPagamentoModels, FormaPagamentoDtoUpdate>().ReverseMap();

            CreateMap<PagamentoPedidoModels, PagamentoPedidoDto>().ReverseMap();
            CreateMap<PagamentoPedidoModels, PagamentoPedidoDtoCreate>().ReverseMap();

            CreateMap<PessoaTipoModels, PessoaTipoDto>().ReverseMap();

            CreateMap<PessoaDtoCreate, PessoasModels>()
               .ConstructUsing(dto => new PessoasModels(dto.PrimeiroNome, dto.SegundoNome, dto.RgIE, dto.CpfCnpj, dto.Sexo, dto.DataNascimentoFundacao, dto.PessoaTipoEntityId));
            CreateMap<PessoaDtoUpdate, PessoasModels>()
              .ConstructUsing(dto => new PessoasModels(dto.Id, dto.PrimeiroNome, dto.SegundoNome, dto.RgIE, dto.CpfCnpj, dto.Sexo, dto.DataNascimentoFundacao, dto.PessoaTipoEntityId));

            CreateMap<ProdutoMedidaModel, ProdutoMedidaDto>().ReverseMap();
            CreateMap<ProdutoMedidaModel, ProdutoMedidaDtoCreate>().ReverseMap();
            CreateMap<ProdutoMedidaModel, ProdutoMedidaDtoUpdate>().ReverseMap();

            CreateMap<ProdutoTipoModels, ProdutoTipoDto>().ReverseMap();
            CreateMap<ProdutoTipoModels, ProdutoTipoDtoCreate>().ReverseMap();
            CreateMap<ProdutoTipoModels, ProdutoTipoDtoUpdate>().ReverseMap();

            CreateMap<ProdutoTipoModels, ProdutoTipoDto>().ReverseMap();
            CreateMap<ProdutoTipoModels, ProdutoTipoDtoCreate>().ReverseMap();
            CreateMap<ProdutoTipoModels, ProdutoTipoDtoUpdate>().ReverseMap();

            CreateMap<PeriodoPontoVendaModels, PeriodoPontoVendaDto>().ReverseMap();
            CreateMap<PeriodoPontoVendaModels, PeriodoPontoVendaDtoCreate>().ReverseMap();
                          
        }

    }
}