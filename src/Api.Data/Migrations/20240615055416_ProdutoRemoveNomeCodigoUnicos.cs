using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class ProdutoRemoveNomeCodigoUnicos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Produtos_CodigoBarrasPersonalizado",
                table: "Produtos");

            migrationBuilder.DropIndex(
                name: "IX_Produtos_NomeProduto",
                table: "Produtos");

            migrationBuilder.UpdateData(
                table: "Produtos",
                keyColumn: "Observacoes",
                keyValue: null,
                column: "Observacoes",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Observacoes",
                table: "Produtos",
                type: "varchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(200)",
                oldMaxLength: 200,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Produtos",
                keyColumn: "ImgUrl",
                keyValue: null,
                column: "ImgUrl",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "ImgUrl",
                table: "Produtos",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Produtos",
                keyColumn: "Descricao",
                keyValue: null,
                column: "Descricao",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "Produtos",
                type: "varchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(200)",
                oldMaxLength: 200,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_CodigoBarrasPersonalizado",
                table: "Produtos",
                column: "CodigoBarrasPersonalizado");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_NomeProduto",
                table: "Produtos",
                column: "NomeProduto");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Produtos_CodigoBarrasPersonalizado",
                table: "Produtos");

            migrationBuilder.DropIndex(
                name: "IX_Produtos_NomeProduto",
                table: "Produtos");

            migrationBuilder.AlterColumn<string>(
                name: "Observacoes",
                table: "Produtos",
                type: "varchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(200)",
                oldMaxLength: 200)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "ImgUrl",
                table: "Produtos",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "Produtos",
                type: "varchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(200)",
                oldMaxLength: 200)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_CodigoBarrasPersonalizado",
                table: "Produtos",
                column: "CodigoBarrasPersonalizado",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_NomeProduto",
                table: "Produtos",
                column: "NomeProduto",
                unique: true);
        }
    }
}
