using Easy.Api.Extensions;
using Easy.Api.Tools;
using Easy.Services.CQRS.PDV.ItemPedido.Commands;
using Easy.Services.CQRS.PDV.ItemPedido.Queries;
using Easy.Services.DTOs;
using Easy.Services.DTOs.ItemPedido;
using Easy.Services.DTOs.Pedido;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Easy.ApiNew.Controllers;

[Route("[controller]")]
[ApiController]
[Authorize]
public class ItemPedidoController(IMediator _mediator) : ControllerBase
{
    [HttpPost]
    //inserir item do pedido Retornar Pedido 
    public async Task<ActionResult<RequestResult<PedidoDto>>> CreateAsync([FromBody] ItemPedidoInserirCommand command)
    {
        command.SetUsers(User.GetUserMasterUserDatalhes());
        return new ReturnActionResult<PedidoDto>().ParseToActionResult(await _mediator.Send(command));
    }

    [HttpPost("inserir-item/return/pedido-include-itens")]
    //inserir item do pedido Retornar Pedido 
    public async Task<ActionResult<RequestResult<PedidoDtoIncludeItens>>> InserirItemReturnPedidoListItens([FromBody] ItemPedidoInserirResultItensIncludeCommand command)
    {
        command.SetUsers(User.GetUserMasterUserDatalhes());
        return new ReturnActionResult<PedidoDtoIncludeItens>().ParseToActionResult(await _mediator.Send(command));
    }

    [HttpPost("cancelar-item")]
    //cancelar item do pedido Retornar Pedido
    public async Task<ActionResult<RequestResult<PedidoDto>>> CreateAsync([FromBody] ItemPedidoCancelarCommand command)
    {
        command.SetUsers(User.GetUserMasterUserDatalhes());
        return new ReturnActionResult<PedidoDto>().ParseToActionResult(await _mediator.Send(command));
    }

    [HttpPost("cancelar-array-itens")]
    //cancelar item do pedido Retornar Pedido
    public async Task<ActionResult<RequestResult<PedidoDto>>> CancelarArrayItensByIds([FromBody] ItemPedidoCancelarArrayItensByIdCommand command)
    {
        command.SetUsers(User.GetUserMasterUserDatalhes());
        return new ReturnActionResult<PedidoDto>().ParseToActionResult(await _mediator.Send(command));
    }

    [HttpPost("aplicar-desconto-item")]
    public async Task<ActionResult<RequestResultForUpdate>> AplicarDescontoItemAsync([FromBody] ItemPedidoAplicarDescontoCommand command)
    {
        command.SetUsers(User.GetUserMasterUserDatalhes());
        return new ReturnActionResultForUpdate().ParseToActionResult(await _mediator.Send(command));
    }


    [HttpPost("get-filtro")]
    public async Task<ActionResult<RequestResult<IEnumerable<ItemPedidoDto>>>> GetItensPedidoFiltroAsync([FromBody] GetItensPedidoQuery commandQuery)
    {
        commandQuery.SetUsers(User.GetUserMasterUserDatalhes());
        return new ReturnActionResult<IEnumerable<ItemPedidoDto>>().ParseToActionResult(await _mediator.Send(commandQuery));
    }

    [HttpPost("get-itens-pedido-resumo-by-pdv")]
    public async Task<ActionResult<RequestResult<List<ItemPedidoDtoResumoSimples>>>> GetResumoItensPedidoByPdvAsync([FromBody] GetItensPedidoResumoByPdvQuery commandQuery)
    {
        commandQuery.SetUsers(User.GetUserMasterUserDatalhes());
        return new ReturnActionResult<List<ItemPedidoDtoResumoSimples>>().ParseToActionResult(await _mediator.Send(commandQuery));
    }
}