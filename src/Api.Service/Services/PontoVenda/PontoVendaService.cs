using Api.Domain.Dtos.PontoVendaDtos;
using Api.Domain.Entities.PontoVenda;
using Api.Domain.Interfaces.Services.PontoVenda;
using Api.Domain.Models.PontoVendaModels;
using AutoMapper;
using Domain.Dtos.PedidoDtos;
using Domain.Dtos.PontoVendaDtos;
using Domain.Enuns;
using Domain.ExceptionsPersonalizadas;
using Domain.Interfaces;
using Domain.Interfaces.Repository;
using Service.Services.PontoVendaService;

namespace Api.Service.Services.PontoVendaService
{
    public class PontoVendaService : IPontoVendaService
    {
        private readonly IRepository<PontoVendaEntity> _repository;
        private readonly IMapper _mapper;
        private readonly IPontoVendaRepository _pontoVendaRepository;

        public PontoVendaService(IRepository<PontoVendaEntity> repository, IMapper mapper, IPontoVendaRepository pontoVendaRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _pontoVendaRepository = pontoVendaRepository;
        }

        public async Task<IEnumerable<PontoVendaDto>> ConsultarPdvsById(List<Guid> idsPdvs)
        {
            try
            {
                IEnumerable<PontoVendaEntity> pdvs = await _pontoVendaRepository.ConsultarPdvsById(idsPdvs);
                IEnumerable<PontoVendaDto> pdvs_dtos = _mapper.Map<IEnumerable<PontoVendaDto>>(pdvs);

                //  var resumo_dia = PontoVendaResumoDetalhadoExt.GetResumoDia(pdvs_dtos.ToList());

                return pdvs_dtos;
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

        public async Task<IEnumerable<PontoVendaDto>> ConsultarPontoVenda(bool abertoFechado)
        {
            try
            {
                IEnumerable<PontoVendaEntity> pdvEntities = await _pontoVendaRepository.GetPontoVenda(pdv => pdv.AbertoFechado.Equals(abertoFechado), false);

                return _mapper.Map<IEnumerable<PontoVendaDto>>(pdvEntities);


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
        public async Task<PontoVendaResumoDetalhadoDto> ConsultarPontoVenda(Guid pontoVendaId)
        {
            try
            {
                PontoVendaEntity? pontoVendaEntity = (await _pontoVendaRepository.GetPontoVenda(pdv => pdv.Id.Equals(pontoVendaId))).FirstOrDefault();

                PontoVendaModels pdvModel = _mapper.Map<PontoVendaModels>(pontoVendaEntity);

                PontoVendaDto pdvDto = _mapper.Map<PontoVendaDto>(pdvModel);

                PontoVendaResumoDetalhadoDto detalhado = PontoVendaExtension.GetResumoDetalhadoPdV(pdvDto);

                return detalhado;

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



        public async Task<PontoVendaDto> EncerrarPontoVenda(Guid pontoVendaId)
        {
            try
            {
                PontoVendaEntity pontoVendaEntity = await _repository.SelectAsync(pontoVendaId);
                PontoVendaModels model = _mapper.Map<PontoVendaModels>(pontoVendaEntity);
                model.EncerrarPontoVendaModels();
                PontoVendaEntity entity = _mapper.Map<PontoVendaEntity>(model);
                PontoVendaEntity result = await _repository.UpdateAsync(entity);
                return _mapper.Map<PontoVendaDto>(await _repository.SelectAsync(result.Id));
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

        public async Task<PontoVendaDto> GerarPontoVenda(PontoVendaDtoCreate pontoVendaDtoCreate)
        {
            try
            {
                //CONTINUAR PONTO DE VENDA
                PontoVendaModels model = _mapper.Map<PontoVendaModels>(pontoVendaDtoCreate);
                model.GerarPontoVendaModels();
                PontoVendaEntity entity = _mapper.Map<PontoVendaEntity>(model);
                PontoVendaEntity result = await _repository.InsertAsync(entity);
                return _mapper.Map<PontoVendaDto>(await _repository.SelectAsync(result.Id));

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<PontoVendaResumoDiaDto>> InfoDashPdvsByPeriodo(PdvGetByData FiltroConsultaPdvDashDto)
        {
            try
            {
                IEnumerable<PontoVendaEntity> pdvs = await _pontoVendaRepository.InfoDashPdvsByPeriodo(FiltroConsultaPdvDashDto);
                IEnumerable<PontoVendaDto> pdvs_dtos = _mapper.Map<IEnumerable<PontoVendaDto>>(pdvs);

                List<PontoVendaResumoDiaDto> resumo_dia = PontoVendaExtension.GetResumoDia(pdvs_dtos.ToList());

                return resumo_dia;
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
        public async Task<IEnumerable<PontoVendaDto>> ConsultarPontoVendaByData(PdvGetByData pdvGetByData)
        {
            try
            {
                IEnumerable<PontoVendaEntity> pdvs = await _pontoVendaRepository.ConsultarPontoVendaByData(pdvGetByData);
                IEnumerable<PontoVendaDto> pdvs_dtos = _mapper.Map<IEnumerable<PontoVendaDto>>(pdvs);

                return pdvs_dtos;
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


        #region Dash Ponto de Venda


        public async Task<DashPontoVendaDtosV2> DashPdvsByIdsPdvs(List<Guid> idsPdvs)
        {
            try
            {
                IEnumerable<PontoVendaEntity> pdvs = await _pontoVendaRepository.GetByIdsPdvs(idsPdvs);
                IEnumerable<PontoVendaDto> pdvsDtos = _mapper.Map<IEnumerable<PontoVendaDto>>(pdvs);


                IEnumerable<Domain.Dtos.PedidoDtos.PedidoDto> all_pedidos = PontoVendaDetalhado.FiltrarPedidosPontoVenda(pdvsDtos, SituacaoPedidoEnum.Aberto, true);
                IEnumerable<Domain.Dtos.PedidoDtos.PedidoDto> all_validos = PontoVendaDetalhado.FiltrarPedidosPontoVenda(pdvsDtos, SituacaoPedidoEnum.Finalizado, false);
                IEnumerable<Domain.Dtos.PedidoDtos.PedidoDto> all_pedidosCancelados = PontoVendaDetalhado.FiltrarPedidosPontoVenda(pdvsDtos, SituacaoPedidoEnum.Cancelado, false);

                DashPontoVendaDtosV2 dash = new DashPontoVendaDtosV2();


                dash.all_pedidos = all_pedidos.ToList();
                dash.all_validos = all_validos.ToList();
                dash.all_pedidos_cancelados = all_pedidosCancelados.ToList();

                dash.total_pedido = PontoVendaDetalhado.TotalPedido(all_pedidos);
                dash.total_pedido_validos = PontoVendaDetalhado.TotalPedido(all_validos);
                dash.total_pedidos_cancelados = PontoVendaDetalhado.TotalPedido(all_pedidosCancelados);



                dash.faturamento = PontoVendaDetalhado.TotalFaturado(all_validos);
                dash.TC = dash.total_pedido_validos;
                dash.CalculaTM(dash.faturamento, dash.TC);

                dash.ListaProdutosAgrupados = PontoVendaDetalhado.ProdutosRegistrados(dash.all_validos);
                dash.ListaFpgtsInformados = PontoVendaDetalhado.PagamentosRegistrados(dash.all_validos);

                return dash;
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




        #endregion
    }
}
