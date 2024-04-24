using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class BUG_CateogiraProdutoMAP : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CategoriasProdutos",
                keyColumn: "Id",
                keyValue: new Guid("45fda62b-ca78-4cc5-bf07-660b2feeae9a"));

            migrationBuilder.DeleteData(
                table: "CategoriasProdutos",
                keyColumn: "Id",
                keyValue: new Guid("9ec82e6b-d699-4cfc-bba0-354dcfd6ed6e"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateAt",
                table: "TiposProdutos",
                type: "datetime(6)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateAt",
                table: "SituacoesPedidos",
                type: "datetime(6)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateAt",
                table: "ProdutosMedidas",
                type: "datetime(6)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateAt",
                table: "Produtos",
                type: "datetime(6)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateAt",
                table: "PrecosProdutos",
                type: "datetime(6)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateAt",
                table: "PontosVendas",
                type: "datetime(6)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateAt",
                table: "PessoasTipos",
                type: "datetime(6)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateAt",
                table: "Pessoas",
                type: "datetime(6)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateAt",
                table: "Pedidos",
                type: "datetime(6)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateAt",
                table: "PagamentosPedidos",
                type: "datetime(6)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateAt",
                table: "ItensPedidos",
                type: "datetime(6)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateAt",
                table: "FormasPagamentos",
                type: "datetime(6)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateAt",
                table: "Filiais",
                type: "datetime(6)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<string>(
                name: "DescricaoCategoria",
                table: "CategoriasProdutos",
                type: "varchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(80)",
                oldMaxLength: 80)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateAt",
                table: "CategoriasProdutos",
                type: "datetime(6)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateAt",
                table: "CategoriasPrecos",
                type: "datetime(6)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

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
                columns: new[] { "CreateAt", "Habilitado" },
                values: new object[] { new DateTime(2024, 4, 20, 18, 46, 49, 933, DateTimeKind.Local).AddTicks(5957), false });

            migrationBuilder.UpdateData(
                table: "PessoasTipos",
                keyColumn: "Id",
                keyValue: new Guid("a58b678c-07d4-417b-929b-600dc63858ea"),
                columns: new[] { "CreateAt", "Habilitado" },
                values: new object[] { new DateTime(2024, 4, 20, 18, 46, 49, 933, DateTimeKind.Local).AddTicks(5953), false });

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

            migrationBuilder.CreateIndex(
                name: "IX_CategoriasProdutos_DescricaoCategoria",
                table: "CategoriasProdutos",
                column: "DescricaoCategoria",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CategoriasProdutos_DescricaoCategoria",
                table: "CategoriasProdutos");

            migrationBuilder.DeleteData(
                table: "CategoriasProdutos",
                keyColumn: "Id",
                keyValue: new Guid("073d8c55-0371-4b57-8f01-d84ddd938b9d"));

            migrationBuilder.DeleteData(
                table: "CategoriasProdutos",
                keyColumn: "Id",
                keyValue: new Guid("dfcac7ec-bc48-4521-a2b4-e4270292d3e4"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateAt",
                table: "TiposProdutos",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateAt",
                table: "SituacoesPedidos",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateAt",
                table: "ProdutosMedidas",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateAt",
                table: "Produtos",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateAt",
                table: "PrecosProdutos",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateAt",
                table: "PontosVendas",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateAt",
                table: "PessoasTipos",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateAt",
                table: "Pessoas",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateAt",
                table: "Pedidos",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateAt",
                table: "PagamentosPedidos",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateAt",
                table: "ItensPedidos",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateAt",
                table: "FormasPagamentos",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateAt",
                table: "Filiais",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DescricaoCategoria",
                table: "CategoriasProdutos",
                type: "varchar(80)",
                maxLength: 80,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldMaxLength: 20)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateAt",
                table: "CategoriasProdutos",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateAt",
                table: "CategoriasPrecos",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "CategoriasProdutos",
                keyColumn: "Id",
                keyValue: new Guid("6fb282e9-6ee8-44d9-a049-994f68bd0b27"),
                column: "CreateAt",
                value: new DateTime(2024, 4, 20, 13, 56, 58, 451, DateTimeKind.Local).AddTicks(6266));

            migrationBuilder.InsertData(
                table: "CategoriasProdutos",
                columns: new[] { "Id", "CreateAt", "DescricaoCategoria", "Habilitado", "UpdateAt" },
                values: new object[,]
                {
                    { new Guid("45fda62b-ca78-4cc5-bf07-660b2feeae9a"), new DateTime(2024, 4, 20, 13, 56, 58, 451, DateTimeKind.Local).AddTicks(6348), "Executivos", true, null },
                    { new Guid("9ec82e6b-d699-4cfc-bba0-354dcfd6ed6e"), new DateTime(2024, 4, 20, 13, 56, 58, 451, DateTimeKind.Local).AddTicks(6307), "Promoções", true, null }
                });

            migrationBuilder.UpdateData(
                table: "FormasPagamentos",
                keyColumn: "Id",
                keyValue: new Guid("18e68a14-54b5-44b6-87ed-e8b0258d9c1d"),
                column: "CreateAt",
                value: new DateTime(2024, 4, 20, 13, 56, 58, 451, DateTimeKind.Local).AddTicks(6604));

            migrationBuilder.UpdateData(
                table: "FormasPagamentos",
                keyColumn: "Id",
                keyValue: new Guid("249c0c31-ee8e-487b-b4c9-1f14ced84553"),
                column: "CreateAt",
                value: new DateTime(2024, 4, 20, 13, 56, 58, 451, DateTimeKind.Local).AddTicks(6601));

            migrationBuilder.UpdateData(
                table: "FormasPagamentos",
                keyColumn: "Id",
                keyValue: new Guid("46152359-216e-4b2e-827c-411092ecc423"),
                column: "CreateAt",
                value: new DateTime(2024, 4, 20, 13, 56, 58, 451, DateTimeKind.Local).AddTicks(6611));

            migrationBuilder.UpdateData(
                table: "FormasPagamentos",
                keyColumn: "Id",
                keyValue: new Guid("7aaecde9-7290-48e7-bf31-f8dab886381f"),
                column: "CreateAt",
                value: new DateTime(2024, 4, 20, 13, 56, 58, 451, DateTimeKind.Local).AddTicks(6620));

            migrationBuilder.UpdateData(
                table: "FormasPagamentos",
                keyColumn: "Id",
                keyValue: new Guid("935f9721-bcc2-4239-88a1-2e0c9b1a75f6"),
                column: "CreateAt",
                value: new DateTime(2024, 4, 20, 13, 56, 58, 451, DateTimeKind.Local).AddTicks(6616));

            migrationBuilder.UpdateData(
                table: "FormasPagamentos",
                keyColumn: "Id",
                keyValue: new Guid("ac336bfb-39eb-4da0-9b04-c159f0068676"),
                column: "CreateAt",
                value: new DateTime(2024, 4, 20, 13, 56, 58, 451, DateTimeKind.Local).AddTicks(6607));

            migrationBuilder.UpdateData(
                table: "FormasPagamentos",
                keyColumn: "Id",
                keyValue: new Guid("cdd1b70b-5c96-472e-a983-3abdcc318c53"),
                column: "CreateAt",
                value: new DateTime(2024, 4, 20, 13, 56, 58, 451, DateTimeKind.Local).AddTicks(6613));

            migrationBuilder.UpdateData(
                table: "FormasPagamentos",
                keyColumn: "Id",
                keyValue: new Guid("d276bcd0-e552-46d4-af7a-390a3af0eb37"),
                column: "CreateAt",
                value: new DateTime(2024, 4, 20, 13, 56, 58, 451, DateTimeKind.Local).AddTicks(6609));

            migrationBuilder.UpdateData(
                table: "FormasPagamentos",
                keyColumn: "Id",
                keyValue: new Guid("e93ceba1-40f8-4420-8dc3-bb1b3ee6ee9f"),
                column: "CreateAt",
                value: new DateTime(2024, 4, 20, 13, 56, 58, 451, DateTimeKind.Local).AddTicks(6618));

            migrationBuilder.UpdateData(
                table: "PessoasTipos",
                keyColumn: "Id",
                keyValue: new Guid("2cc73259-4063-4f20-9c21-34ff2a9cbd58"),
                columns: new[] { "CreateAt", "Habilitado" },
                values: new object[] { new DateTime(2024, 4, 20, 13, 56, 58, 451, DateTimeKind.Local).AddTicks(6652), true });

            migrationBuilder.UpdateData(
                table: "PessoasTipos",
                keyColumn: "Id",
                keyValue: new Guid("a58b678c-07d4-417b-929b-600dc63858ea"),
                columns: new[] { "CreateAt", "Habilitado" },
                values: new object[] { new DateTime(2024, 4, 20, 13, 56, 58, 451, DateTimeKind.Local).AddTicks(6650), true });

            migrationBuilder.UpdateData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: new Guid("d2a0c172-e742-4e54-a806-938ddaaf8edb"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 20, 13, 56, 58, 451, DateTimeKind.Local).AddTicks(6568), new DateTime(2024, 4, 20, 13, 56, 58, 451, DateTimeKind.Local).AddTicks(6576) });

            migrationBuilder.UpdateData(
                table: "ProdutosMedidas",
                keyColumn: "Id",
                keyValue: new Guid("05b3382d-0940-446a-8c2c-3e27293cf77d"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 20, 13, 56, 58, 451, DateTimeKind.Local).AddTicks(6694), new DateTime(2024, 4, 20, 13, 56, 58, 451, DateTimeKind.Local).AddTicks(6695) });

            migrationBuilder.UpdateData(
                table: "ProdutosMedidas",
                keyColumn: "Id",
                keyValue: new Guid("9bbe9cc9-ba40-4bb3-9b71-74a8234133a5"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 20, 13, 56, 58, 451, DateTimeKind.Local).AddTicks(6692), new DateTime(2024, 4, 20, 13, 56, 58, 451, DateTimeKind.Local).AddTicks(6692) });

            migrationBuilder.UpdateData(
                table: "ProdutosMedidas",
                keyColumn: "Id",
                keyValue: new Guid("cc8119c5-7651-4708-bba4-8f350726bdac"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 20, 13, 56, 58, 451, DateTimeKind.Local).AddTicks(6687), new DateTime(2024, 4, 20, 13, 56, 58, 451, DateTimeKind.Local).AddTicks(6688) });

            migrationBuilder.UpdateData(
                table: "TiposProdutos",
                keyColumn: "Id",
                keyValue: new Guid("2491c7e2-10ec-48a4-8898-44e24814f23d"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 20, 13, 56, 58, 451, DateTimeKind.Local).AddTicks(6721), new DateTime(2024, 4, 20, 13, 56, 58, 451, DateTimeKind.Local).AddTicks(6722) });

            migrationBuilder.UpdateData(
                table: "TiposProdutos",
                keyColumn: "Id",
                keyValue: new Guid("3cca7caf-8a98-40b2-9f20-3f864f59e1c5"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 20, 13, 56, 58, 451, DateTimeKind.Local).AddTicks(6725), new DateTime(2024, 4, 20, 13, 56, 58, 451, DateTimeKind.Local).AddTicks(6725) });

            migrationBuilder.UpdateData(
                table: "TiposProdutos",
                keyColumn: "Id",
                keyValue: new Guid("59de4011-1ca7-4a52-833c-9672a03320ac"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 20, 13, 56, 58, 451, DateTimeKind.Local).AddTicks(6727), new DateTime(2024, 4, 20, 13, 56, 58, 451, DateTimeKind.Local).AddTicks(6728) });
        }
    }
}
