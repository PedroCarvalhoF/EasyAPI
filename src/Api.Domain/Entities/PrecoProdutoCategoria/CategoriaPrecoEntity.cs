using Api.Domain.Dtos.CategoriaPrecoDtos;
using Api.Domain.Entities.PrecoProduto;
using Domain.Helpers.Tools;
using Domain.UserIdentity.Masters;
using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Entities.CategoriaPreco
{
    public class CategoriaPrecoEntity : BaseEntity
    {
        [Required(ErrorMessage = "Informe a {0}")]
        [Display(Name = "Categoria de Preço")]
        [MaxLength(80, ErrorMessage = "Quantidade de caracteres deve ser menor ou igual 80")]
        public string? DescricaoCategoria { get; private set; }
        public virtual ICollection<PrecoProdutoEntity>? PrecoProdutoEntities { get; private set; }
        public bool Valida => Validar();

        private bool Validar()
        {
            if (string.IsNullOrEmpty(DescricaoCategoria))
                return false;
            if (DescricaoCategoria.Length > 100)
                return false;

            return true;
        }

        public CategoriaPrecoEntity() { }
        public CategoriaPrecoEntity(CategoriaPrecoDtoCreate create, UserMasterUserDtoCreate users) : base(users)
        {
            if (string.IsNullOrEmpty(create.DescricaoCategoria))
                throw new ArgumentException("Informe a categoria de preço");
            if (create.DescricaoCategoria.Length > 100)
                throw new ArgumentException("Descrição no máximo 100 caracteres.");

            DescricaoCategoria = PrimeiraLetraSempreMaiuscula.Formatar(create.DescricaoCategoria);
        }

        public CategoriaPrecoEntity(CategoriaPrecoDtoUpdate update, UserMasterUserDtoCreate users) : base(update.Id, update.Habilitado, users)
        {

            if (string.IsNullOrEmpty(update.DescricaoCategoria))
                throw new ArgumentException("Informe a categoria de preço");
            if (update.DescricaoCategoria.Length > 100)
                throw new ArgumentException("Descrição no máximo 100 caracteres.");

            DescricaoCategoria = DescricaoCategoria = PrimeiraLetraSempreMaiuscula.Formatar(update.DescricaoCategoria);
        }
    }
}
