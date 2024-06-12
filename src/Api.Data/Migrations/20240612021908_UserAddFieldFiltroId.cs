using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class UserAddFieldFiltroId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "FiltroId",
                table: "AspNetUsers",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.UpdateData(
                table: "CategoriasPrecos",
                keyColumn: "Id",
                keyValue: new Guid("5533b87c-72d5-4033-85c4-ae44f5a3210c"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 11, 23, 19, 7, 828, DateTimeKind.Local).AddTicks(3334), new DateTime(2024, 6, 11, 23, 19, 7, 828, DateTimeKind.Local).AddTicks(3336) });

            migrationBuilder.UpdateData(
                table: "CategoriasPrecos",
                keyColumn: "Id",
                keyValue: new Guid("710bd8dd-1853-43a1-8708-ca1f259d71ad"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 11, 23, 19, 7, 828, DateTimeKind.Local).AddTicks(3323), new DateTime(2024, 6, 11, 23, 19, 7, 828, DateTimeKind.Local).AddTicks(3333) });

            migrationBuilder.UpdateData(
                table: "CategoriasPrecos",
                keyColumn: "Id",
                keyValue: new Guid("ed65a4e3-a0b0-40a7-b7ae-3397a965d924"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 11, 23, 19, 7, 828, DateTimeKind.Local).AddTicks(3338), new DateTime(2024, 6, 11, 23, 19, 7, 828, DateTimeKind.Local).AddTicks(3339) });

            migrationBuilder.UpdateData(
                table: "CategoriasProdutos",
                keyColumn: "Id",
                keyValue: new Guid("a9b05f16-71f0-4f77-a653-52c1a15b36bc"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 12, 2, 19, 7, 827, DateTimeKind.Utc).AddTicks(658), new DateTime(2024, 6, 12, 2, 19, 7, 827, DateTimeKind.Utc).AddTicks(655) });

            migrationBuilder.UpdateData(
                table: "CategoriasProdutos",
                keyColumn: "Id",
                keyValue: new Guid("d9d229c4-9a64-4836-af41-2f111f229c46"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 12, 2, 19, 7, 827, DateTimeKind.Utc).AddTicks(679), new DateTime(2024, 6, 12, 2, 19, 7, 827, DateTimeKind.Utc).AddTicks(679) });

            migrationBuilder.UpdateData(
                table: "FormasPagamentos",
                keyColumn: "Id",
                keyValue: new Guid("92008957-f185-4563-9d9e-7b71f4ea2691"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 11, 23, 19, 7, 832, DateTimeKind.Local).AddTicks(8843), new DateTime(2024, 6, 11, 23, 19, 7, 832, DateTimeKind.Local).AddTicks(8877) });

            migrationBuilder.UpdateData(
                table: "PeriodosPontosVendas",
                keyColumn: "Id",
                keyValue: new Guid("567906bb-6eb4-42e9-b890-10e6da214766"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 11, 23, 19, 7, 828, DateTimeKind.Local).AddTicks(2159), new DateTime(2024, 6, 11, 23, 19, 7, 828, DateTimeKind.Local).AddTicks(2165) });

            migrationBuilder.UpdateData(
                table: "PeriodosPontosVendas",
                keyColumn: "Id",
                keyValue: new Guid("7e107de8-c97a-435b-9976-7a689ca28bb7"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 11, 23, 19, 7, 828, DateTimeKind.Local).AddTicks(2178), new DateTime(2024, 6, 11, 23, 19, 7, 828, DateTimeKind.Local).AddTicks(2179) });

            migrationBuilder.UpdateData(
                table: "PeriodosPontosVendas",
                keyColumn: "Id",
                keyValue: new Guid("f14c83df-1fa4-4a83-8070-b16ecb19aa77"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 11, 23, 19, 7, 828, DateTimeKind.Local).AddTicks(2175), new DateTime(2024, 6, 11, 23, 19, 7, 828, DateTimeKind.Local).AddTicks(2176) });

            migrationBuilder.UpdateData(
                table: "PeriodosPontosVendas",
                keyColumn: "Id",
                keyValue: new Guid("fc6a5d67-8356-4270-b9e6-7749b553dcf3"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 11, 23, 19, 7, 828, DateTimeKind.Local).AddTicks(2172), new DateTime(2024, 6, 11, 23, 19, 7, 828, DateTimeKind.Local).AddTicks(2173) });

            migrationBuilder.UpdateData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: new Guid("f0e75a80-0b64-4b2b-9f53-f3dce3f6d126"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 11, 23, 19, 7, 827, DateTimeKind.Local).AddTicks(9987), new DateTime(2024, 6, 11, 23, 19, 7, 828, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "ProdutosMedidas",
                keyColumn: "Id",
                keyValue: new Guid("2f943e86-f06f-4f7d-babf-48d0d2d8f3ac"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 12, 2, 19, 7, 827, DateTimeKind.Utc).AddTicks(3009), new DateTime(2024, 6, 12, 2, 19, 7, 827, DateTimeKind.Utc).AddTicks(3008) });

            migrationBuilder.UpdateData(
                table: "ProdutosMedidas",
                keyColumn: "Id",
                keyValue: new Guid("414a646f-1146-4b6d-bbfc-39a26e74a091"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 12, 2, 19, 7, 827, DateTimeKind.Utc).AddTicks(3001), new DateTime(2024, 6, 12, 2, 19, 7, 827, DateTimeKind.Utc).AddTicks(3000) });

            migrationBuilder.UpdateData(
                table: "SituacoesPedidos",
                keyColumn: "Id",
                keyValue: new Guid("11b17cc5-c8b1-48f9-b9fd-886339441328"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 11, 23, 19, 7, 832, DateTimeKind.Local).AddTicks(9730), new DateTime(2024, 6, 11, 23, 19, 7, 832, DateTimeKind.Local).AddTicks(9731) });

            migrationBuilder.UpdateData(
                table: "SituacoesPedidos",
                keyColumn: "Id",
                keyValue: new Guid("185b07da-7e82-43d1-b61f-912d8b29a34c"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 11, 23, 19, 7, 832, DateTimeKind.Local).AddTicks(9727), new DateTime(2024, 6, 11, 23, 19, 7, 832, DateTimeKind.Local).AddTicks(9728) });

            migrationBuilder.UpdateData(
                table: "SituacoesPedidos",
                keyColumn: "Id",
                keyValue: new Guid("abc0f0f9-3295-439c-a468-795b071b7f22"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 11, 23, 19, 7, 832, DateTimeKind.Local).AddTicks(9720), new DateTime(2024, 6, 11, 23, 19, 7, 832, DateTimeKind.Local).AddTicks(9724) });

            migrationBuilder.UpdateData(
                table: "TiposProdutos",
                keyColumn: "Id",
                keyValue: new Guid("1e11b25a-8bf5-4d57-80b7-396d09cbfcf1"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 12, 2, 19, 7, 827, DateTimeKind.Utc).AddTicks(2049), new DateTime(2024, 6, 12, 2, 19, 7, 827, DateTimeKind.Utc).AddTicks(2051) });

            migrationBuilder.UpdateData(
                table: "TiposProdutos",
                keyColumn: "Id",
                keyValue: new Guid("edddccfa-a4af-4831-b9ee-29bdd5f755af"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 12, 2, 19, 7, 827, DateTimeKind.Utc).AddTicks(2040), new DateTime(2024, 6, 12, 2, 19, 7, 827, DateTimeKind.Utc).AddTicks(2047) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FiltroId",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "CategoriasPrecos",
                keyColumn: "Id",
                keyValue: new Guid("5533b87c-72d5-4033-85c4-ae44f5a3210c"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 10, 2, 56, 2, 577, DateTimeKind.Local).AddTicks(6237), new DateTime(2024, 6, 10, 2, 56, 2, 577, DateTimeKind.Local).AddTicks(6240) });

            migrationBuilder.UpdateData(
                table: "CategoriasPrecos",
                keyColumn: "Id",
                keyValue: new Guid("710bd8dd-1853-43a1-8708-ca1f259d71ad"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 10, 2, 56, 2, 577, DateTimeKind.Local).AddTicks(6217), new DateTime(2024, 6, 10, 2, 56, 2, 577, DateTimeKind.Local).AddTicks(6234) });

            migrationBuilder.UpdateData(
                table: "CategoriasPrecos",
                keyColumn: "Id",
                keyValue: new Guid("ed65a4e3-a0b0-40a7-b7ae-3397a965d924"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 10, 2, 56, 2, 577, DateTimeKind.Local).AddTicks(6242), new DateTime(2024, 6, 10, 2, 56, 2, 577, DateTimeKind.Local).AddTicks(6245) });

            migrationBuilder.UpdateData(
                table: "CategoriasProdutos",
                keyColumn: "Id",
                keyValue: new Guid("a9b05f16-71f0-4f77-a653-52c1a15b36bc"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 10, 5, 56, 2, 574, DateTimeKind.Utc).AddTicks(7040), new DateTime(2024, 6, 10, 5, 56, 2, 574, DateTimeKind.Utc).AddTicks(7035) });

            migrationBuilder.UpdateData(
                table: "CategoriasProdutos",
                keyColumn: "Id",
                keyValue: new Guid("d9d229c4-9a64-4836-af41-2f111f229c46"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 10, 5, 56, 2, 574, DateTimeKind.Utc).AddTicks(7073), new DateTime(2024, 6, 10, 5, 56, 2, 574, DateTimeKind.Utc).AddTicks(7070) });

            migrationBuilder.UpdateData(
                table: "FormasPagamentos",
                keyColumn: "Id",
                keyValue: new Guid("92008957-f185-4563-9d9e-7b71f4ea2691"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 10, 2, 56, 2, 587, DateTimeKind.Local).AddTicks(5262), new DateTime(2024, 6, 10, 2, 56, 2, 587, DateTimeKind.Local).AddTicks(5338) });

            migrationBuilder.UpdateData(
                table: "PeriodosPontosVendas",
                keyColumn: "Id",
                keyValue: new Guid("567906bb-6eb4-42e9-b890-10e6da214766"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 10, 2, 56, 2, 577, DateTimeKind.Local).AddTicks(4480), new DateTime(2024, 6, 10, 2, 56, 2, 577, DateTimeKind.Local).AddTicks(4491) });

            migrationBuilder.UpdateData(
                table: "PeriodosPontosVendas",
                keyColumn: "Id",
                keyValue: new Guid("7e107de8-c97a-435b-9976-7a689ca28bb7"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 10, 2, 56, 2, 577, DateTimeKind.Local).AddTicks(4504), new DateTime(2024, 6, 10, 2, 56, 2, 577, DateTimeKind.Local).AddTicks(4506) });

            migrationBuilder.UpdateData(
                table: "PeriodosPontosVendas",
                keyColumn: "Id",
                keyValue: new Guid("f14c83df-1fa4-4a83-8070-b16ecb19aa77"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 10, 2, 56, 2, 577, DateTimeKind.Local).AddTicks(4500), new DateTime(2024, 6, 10, 2, 56, 2, 577, DateTimeKind.Local).AddTicks(4501) });

            migrationBuilder.UpdateData(
                table: "PeriodosPontosVendas",
                keyColumn: "Id",
                keyValue: new Guid("fc6a5d67-8356-4270-b9e6-7749b553dcf3"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 10, 2, 56, 2, 577, DateTimeKind.Local).AddTicks(4495), new DateTime(2024, 6, 10, 2, 56, 2, 577, DateTimeKind.Local).AddTicks(4497) });

            migrationBuilder.UpdateData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: new Guid("f0e75a80-0b64-4b2b-9f53-f3dce3f6d126"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 10, 2, 56, 2, 577, DateTimeKind.Local).AddTicks(1102), new DateTime(2024, 6, 10, 2, 56, 2, 577, DateTimeKind.Local).AddTicks(1279) });

            migrationBuilder.UpdateData(
                table: "ProdutosMedidas",
                keyColumn: "Id",
                keyValue: new Guid("2f943e86-f06f-4f7d-babf-48d0d2d8f3ac"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 10, 5, 56, 2, 575, DateTimeKind.Utc).AddTicks(3159), new DateTime(2024, 6, 10, 5, 56, 2, 575, DateTimeKind.Utc).AddTicks(3158) });

            migrationBuilder.UpdateData(
                table: "ProdutosMedidas",
                keyColumn: "Id",
                keyValue: new Guid("414a646f-1146-4b6d-bbfc-39a26e74a091"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 10, 5, 56, 2, 575, DateTimeKind.Utc).AddTicks(3135), new DateTime(2024, 6, 10, 5, 56, 2, 575, DateTimeKind.Utc).AddTicks(3130) });

            migrationBuilder.UpdateData(
                table: "SituacoesPedidos",
                keyColumn: "Id",
                keyValue: new Guid("11b17cc5-c8b1-48f9-b9fd-886339441328"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 10, 2, 56, 2, 587, DateTimeKind.Local).AddTicks(6481), new DateTime(2024, 6, 10, 2, 56, 2, 587, DateTimeKind.Local).AddTicks(6482) });

            migrationBuilder.UpdateData(
                table: "SituacoesPedidos",
                keyColumn: "Id",
                keyValue: new Guid("185b07da-7e82-43d1-b61f-912d8b29a34c"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 10, 2, 56, 2, 587, DateTimeKind.Local).AddTicks(6476), new DateTime(2024, 6, 10, 2, 56, 2, 587, DateTimeKind.Local).AddTicks(6477) });

            migrationBuilder.UpdateData(
                table: "SituacoesPedidos",
                keyColumn: "Id",
                keyValue: new Guid("abc0f0f9-3295-439c-a468-795b071b7f22"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 10, 2, 56, 2, 587, DateTimeKind.Local).AddTicks(6467), new DateTime(2024, 6, 10, 2, 56, 2, 587, DateTimeKind.Local).AddTicks(6471) });

            migrationBuilder.UpdateData(
                table: "TiposProdutos",
                keyColumn: "Id",
                keyValue: new Guid("1e11b25a-8bf5-4d57-80b7-396d09cbfcf1"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 10, 5, 56, 2, 575, DateTimeKind.Utc).AddTicks(43), new DateTime(2024, 6, 10, 5, 56, 2, 575, DateTimeKind.Utc).AddTicks(45) });

            migrationBuilder.UpdateData(
                table: "TiposProdutos",
                keyColumn: "Id",
                keyValue: new Guid("edddccfa-a4af-4831-b9ee-29bdd5f755af"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 10, 5, 56, 2, 575, DateTimeKind.Utc).AddTicks(18), new DateTime(2024, 6, 10, 5, 56, 2, 575, DateTimeKind.Utc).AddTicks(41) });
        }
    }
}
