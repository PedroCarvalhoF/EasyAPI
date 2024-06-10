using AutoMapper;
using Domain.Dtos;
using Domain.Dtos.Pessoa.Funcionario.Funcao;
using Domain.Entities.Pessoa.Funcionario.Funcao;
using Domain.Interfaces;
using Domain.Interfaces.Repository.Pessoa.Funcionario.Funcao;
using Domain.Interfaces.Services.Pessoa.Funcionario.Funcao;
using Domain.Models.Pessoa.Funcionario.Funcao;

namespace Service.Services.Pessoa.Funcionario.Funcao
{
    public class FuncaoFuncionarioServices : IFuncaoFuncionarioServices
    {
        private readonly IFuncaoFuncionarioRepository? _funcaoImplementacao;
        private readonly IBaseRepository<FuncaoFuncionarioEntity>? _repository;
        private readonly IMapper? _mapper;

        public FuncaoFuncionarioServices(IFuncaoFuncionarioRepository? funcaoImplementacao, IBaseRepository<FuncaoFuncionarioEntity>? repository, IMapper? mapper)
        {
            _funcaoImplementacao = funcaoImplementacao;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponseDto<List<FuncaoFuncionarioDto>>> GetAll()
        {
            try
            {
                IEnumerable<FuncaoFuncionarioEntity> entites = await _funcaoImplementacao.GetAll();
                if (entites == null || entites.Count() == 0)
                    return new ResponseDto<List<FuncaoFuncionarioDto>>().EntitiesNull();

                var dtos = _mapper.Map<List<FuncaoFuncionarioDto>>(entites);

                return new ResponseDto<List<FuncaoFuncionarioDto>>().Retorno(dtos);
            }
            catch (Exception ex)
            {
                return new ResponseDto<List<FuncaoFuncionarioDto>>().Erro(ex);
            }
        }

        public async Task<ResponseDto<List<FuncaoFuncionarioDto>>> GetById(Guid funcaoId)
        {
            try
            {
                FuncaoFuncionarioEntity entity = await _funcaoImplementacao.GetById(funcaoId);
                if (entity == null)
                    return new ResponseDto<List<FuncaoFuncionarioDto>>().EntitiesNull();

                var dto = _mapper.Map<FuncaoFuncionarioDto>(entity);

                return new ResponseDto<List<FuncaoFuncionarioDto>>().Retorno(new List<FuncaoFuncionarioDto>() { dto });
            }
            catch (Exception ex)
            {

                return new ResponseDto<List<FuncaoFuncionarioDto>>().Erro(ex);
            }
        }

        public async Task<ResponseDto<List<FuncaoFuncionarioDto>>> CreateFuncao(FuncaoFuncionarioDtoCreate create)
        {
            try
            {
                var model = _mapper.Map<FuncaoFuncionarioModel>(create);
                var entity = _mapper.Map<FuncaoFuncionarioEntity>(model);

                var result = await _repository.InsertAsync(entity);
                if (result == null)
                    return new ResponseDto<List<FuncaoFuncionarioDto>>().ErroCadastro();

                return new ResponseDto<List<FuncaoFuncionarioDto>>().CadastroOk();
            }
            catch (Exception ex)
            {

                return new ResponseDto<List<FuncaoFuncionarioDto>>().Erro(ex);
            }
        }
        public async Task<ResponseDto<List<FuncaoFuncionarioDto>>> Update(FuncaoFuncionarioDtoUpdate update)
        {
            try
            {
                var model = _mapper.Map<FuncaoFuncionarioModel>(update);
                var entity = _mapper.Map<FuncaoFuncionarioEntity>(model);

                var result = await _repository.UpdateAsync(entity);
                if (result == null)
                    return new ResponseDto<List<FuncaoFuncionarioDto>>().ErroUpdate();

                return new ResponseDto<List<FuncaoFuncionarioDto>>().AlteracaoOk();
            }
            catch (Exception ex)
            {

                return new ResponseDto<List<FuncaoFuncionarioDto>>().Erro(ex);
            }
        }
    }
}
