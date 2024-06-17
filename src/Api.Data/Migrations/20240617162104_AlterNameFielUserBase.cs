using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class AlterNameFielUserBase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "TiposProdutos",
                newName: "UserBaseId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "SituacoesPedidos",
                newName: "UserBaseId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "ProdutosMedidas",
                newName: "UserBaseId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Produtos",
                newName: "UserBaseId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "PrecosProdutos",
                newName: "UserBaseId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "PontosVendas",
                newName: "UserBaseId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Pessoas",
                newName: "UserBaseId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "PeriodosPontosVendas",
                newName: "UserBaseId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Pedidos",
                newName: "UserBaseId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "PagamentosPedidos",
                newName: "UserBaseId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "ItensPedidos",
                newName: "UserBaseId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "FuncoesFuncionarios",
                newName: "UserBaseId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "FormasPagamentos",
                newName: "UserBaseId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "EntidadeTestes",
                newName: "UserBaseId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Enderecos",
                newName: "UserBaseId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "DadosBancarios",
                newName: "UserBaseId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Ctpss",
                newName: "UserBaseId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Contatos",
                newName: "UserBaseId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "CategoriasProdutos",
                newName: "UserBaseId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "CategoriasPrecos",
                newName: "UserBaseId");

            migrationBuilder.AddColumn<Guid>(
                name: "UserBaseId",
                table: "UsuariosPontoVendas",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserBaseId",
                table: "UsuariosPontoVendas");

            migrationBuilder.RenameColumn(
                name: "UserBaseId",
                table: "TiposProdutos",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "UserBaseId",
                table: "SituacoesPedidos",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "UserBaseId",
                table: "ProdutosMedidas",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "UserBaseId",
                table: "Produtos",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "UserBaseId",
                table: "PrecosProdutos",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "UserBaseId",
                table: "PontosVendas",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "UserBaseId",
                table: "Pessoas",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "UserBaseId",
                table: "PeriodosPontosVendas",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "UserBaseId",
                table: "Pedidos",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "UserBaseId",
                table: "PagamentosPedidos",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "UserBaseId",
                table: "ItensPedidos",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "UserBaseId",
                table: "FuncoesFuncionarios",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "UserBaseId",
                table: "FormasPagamentos",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "UserBaseId",
                table: "EntidadeTestes",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "UserBaseId",
                table: "Enderecos",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "UserBaseId",
                table: "DadosBancarios",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "UserBaseId",
                table: "Ctpss",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "UserBaseId",
                table: "Contatos",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "UserBaseId",
                table: "CategoriasProdutos",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "UserBaseId",
                table: "CategoriasPrecos",
                newName: "UserId");
        }
    }
}
