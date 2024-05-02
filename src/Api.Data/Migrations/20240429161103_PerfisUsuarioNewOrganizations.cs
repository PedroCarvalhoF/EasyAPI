using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class PerfisUsuarioNewOrganizations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PerfilsUsuarios",
                table: "PerfilsUsuarios");

            migrationBuilder.DropColumn(
                name: "Senha",
                table: "PerfilsUsuarios");

            migrationBuilder.RenameTable(
                name: "PerfilsUsuarios",
                newName: "PerfisUsuarios");

            migrationBuilder.RenameIndex(
                name: "IX_PerfilsUsuarios_Nome",
                table: "PerfisUsuarios",
                newName: "IX_PerfisUsuarios_Nome");

            migrationBuilder.AddColumn<Guid>(
                name: "IdentityId",
                table: "PerfisUsuarios",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PerfisUsuarios",
                table: "PerfisUsuarios",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "CategoriasPrecos",
                keyColumn: "Id",
                keyValue: new Guid("5533b87c-72d5-4033-85c4-ae44f5a3210c"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 29, 13, 11, 2, 903, DateTimeKind.Local).AddTicks(3740), new DateTime(2024, 4, 29, 13, 11, 2, 903, DateTimeKind.Local).AddTicks(3751) });

            migrationBuilder.UpdateData(
                table: "CategoriasPrecos",
                keyColumn: "Id",
                keyValue: new Guid("710bd8dd-1853-43a1-8708-ca1f259d71ad"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 29, 13, 11, 2, 903, DateTimeKind.Local).AddTicks(3731), new DateTime(2024, 4, 29, 13, 11, 2, 903, DateTimeKind.Local).AddTicks(3738) });

            migrationBuilder.UpdateData(
                table: "CategoriasPrecos",
                keyColumn: "Id",
                keyValue: new Guid("ed65a4e3-a0b0-40a7-b7ae-3397a965d924"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 29, 13, 11, 2, 903, DateTimeKind.Local).AddTicks(3752), new DateTime(2024, 4, 29, 13, 11, 2, 903, DateTimeKind.Local).AddTicks(3761) });

            migrationBuilder.UpdateData(
                table: "CategoriasProdutos",
                keyColumn: "Id",
                keyValue: new Guid("a9b05f16-71f0-4f77-a653-52c1a15b36bc"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 29, 16, 11, 2, 902, DateTimeKind.Utc).AddTicks(3922), new DateTime(2024, 4, 29, 16, 11, 2, 902, DateTimeKind.Utc).AddTicks(3919) });

            migrationBuilder.UpdateData(
                table: "CategoriasProdutos",
                keyColumn: "Id",
                keyValue: new Guid("d9d229c4-9a64-4836-af41-2f111f229c46"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 29, 16, 11, 2, 902, DateTimeKind.Utc).AddTicks(3947), new DateTime(2024, 4, 29, 16, 11, 2, 902, DateTimeKind.Utc).AddTicks(3946) });

            migrationBuilder.UpdateData(
                table: "PeriodosPontosVendas",
                keyColumn: "Id",
                keyValue: new Guid("567906bb-6eb4-42e9-b890-10e6da214766"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 29, 13, 11, 2, 903, DateTimeKind.Local).AddTicks(2657), new DateTime(2024, 4, 29, 13, 11, 2, 903, DateTimeKind.Local).AddTicks(2661) });

            migrationBuilder.UpdateData(
                table: "PeriodosPontosVendas",
                keyColumn: "Id",
                keyValue: new Guid("7e107de8-c97a-435b-9976-7a689ca28bb7"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 29, 13, 11, 2, 903, DateTimeKind.Local).AddTicks(2670), new DateTime(2024, 4, 29, 13, 11, 2, 903, DateTimeKind.Local).AddTicks(2672) });

            migrationBuilder.UpdateData(
                table: "PeriodosPontosVendas",
                keyColumn: "Id",
                keyValue: new Guid("f14c83df-1fa4-4a83-8070-b16ecb19aa77"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 29, 13, 11, 2, 903, DateTimeKind.Local).AddTicks(2667), new DateTime(2024, 4, 29, 13, 11, 2, 903, DateTimeKind.Local).AddTicks(2668) });

            migrationBuilder.UpdateData(
                table: "PeriodosPontosVendas",
                keyColumn: "Id",
                keyValue: new Guid("fc6a5d67-8356-4270-b9e6-7749b553dcf3"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 29, 13, 11, 2, 903, DateTimeKind.Local).AddTicks(2664), new DateTime(2024, 4, 29, 13, 11, 2, 903, DateTimeKind.Local).AddTicks(2665) });

            migrationBuilder.UpdateData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: new Guid("f0e75a80-0b64-4b2b-9f53-f3dce3f6d126"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 29, 13, 11, 2, 903, DateTimeKind.Local).AddTicks(1936), new DateTime(2024, 4, 29, 13, 11, 2, 903, DateTimeKind.Local).AddTicks(1947) });

            migrationBuilder.UpdateData(
                table: "ProdutosMedidas",
                keyColumn: "Id",
                keyValue: new Guid("2f943e86-f06f-4f7d-babf-48d0d2d8f3ac"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 29, 16, 11, 2, 902, DateTimeKind.Utc).AddTicks(5951), new DateTime(2024, 4, 29, 16, 11, 2, 902, DateTimeKind.Utc).AddTicks(5951) });

            migrationBuilder.UpdateData(
                table: "ProdutosMedidas",
                keyColumn: "Id",
                keyValue: new Guid("414a646f-1146-4b6d-bbfc-39a26e74a091"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 29, 16, 11, 2, 902, DateTimeKind.Utc).AddTicks(5945), new DateTime(2024, 4, 29, 16, 11, 2, 902, DateTimeKind.Utc).AddTicks(5944) });

            migrationBuilder.UpdateData(
                table: "TiposProdutos",
                keyColumn: "Id",
                keyValue: new Guid("1e11b25a-8bf5-4d57-80b7-396d09cbfcf1"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 29, 16, 11, 2, 902, DateTimeKind.Utc).AddTicks(5135), new DateTime(2024, 4, 29, 16, 11, 2, 902, DateTimeKind.Utc).AddTicks(5137) });

            migrationBuilder.UpdateData(
                table: "TiposProdutos",
                keyColumn: "Id",
                keyValue: new Guid("edddccfa-a4af-4831-b9ee-29bdd5f755af"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 29, 16, 11, 2, 902, DateTimeKind.Utc).AddTicks(5127), new DateTime(2024, 4, 29, 16, 11, 2, 902, DateTimeKind.Utc).AddTicks(5134) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PerfisUsuarios",
                table: "PerfisUsuarios");

            migrationBuilder.DropColumn(
                name: "IdentityId",
                table: "PerfisUsuarios");

            migrationBuilder.RenameTable(
                name: "PerfisUsuarios",
                newName: "PerfilsUsuarios");

            migrationBuilder.RenameIndex(
                name: "IX_PerfisUsuarios_Nome",
                table: "PerfilsUsuarios",
                newName: "IX_PerfilsUsuarios_Nome");

            migrationBuilder.AddColumn<string>(
                name: "Senha",
                table: "PerfilsUsuarios",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PerfilsUsuarios",
                table: "PerfilsUsuarios",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "CategoriasPrecos",
                keyColumn: "Id",
                keyValue: new Guid("5533b87c-72d5-4033-85c4-ae44f5a3210c"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 29, 1, 56, 17, 502, DateTimeKind.Local).AddTicks(4979), new DateTime(2024, 4, 29, 1, 56, 17, 502, DateTimeKind.Local).AddTicks(4981) });

            migrationBuilder.UpdateData(
                table: "CategoriasPrecos",
                keyColumn: "Id",
                keyValue: new Guid("710bd8dd-1853-43a1-8708-ca1f259d71ad"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 29, 1, 56, 17, 502, DateTimeKind.Local).AddTicks(4948), new DateTime(2024, 4, 29, 1, 56, 17, 502, DateTimeKind.Local).AddTicks(4960) });

            migrationBuilder.UpdateData(
                table: "CategoriasPrecos",
                keyColumn: "Id",
                keyValue: new Guid("ed65a4e3-a0b0-40a7-b7ae-3397a965d924"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 29, 1, 56, 17, 502, DateTimeKind.Local).AddTicks(4987), new DateTime(2024, 4, 29, 1, 56, 17, 502, DateTimeKind.Local).AddTicks(4989) });

            migrationBuilder.UpdateData(
                table: "CategoriasProdutos",
                keyColumn: "Id",
                keyValue: new Guid("a9b05f16-71f0-4f77-a653-52c1a15b36bc"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 29, 4, 56, 17, 501, DateTimeKind.Utc).AddTicks(4321), new DateTime(2024, 4, 29, 4, 56, 17, 501, DateTimeKind.Utc).AddTicks(4317) });

            migrationBuilder.UpdateData(
                table: "CategoriasProdutos",
                keyColumn: "Id",
                keyValue: new Guid("d9d229c4-9a64-4836-af41-2f111f229c46"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 29, 4, 56, 17, 501, DateTimeKind.Utc).AddTicks(4343), new DateTime(2024, 4, 29, 4, 56, 17, 501, DateTimeKind.Utc).AddTicks(4342) });

            migrationBuilder.UpdateData(
                table: "PeriodosPontosVendas",
                keyColumn: "Id",
                keyValue: new Guid("567906bb-6eb4-42e9-b890-10e6da214766"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 29, 1, 56, 17, 502, DateTimeKind.Local).AddTicks(3739), new DateTime(2024, 4, 29, 1, 56, 17, 502, DateTimeKind.Local).AddTicks(3744) });

            migrationBuilder.UpdateData(
                table: "PeriodosPontosVendas",
                keyColumn: "Id",
                keyValue: new Guid("7e107de8-c97a-435b-9976-7a689ca28bb7"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 29, 1, 56, 17, 502, DateTimeKind.Local).AddTicks(3751), new DateTime(2024, 4, 29, 1, 56, 17, 502, DateTimeKind.Local).AddTicks(3752) });

            migrationBuilder.UpdateData(
                table: "PeriodosPontosVendas",
                keyColumn: "Id",
                keyValue: new Guid("f14c83df-1fa4-4a83-8070-b16ecb19aa77"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 29, 1, 56, 17, 502, DateTimeKind.Local).AddTicks(3749), new DateTime(2024, 4, 29, 1, 56, 17, 502, DateTimeKind.Local).AddTicks(3750) });

            migrationBuilder.UpdateData(
                table: "PeriodosPontosVendas",
                keyColumn: "Id",
                keyValue: new Guid("fc6a5d67-8356-4270-b9e6-7749b553dcf3"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 29, 1, 56, 17, 502, DateTimeKind.Local).AddTicks(3746), new DateTime(2024, 4, 29, 1, 56, 17, 502, DateTimeKind.Local).AddTicks(3747) });

            migrationBuilder.UpdateData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: new Guid("f0e75a80-0b64-4b2b-9f53-f3dce3f6d126"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 29, 1, 56, 17, 502, DateTimeKind.Local).AddTicks(2888), new DateTime(2024, 4, 29, 1, 56, 17, 502, DateTimeKind.Local).AddTicks(2906) });

            migrationBuilder.UpdateData(
                table: "ProdutosMedidas",
                keyColumn: "Id",
                keyValue: new Guid("2f943e86-f06f-4f7d-babf-48d0d2d8f3ac"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 29, 4, 56, 17, 501, DateTimeKind.Utc).AddTicks(6223), new DateTime(2024, 4, 29, 4, 56, 17, 501, DateTimeKind.Utc).AddTicks(6223) });

            migrationBuilder.UpdateData(
                table: "ProdutosMedidas",
                keyColumn: "Id",
                keyValue: new Guid("414a646f-1146-4b6d-bbfc-39a26e74a091"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 29, 4, 56, 17, 501, DateTimeKind.Utc).AddTicks(6217), new DateTime(2024, 4, 29, 4, 56, 17, 501, DateTimeKind.Utc).AddTicks(6215) });

            migrationBuilder.UpdateData(
                table: "TiposProdutos",
                keyColumn: "Id",
                keyValue: new Guid("1e11b25a-8bf5-4d57-80b7-396d09cbfcf1"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 29, 4, 56, 17, 501, DateTimeKind.Utc).AddTicks(5395), new DateTime(2024, 4, 29, 4, 56, 17, 501, DateTimeKind.Utc).AddTicks(5396) });

            migrationBuilder.UpdateData(
                table: "TiposProdutos",
                keyColumn: "Id",
                keyValue: new Guid("edddccfa-a4af-4831-b9ee-29bdd5f755af"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 29, 4, 56, 17, 501, DateTimeKind.Utc).AddTicks(5387), new DateTime(2024, 4, 29, 4, 56, 17, 501, DateTimeKind.Utc).AddTicks(5393) });
        }
    }
}
