using AutoMapper;
using Data.Migrations;
using Domain.Dtos;
using Domain.Dtos.PessoasDtos.PessoaDtos;
using Domain.Entities.Pessoa.Pessoas;
using Domain.Enuns;
using Domain.Interfaces;
using Domain.Interfaces.Repository.PessoaRepositorys.Pessoa;
using Domain.Interfaces.Services.Pessoas.Pessoa;
using Domain.Models.PessoaModels.PessoaModels;

namespace Service.Services.Pessoas.Pessoa
{
    public class PessoaServices : IPessoaServices
    {
        private readonly IRepository<PessoaEntity> _repository;
        private readonly IMapper _mapper;
        private readonly IPessoaRepository _implementacao;

        public PessoaServices(IRepository<PessoaEntity> repository, IMapper mapper, IPessoaRepository pessoaRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _implementacao = pessoaRepository;
        }

        public async Task<ResponseDto<List<PessoaDto>>> Get(Guid idPessoa, bool include = false)
        {
            try
            {
                var entity = await _implementacao.Get(idPessoa, include);
                if (entity == null)
                {
                    return new ResponseDto<List<PessoaDto>>().EntitiesNull();
                }

                var dto = _mapper.Map<PessoaDto>(entity);

                var response = new ResponseDto<List<PessoaDto>>();

                return response.Retorno(new List<PessoaDto>() { dto });

            }
            catch (Exception ex)
            {

                return new ResponseDto<List<PessoaDto>>().Erro(ex);
            }
        }
        public async Task<ResponseDto<List<PessoaDto>>> GetAll(bool include = false)
        {
            try
            {
                var entities = await _implementacao.GetAll(include);
                if (entities == null || entities.Count() == 0)
                {
                    return new ResponseDto<List<PessoaDto>>().EntitiesNull();
                }

                var dtos = _mapper.Map<List<PessoaDto>>(entities);

                var response = new ResponseDto<List<PessoaDto>>();

                return response.Retorno(dtos);

            }
            catch (Exception ex)
            {

                return new ResponseDto<List<PessoaDto>>().Erro(ex);
            }
        }
        public async Task<ResponseDto<List<PessoaDto>>> GetAllByPessoaTipo(PessoaTipoEnum pessoaTipo, bool include = false)
        {
            try
            {
                var entities = await _implementacao.GetAllByPessoaTipo(pessoaTipo, include);
                if (entities == null || entities.Count() == 0)
                {
                    return new ResponseDto<List<PessoaDto>>().EntitiesNull();
                }

                var dtos = _mapper.Map<List<PessoaDto>>(entities);

                var response = new ResponseDto<List<PessoaDto>>();

                return response.Retorno(dtos);

            }
            catch (Exception ex)
            {

                return new ResponseDto<List<PessoaDto>>().Erro(ex);
            }
        }
        public async Task<ResponseDto<List<PessoaDto>>> Create(PessoaDtoCreate pessoaDtoCreate)
        {
            try
            {
                var model = _mapper.Map<PessoasModel>(pessoaDtoCreate);
                var entity = _mapper.Map<PessoaEntity>(model);
                var entityCreate = await _repository.InsertAsync(entity);
                if (entityCreate == null)
                {
                    return new ResponseDto<List<PessoaDto>>().EntitiesNull();
                }

                var result = await Get(entity.Id);
                if (result.Status)
                {
                    result.Mensagem = "Cadastro efetuado com sucesso";
                    return result;
                }

                return new ResponseDto<List<PessoaDto>>().Erro("Não foi possível realizar cadastro");
            }
            catch (Exception ex)
            {

                return new ResponseDto<List<PessoaDto>>().Erro(ex);
            }
        }
        public async Task<ResponseDto<List<PessoaDto>>> Update(PessoaDtoCreate pesssoaUpdate)
        {
            try
            {
                var model = _mapper.Map<PessoasModel>(pesssoaUpdate);
                var entity = _mapper.Map<PessoaEntity>(model);
                var entityUpdate = await _repository.UpdateAsync(entity);
                if (entityUpdate == null)
                {
                    return new ResponseDto<List<PessoaDto>>().EntitiesNull();
                }

                var result = await Get(entity.Id);
                if (result.Status)
                {
                    result.Mensagem = "Alteração realizada com sucesso";
                    return result;
                }

                return new ResponseDto<List<PessoaDto>>().Erro("Não foi possível realizar alteração");
            }
            catch (Exception ex)
            {

                return new ResponseDto<List<PessoaDto>>().Erro(ex);
            }
        }
    }
}