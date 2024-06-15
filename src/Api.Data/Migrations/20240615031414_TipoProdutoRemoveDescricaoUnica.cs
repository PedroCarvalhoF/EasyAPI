using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class TipoProdutoRemoveDescricaoUnica : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TiposProdutos_DescricaoTipoProduto",
                table: "TiposProdutos");

            migrationBuilder.CreateIndex(
                name: "IX_TiposProdutos_DescricaoTipoProduto",
                table: "TiposProdutos",
                column: "DescricaoTipoProduto");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TiposProdutos_DescricaoTipoProduto",
                table: "TiposProdutos");

            migrationBuilder.CreateIndex(
                name: "IX_TiposProdutos_DescricaoTipoProduto",
                table: "TiposProdutos",
                column: "DescricaoTipoProduto",
                unique: true);
        }
    }
}
