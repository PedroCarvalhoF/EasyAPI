using Api.Domain.Dtos.CategoriaPrecoDtos;
using Api.Domain.Interfaces.Services.CategoriaPreco;
using Api.Extensions;
using Domain.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers
{

    [ApiController]
    [Route("v2/[controller]")]
    [Authorize]
    public class CategoriaPrecoController : ControllerBase
    {
        private readonly ICategoriaPrecoService _service;
        public CategoriaPrecoController(ICategoriaPrecoService categoriaPrecoService)
        {
            _service = categoriaPrecoService;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return new ReturnActionResult().ParseToActionResult(await _service.GetAll(User.GetUserMasterUser()), User.GetUserMasterUserDatalhes());
        }
        [HttpGet("{categoriaPrecoId}")]
        public async Task<ActionResult> GetIdCategoriaPreco(Guid categoriaPrecoId)
        {
            return new ReturnActionResult().ParseToActionResult(await _service.GetIdCategoriaPreco(categoriaPrecoId, User.GetUserMasterUser()), User.GetUserMasterUserDatalhes());
        }
        [HttpPost]
        public async Task<ActionResult> Create(CategoriaPrecoDtoCreate create)
        {
            return new ReturnActionResult().ParseToActionResult(await _service.Create(create, User.GetUserMasterUser()), User.GetUserMasterUserDatalhes());
        }
        [HttpPut]
        public async Task<ActionResult> Update(CategoriaPrecoDtoUpdate update)
        {
            return new ReturnActionResult().ParseToActionResult(await _service.Update(update, User.GetUserMasterUser()), User.GetUserMasterUserDatalhes());
        }
    }
}