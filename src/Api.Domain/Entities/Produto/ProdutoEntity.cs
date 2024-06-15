using Api.Domain.Entities;
using Api.Domain.Entities.PrecoProduto;
using Api.Domain.Entities.ProdutoMedida;
using Domain.Dtos.ProdutoDtos;
using Domain.Entities.CategoriaProduto;
using Domain.Entities.ItensPedido;
using Domain.Entities.ProdutoTipo;
using Domain.Helpers.Tools;
using Domain.UserIdentity.Masters;

namespace Domain.Entities.Produto
{
    public class ProdutoEntity : BaseEntity
    {
        public string NomeProduto { get; private set; }
        public string CodigoBarrasPersonalizado { get; private set; }
        public string Descricao { get; private set; }
        public string Observacoes { get; private set; }
        public string ImgUrl { get; private set; }
        public Guid CategoriaProdutoEntityId { get; private set; }
        public Guid ProdutoMedidaEntityId { get; private set; }
        public Guid ProdutoTipoEntityId { get; private set; }

        public bool Validada => Validar();

        private bool Validar()
        {
            if (string.IsNullOrEmpty(NomeProduto))
                return false;

            if (string.IsNullOrEmpty(CodigoBarrasPersonalizado))
                return false;
            if (CategoriaProdutoEntityId == Guid.Empty || ProdutoMedidaEntityId == Guid.Empty || ProdutoTipoEntityId == Guid.Empty)
                return false;

            return true;
        }

        public virtual CategoriaProdutoEntity? CategoriaProdutoEntity { get; private set; }
        public virtual ProdutoMedidaEntity? ProdutoMedidaEntity { get; private set; }
        public virtual ProdutoTipoEntity? ProdutoTipoEntity { get; private set; }
        public virtual ICollection<ItemPedidoEntity>? ItensPedidoEntities { get; private set; }
        public virtual ICollection<PrecoProdutoEntity>? PrecoProdutoEntities { get; private set; }
        public ProdutoEntity() { }
        public ProdutoEntity(ProdutoDtoCreate create, UserMasterUserDtoCreate users) : base(users)
        {
            if (string.IsNullOrEmpty(create.NomeProduto))
                throw new ArgumentException("Nome do produto não informado.");
            if (string.IsNullOrEmpty(create.CodigoBarrasPersonalizado))
                throw new ArgumentException("Código do produto não informado.");
            if (create.CategoriaProdutoEntityId == Guid.Empty || create.ProdutoMedidaEntityId == Guid.Empty || create.ProdutoTipoEntityId == Guid.Empty)
                throw new ArgumentException("Informe a categoria,tipo e medida do produto.");


            NomeProduto = PrimeiraLetraSempreMaiuscula.Formatar(create.NomeProduto);
            CodigoBarrasPersonalizado = create.CodigoBarrasPersonalizado;
            Descricao = create.Descricao;
            Observacoes = create.Observacoes;
            ImgUrl = create.ImgUrl;
            CategoriaProdutoEntityId = create.CategoriaProdutoEntityId;
            ProdutoMedidaEntityId = create.ProdutoMedidaEntityId;
            ProdutoTipoEntityId = create.ProdutoTipoEntityId;
        }

        public ProdutoEntity(ProdutoDtoUpdate update, UserMasterUserDtoCreate users) : base(update.Id, update.Habilitado, users)
        {
            if (string.IsNullOrEmpty(update.NomeProduto))
                throw new ArgumentException("Nome do produto não informado.");
            if (string.IsNullOrEmpty(update.CodigoBarrasPersonalizado))
                throw new ArgumentException("Código do produto não informado.");
            if (update.CategoriaProdutoEntityId == Guid.Empty || update.ProdutoMedidaEntityId == Guid.Empty || update.ProdutoTipoEntityId == Guid.Empty)
                throw new ArgumentException("Informe a categoria,tipo e medida do produto.");

            NomeProduto = PrimeiraLetraSempreMaiuscula.Formatar(update.NomeProduto);
            CodigoBarrasPersonalizado = update.CodigoBarrasPersonalizado;
            Descricao = update.Descricao;
            Observacoes = update.Observacoes;
            ImgUrl = update.ImgUrl;
            CategoriaProdutoEntityId = update.CategoriaProdutoEntityId;
            ProdutoMedidaEntityId = update.ProdutoMedidaEntityId;
            ProdutoTipoEntityId = update.ProdutoTipoEntityId;
        }
    }
}
