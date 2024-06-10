using AutoMapper;
using Domain.Dtos;
using Domain.Dtos.Pessoas.Contato;
using Domain.Entities.Pessoa.Contato;
using Domain.Entities.Pessoa.PessoaContato;
using Domain.Interfaces;
using Domain.Interfaces.Repository.Pessoa.Contato;
using Domain.Interfaces.Services.Pessoas.Contato;
using Domain.Models.Pessoas.Contato;

namespace Service.Services.Pessoas.Contato
{
    public class ContatoService : IContatoServices
    {
        private readonly IMapper? _mapper;
        private readonly IContatoRepository? _contatoImplementacao;
        private readonly IBaseRepository<ContatoEntity> _baseRepository;
        private readonly IRepositoryGeneric<PessoaContatoEntity> _repositoryGeneric;

        public ContatoService(IMapper mapper, IContatoRepository contatoImplementacao, IBaseRepository<ContatoEntity> baseRepository, IRepositoryGeneric<PessoaContatoEntity> repositoryGeneric)
        {
            _mapper = mapper;
            _contatoImplementacao = contatoImplementacao;
            _baseRepository = baseRepository;
            _repositoryGeneric = repositoryGeneric;
        }
        public async Task<ResponseDto<List<ContatoDto>>> GetAllContatos()
        {
            try
            {
                IEnumerable<ContatoEntity> entities = await _contatoImplementacao.GetAllContatos();
                if (entities == null || entities.Count() == 0)
                    return new ResponseDto<List<ContatoDto>>().EntitiesNull();

                var dtos = _mapper.Map<List<ContatoDto>>(entities);

                return new ResponseDto<List<ContatoDto>>().Retorno(dtos);
            }
            catch (Exception ex)
            {

                return new ResponseDto<List<ContatoDto>>().Erro(ex);
            }
        }
        public async Task<ResponseDto<List<ContatoDto>>> GetByContatoId(Guid idContato)
        {
            try
            {
                ContatoEntity entities = await _contatoImplementacao.GetByContatoId(idContato);
                if (entities == null)
                    return new ResponseDto<List<ContatoDto>>().EntitiesNull();

                var dtos = _mapper.Map<ContatoDto>(entities);

                return new ResponseDto<List<ContatoDto>>().Retorno(new List<ContatoDto>() { dtos });
            }
            catch (Exception ex)
            {

                return new ResponseDto<List<ContatoDto>>().Erro(ex);
            }
        }
        public async Task<ResponseDto<List<ContatoDto>>> CreateContato(ContatoDtoCreate create)
        {
            try
            {
                var model = _mapper.Map<ContatoModel>(create);
                var entity = _mapper.Map<ContatoEntity>(model);

                var result = await _baseRepository.InsertAsync(entity);
                if (result == null)
                    return new ResponseDto<List<ContatoDto>>().EntitiesNull();

                var pessoaContato = new PessoaContatoEntity
                {
                    ContatoEntityId = result.Id,
                    PessoaEntityId = create.PessoaId
                };

                var pessoaContatoResult = await _repositoryGeneric.InsertGenericAsync(pessoaContato);
                if (pessoaContatoResult == null)
                    return new ResponseDto<List<ContatoDto>>().Erro();



                return new ResponseDto<List<ContatoDto>>().CadastroOk();
            }
            catch (Exception ex)
            {
                return new ResponseDto<List<ContatoDto>>().Erro(ex);
            }
        }
        public async Task<ResponseDto<List<ContatoDto>>> UpdateContato(ContatoDtoUpdate update)
        {

            try
            {
                var model = _mapper.Map<ContatoModel>(update);
                var entity = _mapper.Map<ContatoEntity>(model);

                var result = await _baseRepository.UpdateAsync(entity);
                if (result == null)
                    return new ResponseDto<List<ContatoDto>>().EntitiesNull();

                return new ResponseDto<List<ContatoDto>>().AlteracaoOk();
            }
            catch (Exception ex)
            {
                return new ResponseDto<List<ContatoDto>>().Erro(ex);
            }
        }

        public async Task<ResponseDto<List<ContatoDto>>> DeleteContato(Guid idContato)
        {
            try
            {
                var result = await _baseRepository.DeleteAsync(idContato);
                if (result)
                    return new ResponseDto<List<ContatoDto>>().DeleteOK();
                else
                    return new ResponseDto<List<ContatoDto>>().Erro("Nao foi possível deletar");
            }
            catch (Exception ex)
            {
                return new ResponseDto<List<ContatoDto>>().Erro(ex);
            }
        }
    }
}
