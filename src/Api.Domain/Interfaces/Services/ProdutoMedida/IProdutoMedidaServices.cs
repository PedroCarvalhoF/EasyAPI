using Api.Domain.Dtos.ProdutoMedidaDtos;

namespace Api.Domain.Interfaces.Services.ProdutoMedida
{
    public interface IProdutoMedidaServices
    {
        Task<ProdutoMedidaDto> Create(ProdutoMedidaDtoCreate create);
        Task<ProdutoMedidaDto> Update(ProdutoMedidaDtoUpdate update);
        Task<IEnumerable<ProdutoMedidaDto>> GetAll();
        Task<ProdutoMedidaDto> Get(Guid id);
        Task<IEnumerable<ProdutoMedidaDto>> Get(string descricao);

        Task<bool> Desabilitar(Guid id);

    }
}