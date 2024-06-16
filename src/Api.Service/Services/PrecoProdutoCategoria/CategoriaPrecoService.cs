using Api.Domain.Dtos.CategoriaPrecoDtos;
using Api.Domain.Entities.CategoriaPreco;
using Api.Domain.Interfaces.Services.CategoriaPreco;
using AutoMapper;
using Domain.Dtos;
using Domain.Dtos.PrecoCategoria;
using Domain.Interfaces;
using Domain.Interfaces.Repository;
using Domain.UserIdentity.Masters;

namespace Api.Service.Services.CategoriaPreco
{
    public class CategoriaPrecoService : ICategoriaPrecoService
    {
        private readonly IBaseRepository<CategoriaPrecoEntity> _repository;
        private readonly IMapper _mapper;
        private readonly ICategoriaPrecoRepository _implementacao;

        public CategoriaPrecoService(IBaseRepository<CategoriaPrecoEntity> repository, IMapper mapper, ICategoriaPrecoRepository categoriaPrecoRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _implementacao = categoriaPrecoRepository;
        }

        public async Task<RequestResult> GetAll(UserMasterUserDtoCreate users)
        {
            try
            {
                var entities = await _implementacao.GetAll(users);
                if (entities == null || entities.Count() == 0)
                    return new RequestResult().IsNullOrCountZero();

                return new RequestResult().Ok(_mapper.Map<IEnumerable<CategoriaPrecoDto>>(entities));
            }
            catch (Exception ex)
            {

                return new RequestResult().BadRequest(ex.Message);
            }
        }
        public async Task<RequestResult> GetIdCategoriaPreco(Guid id, UserMasterUserDtoCreate users)
        {
            try
            {
                var entity = await _implementacao.GetById(id, users);
                if (entity == null)
                    return new RequestResult().IsNullOrCountZero();

                return new RequestResult().Ok(_mapper.Map<CategoriaPrecoDto>(entity));
            }
            catch (Exception ex)
            {

                return new RequestResult().BadRequest(ex.Message);
            }
        }
        public async Task<RequestResult> Create(CategoriaPrecoDtoCreate create, UserMasterUserDtoCreate users)
        {
            try
            {
                var entity = new CategoriaPrecoEntity(create, users);
                if (!entity.Valida)
                    return new RequestResult().EntidadeInvalida(entity);

                var entityExist = await _implementacao.Exists(entity, users);
                if (entityExist)
                    return new RequestResult().BadRequest("Categoria já está em uso.");



                var result = await _repository.InsertAsync(entity);
                if (result == null)
                    return new RequestResult().BadCreate();

                return new RequestResult().Ok(_mapper.Map<CategoriaPrecoDtoResult>(result));
            }
            catch (Exception ex)
            {

                return new RequestResult().BadRequest(ex.Message);
            }
        }
        public async Task<RequestResult> Update(CategoriaPrecoDtoUpdate update, UserMasterUserDtoCreate users)
        {
            try
            {
                var entity = new CategoriaPrecoEntity(update, users);
                if (!entity.Valida)
                    return new RequestResult().EntidadeInvalida(entity);

                var entityExist = await _implementacao.Exists(entity, users);
                if (entityExist)
                    return new RequestResult().BadRequest("Categoria já está em uso.");


                var result = await _repository.UpdateAsync(entity);
                if (result == null)
                    return new RequestResult().BadCreate();

                return new RequestResult().Ok(_mapper.Map<CategoriaPrecoDtoResult>(result));
            }
            catch (Exception ex)
            {
                return new RequestResult().BadRequest(ex.Message);
            }
        }
    }
}
