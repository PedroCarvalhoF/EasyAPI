using Api.CrossCutting.Mappings;
using AutoMapper;

namespace Api.Application.Extensions
{
    public static class AutoMapperConfiguration
    {
        public static void AutoMapperConfig(this IServiceCollection services)
        {
            MapperConfiguration config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new DtoToModelProfile());
                cfg.AddProfile(new EntityToDtoProfile());
                cfg.AddProfile(new ModelToEntityProfile());
            });

            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);

        }


    }
}
