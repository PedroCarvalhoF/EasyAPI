using Easy.Api.Extensions;
using Easy.Api.Tools;
using Easy.Services.CQRS.PDV.PagamentoPedido.Commands;
using Easy.Services.CQRS.PDV.PagamentoPedido.Queries;
using Easy.Services.DTOs;
using Easy.Services.DTOs.PagamentoPedido;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Easy.ApiNew.Controllers;

[Route("[controller]")]
[ApiController]
[Authorize]
public class PagamentoPedidoController : ControllerBase
{
    private readonly IMediator _mediator;
    public PagamentoPedidoController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    //Inseri pagamento pedido
    //Retornar Lista de pagamentos do pedido
    public async Task<ActionResult<RequestResult<PagamentoPedidoDtoInserirResult>>> InserirPagamentoPedidoAsync([FromBody] PagamentoPedidoInserirCommand command)
    {
        command.SetUsers(User.GetUserMasterUserDatalhes());
        return new ReturnActionResult<PagamentoPedidoDtoInserirResult>().ParseToActionResult(await _mediator.Send(command));
    }

    [HttpGet]
    public async Task<ActionResult<RequestResultForUpdate>> PagamentosPedidosAsync()
    {
        var getCommand = new GetPagamentoPedidoQuery();
        getCommand.SetUsers(User.GetUserMasterUserDatalhes());
        return new ReturnActionResultForUpdate().ParseToActionResult(await _mediator.Send(getCommand));
    }

    [HttpPost("get-pagamentos-by-pedido")]
    //remover pagamentos do pedido    
    public async Task<ActionResult<RequestResult<PagamentoPedidoDtoInserirResult>>> GetPagamentosByPedidoIdAsync([FromBody] GetPagamentosByPedidoIdQuery command)
    {
        command.SetUsers(User.GetUserMasterUserDatalhes());
        return new ReturnActionResult<PagamentoPedidoDtoInserirResult>().ParseToActionResult(await _mediator.Send(command));
    }

    [HttpDelete("remover-pagamentos-pedido")]
    //remover pagamentos do pedido    
    public async Task<ActionResult<RequestResult<PagamentoPedidoDtoInserirResult>>> RemoverPagamentoPedidoAsync([FromBody] PagamentoPedidoRemoverCommand command)
    {
        command.SetUsers(User.GetUserMasterUserDatalhes());
        return new ReturnActionResult<PagamentoPedidoDtoInserirResult>().ParseToActionResult(await _mediator.Send(command));
    }

    [HttpPost("get-resumo-pagamentos-by-pdv")]
    //remover pagamentos do pedido    
    public async Task<ActionResult<RequestResult<List<PagamentoPedidoDtoResumoPdv>>>> GetResumoPagamentosByPedidoIdAsync([FromBody] GetResumoPagamentosByPdvIdQuery command)
    {
        command.SetUsers(User.GetUserMasterUserDatalhes());
        return new ReturnActionResult<List<PagamentoPedidoDtoResumoPdv>>().ParseToActionResult(await _mediator.Send(command));
    }
}