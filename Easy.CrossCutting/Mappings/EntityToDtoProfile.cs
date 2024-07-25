using AutoMapper;
using Easy.Domain.Entities.PDV.CategoriaPreco;
using Easy.Domain.Entities.Produto;
using Easy.Domain.Entities.Produto.CategoriaProduto;
using Easy.Domain.Entities.User;
using Easy.Domain.Entities.UserMasterCliente;
using Easy.Domain.Entities.UserMasterUser;
using Easy.Services.DTOs.CategoriaPreco;
using Easy.Services.DTOs.CategoriaProduto;
using Easy.Services.DTOs.Produto;
using Easy.Services.DTOs.User;
using Easy.Services.DTOs.UserMaster;
using Easy.Services.DTOs.UserMasterUser;

namespace Easy.CrossCutting.Mappings
{
    public class EntityToDtoProfile : Profile
    {
        public EntityToDtoProfile()
        {
            CreateMap<UserDto, UserEntity>().ReverseMap();
            CreateMap<UserMasterClienteDto, UserMasterClienteEntity>().ReverseMap();
            CreateMap<UserMasterUserDto, UserMasterUserEntity>().ReverseMap();

            //Categoria de Produto
            CreateMap<CategoriaProdutoDtoView, CategoriaProdutoEntity>().ReverseMap();

            //Produto
            CreateMap<ProdutoDtoView, ProdutoEntity>().ReverseMap();
            CreateMap<ProdutoDto, ProdutoEntity>().ReverseMap();

            //Categoria de Preço
            CreateMap<CategoriaPrecoDtoView, CategoriaPrecoEntity>().ReverseMap();
            CreateMap<CategoriaPrecoEntity, CategoriaPrecoDto>().ReverseMap();
        }
    }
}
