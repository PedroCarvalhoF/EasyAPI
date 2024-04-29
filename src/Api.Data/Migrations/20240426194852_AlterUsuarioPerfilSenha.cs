using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class AlterUsuarioPerfilSenha : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ConfirmarSenha",
                table: "PerfilsUsuarios",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Senha",
                table: "PerfilsUsuarios",
                type: "varchar(255)",
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

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
                name: "IX_PerfilsUsuarios_IdentityId",
                table: "PerfilsUsuarios",
                column: "IdentityId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PerfilsUsuarios_Senha",
                table: "PerfilsUsuarios",
                column: "Senha",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PerfilsUsuarios_IdentityId",
                table: "PerfilsUsuarios");

            migrationBuilder.DropIndex(
                name: "IX_PerfilsUsuarios_Senha",
                table: "PerfilsUsuarios");

            migrationBuilder.DropColumn(
                name: "ConfirmarSenha",
                table: "PerfilsUsuarios");

            migrationBuilder.DropColumn(
                name: "Senha",
                table: "PerfilsUsuarios");

            migrationBuilder.UpdateData(
                table: "CategoriasPrecos",
                keyColumn: "Id",
                keyValue: new Guid("5533b87c-72d5-4033-85c4-ae44f5a3210c"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 26, 16, 12, 23, 482, DateTimeKind.Local).AddTicks(1317), new DateTime(2024, 4, 26, 16, 12, 23, 482, DateTimeKind.Local).AddTicks(1319) });

            migrationBuilder.UpdateData(
                table: "CategoriasPrecos",
                keyColumn: "Id",
                keyValue: new Guid("710bd8dd-1853-43a1-8708-ca1f259d71ad"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 26, 16, 12, 23, 482, DateTimeKind.Local).AddTicks(1303), new DateTime(2024, 4, 26, 16, 12, 23, 482, DateTimeKind.Local).AddTicks(1314) });

            migrationBuilder.UpdateData(
                table: "CategoriasPrecos",
                keyColumn: "Id",
                keyValue: new Guid("ed65a4e3-a0b0-40a7-b7ae-3397a965d924"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 26, 16, 12, 23, 482, DateTimeKind.Local).AddTicks(1321), new DateTime(2024, 4, 26, 16, 12, 23, 482, DateTimeKind.Local).AddTicks(1324) });

            migrationBuilder.UpdateData(
                table: "CategoriasProdutos",
                keyColumn: "Id",
                keyValue: new Guid("a9b05f16-71f0-4f77-a653-52c1a15b36bc"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 26, 19, 12, 23, 480, DateTimeKind.Utc).AddTicks(6857), new DateTime(2024, 4, 26, 19, 12, 23, 480, DateTimeKind.Utc).AddTicks(6852) });

            migrationBuilder.UpdateData(
                table: "CategoriasProdutos",
                keyColumn: "Id",
                keyValue: new Guid("d9d229c4-9a64-4836-af41-2f111f229c46"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 26, 19, 12, 23, 480, DateTimeKind.Utc).AddTicks(6885), new DateTime(2024, 4, 26, 19, 12, 23, 480, DateTimeKind.Utc).AddTicks(6884) });

            migrationBuilder.UpdateData(
                table: "PeriodosPontosVendas",
                keyColumn: "Id",
                keyValue: new Guid("567906bb-6eb4-42e9-b890-10e6da214766"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 26, 16, 12, 23, 481, DateTimeKind.Local).AddTicks(9813), new DateTime(2024, 4, 26, 16, 12, 23, 481, DateTimeKind.Local).AddTicks(9821) });

            migrationBuilder.UpdateData(
                table: "PeriodosPontosVendas",
                keyColumn: "Id",
                keyValue: new Guid("7e107de8-c97a-435b-9976-7a689ca28bb7"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 26, 16, 12, 23, 481, DateTimeKind.Local).AddTicks(9834), new DateTime(2024, 4, 26, 16, 12, 23, 481, DateTimeKind.Local).AddTicks(9835) });

            migrationBuilder.UpdateData(
                table: "PeriodosPontosVendas",
                keyColumn: "Id",
                keyValue: new Guid("f14c83df-1fa4-4a83-8070-b16ecb19aa77"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 26, 16, 12, 23, 481, DateTimeKind.Local).AddTicks(9830), new DateTime(2024, 4, 26, 16, 12, 23, 481, DateTimeKind.Local).AddTicks(9832) });

            migrationBuilder.UpdateData(
                table: "PeriodosPontosVendas",
                keyColumn: "Id",
                keyValue: new Guid("fc6a5d67-8356-4270-b9e6-7749b553dcf3"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 26, 16, 12, 23, 481, DateTimeKind.Local).AddTicks(9825), new DateTime(2024, 4, 26, 16, 12, 23, 481, DateTimeKind.Local).AddTicks(9827) });

            migrationBuilder.UpdateData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: new Guid("f0e75a80-0b64-4b2b-9f53-f3dce3f6d126"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 26, 16, 12, 23, 481, DateTimeKind.Local).AddTicks(8630), new DateTime(2024, 4, 26, 16, 12, 23, 481, DateTimeKind.Local).AddTicks(8644) });

            migrationBuilder.UpdateData(
                table: "ProdutosMedidas",
                keyColumn: "Id",
                keyValue: new Guid("2f943e86-f06f-4f7d-babf-48d0d2d8f3ac"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 26, 19, 12, 23, 480, DateTimeKind.Utc).AddTicks(9544), new DateTime(2024, 4, 26, 19, 12, 23, 480, DateTimeKind.Utc).AddTicks(9544) });

            migrationBuilder.UpdateData(
                table: "ProdutosMedidas",
                keyColumn: "Id",
                keyValue: new Guid("414a646f-1146-4b6d-bbfc-39a26e74a091"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 26, 19, 12, 23, 480, DateTimeKind.Utc).AddTicks(9532), new DateTime(2024, 4, 26, 19, 12, 23, 480, DateTimeKind.Utc).AddTicks(9530) });

            migrationBuilder.UpdateData(
                table: "TiposProdutos",
                keyColumn: "Id",
                keyValue: new Guid("1e11b25a-8bf5-4d57-80b7-396d09cbfcf1"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 26, 19, 12, 23, 480, DateTimeKind.Utc).AddTicks(8494), new DateTime(2024, 4, 26, 19, 12, 23, 480, DateTimeKind.Utc).AddTicks(8497) });

            migrationBuilder.UpdateData(
                table: "TiposProdutos",
                keyColumn: "Id",
                keyValue: new Guid("edddccfa-a4af-4831-b9ee-29bdd5f755af"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 26, 19, 12, 23, 480, DateTimeKind.Utc).AddTicks(8484), new DateTime(2024, 4, 26, 19, 12, 23, 480, DateTimeKind.Utc).AddTicks(8492) });
        }
    }
}
