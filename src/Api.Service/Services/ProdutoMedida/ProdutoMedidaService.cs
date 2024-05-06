using Api.Domain.Dtos.ProdutoMedidaDtos;
using Api.Domain.Entities.ProdutoMedida;
using Api.Domain.Interfaces.Services.ProdutoMedida;
using Api.Domain.Models.ProdutoMedidaModels;
using AutoMapper;
using Domain.Dtos;
using Domain.Interfaces;
using Domain.Interfaces.Repository;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Service.Services.ProdutoMedidaService
{
    public class ProdutoMedidaService : IProdutoMedidaServices
    {
        private readonly IRepository<ProdutoMedidaEntity> _repository;
        private readonly IProdutoMedidaRepository _implementation;
        private readonly IMapper _mapper;
        public ProdutoMedidaService(IRepository<ProdutoMedidaEntity> repository,
                                    IMapper mapper,
                                    IProdutoMedidaRepository implementation)
        {
            _repository = repository;
            _mapper = mapper;
            _implementation = implementation;
        }
        public async Task<ResponseDto<List<ProdutoMedidaDto>>> GetAll()
        {
            ResponseDto<List<ProdutoMedidaDto>> response = new ResponseDto<List<ProdutoMedidaDto>>();
            response.Dados = new List<ProdutoMedidaDto>();
            try
            {
                var entity = await _repository.SelectAsync();

                if (entity == null)
                {
                    response.ErroConsulta();
                    return response;
                }

                var models = _mapper.Map<List<ProdutoMedidaModel>>(entity);
                var dtos = _mapper.Map<List<ProdutoMedidaDto>>(models);
                response.Dados = dtos;

                return response;
            }
            catch (Exception ex)
            {
                response.Erro(ex.Message);
                return response;
            }
        }
        public async Task<ResponseDto<List<ProdutoMedidaDto>>> Get(Guid id)
        {
            ResponseDto<List<ProdutoMedidaDto>> response = new ResponseDto<List<ProdutoMedidaDto>>();
            response.Dados = new List<ProdutoMedidaDto>();
            try
            {
                var entity = await _repository.SelectAsync(id);

                if (entity == null)
                {
                    response.ErroConsulta();
                    return response;
                }

                var models = _mapper.Map<ProdutoMedidaModel>(entity);
                var dtos = _mapper.Map<ProdutoMedidaDto>(models);
                response.Dados.Add(dtos);

                return response;
            }
            catch (Exception ex)
            {
                response.Erro(ex.Message);
                return response;
            }
        }

        public async Task<ResponseDto<List<ProdutoMedidaDto>>> Get(string descricao)
        {
            ResponseDto<List<ProdutoMedidaDto>> response = new ResponseDto<List<ProdutoMedidaDto>>();
            response.Dados = new List<ProdutoMedidaDto>();
            try
            {
                var entity = await _implementation.Get(descricao);

                if (entity == null)
                {
                    response.ErroConsulta();
                    return response;
                }

                var models = _mapper.Map<ProdutoMedidaModel>(entity);
                var dtos = _mapper.Map<ProdutoMedidaDto>(models);
                response.Dados.Add(dtos);

                return response;
            }
            catch (Exception ex)
            {
                response.Erro(ex.Message);
                return response;
            }
        }
        public async Task<ResponseDto<List<ProdutoMedidaDto>>> Create(ProdutoMedidaDtoCreate create)
        {
            ResponseDto<List<ProdutoMedidaDto>> response = new ResponseDto<List<ProdutoMedidaDto>>();
            response.Dados = new List<ProdutoMedidaDto>();
            try
            {
                var model = _mapper.Map<ProdutoMedidaModel>(create);
                var entity = _mapper.Map<ProdutoMedidaEntity>(model);
                var result = await _repository.InsertAsync(entity);

                if (entity == null)
                {
                    response.ErroCadastro();
                    return response;
                }

                var resultCreate = await Get(result.Id);

                if (resultCreate.Status)
                {
                    response = resultCreate;
                    return response;
                }
                else
                {
                    response.ErroCadastro();
                    return response;
                }
            }
            catch (Exception ex)
            {
                response.Erro(ex.Message);
                return response;
            }
        }
        public async Task<ResponseDto<List<ProdutoMedidaDto>>> Update(ProdutoMedidaDtoUpdate update)
        {
            ResponseDto<List<ProdutoMedidaDto>> response = new ResponseDto<List<ProdutoMedidaDto>>();
            response.Dados = new List<ProdutoMedidaDto>();
            try
            {
                var model = _mapper.Map<ProdutoMedidaModel>(update);
                var entity = _mapper.Map<ProdutoMedidaEntity>(model);
                var result = await _repository.UpdateAsync(entity);

                if (entity == null)
                {
                    response.ErroUpdate();
                    return response;
                }

                var resultUpdate = await Get(result.Id);

                if (resultUpdate.Status)
                {
                    response = resultUpdate;
                    return response;
                }
                else
                {
                    response.ErroUpdate();
                    return response;
                }
            }
            catch (Exception ex)
            {
                response.Erro(ex.Message);
                return response;
            }
        }
        public async Task<ResponseDto<List<ProdutoMedidaDto>>> Desabilitar(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
