using AutoMapper;
using Domain.Dtos;
using Domain.Dtos.Pessoas.DadosBancarios;
using Domain.Entities.Pessoa.DadosBancarios;
using Domain.Entities.Pessoa.Pessoas;
using Domain.Interfaces;
using Domain.Interfaces.Repository.Pessoa.Pessoa;
using Domain.Interfaces.Services.Pessoas.Pessoa;
using Domain.Models.Pessoas.Pessoa;

namespace Service.Services.Pessoas.DadosBancarios
{
    public class DadosBancariosService : IDadosBancariosServices
    {
        private readonly IMapper? _mapper;
        private readonly IBaseRepository<DadosBancariosEntity>? _dadosBaseRepository;
        private readonly IRepositoryGeneric<PessoaDadosBancariosEntity>? _pessoaDadosBancarioRepository;
        private readonly IDadosBancariosRepository? _dadosImplementacao;

        public DadosBancariosService(IMapper? mapper,
                                     IBaseRepository<DadosBancariosEntity>? dadosBaseRepository, IRepositoryGeneric<PessoaDadosBancariosEntity>? repositoryGeneric,
                                     IDadosBancariosRepository? dadosImplementacao)
        {
            _mapper = mapper;
            _dadosBaseRepository = dadosBaseRepository;
            _dadosImplementacao = dadosImplementacao;
            _pessoaDadosBancarioRepository = repositoryGeneric;
        }

        public async Task<ResponseDto<List<DadosBancariosDto>>> GetAll(bool include = false)
        {
            try
            {
                var entities = await _dadosImplementacao.GetAll(include);

                if (entities == null || entities.Count() == 0)
                {
                    return new ResponseDto<List<DadosBancariosDto>>().EntitiesNull();
                }

                var dtos = _mapper.Map<List<DadosBancariosDto>>(entities);

                return new ResponseDto<List<DadosBancariosDto>>().Retorno(dtos);
            }
            catch (Exception ex)
            {

                return new ResponseDto<List<DadosBancariosDto>>().Erro(ex);
            }
        }

        public async Task<ResponseDto<List<DadosBancariosDto>>> GetByAgencia(string agencia, bool include = false)
        {
            try
            {
                var entities = await _dadosImplementacao.GetByAgencia(agencia, include);

                if (entities == null || entities.Count() == 0)
                {
                    return new ResponseDto<List<DadosBancariosDto>>().EntitiesNull();
                }

                var dtos = _mapper.Map<List<DadosBancariosDto>>(entities);

                return new ResponseDto<List<DadosBancariosDto>>().Retorno(dtos);
            }
            catch (Exception ex)
            {

                return new ResponseDto<List<DadosBancariosDto>>().Erro(ex);
            }
        }

        public async Task<ResponseDto<List<DadosBancariosDto>>> GetByContaCorrente(string contaComDigito, bool include = false)
        {
            try
            {
                var entities = await _dadosImplementacao.GetByContaCorrente(contaComDigito, include);

                if (entities == null)
                {
                    return new ResponseDto<List<DadosBancariosDto>>().EntitiesNull();
                }

                var dtos = _mapper.Map<DadosBancariosDto>(entities);

                return new ResponseDto<List<DadosBancariosDto>>().Retorno(new List<DadosBancariosDto>() { dtos });
            }
            catch (Exception ex)
            {

                return new ResponseDto<List<DadosBancariosDto>>().Erro(ex);
            }
        }

        public async Task<ResponseDto<List<DadosBancariosDto>>> Create(DadosBancariosDtoCreate create)
        {
            try
            {
                var model = _mapper.Map<DadosBancariosModel>(create);
                var entity = _mapper.Map<DadosBancariosEntity>(model);

                var result = await _dadosBaseRepository.InsertAsync(entity);
                if (result == null)
                {
                    return new ResponseDto<List<DadosBancariosDto>>().ErroCadastro();
                }

                var dadosBancarioEntity = new PessoaDadosBancariosEntity
                {
                    PessoaEntityId = create.PessoaId,
                    DadosBancariosEntityId = result.Id
                };

                var pessoaDadosBancario = await _pessoaDadosBancarioRepository.InsertGenericAsync(dadosBancarioEntity);

                return new ResponseDto<List<DadosBancariosDto>>().CadastroOk();
            }
            catch (Exception ex)
            {

                return new ResponseDto<List<DadosBancariosDto>>().Erro(ex);
            }
        }
        public async Task<ResponseDto<List<DadosBancariosDto>>> Update(DadosBancariosDtoUpdate update)
        {
            try
            {
                var model = _mapper.Map<DadosBancariosModel>(update);
                var entity = _mapper.Map<DadosBancariosEntity>(model);

                var result = await _dadosBaseRepository.UpdateAsync(entity);
                if (result == null)
                {
                    return new ResponseDto<List<DadosBancariosDto>>().ErroUpdate();
                }

                return new ResponseDto<List<DadosBancariosDto>>().CadastroOk();
            }
            catch (Exception ex)
            {

                return new ResponseDto<List<DadosBancariosDto>>().Erro(ex);
            }
        }
    }
}
