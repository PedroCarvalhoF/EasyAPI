using Api.Domain.Dtos.CategoriaProdutoDtos;
using AutoMapper;
using Domain.Dtos;
using Domain.Dtos.ProdutoTipo;
using Domain.Entities.ProdutoTipo;
using Domain.Interfaces;
using Domain.Interfaces.Repository.Produto;
using Domain.Interfaces.Services.ProdutoTipo;
using Domain.UserIdentity.Masters;

namespace Service.Services.ProdutoTipoService
{
    public class ProdutoTipoServices : IProdutoTipoServices
    {
        private readonly IBaseRepository<ProdutoTipoEntity> _repository;
        private readonly IMapper _mapper;
        private readonly IProdutoTipoRepository _implementacao;

        public ProdutoTipoServices(IBaseRepository<ProdutoTipoEntity> repository, IMapper mapper, IProdutoTipoRepository implementacao)
        {
            _repository = repository;
            _mapper = mapper;
            _implementacao = implementacao;
        }

        public async Task<RequestResult> GetAll(UserMasterUserDtoCreate user)
        {
            try
            {
                var entities = await _implementacao.GetAll(user);
                if (entities == null)
                {
                    return new RequestResult().BadRequest("Nenhum resultado encontrado");
                }

                var dtos = _mapper.Map<IEnumerable<ProdutoTipoDto>>(entities);
                return new RequestResult().Ok(dtos);
            }
            catch (Exception ex)
            {
                return new RequestResult().BadRequest(ex.Message);
            }
        }
        public async Task<RequestResult> GetByIdTipoProduto(Guid id, UserMasterUserDtoCreate users)
        {
            try
            {
                var entities = await _implementacao!.GetByIdTipoProduto(id, users);
                if (entities == null)
                    return new RequestResult().IsNullOrCountZero();

                return new RequestResult().Ok(_mapper!.Map<ProdutoTipoDto>(entities));
            }
            catch (Exception ex)
            {

                return new RequestResult().BadRequest(ex.Message);
            }
        }
        public async Task<RequestResult> Create(ProdutoTipoDtoCreate create, UserMasterUserDtoCreate user)
        {
            try
            {

                var entity = new ProdutoTipoEntity(create, user);
                var resultCreate = await _repository.InsertAsync(entity);

                if (resultCreate == null)
                {
                    return new RequestResult().IsNullOrCountZero();
                }

                return new RequestResult().Ok(_mapper.Map<ProdutoTipoDto>(resultCreate));

            }
            catch (Exception ex)
            {
                return new RequestResult().BadRequest(ex.Message);
            }
        }
        public async Task<RequestResult> Update(ProdutoTipoDtoUpdate update, UserMasterUserDtoCreate user)
        {
            try
            {
                var entity = new ProdutoTipoEntity(update, user);

                if (!entity.isBaseValida)
                    return new RequestResult().BadRequest("Não foi possível realizar Update.");

                var resultUpdate = await _repository.UpdateAsync(entity);


                if (resultUpdate == null)
                {
                    return new RequestResult().IsNullOrCountZero();
                }

                return new RequestResult().Ok(_mapper.Map<ProdutoTipoDto>(resultUpdate));
            }
            catch (Exception ex)
            {
                return new RequestResult().BadRequest(ex.Message);
            }
        }
    }
}

