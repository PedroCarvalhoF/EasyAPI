using Api.Domain.Dtos.ProdutoMedidaDtos;
using Domain.Entities.Produto;
using Domain.UserIdentity.Masters;

namespace Api.Domain.Entities.ProdutoMedida
{
    public class ProdutoMedidaEntity : BaseEntity
    {
        public string? Descricao { get; private set; }
        public virtual ICollection<ProdutoEntity>? ProdutoEntities { get; private set; }
        public bool isValidada => Validar();

        private bool Validar()
        {
            return
                Descricao != null;
        }

        public ProdutoMedidaEntity() { }
        public ProdutoMedidaEntity(ProdutoMedidaDtoCreate create, UserMasterUserDtoCreate users) : base(users)
        {
            Descricao = create.Descricao;
        }
        public ProdutoMedidaEntity(ProdutoMedidaDtoUpdate update, UserMasterUserDtoCreate users) : base(update.Id, update.Habilitado, users)
        {
            Descricao = update.Descricao;
        }
    }
}