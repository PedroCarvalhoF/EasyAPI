using Domain.Entities.Pessoa.Contato;

namespace Domain.Interfaces.Repository.Pessoa.Contato
{
    public interface IContatoRepository
    {
        Task<IEnumerable<ContatoEntity>> GetAllContatos();
        Task<ContatoEntity> GetByContatoId(Guid idContato);
    }
}
