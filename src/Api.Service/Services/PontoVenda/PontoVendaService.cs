using Api.Domain.Dtos.PontoVendaDtos;
using Api.Domain.Entities.PontoVenda;
using Api.Domain.Interfaces.Services.PontoVenda;
using Api.Domain.Models.PontoVendaModels;
using AutoMapper;
using Domain.Dtos;
using Domain.Dtos.PontoVenda.Filtros;
using Domain.Interfaces;
using Domain.Interfaces.Repository.PontoVenda;

namespace Api.Service.Services.PontoVendaService
{
    public class PontoVendaService : IPontoVendaService
    {
        private readonly IRepository<PontoVendaEntity> _repository;
        private readonly IMapper _mapper;
        private readonly IPontoVendaRepository _implementacao;

        public PontoVendaService(IRepository<PontoVendaEntity> repository,
                                 IMapper mapper,
                                 IPontoVendaRepository pontoVendaRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _implementacao = pontoVendaRepository;
        }
        public async Task<ResponseDto<List<PontoVendaDto>>> GetPdvs()
        {
            var resposta = new ResponseDto<List<PontoVendaDto>>();

            try
            {
                var entities = await _implementacao.GetPdvs();

                if (entities == null)
                {
                    return resposta.EntitiesNull();
                }

                var dtos = _mapper.Map<List<PontoVendaDto>>(entities);
                return resposta.Retorno(dtos);
            }
            catch (Exception ex)
            {
                return resposta.Erro(ex);
            }
        }
        public async Task<ResponseDto<List<PontoVendaDto>>> GetByIdPdv(Guid pdvId)
        {
            var resposta = new ResponseDto<List<PontoVendaDto>>();

            try
            {
                var entities = await _implementacao.GetByIdPdv(pdvId);

                if (entities == null)
                {
                    resposta.Status = true;
                    resposta.Mensagem = "Ponto de Venda não localizado";
                    return resposta;
                }

                var dtos = _mapper.Map<PontoVendaDto>(entities);
                resposta.Dados = new List<PontoVendaDto> { dtos };

                return resposta.ConsultaOk();
            }
            catch (Exception ex)
            {
                return resposta.Erro(ex);
            }
        }
        public async Task<ResponseDto<List<PontoVendaDto>>> GetByIdPerfilUsuario(Guid IdPerfilUtilizarPDV)
        {
            var resposta = new ResponseDto<List<PontoVendaDto>>();

            try
            {
                var entities = await _implementacao.GetByIdPerfilUsuario(IdPerfilUtilizarPDV);

                if (entities == null)
                {

                    return resposta.EntitiesNull();
                }

                var dtos = _mapper.Map<List<PontoVendaDto>>(entities);
                return resposta.Retorno(dtos);
            }
            catch (Exception ex)
            {
                return resposta.Erro(ex);
            }
        }
        public async Task<ResponseDto<List<PontoVendaDto>>> AbertosFechados(bool abertoFechado)
        {
            var resposta = new ResponseDto<List<PontoVendaDto>>();

            try
            {
                var entities = await _implementacao.AbertosFechados(abertoFechado);

                if (entities == null)
                {
                    return resposta.EntitiesNull();
                }

                var dtos = _mapper.Map<List<PontoVendaDto>>(entities);

                return resposta.Retorno(dtos);
            }
            catch (Exception ex)
            {
                return resposta.Erro(ex);
            }
        }
        public async Task<ResponseDto<List<PontoVendaDto>>> FiltrarByData(PontoVendaDtoFiltrarData data)
        {
            var resposta = new ResponseDto<List<PontoVendaDto>>();

            try
            {
                var entities = await _implementacao.FiltrarByData(data);

                if (entities == null)
                {
                    return resposta.EntitiesNull();
                }

                var dtos = _mapper.Map<List<PontoVendaDto>>(entities);
                return resposta.Retorno(dtos);
            }
            catch (Exception ex)
            {
                return resposta.Erro(ex);
            }
        }
        public async Task<ResponseDto<List<PontoVendaDto>>> Create(PontoVendaDtoCreate pontoVendaDtoCreate)
        {
            var resposta = new ResponseDto<List<PontoVendaDto>>();

            try
            {
                var model = _mapper.Map<PontoVendaModel>(pontoVendaDtoCreate);
                model.AbrirPDV();
                var entity = _mapper.Map<PontoVendaEntity>(model);

                var result = await _repository.InsertAsync(entity);

                if (result == null)
                {
                    resposta.ErroCadastro();
                    return resposta;
                }

                var pdvCreate = await GetByIdPdv(result.Id);
                pdvCreate.CadastroOk();

                return pdvCreate;
            }
            catch (Exception ex)
            {
                return resposta.Erro(ex);
            }
        }
        public async Task<ResponseDto<List<PontoVendaDto>>> Encerrar(Guid pontoVendaId)
        {
            var resposta = new ResponseDto<List<PontoVendaDto>>();
            resposta.Dados = new List<PontoVendaDto>();
            try
            {
                var pdvSelecionado = await _repository.SelectAsync(pontoVendaId);

                var model = _mapper.Map<PontoVendaModel>(pdvSelecionado);

                model.FinalizarPDV();

                var entity = _mapper.Map<PontoVendaEntity>(model);

                var resultUpdate = await _repository.UpdateAsync(entity);

                var verificarUpdate = await _implementacao.GetByIdPdv(pontoVendaId);

                if (!verificarUpdate.AbertoFechado)
                {
                    resposta.Mensagem = $"PDV {entity.Id} encerrado com sucesso! {resultUpdate.UpdateAt} ";
                    return resposta;
                }
                else
                {
                    resposta.Status = false;
                    resposta.Mensagem = "Não foi possível encerrar pdv";
                    return resposta;
                }
            }
            catch (Exception ex)
            {
                return resposta.Erro(ex);
            }
        }

    }
}