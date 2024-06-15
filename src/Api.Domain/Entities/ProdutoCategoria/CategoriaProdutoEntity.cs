using Api.Domain.Entities;
using Domain.Dtos.ProdutoCategoria;
using Domain.Entities.Produto;
using Domain.Helpers.Tools;
using Domain.UserIdentity.Masters;

namespace Domain.Entities.CategoriaProduto
{
    public class CategoriaProdutoEntity : BaseEntity
    {
        public string DescricaoCategoria { get; private set; }
        public bool Validada => Validar();
        public IEnumerable<ProdutoEntity> ProdutoEntities { get; private set; }
        private bool Validar()
        {
            if (!isBaseValida)
                return isBaseValida;

            if (DescricaoCategoria.Length > 80)
                return false;

            return true;
        }


        public CategoriaProdutoEntity() { }
        public CategoriaProdutoEntity(CategoriaProdutoDtoCreate create, UserMasterUserDtoCreate users) : base(users)
        {
            if (string.IsNullOrWhiteSpace(create.DescricaoCategoria))
                throw new ArgumentException("Preencha descrição da categoria");
            DescricaoCategoria = PrimeiraLetraSempreMaiuscula.Formatar(create.DescricaoCategoria);
        }

        public CategoriaProdutoEntity(CategoriaProdutoDtoUpdate update, UserMasterUserDtoCreate users) : base(update.Id, update.Habilitado, users)
        {
            if (string.IsNullOrWhiteSpace(update.DescricaoCategoria))
                throw new ArgumentException("Preencha descrição da categoria");
            DescricaoCategoria = PrimeiraLetraSempreMaiuscula.Formatar(update.DescricaoCategoria);
        }
    }
}
