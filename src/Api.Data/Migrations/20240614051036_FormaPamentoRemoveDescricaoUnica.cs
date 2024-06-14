using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class FormaPamentoRemoveDescricaoUnica : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_FormasPagamentos_DescricaoFormaPg",
                table: "FormasPagamentos");

            migrationBuilder.DeleteData(
                table: "CategoriasPrecos",
                keyColumn: "Id",
                keyValue: new Guid("5533b87c-72d5-4033-85c4-ae44f5a3210c"));

            migrationBuilder.DeleteData(
                table: "CategoriasPrecos",
                keyColumn: "Id",
                keyValue: new Guid("710bd8dd-1853-43a1-8708-ca1f259d71ad"));

            migrationBuilder.DeleteData(
                table: "CategoriasPrecos",
                keyColumn: "Id",
                keyValue: new Guid("ed65a4e3-a0b0-40a7-b7ae-3397a965d924"));

            migrationBuilder.DeleteData(
                table: "FormasPagamentos",
                keyColumn: "Id",
                keyValue: new Guid("92008957-f185-4563-9d9e-7b71f4ea2691"));

            migrationBuilder.DeleteData(
                table: "PeriodosPontosVendas",
                keyColumn: "Id",
                keyValue: new Guid("567906bb-6eb4-42e9-b890-10e6da214766"));

            migrationBuilder.DeleteData(
                table: "PeriodosPontosVendas",
                keyColumn: "Id",
                keyValue: new Guid("7e107de8-c97a-435b-9976-7a689ca28bb7"));

            migrationBuilder.DeleteData(
                table: "PeriodosPontosVendas",
                keyColumn: "Id",
                keyValue: new Guid("f14c83df-1fa4-4a83-8070-b16ecb19aa77"));

            migrationBuilder.DeleteData(
                table: "PeriodosPontosVendas",
                keyColumn: "Id",
                keyValue: new Guid("fc6a5d67-8356-4270-b9e6-7749b553dcf3"));

            migrationBuilder.DeleteData(
                table: "ProdutosMedidas",
                keyColumn: "Id",
                keyValue: new Guid("2f943e86-f06f-4f7d-babf-48d0d2d8f3ac"));

            migrationBuilder.DeleteData(
                table: "ProdutosMedidas",
                keyColumn: "Id",
                keyValue: new Guid("414a646f-1146-4b6d-bbfc-39a26e74a091"));

            migrationBuilder.DeleteData(
                table: "SituacoesPedidos",
                keyColumn: "Id",
                keyValue: new Guid("11b17cc5-c8b1-48f9-b9fd-886339441328"));

            migrationBuilder.DeleteData(
                table: "SituacoesPedidos",
                keyColumn: "Id",
                keyValue: new Guid("185b07da-7e82-43d1-b61f-912d8b29a34c"));

            migrationBuilder.DeleteData(
                table: "SituacoesPedidos",
                keyColumn: "Id",
                keyValue: new Guid("abc0f0f9-3295-439c-a468-795b071b7f22"));

            migrationBuilder.DeleteData(
                table: "TiposProdutos",
                keyColumn: "Id",
                keyValue: new Guid("1e11b25a-8bf5-4d57-80b7-396d09cbfcf1"));

            migrationBuilder.DeleteData(
                table: "TiposProdutos",
                keyColumn: "Id",
                keyValue: new Guid("edddccfa-a4af-4831-b9ee-29bdd5f755af"));

            migrationBuilder.CreateIndex(
                name: "IX_FormasPagamentos_DescricaoFormaPg",
                table: "FormasPagamentos",
                column: "DescricaoFormaPg");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_FormasPagamentos_DescricaoFormaPg",
                table: "FormasPagamentos");

            migrationBuilder.InsertData(
                table: "CategoriasPrecos",
                columns: new[] { "Id", "CreateAt", "DescricaoCategoria", "Habilitado", "UpdateAt", "UserId", "UserMasterClienteIdentityId" },
                values: new object[,]
                {
                    { new Guid("5533b87c-72d5-4033-85c4-ae44f5a3210c"), new DateTime(2024, 6, 13, 4, 10, 54, 967, DateTimeKind.Local).AddTicks(3904), "IFood", true, new DateTime(2024, 6, 13, 4, 10, 54, 967, DateTimeKind.Local).AddTicks(3906), null, null },
                    { new Guid("710bd8dd-1853-43a1-8708-ca1f259d71ad"), new DateTime(2024, 6, 13, 4, 10, 54, 967, DateTimeKind.Local).AddTicks(3888), "Balcão", true, new DateTime(2024, 6, 13, 4, 10, 54, 967, DateTimeKind.Local).AddTicks(3902), null, null },
                    { new Guid("ed65a4e3-a0b0-40a7-b7ae-3397a965d924"), new DateTime(2024, 6, 13, 4, 10, 54, 967, DateTimeKind.Local).AddTicks(3907), "Lojista", true, new DateTime(2024, 6, 13, 4, 10, 54, 967, DateTimeKind.Local).AddTicks(3909), null, null }
                });

            migrationBuilder.InsertData(
                table: "FormasPagamentos",
                columns: new[] { "Id", "CreateAt", "DescricaoFormaPg", "Habilitado", "UpdateAt", "UserId", "UserMasterClienteIdentityId" },
                values: new object[] { new Guid("92008957-f185-4563-9d9e-7b71f4ea2691"), new DateTime(2024, 6, 13, 4, 10, 54, 979, DateTimeKind.Local).AddTicks(6818), "Dinheiro", true, new DateTime(2024, 6, 13, 4, 10, 54, 979, DateTimeKind.Local).AddTicks(6873), null, null });

            migrationBuilder.InsertData(
                table: "PeriodosPontosVendas",
                columns: new[] { "Id", "CreateAt", "DescricaoPeriodo", "Habilitado", "UpdateAt", "UserId", "UserMasterClienteIdentityId" },
                values: new object[,]
                {
                    { new Guid("567906bb-6eb4-42e9-b890-10e6da214766"), new DateTime(2024, 6, 13, 4, 10, 54, 967, DateTimeKind.Local).AddTicks(2319), "Almoço", true, new DateTime(2024, 6, 13, 4, 10, 54, 967, DateTimeKind.Local).AddTicks(2340), null, null },
                    { new Guid("7e107de8-c97a-435b-9976-7a689ca28bb7"), new DateTime(2024, 6, 13, 4, 10, 54, 967, DateTimeKind.Local).AddTicks(2350), "Noturno", true, new DateTime(2024, 6, 13, 4, 10, 54, 967, DateTimeKind.Local).AddTicks(2351), null, null },
                    { new Guid("f14c83df-1fa4-4a83-8070-b16ecb19aa77"), new DateTime(2024, 6, 13, 4, 10, 54, 967, DateTimeKind.Local).AddTicks(2346), "Dia Todo", true, new DateTime(2024, 6, 13, 4, 10, 54, 967, DateTimeKind.Local).AddTicks(2348), null, null },
                    { new Guid("fc6a5d67-8356-4270-b9e6-7749b553dcf3"), new DateTime(2024, 6, 13, 4, 10, 54, 967, DateTimeKind.Local).AddTicks(2343), "Janta", true, new DateTime(2024, 6, 13, 4, 10, 54, 967, DateTimeKind.Local).AddTicks(2344), null, null }
                });

            migrationBuilder.InsertData(
                table: "ProdutosMedidas",
                columns: new[] { "Id", "CreateAt", "Descricao", "Habilitado", "UpdateAt", "UserId", "UserMasterClienteIdentityId" },
                values: new object[,]
                {
                    { new Guid("2f943e86-f06f-4f7d-babf-48d0d2d8f3ac"), new DateTime(2024, 6, 13, 7, 10, 54, 966, DateTimeKind.Utc).AddTicks(1078), "Caixa", true, new DateTime(2024, 6, 13, 7, 10, 54, 966, DateTimeKind.Utc).AddTicks(1078), null, null },
                    { new Guid("414a646f-1146-4b6d-bbfc-39a26e74a091"), new DateTime(2024, 6, 13, 7, 10, 54, 966, DateTimeKind.Utc).AddTicks(1062), "Unidade", true, new DateTime(2024, 6, 13, 7, 10, 54, 966, DateTimeKind.Utc).AddTicks(1059), null, null }
                });

            migrationBuilder.InsertData(
                table: "SituacoesPedidos",
                columns: new[] { "Id", "CreateAt", "DescricaoSituacao", "Habilitado", "UpdateAt", "UserId", "UserMasterClienteIdentityId" },
                values: new object[,]
                {
                    { new Guid("11b17cc5-c8b1-48f9-b9fd-886339441328"), new DateTime(2024, 6, 13, 4, 10, 54, 979, DateTimeKind.Local).AddTicks(8949), "Cancelado", true, new DateTime(2024, 6, 13, 4, 10, 54, 979, DateTimeKind.Local).AddTicks(8968), null, null },
                    { new Guid("185b07da-7e82-43d1-b61f-912d8b29a34c"), new DateTime(2024, 6, 13, 4, 10, 54, 979, DateTimeKind.Local).AddTicks(8941), "Fechado", true, new DateTime(2024, 6, 13, 4, 10, 54, 979, DateTimeKind.Local).AddTicks(8946), null, null },
                    { new Guid("abc0f0f9-3295-439c-a468-795b071b7f22"), new DateTime(2024, 6, 13, 4, 10, 54, 979, DateTimeKind.Local).AddTicks(8923), "Aberto", true, new DateTime(2024, 6, 13, 4, 10, 54, 979, DateTimeKind.Local).AddTicks(8937), null, null }
                });

            migrationBuilder.InsertData(
                table: "TiposProdutos",
                columns: new[] { "Id", "CreateAt", "DescricaoTipoProduto", "Habilitado", "UpdateAt", "UserId", "UserMasterClienteIdentityId" },
                values: new object[,]
                {
                    { new Guid("1e11b25a-8bf5-4d57-80b7-396d09cbfcf1"), new DateTime(2024, 6, 13, 7, 10, 54, 965, DateTimeKind.Utc).AddTicks(9413), "Materia Prima", true, new DateTime(2024, 6, 13, 7, 10, 54, 965, DateTimeKind.Utc).AddTicks(9417), null, null },
                    { new Guid("edddccfa-a4af-4831-b9ee-29bdd5f755af"), new DateTime(2024, 6, 13, 7, 10, 54, 965, DateTimeKind.Utc).AddTicks(9376), "Venda", true, new DateTime(2024, 6, 13, 7, 10, 54, 965, DateTimeKind.Utc).AddTicks(9411), null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_FormasPagamentos_DescricaoFormaPg",
                table: "FormasPagamentos",
                column: "DescricaoFormaPg",
                unique: true);
        }
    }
}
