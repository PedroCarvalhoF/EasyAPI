using Api.Domain.Dtos.ProdutoMedidaDtos;
using Domain.Dtos;

namespace Api.Domain.Interfaces.Services.ProdutoMedida
{
    public interface IProdutoMedidaServices
    {
        Task<ResponseDto<List<ProdutoMedidaDto>>> GetAll();
        Task<ResponseDto<List<ProdutoMedidaDto>>> Get(Guid id);
        Task<ResponseDto<List<ProdutoMedidaDto>>> Get(string descricao);
        Task<ResponseDto<List<ProdutoMedidaDto>>> Create(ProdutoMedidaDtoCreate create);
        Task<ResponseDto<List<ProdutoMedidaDto>>> Update(ProdutoMedidaDtoUpdate update);
        Task<ResponseDto<List<ProdutoMedidaDto>>> Desabilitar(Guid id);

    }
}