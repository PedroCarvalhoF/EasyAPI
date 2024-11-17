using Easy.Api.Extensions;
using Easy.Api.Tools;
using Easy.Services.CQRS.PDV.Pdv.Commands;
using Easy.Services.CQRS.PDV.Pdv.Queries;
using Easy.Services.DTOs;
using Easy.Services.DTOs.PDV;
using Easy.Services.DTOs.PDV.Dashboard;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Easy.ApiNew.Controllers;

[Route("[controller]")]
[ApiController]
[Authorize]
public class PontoVendaController : ControllerBase
{
    private readonly IMediator _mediator;
    public PontoVendaController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [HttpPost]
    public async Task<ActionResult<PontoVendaDto>> CreateAsync([FromBody] PontoVendaAberturaCommand command)
    {
        command.SetUsers(User.GetUserMasterUserDatalhes());
        return new ReturnActionResult<PontoVendaDto>().ParseToActionResult(await _mediator.Send(command));
    }
    [HttpPost("get-pdv-filter")]
    public async Task<ActionResult<IEnumerable<PontoVendaDto>>> SelectAsync([FromBody] GetPontoVendaQuery queryCommand)
    {
        queryCommand.SetUsers(User.GetUserMasterUserDatalhes());
        return new ReturnActionResult<IEnumerable<PontoVendaDto>>().ParseToActionResult(await _mediator.Send(queryCommand));
    }

    [HttpPost("encerrar")]
    public async Task<ActionResult<RequestResult<PontoVendaDtoEncerrarResult>>> EncerrarPdvAsync(PontoVendaEncerrarCommand command)
    {
        command.SetUsers(User.GetUserMasterUserDatalhes());
        return new ReturnActionResult<PontoVendaDtoEncerrarResult>().ParseToActionResult(await _mediator.Send(command));
    }



    #region Dashboard

    [HttpPost("get-dashboard")]
    public async Task<ActionResult<RequestResult<GetPontoVendaDashboardQueryPdvFilterResult>>> GetDashboardAsync(GetPontoVendaDashboardQueryPdvFilter command)
    {
        command.SetUsers(User.GetUserMasterUserDatalhes());
        return new ReturnActionResult<GetPontoVendaDashboardQueryPdvFilterResult>().ParseToActionResult(await _mediator.Send(command));
    }

    #endregion


}