using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class AlterPerfilUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PerfilsUsuarios_Senha",
                table: "PerfilsUsuarios");

            migrationBuilder.AlterColumn<string>(
                name: "Senha",
                table: "PerfilsUsuarios",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Senha",
                table: "PerfilsUsuarios",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "CategoriasPrecos",
                keyColumn: "Id",
                keyValue: new Guid("5533b87c-72d5-4033-85c4-ae44f5a3210c"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 26, 16, 48, 51, 717, DateTimeKind.Local).AddTicks(1621), new DateTime(2024, 4, 26, 16, 48, 51, 717, DateTimeKind.Local).AddTicks(1624) });

            migrationBuilder.UpdateData(
                table: "CategoriasPrecos",
                keyColumn: "Id",
                keyValue: new Guid("710bd8dd-1853-43a1-8708-ca1f259d71ad"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 26, 16, 48, 51, 717, DateTimeKind.Local).AddTicks(1612), new DateTime(2024, 4, 26, 16, 48, 51, 717, DateTimeKind.Local).AddTicks(1619) });

            migrationBuilder.UpdateData(
                table: "CategoriasPrecos",
                keyColumn: "Id",
                keyValue: new Guid("ed65a4e3-a0b0-40a7-b7ae-3397a965d924"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 26, 16, 48, 51, 717, DateTimeKind.Local).AddTicks(1626), new DateTime(2024, 4, 26, 16, 48, 51, 717, DateTimeKind.Local).AddTicks(1627) });

            migrationBuilder.UpdateData(
                table: "CategoriasProdutos",
                keyColumn: "Id",
                keyValue: new Guid("a9b05f16-71f0-4f77-a653-52c1a15b36bc"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 26, 19, 48, 51, 716, DateTimeKind.Utc).AddTicks(1748), new DateTime(2024, 4, 26, 19, 48, 51, 716, DateTimeKind.Utc).AddTicks(1745) });

            migrationBuilder.UpdateData(
                table: "CategoriasProdutos",
                keyColumn: "Id",
                keyValue: new Guid("d9d229c4-9a64-4836-af41-2f111f229c46"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 26, 19, 48, 51, 716, DateTimeKind.Utc).AddTicks(1774), new DateTime(2024, 4, 26, 19, 48, 51, 716, DateTimeKind.Utc).AddTicks(1773) });

            migrationBuilder.UpdateData(
                table: "PeriodosPontosVendas",
                keyColumn: "Id",
                keyValue: new Guid("567906bb-6eb4-42e9-b890-10e6da214766"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 26, 16, 48, 51, 717, DateTimeKind.Local).AddTicks(579), new DateTime(2024, 4, 26, 16, 48, 51, 717, DateTimeKind.Local).AddTicks(583) });

            migrationBuilder.UpdateData(
                table: "PeriodosPontosVendas",
                keyColumn: "Id",
                keyValue: new Guid("7e107de8-c97a-435b-9976-7a689ca28bb7"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 26, 16, 48, 51, 717, DateTimeKind.Local).AddTicks(598), new DateTime(2024, 4, 26, 16, 48, 51, 717, DateTimeKind.Local).AddTicks(599) });

            migrationBuilder.UpdateData(
                table: "PeriodosPontosVendas",
                keyColumn: "Id",
                keyValue: new Guid("f14c83df-1fa4-4a83-8070-b16ecb19aa77"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 26, 16, 48, 51, 717, DateTimeKind.Local).AddTicks(594), new DateTime(2024, 4, 26, 16, 48, 51, 717, DateTimeKind.Local).AddTicks(595) });

            migrationBuilder.UpdateData(
                table: "PeriodosPontosVendas",
                keyColumn: "Id",
                keyValue: new Guid("fc6a5d67-8356-4270-b9e6-7749b553dcf3"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 26, 16, 48, 51, 717, DateTimeKind.Local).AddTicks(586), new DateTime(2024, 4, 26, 16, 48, 51, 717, DateTimeKind.Local).AddTicks(587) });

            migrationBuilder.UpdateData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: new Guid("f0e75a80-0b64-4b2b-9f53-f3dce3f6d126"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 26, 16, 48, 51, 716, DateTimeKind.Local).AddTicks(9774), new DateTime(2024, 4, 26, 16, 48, 51, 716, DateTimeKind.Local).AddTicks(9788) });

            migrationBuilder.UpdateData(
                table: "ProdutosMedidas",
                keyColumn: "Id",
                keyValue: new Guid("2f943e86-f06f-4f7d-babf-48d0d2d8f3ac"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 26, 19, 48, 51, 716, DateTimeKind.Utc).AddTicks(3544), new DateTime(2024, 4, 26, 19, 48, 51, 716, DateTimeKind.Utc).AddTicks(3544) });

            migrationBuilder.UpdateData(
                table: "ProdutosMedidas",
                keyColumn: "Id",
                keyValue: new Guid("414a646f-1146-4b6d-bbfc-39a26e74a091"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 26, 19, 48, 51, 716, DateTimeKind.Utc).AddTicks(3537), new DateTime(2024, 4, 26, 19, 48, 51, 716, DateTimeKind.Utc).AddTicks(3536) });

            migrationBuilder.UpdateData(
                table: "TiposProdutos",
                keyColumn: "Id",
                keyValue: new Guid("1e11b25a-8bf5-4d57-80b7-396d09cbfcf1"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 26, 19, 48, 51, 716, DateTimeKind.Utc).AddTicks(2824), new DateTime(2024, 4, 26, 19, 48, 51, 716, DateTimeKind.Utc).AddTicks(2825) });

            migrationBuilder.UpdateData(
                table: "TiposProdutos",
                keyColumn: "Id",
                keyValue: new Guid("edddccfa-a4af-4831-b9ee-29bdd5f755af"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 26, 19, 48, 51, 716, DateTimeKind.Utc).AddTicks(2815), new DateTime(2024, 4, 26, 19, 48, 51, 716, DateTimeKind.Utc).AddTicks(2822) });

            migrationBuilder.CreateIndex(
                name: "IX_PerfilsUsuarios_Senha",
                table: "PerfilsUsuarios",
                column: "Senha",
                unique: true);
        }
    }
}
