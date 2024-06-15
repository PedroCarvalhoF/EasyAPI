using Api.Domain.Dtos.ProdutoMedidaDtos;
using Api.Domain.Entities.ProdutoMedida;
using Api.Domain.Interfaces.Services.ProdutoMedida;
using AutoMapper;
using Domain.Dtos;
using Domain.Interfaces;
using Domain.Interfaces.Repository.Produto;
using Domain.UserIdentity.Masters;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Service.Services.ProdutoMedidaService
{
    public class ProdutoMedidaService : IProdutoMedidaServices
    {
        private readonly IBaseRepository<ProdutoMedidaEntity> _repository;
        private readonly IProdutoMedidaRepository _implementation;
        private readonly IMapper _mapper;
        public ProdutoMedidaService(IBaseRepository<ProdutoMedidaEntity> repository,
                                    IMapper mapper,
                                    IProdutoMedidaRepository implementation)
        {
            _repository = repository;
            _mapper = mapper;
            _implementation = implementation;
        }
        public async Task<RequestResult> GetAll(UserMasterUserDtoCreate users)
        {
            try
            {
                var entities = await _implementation.GetAll(users);
                if (entities == null || entities.Count() == 0)
                    return new RequestResult().IsNullOrCountZero();

                return new RequestResult().Ok(_mapper.Map<IEnumerable<ProdutoMedidaDto>>(entities));
            }
            catch (Exception ex)
            {

                return new RequestResult().BadRequest(ex.Message);
            }
        }
        public async Task<RequestResult> GetByIdMididaProduto(Guid id, UserMasterUserDtoCreate users)
        {
            try
            {
                var entity = await _implementation.GetByIdMididaProduto(id, users);
                if (entity == null)
                    return new RequestResult().IsNullOrCountZero();

                return new RequestResult().Ok(_mapper.Map<ProdutoMedidaDto>(entity));
            }
            catch (Exception ex)
            {

                return new RequestResult().BadRequest(ex.Message);
            }
        }
        public async Task<RequestResult> Create(ProdutoMedidaDtoCreate create, UserMasterUserDtoCreate users)
        {
            try
            {
                var entity = new ProdutoMedidaEntity(create, users);
                if (!entity.isValidada)
                    return new RequestResult().EntidadeInvalida(entity);

                var result = await _repository.InsertAsync(entity);
                if (result == null)
                    return new RequestResult().BadRequest("Erro ao cadastrar");

                return new RequestResult().Ok(_mapper.Map<ProdutoMedidaDto>(result));
            }
            catch (Exception ex)
            {

                return new RequestResult().BadRequest(ex.Message);
            }
        }
        public async Task<RequestResult> Update(ProdutoMedidaDtoUpdate update, UserMasterUserDtoCreate users)
        {
            try
            {
                var entity = new ProdutoMedidaEntity(update, users);
                if (!entity.isValidada)
                    return new RequestResult().EntidadeInvalida(entity);

                var result = await _repository.UpdateAsync(entity);
                if (result == null)
                    return new RequestResult().BadRequest("Erro ao atualizar");

                return new RequestResult().Ok(_mapper.Map<ProdutoMedidaDto>(result));
            }
            catch (Exception ex)
            {

                return new RequestResult().BadRequest(ex.Message);
            }
        }
    }
}