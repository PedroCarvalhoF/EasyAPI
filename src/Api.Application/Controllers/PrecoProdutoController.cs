using Api.Domain.Dtos.PrecoProdutoDtos;
using Api.Domain.Interfaces.Services.PrecoProdutoService;
using Api.Extensions;
using Domain.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers
{
    [ApiController]
    [Route("v2/[controller]")]
    [Authorize]
    public class PrecoProdutoController : Controller
    {
        private readonly IPrecoProdutoService _service;
        public PrecoProdutoController(IPrecoProdutoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult> GetIdCategoriaPreco()
        {
            return new ReturnActionResult().ParseToActionResult(await _service.GetAll(User.GetUserMasterUser()), User.GetUserMasterUserDatalhes());
        }
        [HttpPost]
        public async Task<ActionResult> Create(PrecoProdutoDtoCreate create)
        {
            return new ReturnActionResult().ParseToActionResult(await _service.CreateUpdate(create, User.GetUserMasterUser()), User.GetUserMasterUserDatalhes());
        }
    }
}