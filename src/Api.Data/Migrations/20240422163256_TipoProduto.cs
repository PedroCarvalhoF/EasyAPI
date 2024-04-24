using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class TipoProduto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CategoriasProdutos",
                keyColumn: "Id",
                keyValue: new Guid("073d8c55-0371-4b57-8f01-d84ddd938b9d"));

            migrationBuilder.DeleteData(
                table: "CategoriasProdutos",
                keyColumn: "Id",
                keyValue: new Guid("dfcac7ec-bc48-4521-a2b4-e4270292d3e4"));

            migrationBuilder.UpdateData(
                table: "TiposProdutos",
                keyColumn: "DescricaoTipoProduto",
                keyValue: null,
                column: "DescricaoTipoProduto",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "DescricaoTipoProduto",
                table: "TiposProdutos",
                type: "varchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "CategoriasProdutos",
                keyColumn: "Id",
                keyValue: new Guid("6fb282e9-6ee8-44d9-a049-994f68bd0b27"),
                column: "CreateAt",
                value: new DateTime(2024, 4, 22, 13, 32, 56, 253, DateTimeKind.Local).AddTicks(7270));

            migrationBuilder.InsertData(
                table: "CategoriasProdutos",
                columns: new[] { "Id", "CreateAt", "DescricaoCategoria", "Habilitado", "UpdateAt" },
                values: new object[,]
                {
                    { new Guid("c76ca727-7dc3-46c0-ae0f-c90b4aaf02b3"), new DateTime(2024, 4, 22, 13, 32, 56, 253, DateTimeKind.Local).AddTicks(7325), "Promoções", true, null },
                    { new Guid("e552f739-e542-45f8-a8b9-e22ca88ac6f8"), new DateTime(2024, 4, 22, 13, 32, 56, 253, DateTimeKind.Local).AddTicks(7356), "Executivos", true, null }
                });

            migrationBuilder.UpdateData(
                table: "FormasPagamentos",
                keyColumn: "Id",
                keyValue: new Guid("18e68a14-54b5-44b6-87ed-e8b0258d9c1d"),
                column: "CreateAt",
                value: new DateTime(2024, 4, 22, 13, 32, 56, 253, DateTimeKind.Local).AddTicks(7947));

            migrationBuilder.UpdateData(
                table: "FormasPagamentos",
                keyColumn: "Id",
                keyValue: new Guid("249c0c31-ee8e-487b-b4c9-1f14ced84553"),
                column: "CreateAt",
                value: new DateTime(2024, 4, 22, 13, 32, 56, 253, DateTimeKind.Local).AddTicks(7944));

            migrationBuilder.UpdateData(
                table: "FormasPagamentos",
                keyColumn: "Id",
                keyValue: new Guid("46152359-216e-4b2e-827c-411092ecc423"),
                column: "CreateAt",
                value: new DateTime(2024, 4, 22, 13, 32, 56, 253, DateTimeKind.Local).AddTicks(7955));

            migrationBuilder.UpdateData(
                table: "FormasPagamentos",
                keyColumn: "Id",
                keyValue: new Guid("7aaecde9-7290-48e7-bf31-f8dab886381f"),
                column: "CreateAt",
                value: new DateTime(2024, 4, 22, 13, 32, 56, 253, DateTimeKind.Local).AddTicks(7970));

            migrationBuilder.UpdateData(
                table: "FormasPagamentos",
                keyColumn: "Id",
                keyValue: new Guid("935f9721-bcc2-4239-88a1-2e0c9b1a75f6"),
                column: "CreateAt",
                value: new DateTime(2024, 4, 22, 13, 32, 56, 253, DateTimeKind.Local).AddTicks(7964));

            migrationBuilder.UpdateData(
                table: "FormasPagamentos",
                keyColumn: "Id",
                keyValue: new Guid("ac336bfb-39eb-4da0-9b04-c159f0068676"),
                column: "CreateAt",
                value: new DateTime(2024, 4, 22, 13, 32, 56, 253, DateTimeKind.Local).AddTicks(7949));

            migrationBuilder.UpdateData(
                table: "FormasPagamentos",
                keyColumn: "Id",
                keyValue: new Guid("cdd1b70b-5c96-472e-a983-3abdcc318c53"),
                column: "CreateAt",
                value: new DateTime(2024, 4, 22, 13, 32, 56, 253, DateTimeKind.Local).AddTicks(7962));

            migrationBuilder.UpdateData(
                table: "FormasPagamentos",
                keyColumn: "Id",
                keyValue: new Guid("d276bcd0-e552-46d4-af7a-390a3af0eb37"),
                column: "CreateAt",
                value: new DateTime(2024, 4, 22, 13, 32, 56, 253, DateTimeKind.Local).AddTicks(7952));

            migrationBuilder.UpdateData(
                table: "FormasPagamentos",
                keyColumn: "Id",
                keyValue: new Guid("e93ceba1-40f8-4420-8dc3-bb1b3ee6ee9f"),
                column: "CreateAt",
                value: new DateTime(2024, 4, 22, 13, 32, 56, 253, DateTimeKind.Local).AddTicks(7967));

            migrationBuilder.UpdateData(
                table: "PessoasTipos",
                keyColumn: "Id",
                keyValue: new Guid("2cc73259-4063-4f20-9c21-34ff2a9cbd58"),
                column: "CreateAt",
                value: new DateTime(2024, 4, 22, 13, 32, 56, 253, DateTimeKind.Local).AddTicks(8058));

            migrationBuilder.UpdateData(
                table: "PessoasTipos",
                keyColumn: "Id",
                keyValue: new Guid("a58b678c-07d4-417b-929b-600dc63858ea"),
                column: "CreateAt",
                value: new DateTime(2024, 4, 22, 13, 32, 56, 253, DateTimeKind.Local).AddTicks(8055));

            migrationBuilder.UpdateData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: new Guid("d2a0c172-e742-4e54-a806-938ddaaf8edb"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 22, 13, 32, 56, 253, DateTimeKind.Local).AddTicks(7870), new DateTime(2024, 4, 22, 13, 32, 56, 253, DateTimeKind.Local).AddTicks(7886) });

            migrationBuilder.UpdateData(
                table: "ProdutosMedidas",
                keyColumn: "Id",
                keyValue: new Guid("05b3382d-0940-446a-8c2c-3e27293cf77d"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 22, 13, 32, 56, 253, DateTimeKind.Local).AddTicks(8119), new DateTime(2024, 4, 22, 13, 32, 56, 253, DateTimeKind.Local).AddTicks(8120) });

            migrationBuilder.UpdateData(
                table: "ProdutosMedidas",
                keyColumn: "Id",
                keyValue: new Guid("9bbe9cc9-ba40-4bb3-9b71-74a8234133a5"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 22, 13, 32, 56, 253, DateTimeKind.Local).AddTicks(8114), new DateTime(2024, 4, 22, 13, 32, 56, 253, DateTimeKind.Local).AddTicks(8116) });

            migrationBuilder.UpdateData(
                table: "ProdutosMedidas",
                keyColumn: "Id",
                keyValue: new Guid("cc8119c5-7651-4708-bba4-8f350726bdac"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 22, 13, 32, 56, 253, DateTimeKind.Local).AddTicks(8105), new DateTime(2024, 4, 22, 13, 32, 56, 253, DateTimeKind.Local).AddTicks(8106) });

            migrationBuilder.UpdateData(
                table: "TiposProdutos",
                keyColumn: "Id",
                keyValue: new Guid("2491c7e2-10ec-48a4-8898-44e24814f23d"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 22, 13, 32, 56, 253, DateTimeKind.Local).AddTicks(8157), new DateTime(2024, 4, 22, 13, 32, 56, 253, DateTimeKind.Local).AddTicks(8158) });

            migrationBuilder.UpdateData(
                table: "TiposProdutos",
                keyColumn: "Id",
                keyValue: new Guid("3cca7caf-8a98-40b2-9f20-3f864f59e1c5"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 22, 13, 32, 56, 253, DateTimeKind.Local).AddTicks(8162), new DateTime(2024, 4, 22, 13, 32, 56, 253, DateTimeKind.Local).AddTicks(8163) });

            migrationBuilder.UpdateData(
                table: "TiposProdutos",
                keyColumn: "Id",
                keyValue: new Guid("59de4011-1ca7-4a52-833c-9672a03320ac"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 22, 13, 32, 56, 253, DateTimeKind.Local).AddTicks(8165), new DateTime(2024, 4, 22, 13, 32, 56, 253, DateTimeKind.Local).AddTicks(8166) });

            migrationBuilder.CreateIndex(
                name: "IX_TiposProdutos_DescricaoTipoProduto",
                table: "TiposProdutos",
                column: "DescricaoTipoProduto",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TiposProdutos_DescricaoTipoProduto",
                table: "TiposProdutos");

            migrationBuilder.DeleteData(
                table: "CategoriasProdutos",
                keyColumn: "Id",
                keyValue: new Guid("c76ca727-7dc3-46c0-ae0f-c90b4aaf02b3"));

            migrationBuilder.DeleteData(
                table: "CategoriasProdutos",
                keyColumn: "Id",
                keyValue: new Guid("e552f739-e542-45f8-a8b9-e22ca88ac6f8"));

            migrationBuilder.AlterColumn<string>(
                name: "DescricaoTipoProduto",
                table: "TiposProdutos",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(30)",
                oldMaxLength: 30)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "CategoriasProdutos",
                keyColumn: "Id",
                keyValue: new Guid("6fb282e9-6ee8-44d9-a049-994f68bd0b27"),
                column: "CreateAt",
                value: new DateTime(2024, 4, 20, 18, 46, 49, 933, DateTimeKind.Local).AddTicks(5306));

            migrationBuilder.InsertData(
                table: "CategoriasProdutos",
                columns: new[] { "Id", "CreateAt", "DescricaoCategoria", "Habilitado", "UpdateAt" },
                values: new object[,]
                {
                    { new Guid("073d8c55-0371-4b57-8f01-d84ddd938b9d"), new DateTime(2024, 4, 20, 18, 46, 49, 933, DateTimeKind.Local).AddTicks(5387), "Executivos", true, null },
                    { new Guid("dfcac7ec-bc48-4521-a2b4-e4270292d3e4"), new DateTime(2024, 4, 20, 18, 46, 49, 933, DateTimeKind.Local).AddTicks(5346), "Promoções", true, null }
                });

            migrationBuilder.UpdateData(
                table: "FormasPagamentos",
                keyColumn: "Id",
                keyValue: new Guid("18e68a14-54b5-44b6-87ed-e8b0258d9c1d"),
                column: "CreateAt",
                value: new DateTime(2024, 4, 20, 18, 46, 49, 933, DateTimeKind.Local).AddTicks(5883));

            migrationBuilder.UpdateData(
                table: "FormasPagamentos",
                keyColumn: "Id",
                keyValue: new Guid("249c0c31-ee8e-487b-b4c9-1f14ced84553"),
                column: "CreateAt",
                value: new DateTime(2024, 4, 20, 18, 46, 49, 933, DateTimeKind.Local).AddTicks(5879));

            migrationBuilder.UpdateData(
                table: "FormasPagamentos",
                keyColumn: "Id",
                keyValue: new Guid("46152359-216e-4b2e-827c-411092ecc423"),
                column: "CreateAt",
                value: new DateTime(2024, 4, 20, 18, 46, 49, 933, DateTimeKind.Local).AddTicks(5892));

            migrationBuilder.UpdateData(
                table: "FormasPagamentos",
                keyColumn: "Id",
                keyValue: new Guid("7aaecde9-7290-48e7-bf31-f8dab886381f"),
                column: "CreateAt",
                value: new DateTime(2024, 4, 20, 18, 46, 49, 933, DateTimeKind.Local).AddTicks(5906));

            migrationBuilder.UpdateData(
                table: "FormasPagamentos",
                keyColumn: "Id",
                keyValue: new Guid("935f9721-bcc2-4239-88a1-2e0c9b1a75f6"),
                column: "CreateAt",
                value: new DateTime(2024, 4, 20, 18, 46, 49, 933, DateTimeKind.Local).AddTicks(5900));

            migrationBuilder.UpdateData(
                table: "FormasPagamentos",
                keyColumn: "Id",
                keyValue: new Guid("ac336bfb-39eb-4da0-9b04-c159f0068676"),
                column: "CreateAt",
                value: new DateTime(2024, 4, 20, 18, 46, 49, 933, DateTimeKind.Local).AddTicks(5887));

            migrationBuilder.UpdateData(
                table: "FormasPagamentos",
                keyColumn: "Id",
                keyValue: new Guid("cdd1b70b-5c96-472e-a983-3abdcc318c53"),
                column: "CreateAt",
                value: new DateTime(2024, 4, 20, 18, 46, 49, 933, DateTimeKind.Local).AddTicks(5895));

            migrationBuilder.UpdateData(
                table: "FormasPagamentos",
                keyColumn: "Id",
                keyValue: new Guid("d276bcd0-e552-46d4-af7a-390a3af0eb37"),
                column: "CreateAt",
                value: new DateTime(2024, 4, 20, 18, 46, 49, 933, DateTimeKind.Local).AddTicks(5890));

            migrationBuilder.UpdateData(
                table: "FormasPagamentos",
                keyColumn: "Id",
                keyValue: new Guid("e93ceba1-40f8-4420-8dc3-bb1b3ee6ee9f"),
                column: "CreateAt",
                value: new DateTime(2024, 4, 20, 18, 46, 49, 933, DateTimeKind.Local).AddTicks(5903));

            migrationBuilder.UpdateData(
                table: "PessoasTipos",
                keyColumn: "Id",
                keyValue: new Guid("2cc73259-4063-4f20-9c21-34ff2a9cbd58"),
                column: "CreateAt",
                value: new DateTime(2024, 4, 20, 18, 46, 49, 933, DateTimeKind.Local).AddTicks(5957));

            migrationBuilder.UpdateData(
                table: "PessoasTipos",
                keyColumn: "Id",
                keyValue: new Guid("a58b678c-07d4-417b-929b-600dc63858ea"),
                column: "CreateAt",
                value: new DateTime(2024, 4, 20, 18, 46, 49, 933, DateTimeKind.Local).AddTicks(5953));

            migrationBuilder.UpdateData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: new Guid("d2a0c172-e742-4e54-a806-938ddaaf8edb"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 20, 18, 46, 49, 933, DateTimeKind.Local).AddTicks(5828), new DateTime(2024, 4, 20, 18, 46, 49, 933, DateTimeKind.Local).AddTicks(5838) });

            migrationBuilder.UpdateData(
                table: "ProdutosMedidas",
                keyColumn: "Id",
                keyValue: new Guid("05b3382d-0940-446a-8c2c-3e27293cf77d"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 20, 18, 46, 49, 933, DateTimeKind.Local).AddTicks(6001), new DateTime(2024, 4, 20, 18, 46, 49, 933, DateTimeKind.Local).AddTicks(6002) });

            migrationBuilder.UpdateData(
                table: "ProdutosMedidas",
                keyColumn: "Id",
                keyValue: new Guid("9bbe9cc9-ba40-4bb3-9b71-74a8234133a5"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 20, 18, 46, 49, 933, DateTimeKind.Local).AddTicks(5996), new DateTime(2024, 4, 20, 18, 46, 49, 933, DateTimeKind.Local).AddTicks(5999) });

            migrationBuilder.UpdateData(
                table: "ProdutosMedidas",
                keyColumn: "Id",
                keyValue: new Guid("cc8119c5-7651-4708-bba4-8f350726bdac"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 20, 18, 46, 49, 933, DateTimeKind.Local).AddTicks(5991), new DateTime(2024, 4, 20, 18, 46, 49, 933, DateTimeKind.Local).AddTicks(5993) });

            migrationBuilder.UpdateData(
                table: "TiposProdutos",
                keyColumn: "Id",
                keyValue: new Guid("2491c7e2-10ec-48a4-8898-44e24814f23d"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 20, 18, 46, 49, 933, DateTimeKind.Local).AddTicks(6037), new DateTime(2024, 4, 20, 18, 46, 49, 933, DateTimeKind.Local).AddTicks(6038) });

            migrationBuilder.UpdateData(
                table: "TiposProdutos",
                keyColumn: "Id",
                keyValue: new Guid("3cca7caf-8a98-40b2-9f20-3f864f59e1c5"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 20, 18, 46, 49, 933, DateTimeKind.Local).AddTicks(6042), new DateTime(2024, 4, 20, 18, 46, 49, 933, DateTimeKind.Local).AddTicks(6043) });

            migrationBuilder.UpdateData(
                table: "TiposProdutos",
                keyColumn: "Id",
                keyValue: new Guid("59de4011-1ca7-4a52-833c-9672a03320ac"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 20, 18, 46, 49, 933, DateTimeKind.Local).AddTicks(6045), new DateTime(2024, 4, 20, 18, 46, 49, 933, DateTimeKind.Local).AddTicks(6046) });
        }
    }
}
