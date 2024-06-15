using Api.Extensions;
using Domain.Dtos;
using Domain.Dtos.ProdutoDtos;
using Domain.Interfaces.Services.Produto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("v2/[controller]")]
    [Authorize]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutoService _service;
        public ProdutosController(IProdutoService produtoService)
        {
            _service = produtoService;
        }
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return new ReturnActionResult().ParseToActionResult(await _service.GetAll(User.GetUserMasterUser()), User.GetUserMasterUserDatalhes());
        }
        [HttpGet("{produtoId}")]
        public async Task<ActionResult> GetByIdCategoria(Guid produtoId)
        {
            return new ReturnActionResult().ParseToActionResult(await _service.GetByIdProduto(produtoId, User.GetUserMasterUser()), User.GetUserMasterUserDatalhes());
        }
        [HttpPost]
        public async Task<ActionResult> Create(ProdutoDtoCreate create)
        {
            return new ReturnActionResult().ParseToActionResult(await _service.Create(create, User.GetUserMasterUser()), User.GetUserMasterUserDatalhes());
        }
        [HttpPut]
        public async Task<ActionResult> Update(ProdutoDtoUpdate update)
        {
            return new ReturnActionResult().ParseToActionResult(await _service.Update(update, User.GetUserMasterUser()), User.GetUserMasterUserDatalhes());
        }
    }
}