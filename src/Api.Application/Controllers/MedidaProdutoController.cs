using Api.Domain.Dtos.ProdutoMedidaDtos;
using Api.Domain.Interfaces.Services.ProdutoMedida;
using Api.Extensions;
using Domain.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("v2/[controller]")]
    [Authorize]
    public class MedidaProdutoController : ControllerBase
    {
        private readonly IProdutoMedidaServices _service;

        public MedidaProdutoController(IProdutoMedidaServices produtoMedidaServices)
        {
            _service = produtoMedidaServices;
        }
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return new ReturnActionResult().ParseToActionResult(await _service.GetAll(User.GetUserMasterUser()), User.GetUserMasterUserDatalhes());
        }
        [HttpGet("{medidaId}")]
        public async Task<ActionResult> GetById(Guid medidaId)
        {
            return new ReturnActionResult().ParseToActionResult(await _service.GetById(medidaId, User.GetUserMasterUser()), User.GetUserMasterUserDatalhes());
        }
        [HttpPost]
        public async Task<ActionResult> Create(ProdutoMedidaDtoCreate create)
        {
            return new ReturnActionResult().ParseToActionResult(await _service.Create(create, User.GetUserMasterUser()), User.GetUserMasterUserDatalhes());
        }
        [HttpPut]
        public async Task<ActionResult> Update(ProdutoMedidaDtoUpdate update)
        {
            return new ReturnActionResult().ParseToActionResult(await _service.Update(update, User.GetUserMasterUser()), User.GetUserMasterUserDatalhes());
        }
    }
}