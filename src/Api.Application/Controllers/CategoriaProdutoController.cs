using Api.Domain.Dtos.CategoriaProdutoDtos;
using Api.Domain.Interfaces.Services.CategoriaProduto;
using Api.Extensions;
using Domain.Dtos;
using Domain.Dtos.CategoriaProdutoDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers
{
    [ApiController]
    [Route("v2/[controller]")]
    [Authorize]
    public class CategoriaProdutoController : ControllerBase
    {
        private readonly ICategoriaProdutoService _service;
        public CategoriaProdutoController(ICategoriaProdutoService categoriaProdutoService)
        {
            _service = categoriaProdutoService;
        }
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return new ReturnActionResult().ParseToActionResult(await _service.GetAll(User.GetUserMasterUser()), User.GetUserMasterUserDatalhes());
        }
        [HttpGet("{categoriaId}")]
        public async Task<ActionResult> GetByIdCategoria(Guid categoriaId)
        {
            return new ReturnActionResult().ParseToActionResult(await _service.GetByIdCategoria(categoriaId, User.GetUserMasterUser()), User.GetUserMasterUserDatalhes());
        }
        [HttpPost]
        public async Task<ActionResult> Create(CategoriaProdutoDtoCreate create)
        {
            return new ReturnActionResult().ParseToActionResult(await _service.Create(create, User.GetUserMasterUser()), User.GetUserMasterUserDatalhes());
        }
        [HttpPut]
        public async Task<ActionResult> Update(CategoriaProdutoDtoUpdate update)
        {
            return new ReturnActionResult().ParseToActionResult(await _service.Update(update, User.GetUserMasterUser()), User.GetUserMasterUserDatalhes());
        }
    }
}