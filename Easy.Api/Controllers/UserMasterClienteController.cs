using Easy.Domain.Intefaces;
using Microsoft.AspNetCore.Mvc;

namespace Easy.Api.Controllers;

[Route("[controller]")]
[ApiController]
public class UserMasterClienteController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;
    public UserMasterClienteController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpGet]
    public async Task<IActionResult> GetUsers()
    {
        var users = await _unitOfWork.UsuarioMasterClienteRepository.GetAllAsync();
        return Ok(users);
    }

}
