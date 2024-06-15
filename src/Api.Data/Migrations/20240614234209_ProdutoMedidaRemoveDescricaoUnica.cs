using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class ProdutoMedidaRemoveDescricaoUnica : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ProdutosMedidas_Descricao",
                table: "ProdutosMedidas");

            migrationBuilder.CreateIndex(
                name: "IX_ProdutosMedidas_Descricao",
                table: "ProdutosMedidas",
                column: "Descricao");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ProdutosMedidas_Descricao",
                table: "ProdutosMedidas");

            migrationBuilder.CreateIndex(
                name: "IX_ProdutosMedidas_Descricao",
                table: "ProdutosMedidas",
                column: "Descricao",
                unique: true);
        }
    }
}
