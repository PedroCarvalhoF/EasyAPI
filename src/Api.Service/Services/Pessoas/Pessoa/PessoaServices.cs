using AutoMapper;
using Domain.Dtos.PessoasDtos.PessoaDtos;
using Domain.Entities.Pessoa.Pessoas;
using Domain.ExceptionsPersonalizadas;
using Domain.Interfaces;
using Domain.Interfaces.Services.Pessoas.Pessoa;
using Domain.Models.PessoaModels.PessoaModels;
using Domain.Repository.PessoaRepositorys.Pessoa;

namespace Service.Services.Pessoas.Pessoa
{
    public class PessoaServices : IPessoaServices
    {
        private readonly IRepository<PessoaEntity> _repository;
        private readonly IMapper _mapper;
        private readonly IPessoaRepository _pessoaRepository;

        public PessoaServices(IRepository<PessoaEntity> repository, IMapper mapper, IPessoaRepository pessoaRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _pessoaRepository = pessoaRepository;
        }
        public async Task<PessoaDto> Get(Guid idPessoa)
        {
            try
            {
                PessoaEntity entity = await _pessoaRepository.Get(idPessoa);

                PessoaDto dto = _mapper.Map<PessoaDto>(entity);

                return dto;
            }
            catch (ModelsExceptions ex)
            {
                throw new ModelsExceptions(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<IEnumerable<PessoaDto>> GetAll()
        {
            try
            {
                IEnumerable<PessoaEntity> entities = await _pessoaRepository.GetAll();

                IEnumerable<PessoaDto> dtos = _mapper.Map<IEnumerable<PessoaDto>>(entities);

                return dtos;
            }
            catch (ModelsExceptions ex)
            {
                throw new ModelsExceptions(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<PessoaDto>> GetAll(Guid pessoaTipo)
        {
            try
            {
                IEnumerable<PessoaEntity> entities = await _pessoaRepository.GetAll(pessoaTipo);

                IEnumerable<PessoaDto> dtos = _mapper.Map<IEnumerable<PessoaDto>>(entities);

                return dtos;
            }
            catch (ModelsExceptions ex)
            {
                throw new ModelsExceptions(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<PessoaDto> Create(PessoaDtoCreate pessoaCreate)
        {
            try
            {
                PessoasModels model = _mapper.Map<PessoasModels>(pessoaCreate);
                PessoaEntity entity = _mapper.Map<PessoaEntity>(model);
                PessoaEntity result = await _repository.InsertAsync(entity);
                PessoaEntity entityResult = await _pessoaRepository.Get(result.Id);
                PessoaDto dtoResult = _mapper.Map<PessoaDto>(entityResult);
                return dtoResult;
            }
            catch (ModelsExceptions ex)
            {
                throw new ModelsExceptions(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<PessoaDto> Update(PessoaDtoUpdate pessoaDto)
        {
            try
            {
                PessoasModels models = _mapper.Map<PessoasModels>(pessoaDto);
                PessoaEntity entity = _mapper.Map<PessoaEntity>(models);
                PessoaEntity updateResultEntity = await _repository.UpdateAsync(entity);

                PessoaEntity result = await _pessoaRepository.Get(updateResultEntity.Id);

                PessoaDto resultDto = _mapper.Map<PessoaDto>(result);

                return resultDto;
            }
            catch (ModelsExceptions ex)
            {
                throw new ModelsExceptions(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
