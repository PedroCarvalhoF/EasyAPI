using Domain.Dtos.ProdutoTipo;

namespace Domain.Interfaces.Services.ProdutoTipo
{
    public interface IProdutoTipoServices
    {
        Task<IEnumerable<ProdutoTipoDto>> GetAll();
        Task<ProdutoTipoDto> Get(Guid id);
        Task<IEnumerable<ProdutoTipoDto>> Get(string descricao);
        Task<ProdutoTipoDto> Create(ProdutoTipoDtoCreate create);
        Task<ProdutoTipoDto> Update(ProdutoTipoDtoUpdate update);
        Task<bool> Desabilitar(Guid id);

    }
}
