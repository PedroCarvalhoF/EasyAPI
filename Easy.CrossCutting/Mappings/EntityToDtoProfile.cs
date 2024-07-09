using AutoMapper;
using Easy.Domain.Entities.Produto.CategoriaProduto;
using Easy.Domain.Entities.User;
using Easy.Domain.Entities.UserMasterCliente;
using Easy.Domain.Entities.UserMasterUser;
using Easy.Services.DTOs.CategoriaProduto;
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
            CreateMap<CategoriaProdutoView, CategoriaProdutoEntity>().ReverseMap();
        }
    }
}
