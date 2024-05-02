using AutoMapper;
using Domain.Dtos;
using Domain.Dtos.PerfilUsuario;
using Domain.Entities.UsuarioSistema;
using Domain.Interfaces;
using Domain.Interfaces.Repository.PerfilUsuario;
using Domain.Interfaces.Services.PerfilUsuario;
using Domain.Models.PerfilUsuario;

namespace Service.Services.PerfilUsuario
{
    public class PerfilUsuarioService : IPerfilUsuarioService
    {
        #region Contrutor


        private readonly IRepository<PerfilUsuarioEntity> _repository;
        private readonly IPerfilUsuarioRepository _implementacao;
        private readonly IMapper _mapper;

        public PerfilUsuarioService(IRepository<PerfilUsuarioEntity> repository,
                                    IPerfilUsuarioRepository implementacao,
                                    IMapper mapper)
        {
            _repository = repository;
            _implementacao = implementacao;
            _mapper = mapper;
        }

        #endregion
        public async Task<ResponseDto<List<PerfilUsuarioDto>>> GetAll()
        {
            ResponseDto<List<PerfilUsuarioDto>> resposta = new ResponseDto<List<PerfilUsuarioDto>>();

            try
            {
                IEnumerable<PerfilUsuarioEntity> entities = await _implementacao.GetAll();
                IEnumerable<PerfilUsuarioDto> dtos = _mapper.Map<IEnumerable<PerfilUsuarioDto>>(entities);

                if (entities == null)
                {
                    resposta.Mensagem = "Nenhum encontrado";
                    return resposta;
                }

                resposta.Dados = dtos.ToList();
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }
        public async Task<ResponseDto<List<PerfilUsuarioDto>>> GetPerfilUsuarioId(Guid id)
        {
            ResponseDto<List<PerfilUsuarioDto>> resposta = new ResponseDto<List<PerfilUsuarioDto>>();
            resposta.Dados = new List<PerfilUsuarioDto>();
            try
            {
                PerfilUsuarioEntity entity = await _implementacao.GetPerfilUsuarioId(id);
                if (entity == null)
                {
                    resposta.Mensagem = "Não encontrado";

                    return resposta;
                }
                PerfilUsuarioDto dto = _mapper.Map<PerfilUsuarioDto>(entity);

                resposta.Dados.Add(dto);

                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }
        public async Task<ResponseDto<List<PerfilUsuarioDto>>> GetPerfilUsuarioName(string name)
        {
            ResponseDto<List<PerfilUsuarioDto>> resposta = new ResponseDto<List<PerfilUsuarioDto>>();
            resposta.Dados = new List<PerfilUsuarioDto>();
            try
            {
                IEnumerable<PerfilUsuarioEntity> entities = await _implementacao.GetPerfilUsuarioName(name);
                if (!entities.Any())
                {
                    resposta.Mensagem = "Não encontrado";
                    return resposta;
                }
                List<PerfilUsuarioDto> dtos = _mapper.Map<List<PerfilUsuarioDto>>(entities);

                resposta.Dados = dtos;

                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseDto<List<PerfilUsuarioDto>>> Create(PerfilUsuarioDtoCreate create)
        {
            ResponseDto<List<PerfilUsuarioDto>> resposta = new ResponseDto<List<PerfilUsuarioDto>>();
            resposta.Dados = new List<PerfilUsuarioDto>();
            try
            {
                IEnumerable<PerfilUsuarioEntity> perfilNameExists = await _implementacao.GetPerfilUsuarioName(create.Nome);
                if (perfilNameExists.Any())
                {
                    resposta.Mensagem = "Não foi possível cadastrar: Nome já está em uso";
                    resposta.Status = false;
                    return resposta;
                }

                PerfilUsuarioModel model = _mapper.Map<PerfilUsuarioModel>(create);
                PerfilUsuarioEntity entity = _mapper.Map<PerfilUsuarioEntity>(model);
                PerfilUsuarioEntity result = await _repository.InsertAsync(entity);

                if (result.Id == Guid.Empty)
                {
                    resposta.Mensagem = "Não foi possível cadastrar";
                    return resposta;
                }

                PerfilUsuarioDto dto = _mapper.Map<PerfilUsuarioDto>(result);

                resposta.Dados.Add(dto);

                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }

        }
        public async Task<ResponseDto<List<PerfilUsuarioDto>>> Update(PerfilUsuarioDtoUpdate update)
        {
            ResponseDto<List<PerfilUsuarioDto>> resposta = new ResponseDto<List<PerfilUsuarioDto>>();
            resposta.Dados = new List<PerfilUsuarioDto>();
            try
            {
                IEnumerable<PerfilUsuarioEntity> perfilNameExists = await _implementacao.GetPerfilUsuarioName(update.Nome);
                if (perfilNameExists.Any())
                {
                    resposta.Mensagem = "Não foi possível cadastrar: Nome já está em uso";
                    return resposta;
                }


                PerfilUsuarioModel model = _mapper.Map<PerfilUsuarioModel>(update);
                PerfilUsuarioEntity entity = _mapper.Map<PerfilUsuarioEntity>(model);
                PerfilUsuarioEntity result = await _repository.UpdateAsync(entity);
                PerfilUsuarioDto dto = _mapper.Map<PerfilUsuarioDto>(result);

                resposta.Dados.Add(dto);


                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseDto<List<PerfilUsuarioDto>>> Desabilitar(Guid id)
        {
            ResponseDto<List<PerfilUsuarioDto>> resposta = new ResponseDto<List<PerfilUsuarioDto>>();
            try
            {
                bool result = await _repository.DesabilitarHabilitar(id);
                if (result)
                {
                    resposta.Mensagem = "Desabilitado com sucesso!";

                }
                else
                if (result)
                {
                    resposta.Mensagem = "Não foi possível desabilitar!";
                }
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }


    }
}
