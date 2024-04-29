using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class PerfilUsuarioRemoveFieldIdentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PerfilsUsuarios_IdentityId",
                table: "PerfilsUsuarios");

            migrationBuilder.UpdateData(
                table: "CategoriasPrecos",
                keyColumn: "Id",
                keyValue: new Guid("5533b87c-72d5-4033-85c4-ae44f5a3210c"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 28, 21, 3, 20, 87, DateTimeKind.Local).AddTicks(7351), new DateTime(2024, 4, 28, 21, 3, 20, 87, DateTimeKind.Local).AddTicks(7352) });

            migrationBuilder.UpdateData(
                table: "CategoriasPrecos",
                keyColumn: "Id",
                keyValue: new Guid("710bd8dd-1853-43a1-8708-ca1f259d71ad"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 28, 21, 3, 20, 87, DateTimeKind.Local).AddTicks(7342), new DateTime(2024, 4, 28, 21, 3, 20, 87, DateTimeKind.Local).AddTicks(7349) });

            migrationBuilder.UpdateData(
                table: "CategoriasPrecos",
                keyColumn: "Id",
                keyValue: new Guid("ed65a4e3-a0b0-40a7-b7ae-3397a965d924"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 28, 21, 3, 20, 87, DateTimeKind.Local).AddTicks(7353), new DateTime(2024, 4, 28, 21, 3, 20, 87, DateTimeKind.Local).AddTicks(7355) });

            migrationBuilder.UpdateData(
                table: "CategoriasProdutos",
                keyColumn: "Id",
                keyValue: new Guid("a9b05f16-71f0-4f77-a653-52c1a15b36bc"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 29, 0, 3, 20, 86, DateTimeKind.Utc).AddTicks(1638), new DateTime(2024, 4, 29, 0, 3, 20, 86, DateTimeKind.Utc).AddTicks(1632) });

            migrationBuilder.UpdateData(
                table: "CategoriasProdutos",
                keyColumn: "Id",
                keyValue: new Guid("d9d229c4-9a64-4836-af41-2f111f229c46"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 29, 0, 3, 20, 86, DateTimeKind.Utc).AddTicks(1672), new DateTime(2024, 4, 29, 0, 3, 20, 86, DateTimeKind.Utc).AddTicks(1672) });

            migrationBuilder.UpdateData(
                table: "PeriodosPontosVendas",
                keyColumn: "Id",
                keyValue: new Guid("567906bb-6eb4-42e9-b890-10e6da214766"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 28, 21, 3, 20, 87, DateTimeKind.Local).AddTicks(5999), new DateTime(2024, 4, 28, 21, 3, 20, 87, DateTimeKind.Local).AddTicks(6006) });

            migrationBuilder.UpdateData(
                table: "PeriodosPontosVendas",
                keyColumn: "Id",
                keyValue: new Guid("7e107de8-c97a-435b-9976-7a689ca28bb7"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 28, 21, 3, 20, 87, DateTimeKind.Local).AddTicks(6024), new DateTime(2024, 4, 28, 21, 3, 20, 87, DateTimeKind.Local).AddTicks(6025) });

            migrationBuilder.UpdateData(
                table: "PeriodosPontosVendas",
                keyColumn: "Id",
                keyValue: new Guid("f14c83df-1fa4-4a83-8070-b16ecb19aa77"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 28, 21, 3, 20, 87, DateTimeKind.Local).AddTicks(6012), new DateTime(2024, 4, 28, 21, 3, 20, 87, DateTimeKind.Local).AddTicks(6013) });

            migrationBuilder.UpdateData(
                table: "PeriodosPontosVendas",
                keyColumn: "Id",
                keyValue: new Guid("fc6a5d67-8356-4270-b9e6-7749b553dcf3"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 28, 21, 3, 20, 87, DateTimeKind.Local).AddTicks(6009), new DateTime(2024, 4, 28, 21, 3, 20, 87, DateTimeKind.Local).AddTicks(6010) });

            migrationBuilder.UpdateData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: new Guid("f0e75a80-0b64-4b2b-9f53-f3dce3f6d126"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 28, 21, 3, 20, 87, DateTimeKind.Local).AddTicks(4756), new DateTime(2024, 4, 28, 21, 3, 20, 87, DateTimeKind.Local).AddTicks(4778) });

            migrationBuilder.UpdateData(
                table: "ProdutosMedidas",
                keyColumn: "Id",
                keyValue: new Guid("2f943e86-f06f-4f7d-babf-48d0d2d8f3ac"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 29, 0, 3, 20, 86, DateTimeKind.Utc).AddTicks(6763), new DateTime(2024, 4, 29, 0, 3, 20, 86, DateTimeKind.Utc).AddTicks(6762) });

            migrationBuilder.UpdateData(
                table: "ProdutosMedidas",
                keyColumn: "Id",
                keyValue: new Guid("414a646f-1146-4b6d-bbfc-39a26e74a091"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 29, 0, 3, 20, 86, DateTimeKind.Utc).AddTicks(6749), new DateTime(2024, 4, 29, 0, 3, 20, 86, DateTimeKind.Utc).AddTicks(6745) });

            migrationBuilder.UpdateData(
                table: "TiposProdutos",
                keyColumn: "Id",
                keyValue: new Guid("1e11b25a-8bf5-4d57-80b7-396d09cbfcf1"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 29, 0, 3, 20, 86, DateTimeKind.Utc).AddTicks(4798), new DateTime(2024, 4, 29, 0, 3, 20, 86, DateTimeKind.Utc).AddTicks(4800) });

            migrationBuilder.UpdateData(
                table: "TiposProdutos",
                keyColumn: "Id",
                keyValue: new Guid("edddccfa-a4af-4831-b9ee-29bdd5f755af"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 29, 0, 3, 20, 86, DateTimeKind.Utc).AddTicks(4748), new DateTime(2024, 4, 29, 0, 3, 20, 86, DateTimeKind.Utc).AddTicks(4795) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "CategoriasPrecos",
                keyColumn: "Id",
                keyValue: new Guid("5533b87c-72d5-4033-85c4-ae44f5a3210c"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 28, 20, 16, 42, 500, DateTimeKind.Local).AddTicks(754), new DateTime(2024, 4, 28, 20, 16, 42, 500, DateTimeKind.Local).AddTicks(756) });

            migrationBuilder.UpdateData(
                table: "CategoriasPrecos",
                keyColumn: "Id",
                keyValue: new Guid("710bd8dd-1853-43a1-8708-ca1f259d71ad"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 28, 20, 16, 42, 500, DateTimeKind.Local).AddTicks(741), new DateTime(2024, 4, 28, 20, 16, 42, 500, DateTimeKind.Local).AddTicks(750) });

            migrationBuilder.UpdateData(
                table: "CategoriasPrecos",
                keyColumn: "Id",
                keyValue: new Guid("ed65a4e3-a0b0-40a7-b7ae-3397a965d924"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 28, 20, 16, 42, 500, DateTimeKind.Local).AddTicks(758), new DateTime(2024, 4, 28, 20, 16, 42, 500, DateTimeKind.Local).AddTicks(759) });

            migrationBuilder.UpdateData(
                table: "CategoriasProdutos",
                keyColumn: "Id",
                keyValue: new Guid("a9b05f16-71f0-4f77-a653-52c1a15b36bc"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 28, 23, 16, 42, 499, DateTimeKind.Utc).AddTicks(97), new DateTime(2024, 4, 28, 23, 16, 42, 499, DateTimeKind.Utc).AddTicks(93) });

            migrationBuilder.UpdateData(
                table: "CategoriasProdutos",
                keyColumn: "Id",
                keyValue: new Guid("d9d229c4-9a64-4836-af41-2f111f229c46"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 28, 23, 16, 42, 499, DateTimeKind.Utc).AddTicks(125), new DateTime(2024, 4, 28, 23, 16, 42, 499, DateTimeKind.Utc).AddTicks(123) });

            migrationBuilder.UpdateData(
                table: "PeriodosPontosVendas",
                keyColumn: "Id",
                keyValue: new Guid("567906bb-6eb4-42e9-b890-10e6da214766"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 28, 20, 16, 42, 499, DateTimeKind.Local).AddTicks(9696), new DateTime(2024, 4, 28, 20, 16, 42, 499, DateTimeKind.Local).AddTicks(9700) });

            migrationBuilder.UpdateData(
                table: "PeriodosPontosVendas",
                keyColumn: "Id",
                keyValue: new Guid("7e107de8-c97a-435b-9976-7a689ca28bb7"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 28, 20, 16, 42, 499, DateTimeKind.Local).AddTicks(9710), new DateTime(2024, 4, 28, 20, 16, 42, 499, DateTimeKind.Local).AddTicks(9711) });

            migrationBuilder.UpdateData(
                table: "PeriodosPontosVendas",
                keyColumn: "Id",
                keyValue: new Guid("f14c83df-1fa4-4a83-8070-b16ecb19aa77"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 28, 20, 16, 42, 499, DateTimeKind.Local).AddTicks(9707), new DateTime(2024, 4, 28, 20, 16, 42, 499, DateTimeKind.Local).AddTicks(9708) });

            migrationBuilder.UpdateData(
                table: "PeriodosPontosVendas",
                keyColumn: "Id",
                keyValue: new Guid("fc6a5d67-8356-4270-b9e6-7749b553dcf3"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 28, 20, 16, 42, 499, DateTimeKind.Local).AddTicks(9703), new DateTime(2024, 4, 28, 20, 16, 42, 499, DateTimeKind.Local).AddTicks(9704) });

            migrationBuilder.UpdateData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: new Guid("f0e75a80-0b64-4b2b-9f53-f3dce3f6d126"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 28, 20, 16, 42, 499, DateTimeKind.Local).AddTicks(8440), new DateTime(2024, 4, 28, 20, 16, 42, 499, DateTimeKind.Local).AddTicks(8453) });

            migrationBuilder.UpdateData(
                table: "ProdutosMedidas",
                keyColumn: "Id",
                keyValue: new Guid("2f943e86-f06f-4f7d-babf-48d0d2d8f3ac"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 28, 23, 16, 42, 499, DateTimeKind.Utc).AddTicks(2054), new DateTime(2024, 4, 28, 23, 16, 42, 499, DateTimeKind.Utc).AddTicks(2054) });

            migrationBuilder.UpdateData(
                table: "ProdutosMedidas",
                keyColumn: "Id",
                keyValue: new Guid("414a646f-1146-4b6d-bbfc-39a26e74a091"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 28, 23, 16, 42, 499, DateTimeKind.Utc).AddTicks(2048), new DateTime(2024, 4, 28, 23, 16, 42, 499, DateTimeKind.Utc).AddTicks(2047) });

            migrationBuilder.UpdateData(
                table: "TiposProdutos",
                keyColumn: "Id",
                keyValue: new Guid("1e11b25a-8bf5-4d57-80b7-396d09cbfcf1"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 28, 23, 16, 42, 499, DateTimeKind.Utc).AddTicks(1251), new DateTime(2024, 4, 28, 23, 16, 42, 499, DateTimeKind.Utc).AddTicks(1254) });

            migrationBuilder.UpdateData(
                table: "TiposProdutos",
                keyColumn: "Id",
                keyValue: new Guid("edddccfa-a4af-4831-b9ee-29bdd5f755af"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 28, 23, 16, 42, 499, DateTimeKind.Utc).AddTicks(1243), new DateTime(2024, 4, 28, 23, 16, 42, 499, DateTimeKind.Utc).AddTicks(1250) });

            migrationBuilder.CreateIndex(
                name: "IX_PerfilsUsuarios_IdentityId",
                table: "PerfilsUsuarios",
                column: "IdentityId",
                unique: true);
        }
    }
}
