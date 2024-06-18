using Application.DTOs.User;
using Application.DTOs.UserMaster;
using Application.DTOs.UserMasterUser;
using AutoMapper;
using Domain.Entities.User;
using Domain.Entities.UserMasterCliente;
using Domain.Entities.UserMasterUser;

namespace Api.CrossCutting.Mappings
{
    public class EntityToDtoProfile : Profile
    {
        public EntityToDtoProfile()
        {
            CreateMap<UserView, UserEntity>().ReverseMap();
            CreateMap<UserMasterClienteView, UserMasterClienteEntity>().ReverseMap();
            CreateMap<UserMasterUserView, UserMasterUserEntity>().ReverseMap();
        }
    }
}
