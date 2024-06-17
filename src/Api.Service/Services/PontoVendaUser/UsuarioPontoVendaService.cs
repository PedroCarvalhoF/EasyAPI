using AutoMapper;
using Domain.Dtos;
using Domain.Dtos.PontoVendaUser;
using Domain.Entities.PontoVendaUser;
using Domain.Interfaces;
using Domain.Interfaces.Repository.PontoVendaUser;
using Domain.Interfaces.Services.PontoVendaUser;
using Domain.Models.PontoVendaUser;

namespace Service.Services.PontoVendaUser
{
    public class UsuarioPontoVendaService : IUsuarioPontoVendaService
    {
        private readonly IMapper? _mapper;
        private readonly IUsuarioPontoVendaRepository? _implementacao;
        private readonly IBaseRepository<UsuarioPontoVendaEntity>? _repository;

        public UsuarioPontoVendaService(IMapper? mapper, IUsuarioPontoVendaRepository? implementacao, IBaseRepository<UsuarioPontoVendaEntity>? repository)
        {
            _mapper = mapper;
            _implementacao = implementacao;
            _repository = repository;
        }

        public async Task<ResponseDto<List<UsuarioPontoVendaDto>>> GetAll()
        {
            var resposta = new ResponseDto<List<UsuarioPontoVendaDto>>();

            try
            {
                var entities = await _implementacao.GetAll();
                if (entities == null)
                {
                    return resposta.EntitiesNull();
                }

                var dtos = _mapper.Map<List<UsuarioPontoVendaDto>>(entities);

                return resposta.Retorno(dtos);
            }
            catch (Exception ex)
            {
                return resposta.Erro(ex);
            }
        }
        public async Task<ResponseDto<List<UsuarioPontoVendaDto>>> Get(Guid id)
        {
            var resposta = new ResponseDto<List<UsuarioPontoVendaDto>>();

            try
            {
                var entities = await _implementacao.Get(id);
                if (entities == null)
                {
                    return resposta.EntitiesNull();
                }

                var dto = _mapper.Map<UsuarioPontoVendaDto>(entities);

                resposta.Dados = new List<UsuarioPontoVendaDto>
                {
                    dto
                };
                return resposta.ConsultaOk();
            }
            catch (Exception ex)
            {
                return resposta.Erro(ex);
            }
        }
        public async Task<ResponseDto<List<UsuarioPontoVendaDto>>> GetByIdUser(Guid userId)
        {
            var resposta = new ResponseDto<List<UsuarioPontoVendaDto>>();

            try
            {
                var entities = await _implementacao.GetByIdUser(userId);
                if (entities == null)
                {
                    return resposta.EntitiesNull();
                }

                var dto = _mapper.Map<UsuarioPontoVendaDto>(entities);

                resposta.Dados = new List<UsuarioPontoVendaDto>
                {
                    dto
                };
                return resposta.ConsultaOk();
            }
            catch (Exception ex)
            {
                return resposta.Erro(ex);
            }
        }
        public async Task<ResponseDto<List<UsuarioPontoVendaDto>>> Create(UsuarioPontoVendaDtoCreate userCreate)
        {
            var resposta = new ResponseDto<List<UsuarioPontoVendaDto>>();

            try
            {
                var existsUser = await GetByIdUser(userCreate.UserId);
                if (existsUser.Status)
                {
                    existsUser.Mensagem = "Usuário já está registrado para vendas.";
                    existsUser.Status = false;
                    return existsUser;
                }

                var model = _mapper.Map<UsuarioPontoVendaModel>(userCreate);
                var entity = _mapper.Map<UsuarioPontoVendaEntity>(model);

                var result = await _repository.InsertAsync(entity);
                if (result == null)
                {
                    return resposta.ErroCadastro();
                }

                var resultCreate = await GetByIdUser(entity.UserPdvId);
                if (resultCreate.Status)
                    return resultCreate.CadastroOk();
                else
                    return resultCreate;
            }
            catch (Exception ex)
            {
                return resposta.Erro(ex);
            }
        }
    }
}
