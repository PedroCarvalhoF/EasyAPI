using Api.Domain.Dtos.PrecoProdutoDtos;
using Api.Domain.Entities.CategoriaPreco;
using Domain.Entities.Produto;
using Domain.UserIdentity.Masters;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Domain.Entities.PrecoProduto
{
    public class PrecoProdutoEntity : BaseEntity
    {
        public PrecoProdutoEntity() { }
        public PrecoProdutoEntity(PrecoProdutoDtoCreate create, UserMasterUserDtoCreate users) : base(users)
        {
            if (create.ProdutoEntityId == Guid.Empty || create.CategoriaPrecoEntityId == Guid.Empty)
                throw new ArgumentException("Necessário id produto e id categoria de preco");
            if (create.PrecoProduto < 0)
                throw new ArgumentException("O preço não pode ser menor do que zero");

            ProdutoEntityId = create.ProdutoEntityId;
            CategoriaPrecoEntityId = create.CategoriaPrecoEntityId;
            PrecoProduto = create.PrecoProduto;
        }

        public PrecoProdutoEntity(PrecoProdutoDtoUpdate update, UserMasterUserDtoCreate users) : base(update.Id, update.Habilitado, users)
        {
            if (update.ProdutoEntityId == Guid.Empty || update.CategoriaPrecoEntityId == Guid.Empty)
                throw new ArgumentException("Necessário id produto e id categoria de preco");
            if (update.PrecoProduto < 0)
                throw new ArgumentException("O preço não pode ser menor do que zero"); if (update.ProdutoEntityId == Guid.Empty || update.CategoriaPrecoEntityId == Guid.Empty)
                throw new ArgumentException("Necessário id produto e id categoria de preco");
            if (update.PrecoProduto < 0)
                throw new ArgumentException("O preço não pode ser menor do que zero");

            ProdutoEntityId = update.ProdutoEntityId;
            CategoriaPrecoEntityId = update.CategoriaPrecoEntityId;
            PrecoProduto = update.PrecoProduto;
        }

        [Required(ErrorMessage = "Informe o {0}")]
        [Display(Name = "Codigo do Produto")]
        public Guid ProdutoEntityId { get; private set; }
        public virtual ProdutoEntity? ProdutoEntity { get; private set; }


        [Required(ErrorMessage = "Informe o {0}")]
        [Display(Name = "Categoria de Produto")]
        public Guid CategoriaPrecoEntityId { get; private set; }
        public virtual CategoriaPrecoEntity? CategoriaPrecoEntity { get; private set; }

        [Required(ErrorMessage = "Informe o {0}")]
        [Display(Name = "Preço do Produto")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal PrecoProduto { get; private set; }

        public bool Valida => Validar();

        public bool Validar()
        {

            if (this.ProdutoEntityId == Guid.Empty || this.CategoriaPrecoEntityId == Guid.Empty)
                return false;
            if (this.PrecoProduto < 0)
                return false;
            if (this.ProdutoEntityId == Guid.Empty || this.CategoriaPrecoEntityId == Guid.Empty)
                return false;
            if (this.PrecoProduto < 0)
                return false;

            return true;
        }
    }
}