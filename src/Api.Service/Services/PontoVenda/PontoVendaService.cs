using Api.Domain.Dtos.PontoVendaDtos;
using Api.Domain.Entities.PontoVenda;
using Api.Domain.Interfaces.Services.PontoVenda;
using Api.Domain.Models.PontoVendaModels;
using AutoMapper;
using Domain.Dtos;
using Domain.Interfaces;
using Domain.Interfaces.Repository.PontoVenda;
using System.Globalization;

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
            ResponseDto<List<PontoVendaDto>> resposta = new ResponseDto<List<PontoVendaDto>>();
            resposta.Dados = new List<PontoVendaDto>();
            try
            {
                var entities = await _implementacao.GetPdvs();

                if (entities == null)
                {
                    resposta.Status = true;
                    resposta.Mensagem = "Ponto de Venda não localizado";
                    return resposta;
                }

                var dtos = _mapper.Map<List<PontoVendaDto>>(entities);
                resposta.Dados = dtos;
                resposta.Mensagem = $"PDVs Localizados: {dtos.Count} ";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Status = false;
                resposta.Mensagem = $"Erro.Detalhes: {ex.Message}";
                return resposta;
            }
        }
        public async Task<ResponseDto<List<PontoVendaDto>>> GetByIdPdv(Guid pdvId)
        {
            ResponseDto<List<PontoVendaDto>> resposta = new ResponseDto<List<PontoVendaDto>>();
            resposta.Dados = new List<PontoVendaDto>();
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

                resposta.Dados.Add(dtos);
                resposta.Mensagem = "PDV Localizado";

                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Status = false;
                resposta.Mensagem = $"Erro.Detalhes: {ex.Message}";
                return resposta;
            }
        }
        public async Task<ResponseDto<List<PontoVendaDto>>> GetByIdPerfilUsuario(Guid IdPerfilUtilizarPDV)
        {
            ResponseDto<List<PontoVendaDto>> resposta = new ResponseDto<List<PontoVendaDto>>();
            resposta.Dados = new List<PontoVendaDto>();
            try
            {
                var entities = await _implementacao.GetByIdPerfilUsuario(IdPerfilUtilizarPDV);

                if (entities == null)
                {
                    resposta.Status = true;
                    resposta.Mensagem = "Ponto de Venda não localizado para este usuário";
                    return resposta;
                }
                var dtos = _mapper.Map<List<PontoVendaDto>>(entities);

                resposta.Dados = dtos;
                resposta.Mensagem = "PDV Localizado";

                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Status = false;
                resposta.Mensagem = $"Erro.Detalhes: {ex.Message}";
                return resposta;
            }
        }
        public async Task<ResponseDto<List<PontoVendaDto>>> AbertosFechados(bool abertoFechado)
        {
            ResponseDto<List<PontoVendaDto>> resposta = new ResponseDto<List<PontoVendaDto>>();
            resposta.Dados = new List<PontoVendaDto>();
            try
            {
                var entities = await _implementacao.AbertosFechados(abertoFechado);

                if (entities == null)
                {
                    resposta.Status = true;
                    resposta.Mensagem = "Ponto de Venda não localizado";
                    return resposta;
                }
                var dtos = _mapper.Map<List<PontoVendaDto>>(entities);

                resposta.Dados = dtos;
                resposta.Mensagem = $"PDV Localizado: {dtos.Count} {(abertoFechado == true ? "ABERTOS" : "FECHADOS")}";

                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Status = false;
                resposta.Mensagem = $"Erro.Detalhes: {ex.Message}";
                return resposta;
            }
        }
        public async Task<ResponseDto<List<PontoVendaDto>>> Create(PontoVendaDtoCreate pontoVendaDtoCreate)
        {
            ResponseDto<List<PontoVendaDto>> resposta = new ResponseDto<List<PontoVendaDto>>();
            resposta.Dados = new List<PontoVendaDto>();
            try
            {
                var model = _mapper.Map<PontoVendaModel>(pontoVendaDtoCreate);
                model.AbrirPDV();
                var entity = _mapper.Map<PontoVendaEntity>(model);

                var result = await _repository.InsertAsync(entity);

                var pdvCreate = await GetByIdPdv(result.Id);

                return pdvCreate;
            }
            catch (Exception ex)
            {
                resposta.Status = false;
                resposta.Mensagem = $"Erro.Detalhes: {ex.Message}";
                return resposta;
            }
        }
        public async Task<ResponseDto<List<PontoVendaDto>>> Encerrar(Guid pontoVendaId)
        {
            ResponseDto<List<PontoVendaDto>> resposta = new ResponseDto<List<PontoVendaDto>>();
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
                resposta.Status = false;
                resposta.Mensagem = $"Erro.Detalhes: {ex.Message}";
                return resposta;
            }
        }
    }
}