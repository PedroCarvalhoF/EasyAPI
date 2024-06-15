using Api.Domain.Interfaces.Services.CategoriaProduto;
using AutoMapper;
using Domain.Dtos;
using Domain.Dtos.ProdutoCategoria;
using Domain.Entities.CategoriaProduto;
using Domain.Interfaces;
using Domain.Interfaces.Repository;
using Domain.UserIdentity.Masters;

namespace Api.Service.Services.CategoriaProduto
{
    public class CategoriaProdutoService : ICategoriaProdutoService
    {
        private readonly ICategoriaProdutoRepository? _implementacao;
        private readonly IMapper? _mapper;
        private readonly IBaseRepository<CategoriaProdutoEntity> _repositoryBase;
        public CategoriaProdutoService(ICategoriaProdutoRepository? implementacao, IMapper? mapper, IBaseRepository<CategoriaProdutoEntity> repositoryBase)
        {
            _implementacao = implementacao;
            _mapper = mapper;
            _repositoryBase = repositoryBase;
        }
        public async Task<RequestResult> GetAll(UserMasterUserDtoCreate users)
        {
            try
            {
                var entities = await _implementacao.GetAll(users);
                if (entities == null || entities.Count() == 0)
                    return new RequestResult().IsNullOrCountZero();

                return new RequestResult().Ok(_mapper!.Map<IEnumerable<CategoriaProdutoDto>>(entities));
            }
            catch (Exception ex)
            {

                return new RequestResult().BadRequest(ex.Message);
            }
        }
        public async Task<RequestResult> GetByIdCategoria(Guid id, UserMasterUserDtoCreate users)
        {
            try
            {
                var entities = await _implementacao!.GetByIdCategoria(id, users);
                if (entities == null)
                    return new RequestResult().IsNullOrCountZero();

                return new RequestResult().Ok(_mapper!.Map<CategoriaProdutoDto>(entities));
            }
            catch (Exception ex)
            {

                return new RequestResult().BadRequest(ex.Message);
            }
        }
        public async Task<RequestResult> Create(CategoriaProdutoDtoCreate create, UserMasterUserDtoCreate users)
        {
            try
            {
                var entity = new CategoriaProdutoEntity(create, users);
                if (!entity.Validada)
                    return new RequestResult().EntidadeInvalida();

                var entityResult = await _repositoryBase.InsertAsync(entity);

                return new RequestResult().Ok(_mapper.Map<CategoriaProdutoDto>(entityResult));
            }
            catch (Exception ex)
            {

                return new RequestResult().BadRequest(ex.Message);
            }
        }
        public async Task<RequestResult> Update(CategoriaProdutoDtoUpdate update, UserMasterUserDtoCreate users)
        {
            try
            {
                var entity = new CategoriaProdutoEntity(update, users);
                if (!entity.Validada)
                    return new RequestResult().EntidadeInvalida();

                var entityResult = await _repositoryBase.UpdateAsync(entity);

                return new RequestResult().Ok(_mapper.Map<CategoriaProdutoDto>(entityResult));
            }
            catch (Exception ex)
            {

                return new RequestResult().BadRequest(ex.Message);
            }
        }
    }
}