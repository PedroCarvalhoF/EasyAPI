using Api.Domain.Dtos.ProdutoMedidaDtos;
using Api.Domain.Entities.ProdutoMedida;
using Api.Domain.Interfaces.Services.ProdutoMedida;
using AutoMapper;
using Domain.Interfaces;
using Domain.Interfaces.Repository;

namespace Service.Services.ProdutoMedidaService
{
    public class ProdutoMedidaServices : IProdutoMedidaServices
    {
        private readonly IRepository<ProdutoMedidaEntity>? _repository;
        private readonly IProdutoMedidaRepository? _implementation;
        private readonly IMapper? _mapper;
        public ProdutoMedidaServices(IRepository<ProdutoMedidaEntity>? repository, IMapper? mapper, IProdutoMedidaRepository? implementation)
        {
            _repository = repository;
            _mapper = mapper;
            _implementation = implementation;
        }
        public async Task<ProdutoMedidaDto> Get(Guid id)
        {
            try
            {
                ProdutoMedidaEntity entity = await _repository.SelectAsync(id);
                ProdutoMedidaDto dto = _mapper.Map<ProdutoMedidaDto>(entity);
                return dto;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<ProdutoMedidaDto>> Get(string descricao)
        {
            IEnumerable<ProdutoMedidaEntity> entity = await _implementation.Get(descricao);
            return _mapper.Map<IEnumerable<ProdutoMedidaDto>>(entity);
        }

        public async Task<IEnumerable<ProdutoMedidaDto>> GetAll()
        {
            IEnumerable<ProdutoMedidaEntity> entity = await _repository.SelectAsync();
            return _mapper.Map<IEnumerable<ProdutoMedidaDto>>(entity);
        }
        public async Task<ProdutoMedidaDto> Create(ProdutoMedidaDtoCreate create)
        {
            ProdutoMedidaEntity entity = _mapper.Map<ProdutoMedidaEntity>(create);
            ProdutoMedidaEntity result = await _repository.InsertAsync(entity);
            ProdutoMedidaDto dto = _mapper.Map<ProdutoMedidaDto>(result);

            return dto;
        }

        public async Task<ProdutoMedidaDto> Update(ProdutoMedidaDtoUpdate update)
        {
            ProdutoMedidaEntity entity = _mapper.Map<ProdutoMedidaEntity>(update);
            ProdutoMedidaEntity result = await _repository.UpdateAsync(entity);
            ProdutoMedidaDto dto = _mapper.Map<ProdutoMedidaDto>(result);

            return dto;
        }
        public async Task<bool> Desabilitar(Guid id)
        {
            bool result = await _repository.DeleteAsync(id);
            return result;
        }
    }
}
