using Domain.Dtos;
using Domain.Dtos.ProdutoTipo;

namespace Domain.Interfaces.Services.ProdutoTipo
{
    public interface IProdutoTipoServices
    {
        Task<ResponseDto<List<ProdutoTipoDto>>> GetAll();
        Task<ResponseDto<List<ProdutoTipoDto>>> Get(Guid id);
        Task<ResponseDto<List<ProdutoTipoDto>>> Get(string descricao);
        Task<ResponseDto<List<ProdutoTipoDto>>> Create(ProdutoTipoDtoCreate create);
        Task<ResponseDto<List<ProdutoTipoDto>>> Update(ProdutoTipoDtoUpdate update);
        Task<ResponseDto<List<ProdutoTipoDto>>> Desabilitar(Guid id);

    }
}
