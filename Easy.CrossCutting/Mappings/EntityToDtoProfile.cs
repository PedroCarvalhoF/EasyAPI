using AutoMapper;
using Easy.Domain.Entities.User;
using Easy.Domain.Entities.UserMasterCliente;
using Easy.Domain.Entities.UserMasterUser;
using Easy.Services.DTOs.User;
using Easy.Services.DTOs.UserMaster;
using Easy.Services.DTOs.UserMasterUser;

namespace Easy.CrossCutting.Mappings
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
