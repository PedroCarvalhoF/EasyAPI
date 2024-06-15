using Api.Extensions;
using Domain.Dtos;
using Domain.Dtos.ProdutoTipo;
using Domain.Interfaces.Services.ProdutoTipo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("v2/[controller]")]
    [Authorize]
    public class TipoProdutoController : ControllerBase
    {
        private readonly IProdutoTipoServices _service;

        public TipoProdutoController(IProdutoTipoServices services)
        {
            _service = services;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return new ReturnActionResult().ParseToActionResult(await _service.GetAll(User.GetUserMasterUser()), User.GetUserMasterUserDatalhes());
        }
        [HttpGet("{tipoProdutoId}")]
        public async Task<ActionResult> GetByIdTipoProduto(Guid tipoProdutoId)
        {
            return new ReturnActionResult().ParseToActionResult(await _service.GetByIdTipoProduto(tipoProdutoId, User.GetUserMasterUser()), User.GetUserMasterUserDatalhes());
        }
        [HttpPost]
        public async Task<ActionResult> Create(ProdutoTipoDtoCreate create)
        {
            return new ReturnActionResult().ParseToActionResult(await _service.Create(create, User.GetUserMasterUser()), User.GetUserMasterUserDatalhes());
        }
        [HttpPut]
        public async Task<ActionResult> Update(ProdutoTipoDtoUpdate update)
        {
            return new ReturnActionResult().ParseToActionResult(await _service.Update(update, User.GetUserMasterUser()), User.GetUserMasterUserDatalhes());
        }
    }
}