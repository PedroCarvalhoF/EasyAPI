using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class UserMasterUser_BaseEntity_APENAS_PROPRIEDADE : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UserMasterClienteIdentityId",
                table: "UsuariosPontoVendas",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "TiposProdutos",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "UserMasterClienteIdentityId",
                table: "TiposProdutos",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "SituacoesPedidos",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "UserMasterClienteIdentityId",
                table: "SituacoesPedidos",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "ProdutosMedidas",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "UserMasterClienteIdentityId",
                table: "ProdutosMedidas",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Produtos",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "UserMasterClienteIdentityId",
                table: "Produtos",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "PrecosProdutos",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "UserMasterClienteIdentityId",
                table: "PrecosProdutos",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "PontosVendas",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "UserMasterClienteIdentityId",
                table: "PontosVendas",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Pessoas",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "UserMasterClienteIdentityId",
                table: "Pessoas",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "PeriodosPontosVendas",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "UserMasterClienteIdentityId",
                table: "PeriodosPontosVendas",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Pedidos",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "UserMasterClienteIdentityId",
                table: "Pedidos",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "PagamentosPedidos",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "UserMasterClienteIdentityId",
                table: "PagamentosPedidos",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "ItensPedidos",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "UserMasterClienteIdentityId",
                table: "ItensPedidos",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "FuncoesFuncionarios",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "UserMasterClienteIdentityId",
                table: "FuncoesFuncionarios",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "FormasPagamentos",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "UserMasterClienteIdentityId",
                table: "FormasPagamentos",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "EntidadeTestes",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "UserMasterClienteIdentityId",
                table: "EntidadeTestes",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Enderecos",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "UserMasterClienteIdentityId",
                table: "Enderecos",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "DadosBancarios",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "UserMasterClienteIdentityId",
                table: "DadosBancarios",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Ctpss",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "UserMasterClienteIdentityId",
                table: "Ctpss",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Contatos",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "UserMasterClienteIdentityId",
                table: "Contatos",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "CategoriasProdutos",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "UserMasterClienteIdentityId",
                table: "CategoriasProdutos",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "CategoriasPrecos",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "UserMasterClienteIdentityId",
                table: "CategoriasPrecos",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.UpdateData(
                table: "CategoriasPrecos",
                keyColumn: "Id",
                keyValue: new Guid("5533b87c-72d5-4033-85c4-ae44f5a3210c"),
                columns: new[] { "CreateAt", "UpdateAt", "UserId", "UserMasterClienteIdentityId" },
                values: new object[] { new DateTime(2024, 6, 13, 4, 10, 54, 967, DateTimeKind.Local).AddTicks(3904), new DateTime(2024, 6, 13, 4, 10, 54, 967, DateTimeKind.Local).AddTicks(3906), null, null });

            migrationBuilder.UpdateData(
                table: "CategoriasPrecos",
                keyColumn: "Id",
                keyValue: new Guid("710bd8dd-1853-43a1-8708-ca1f259d71ad"),
                columns: new[] { "CreateAt", "UpdateAt", "UserId", "UserMasterClienteIdentityId" },
                values: new object[] { new DateTime(2024, 6, 13, 4, 10, 54, 967, DateTimeKind.Local).AddTicks(3888), new DateTime(2024, 6, 13, 4, 10, 54, 967, DateTimeKind.Local).AddTicks(3902), null, null });

            migrationBuilder.UpdateData(
                table: "CategoriasPrecos",
                keyColumn: "Id",
                keyValue: new Guid("ed65a4e3-a0b0-40a7-b7ae-3397a965d924"),
                columns: new[] { "CreateAt", "UpdateAt", "UserId", "UserMasterClienteIdentityId" },
                values: new object[] { new DateTime(2024, 6, 13, 4, 10, 54, 967, DateTimeKind.Local).AddTicks(3907), new DateTime(2024, 6, 13, 4, 10, 54, 967, DateTimeKind.Local).AddTicks(3909), null, null });

            migrationBuilder.UpdateData(
                table: "FormasPagamentos",
                keyColumn: "Id",
                keyValue: new Guid("92008957-f185-4563-9d9e-7b71f4ea2691"),
                columns: new[] { "CreateAt", "UpdateAt", "UserId", "UserMasterClienteIdentityId" },
                values: new object[] { new DateTime(2024, 6, 13, 4, 10, 54, 979, DateTimeKind.Local).AddTicks(6818), new DateTime(2024, 6, 13, 4, 10, 54, 979, DateTimeKind.Local).AddTicks(6873), null, null });

            migrationBuilder.UpdateData(
                table: "PeriodosPontosVendas",
                keyColumn: "Id",
                keyValue: new Guid("567906bb-6eb4-42e9-b890-10e6da214766"),
                columns: new[] { "CreateAt", "UpdateAt", "UserId", "UserMasterClienteIdentityId" },
                values: new object[] { new DateTime(2024, 6, 13, 4, 10, 54, 967, DateTimeKind.Local).AddTicks(2319), new DateTime(2024, 6, 13, 4, 10, 54, 967, DateTimeKind.Local).AddTicks(2340), null, null });

            migrationBuilder.UpdateData(
                table: "PeriodosPontosVendas",
                keyColumn: "Id",
                keyValue: new Guid("7e107de8-c97a-435b-9976-7a689ca28bb7"),
                columns: new[] { "CreateAt", "UpdateAt", "UserId", "UserMasterClienteIdentityId" },
                values: new object[] { new DateTime(2024, 6, 13, 4, 10, 54, 967, DateTimeKind.Local).AddTicks(2350), new DateTime(2024, 6, 13, 4, 10, 54, 967, DateTimeKind.Local).AddTicks(2351), null, null });

            migrationBuilder.UpdateData(
                table: "PeriodosPontosVendas",
                keyColumn: "Id",
                keyValue: new Guid("f14c83df-1fa4-4a83-8070-b16ecb19aa77"),
                columns: new[] { "CreateAt", "UpdateAt", "UserId", "UserMasterClienteIdentityId" },
                values: new object[] { new DateTime(2024, 6, 13, 4, 10, 54, 967, DateTimeKind.Local).AddTicks(2346), new DateTime(2024, 6, 13, 4, 10, 54, 967, DateTimeKind.Local).AddTicks(2348), null, null });

            migrationBuilder.UpdateData(
                table: "PeriodosPontosVendas",
                keyColumn: "Id",
                keyValue: new Guid("fc6a5d67-8356-4270-b9e6-7749b553dcf3"),
                columns: new[] { "CreateAt", "UpdateAt", "UserId", "UserMasterClienteIdentityId" },
                values: new object[] { new DateTime(2024, 6, 13, 4, 10, 54, 967, DateTimeKind.Local).AddTicks(2343), new DateTime(2024, 6, 13, 4, 10, 54, 967, DateTimeKind.Local).AddTicks(2344), null, null });

            migrationBuilder.UpdateData(
                table: "ProdutosMedidas",
                keyColumn: "Id",
                keyValue: new Guid("2f943e86-f06f-4f7d-babf-48d0d2d8f3ac"),
                columns: new[] { "CreateAt", "UpdateAt", "UserId", "UserMasterClienteIdentityId" },
                values: new object[] { new DateTime(2024, 6, 13, 7, 10, 54, 966, DateTimeKind.Utc).AddTicks(1078), new DateTime(2024, 6, 13, 7, 10, 54, 966, DateTimeKind.Utc).AddTicks(1078), null, null });

            migrationBuilder.UpdateData(
                table: "ProdutosMedidas",
                keyColumn: "Id",
                keyValue: new Guid("414a646f-1146-4b6d-bbfc-39a26e74a091"),
                columns: new[] { "CreateAt", "UpdateAt", "UserId", "UserMasterClienteIdentityId" },
                values: new object[] { new DateTime(2024, 6, 13, 7, 10, 54, 966, DateTimeKind.Utc).AddTicks(1062), new DateTime(2024, 6, 13, 7, 10, 54, 966, DateTimeKind.Utc).AddTicks(1059), null, null });

            migrationBuilder.UpdateData(
                table: "SituacoesPedidos",
                keyColumn: "Id",
                keyValue: new Guid("11b17cc5-c8b1-48f9-b9fd-886339441328"),
                columns: new[] { "CreateAt", "UpdateAt", "UserId", "UserMasterClienteIdentityId" },
                values: new object[] { new DateTime(2024, 6, 13, 4, 10, 54, 979, DateTimeKind.Local).AddTicks(8949), new DateTime(2024, 6, 13, 4, 10, 54, 979, DateTimeKind.Local).AddTicks(8968), null, null });

            migrationBuilder.UpdateData(
                table: "SituacoesPedidos",
                keyColumn: "Id",
                keyValue: new Guid("185b07da-7e82-43d1-b61f-912d8b29a34c"),
                columns: new[] { "CreateAt", "UpdateAt", "UserId", "UserMasterClienteIdentityId" },
                values: new object[] { new DateTime(2024, 6, 13, 4, 10, 54, 979, DateTimeKind.Local).AddTicks(8941), new DateTime(2024, 6, 13, 4, 10, 54, 979, DateTimeKind.Local).AddTicks(8946), null, null });

            migrationBuilder.UpdateData(
                table: "SituacoesPedidos",
                keyColumn: "Id",
                keyValue: new Guid("abc0f0f9-3295-439c-a468-795b071b7f22"),
                columns: new[] { "CreateAt", "UpdateAt", "UserId", "UserMasterClienteIdentityId" },
                values: new object[] { new DateTime(2024, 6, 13, 4, 10, 54, 979, DateTimeKind.Local).AddTicks(8923), new DateTime(2024, 6, 13, 4, 10, 54, 979, DateTimeKind.Local).AddTicks(8937), null, null });

            migrationBuilder.UpdateData(
                table: "TiposProdutos",
                keyColumn: "Id",
                keyValue: new Guid("1e11b25a-8bf5-4d57-80b7-396d09cbfcf1"),
                columns: new[] { "CreateAt", "UpdateAt", "UserId", "UserMasterClienteIdentityId" },
                values: new object[] { new DateTime(2024, 6, 13, 7, 10, 54, 965, DateTimeKind.Utc).AddTicks(9413), new DateTime(2024, 6, 13, 7, 10, 54, 965, DateTimeKind.Utc).AddTicks(9417), null, null });

            migrationBuilder.UpdateData(
                table: "TiposProdutos",
                keyColumn: "Id",
                keyValue: new Guid("edddccfa-a4af-4831-b9ee-29bdd5f755af"),
                columns: new[] { "CreateAt", "UpdateAt", "UserId", "UserMasterClienteIdentityId" },
                values: new object[] { new DateTime(2024, 6, 13, 7, 10, 54, 965, DateTimeKind.Utc).AddTicks(9376), new DateTime(2024, 6, 13, 7, 10, 54, 965, DateTimeKind.Utc).AddTicks(9411), null, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserMasterClienteIdentityId",
                table: "UsuariosPontoVendas");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "TiposProdutos");

            migrationBuilder.DropColumn(
                name: "UserMasterClienteIdentityId",
                table: "TiposProdutos");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "SituacoesPedidos");

            migrationBuilder.DropColumn(
                name: "UserMasterClienteIdentityId",
                table: "SituacoesPedidos");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ProdutosMedidas");

            migrationBuilder.DropColumn(
                name: "UserMasterClienteIdentityId",
                table: "ProdutosMedidas");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "UserMasterClienteIdentityId",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "PrecosProdutos");

            migrationBuilder.DropColumn(
                name: "UserMasterClienteIdentityId",
                table: "PrecosProdutos");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "PontosVendas");

            migrationBuilder.DropColumn(
                name: "UserMasterClienteIdentityId",
                table: "PontosVendas");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Pessoas");

            migrationBuilder.DropColumn(
                name: "UserMasterClienteIdentityId",
                table: "Pessoas");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "PeriodosPontosVendas");

            migrationBuilder.DropColumn(
                name: "UserMasterClienteIdentityId",
                table: "PeriodosPontosVendas");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "UserMasterClienteIdentityId",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "PagamentosPedidos");

            migrationBuilder.DropColumn(
                name: "UserMasterClienteIdentityId",
                table: "PagamentosPedidos");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ItensPedidos");

            migrationBuilder.DropColumn(
                name: "UserMasterClienteIdentityId",
                table: "ItensPedidos");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "FuncoesFuncionarios");

            migrationBuilder.DropColumn(
                name: "UserMasterClienteIdentityId",
                table: "FuncoesFuncionarios");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "FormasPagamentos");

            migrationBuilder.DropColumn(
                name: "UserMasterClienteIdentityId",
                table: "FormasPagamentos");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "EntidadeTestes");

            migrationBuilder.DropColumn(
                name: "UserMasterClienteIdentityId",
                table: "EntidadeTestes");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Enderecos");

            migrationBuilder.DropColumn(
                name: "UserMasterClienteIdentityId",
                table: "Enderecos");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "DadosBancarios");

            migrationBuilder.DropColumn(
                name: "UserMasterClienteIdentityId",
                table: "DadosBancarios");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Ctpss");

            migrationBuilder.DropColumn(
                name: "UserMasterClienteIdentityId",
                table: "Ctpss");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Contatos");

            migrationBuilder.DropColumn(
                name: "UserMasterClienteIdentityId",
                table: "Contatos");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "CategoriasProdutos");

            migrationBuilder.DropColumn(
                name: "UserMasterClienteIdentityId",
                table: "CategoriasProdutos");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "CategoriasPrecos");

            migrationBuilder.DropColumn(
                name: "UserMasterClienteIdentityId",
                table: "CategoriasPrecos");

            migrationBuilder.UpdateData(
                table: "CategoriasPrecos",
                keyColumn: "Id",
                keyValue: new Guid("5533b87c-72d5-4033-85c4-ae44f5a3210c"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 13, 1, 32, 44, 768, DateTimeKind.Local).AddTicks(103), new DateTime(2024, 6, 13, 1, 32, 44, 768, DateTimeKind.Local).AddTicks(105) });

            migrationBuilder.UpdateData(
                table: "CategoriasPrecos",
                keyColumn: "Id",
                keyValue: new Guid("710bd8dd-1853-43a1-8708-ca1f259d71ad"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 13, 1, 32, 44, 768, DateTimeKind.Local).AddTicks(90), new DateTime(2024, 6, 13, 1, 32, 44, 768, DateTimeKind.Local).AddTicks(101) });

            migrationBuilder.UpdateData(
                table: "CategoriasPrecos",
                keyColumn: "Id",
                keyValue: new Guid("ed65a4e3-a0b0-40a7-b7ae-3397a965d924"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 13, 1, 32, 44, 768, DateTimeKind.Local).AddTicks(106), new DateTime(2024, 6, 13, 1, 32, 44, 768, DateTimeKind.Local).AddTicks(107) });

            migrationBuilder.UpdateData(
                table: "FormasPagamentos",
                keyColumn: "Id",
                keyValue: new Guid("92008957-f185-4563-9d9e-7b71f4ea2691"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 13, 1, 32, 44, 771, DateTimeKind.Local).AddTicks(3335), new DateTime(2024, 6, 13, 1, 32, 44, 771, DateTimeKind.Local).AddTicks(3361) });

            migrationBuilder.UpdateData(
                table: "PeriodosPontosVendas",
                keyColumn: "Id",
                keyValue: new Guid("567906bb-6eb4-42e9-b890-10e6da214766"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 13, 1, 32, 44, 767, DateTimeKind.Local).AddTicks(7931), new DateTime(2024, 6, 13, 1, 32, 44, 767, DateTimeKind.Local).AddTicks(7944) });

            migrationBuilder.UpdateData(
                table: "PeriodosPontosVendas",
                keyColumn: "Id",
                keyValue: new Guid("7e107de8-c97a-435b-9976-7a689ca28bb7"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 13, 1, 32, 44, 767, DateTimeKind.Local).AddTicks(7956), new DateTime(2024, 6, 13, 1, 32, 44, 767, DateTimeKind.Local).AddTicks(7957) });

            migrationBuilder.UpdateData(
                table: "PeriodosPontosVendas",
                keyColumn: "Id",
                keyValue: new Guid("f14c83df-1fa4-4a83-8070-b16ecb19aa77"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 13, 1, 32, 44, 767, DateTimeKind.Local).AddTicks(7953), new DateTime(2024, 6, 13, 1, 32, 44, 767, DateTimeKind.Local).AddTicks(7954) });

            migrationBuilder.UpdateData(
                table: "PeriodosPontosVendas",
                keyColumn: "Id",
                keyValue: new Guid("fc6a5d67-8356-4270-b9e6-7749b553dcf3"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 13, 1, 32, 44, 767, DateTimeKind.Local).AddTicks(7949), new DateTime(2024, 6, 13, 1, 32, 44, 767, DateTimeKind.Local).AddTicks(7950) });

            migrationBuilder.UpdateData(
                table: "ProdutosMedidas",
                keyColumn: "Id",
                keyValue: new Guid("2f943e86-f06f-4f7d-babf-48d0d2d8f3ac"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 13, 4, 32, 44, 766, DateTimeKind.Utc).AddTicks(1584), new DateTime(2024, 6, 13, 4, 32, 44, 766, DateTimeKind.Utc).AddTicks(1583) });

            migrationBuilder.UpdateData(
                table: "ProdutosMedidas",
                keyColumn: "Id",
                keyValue: new Guid("414a646f-1146-4b6d-bbfc-39a26e74a091"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 13, 4, 32, 44, 766, DateTimeKind.Utc).AddTicks(1568), new DateTime(2024, 6, 13, 4, 32, 44, 766, DateTimeKind.Utc).AddTicks(1565) });

            migrationBuilder.UpdateData(
                table: "SituacoesPedidos",
                keyColumn: "Id",
                keyValue: new Guid("11b17cc5-c8b1-48f9-b9fd-886339441328"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 13, 1, 32, 44, 771, DateTimeKind.Local).AddTicks(4144), new DateTime(2024, 6, 13, 1, 32, 44, 771, DateTimeKind.Local).AddTicks(4145) });

            migrationBuilder.UpdateData(
                table: "SituacoesPedidos",
                keyColumn: "Id",
                keyValue: new Guid("185b07da-7e82-43d1-b61f-912d8b29a34c"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 13, 1, 32, 44, 771, DateTimeKind.Local).AddTicks(4140), new DateTime(2024, 6, 13, 1, 32, 44, 771, DateTimeKind.Local).AddTicks(4141) });

            migrationBuilder.UpdateData(
                table: "SituacoesPedidos",
                keyColumn: "Id",
                keyValue: new Guid("abc0f0f9-3295-439c-a468-795b071b7f22"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 13, 1, 32, 44, 771, DateTimeKind.Local).AddTicks(4133), new DateTime(2024, 6, 13, 1, 32, 44, 771, DateTimeKind.Local).AddTicks(4138) });

            migrationBuilder.UpdateData(
                table: "TiposProdutos",
                keyColumn: "Id",
                keyValue: new Guid("1e11b25a-8bf5-4d57-80b7-396d09cbfcf1"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 13, 4, 32, 44, 765, DateTimeKind.Utc).AddTicks(8836), new DateTime(2024, 6, 13, 4, 32, 44, 765, DateTimeKind.Utc).AddTicks(8838) });

            migrationBuilder.UpdateData(
                table: "TiposProdutos",
                keyColumn: "Id",
                keyValue: new Guid("edddccfa-a4af-4831-b9ee-29bdd5f755af"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 13, 4, 32, 44, 765, DateTimeKind.Utc).AddTicks(8802), new DateTime(2024, 6, 13, 4, 32, 44, 765, DateTimeKind.Utc).AddTicks(8834) });
        }
    }
}
