using Api.Domain.Entities;
using Domain.Dtos.ProdutoTipo;
using Domain.Entities.Produto;
using Domain.Helpers.Tools;
using Domain.UserIdentity.Masters;

namespace Domain.Entities.ProdutoTipo
{
    public class ProdutoTipoEntity : BaseEntity
    {
        public string? DescricaoTipoProduto { get; private set; }
        public IEnumerable<ProdutoEntity>? ProdutoEntities { get; private set; }

        public bool isValidada => Validar();

        private bool Validar()
        {
            return DescricaoTipoProduto != null && DescricaoTipoProduto.Length <= 80;
        }
        public ProdutoTipoEntity() { }
        public ProdutoTipoEntity(ProdutoTipoDtoCreate create, UserMasterUserDtoCreate users) : base(users)
        {
            if (string.IsNullOrWhiteSpace(create.DescricaoTipoProduto))
                throw new ArgumentException("Descrição não pode ser vazia.");

            DescricaoTipoProduto = PrimeiraLetraSempreMaiuscula.Formatar(create.DescricaoTipoProduto!);
        }

        public ProdutoTipoEntity(ProdutoTipoDtoUpdate update, UserMasterUserDtoCreate users) : base(update.Id, update.Habilitado, users)
        {
            if (string.IsNullOrWhiteSpace(update.DescricaoTipoProduto))
                throw new ArgumentException("Descrição não pode ser vazia.");

            DescricaoTipoProduto = PrimeiraLetraSempreMaiuscula.Formatar(update.DescricaoTipoProduto!);
        }
    }
}