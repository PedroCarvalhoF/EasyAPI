using AutoMapper;
using Domain.Dtos;
using Domain.Dtos.Pessoas.Endereco;
using Domain.Entities.Pessoa.Endereco;
using Domain.Entities.Pessoa.Pessoas;
using Domain.Interfaces;
using Domain.Interfaces.Repository.Pessoa.Endereco;
using Domain.Interfaces.Services.Pessoas.Endereco;
using Domain.Interfaces.Services.Pessoas.PessoaEndereco;
using Domain.Models.Pessoas.Endereco;

namespace Service.Services.Pessoas.Endereco
{
    public class EnderecoServices : IEnderecoServices
    {
        private readonly IEnderecoRepository? _enderecoImplementacao;
        private readonly IBaseRepository<EnderecoEntity>? _baseRepository;
        private readonly IRepositoryGeneric<EnderecoEntity>? _repositoryGenerec;
        private readonly IMapper? _mapper;
        private readonly IPessoaEnderecoServices? _pessoaEnderecoService;

        public EnderecoServices(IMapper mapper, IEnderecoRepository? enderecoImplementacao, IBaseRepository<EnderecoEntity>? baseRepository, IRepositoryGeneric<EnderecoEntity>? repositoryGenerec, IPessoaEnderecoServices pessoaEnderecoServices)
        {
            _enderecoImplementacao = enderecoImplementacao;
            _baseRepository = baseRepository;
            _repositoryGenerec = repositoryGenerec;
            _mapper = mapper;
            _pessoaEnderecoService = pessoaEnderecoServices;
        }

        public async Task<ResponseDto<List<EnderecoDto>>> GetAll(bool include)
        {
            try
            {
                IEnumerable<EnderecoEntity> entities = await _enderecoImplementacao.GetAll(include);
                if (entities == null || entities.Count() == 0)
                {
                    return new ResponseDto<List<EnderecoDto>>().EntitiesNull();
                }

                var dtos = _mapper.Map<List<EnderecoDto>>(entities);

                return new ResponseDto<List<EnderecoDto>>().Retorno(dtos);
            }
            catch (Exception ex)
            {
                return new ResponseDto<List<EnderecoDto>>().Erro(ex);
            }
        }
        public async Task<ResponseDto<List<EnderecoDto>>> Create(EnderecoDtoCreate create)
        {
            try
            {
                var model = _mapper.Map<EnderecoModel>(create);
                var entity = _mapper.Map<EnderecoEntity>(model);
                var result = await _baseRepository.InsertAsync(entity);

                if (result == null)
                    return new ResponseDto<List<EnderecoDto>>().EntitiesNull();

                var pessoaEnderecoEntity = new PessoaEnderecoEntity
                {
                    PessoaEntityId = create.PessoaId,
                    EnderecoEntityId = result.Id
                };

                var resultPessoaEndereco = await _pessoaEnderecoService.CreatePessoaEndereco(pessoaEnderecoEntity);
                if (resultPessoaEndereco)
                    return new ResponseDto<List<EnderecoDto>>().CadastroOk();

                return new ResponseDto<List<EnderecoDto>>().ErroCadastro();

            }
            catch (Exception ex)
            {

                return new ResponseDto<List<EnderecoDto>>().Erro(ex);
            }
        }

        public async Task<ResponseDto<List<EnderecoDto>>> Update(EnderecoDtoUpdate update)
        {
            try
            {
                var model = _mapper.Map<EnderecoModel>(update);
                var entity = _mapper.Map<EnderecoEntity>(model);
                var result = await _baseRepository.UpdateAsync(entity);

                if (result == null)
                    return new ResponseDto<List<EnderecoDto>>().EntitiesNull();

                return new ResponseDto<List<EnderecoDto>>().UpdateOk();

            }
            catch (Exception ex)
            {

                return new ResponseDto<List<EnderecoDto>>().Erro(ex);
            }
        }
    }
}
