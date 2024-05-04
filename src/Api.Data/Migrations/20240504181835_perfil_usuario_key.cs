using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class perfil_usuario_key : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PontosVendas_PerfisUsuarios_IdPerfilAbriuPDV",
                table: "PontosVendas");

            migrationBuilder.DropForeignKey(
                name: "FK_PontosVendas_PerfisUsuarios_IdPerfilUtilizarPDV",
                table: "PontosVendas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PerfisUsuarios",
                table: "PerfisUsuarios");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PerfisUsuarios",
                table: "PerfisUsuarios",
                column: "IdentityId");

            migrationBuilder.UpdateData(
                table: "CategoriasPrecos",
                keyColumn: "Id",
                keyValue: new Guid("5533b87c-72d5-4033-85c4-ae44f5a3210c"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 4, 15, 18, 34, 709, DateTimeKind.Local).AddTicks(7549), new DateTime(2024, 5, 4, 15, 18, 34, 709, DateTimeKind.Local).AddTicks(7551) });

            migrationBuilder.UpdateData(
                table: "CategoriasPrecos",
                keyColumn: "Id",
                keyValue: new Guid("710bd8dd-1853-43a1-8708-ca1f259d71ad"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 4, 15, 18, 34, 709, DateTimeKind.Local).AddTicks(7540), new DateTime(2024, 5, 4, 15, 18, 34, 709, DateTimeKind.Local).AddTicks(7547) });

            migrationBuilder.UpdateData(
                table: "CategoriasPrecos",
                keyColumn: "Id",
                keyValue: new Guid("ed65a4e3-a0b0-40a7-b7ae-3397a965d924"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 4, 15, 18, 34, 709, DateTimeKind.Local).AddTicks(7552), new DateTime(2024, 5, 4, 15, 18, 34, 709, DateTimeKind.Local).AddTicks(7554) });

            migrationBuilder.UpdateData(
                table: "CategoriasProdutos",
                keyColumn: "Id",
                keyValue: new Guid("a9b05f16-71f0-4f77-a653-52c1a15b36bc"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 4, 18, 18, 34, 708, DateTimeKind.Utc).AddTicks(4517), new DateTime(2024, 5, 4, 18, 18, 34, 708, DateTimeKind.Utc).AddTicks(4512) });

            migrationBuilder.UpdateData(
                table: "CategoriasProdutos",
                keyColumn: "Id",
                keyValue: new Guid("d9d229c4-9a64-4836-af41-2f111f229c46"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 4, 18, 18, 34, 708, DateTimeKind.Utc).AddTicks(4546), new DateTime(2024, 5, 4, 18, 18, 34, 708, DateTimeKind.Utc).AddTicks(4546) });

            migrationBuilder.UpdateData(
                table: "FormasPagamentos",
                keyColumn: "Id",
                keyValue: new Guid("92008957-f185-4563-9d9e-7b71f4ea2691"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 4, 15, 18, 34, 715, DateTimeKind.Local).AddTicks(7012), new DateTime(2024, 5, 4, 15, 18, 34, 715, DateTimeKind.Local).AddTicks(7052) });

            migrationBuilder.UpdateData(
                table: "PeriodosPontosVendas",
                keyColumn: "Id",
                keyValue: new Guid("567906bb-6eb4-42e9-b890-10e6da214766"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 4, 15, 18, 34, 709, DateTimeKind.Local).AddTicks(6731), new DateTime(2024, 5, 4, 15, 18, 34, 709, DateTimeKind.Local).AddTicks(6736) });

            migrationBuilder.UpdateData(
                table: "PeriodosPontosVendas",
                keyColumn: "Id",
                keyValue: new Guid("7e107de8-c97a-435b-9976-7a689ca28bb7"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 4, 15, 18, 34, 709, DateTimeKind.Local).AddTicks(6745), new DateTime(2024, 5, 4, 15, 18, 34, 709, DateTimeKind.Local).AddTicks(6746) });

            migrationBuilder.UpdateData(
                table: "PeriodosPontosVendas",
                keyColumn: "Id",
                keyValue: new Guid("f14c83df-1fa4-4a83-8070-b16ecb19aa77"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 4, 15, 18, 34, 709, DateTimeKind.Local).AddTicks(6742), new DateTime(2024, 5, 4, 15, 18, 34, 709, DateTimeKind.Local).AddTicks(6743) });

            migrationBuilder.UpdateData(
                table: "PeriodosPontosVendas",
                keyColumn: "Id",
                keyValue: new Guid("fc6a5d67-8356-4270-b9e6-7749b553dcf3"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 4, 15, 18, 34, 709, DateTimeKind.Local).AddTicks(6739), new DateTime(2024, 5, 4, 15, 18, 34, 709, DateTimeKind.Local).AddTicks(6740) });

            migrationBuilder.UpdateData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: new Guid("f0e75a80-0b64-4b2b-9f53-f3dce3f6d126"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 4, 15, 18, 34, 709, DateTimeKind.Local).AddTicks(5824), new DateTime(2024, 5, 4, 15, 18, 34, 709, DateTimeKind.Local).AddTicks(5836) });

            migrationBuilder.UpdateData(
                table: "ProdutosMedidas",
                keyColumn: "Id",
                keyValue: new Guid("2f943e86-f06f-4f7d-babf-48d0d2d8f3ac"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 4, 18, 18, 34, 708, DateTimeKind.Utc).AddTicks(8308), new DateTime(2024, 5, 4, 18, 18, 34, 708, DateTimeKind.Utc).AddTicks(8307) });

            migrationBuilder.UpdateData(
                table: "ProdutosMedidas",
                keyColumn: "Id",
                keyValue: new Guid("414a646f-1146-4b6d-bbfc-39a26e74a091"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 4, 18, 18, 34, 708, DateTimeKind.Utc).AddTicks(8299), new DateTime(2024, 5, 4, 18, 18, 34, 708, DateTimeKind.Utc).AddTicks(8298) });

            migrationBuilder.UpdateData(
                table: "SituacoesPedidos",
                keyColumn: "Id",
                keyValue: new Guid("11b17cc5-c8b1-48f9-b9fd-886339441328"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 4, 15, 18, 34, 715, DateTimeKind.Local).AddTicks(7915), new DateTime(2024, 5, 4, 15, 18, 34, 715, DateTimeKind.Local).AddTicks(7916) });

            migrationBuilder.UpdateData(
                table: "SituacoesPedidos",
                keyColumn: "Id",
                keyValue: new Guid("185b07da-7e82-43d1-b61f-912d8b29a34c"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 4, 15, 18, 34, 715, DateTimeKind.Local).AddTicks(7910), new DateTime(2024, 5, 4, 15, 18, 34, 715, DateTimeKind.Local).AddTicks(7911) });

            migrationBuilder.UpdateData(
                table: "SituacoesPedidos",
                keyColumn: "Id",
                keyValue: new Guid("abc0f0f9-3295-439c-a468-795b071b7f22"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 4, 15, 18, 34, 715, DateTimeKind.Local).AddTicks(7902), new DateTime(2024, 5, 4, 15, 18, 34, 715, DateTimeKind.Local).AddTicks(7906) });

            migrationBuilder.UpdateData(
                table: "TiposProdutos",
                keyColumn: "Id",
                keyValue: new Guid("1e11b25a-8bf5-4d57-80b7-396d09cbfcf1"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 4, 18, 18, 34, 708, DateTimeKind.Utc).AddTicks(7026), new DateTime(2024, 5, 4, 18, 18, 34, 708, DateTimeKind.Utc).AddTicks(7030) });

            migrationBuilder.UpdateData(
                table: "TiposProdutos",
                keyColumn: "Id",
                keyValue: new Guid("edddccfa-a4af-4831-b9ee-29bdd5f755af"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 4, 18, 18, 34, 708, DateTimeKind.Utc).AddTicks(7002), new DateTime(2024, 5, 4, 18, 18, 34, 708, DateTimeKind.Utc).AddTicks(7024) });

            migrationBuilder.AddForeignKey(
                name: "FK_PontosVendas_PerfisUsuarios_IdPerfilAbriuPDV",
                table: "PontosVendas",
                column: "IdPerfilAbriuPDV",
                principalTable: "PerfisUsuarios",
                principalColumn: "IdentityId");

            migrationBuilder.AddForeignKey(
                name: "FK_PontosVendas_PerfisUsuarios_IdPerfilUtilizarPDV",
                table: "PontosVendas",
                column: "IdPerfilUtilizarPDV",
                principalTable: "PerfisUsuarios",
                principalColumn: "IdentityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PontosVendas_PerfisUsuarios_IdPerfilAbriuPDV",
                table: "PontosVendas");

            migrationBuilder.DropForeignKey(
                name: "FK_PontosVendas_PerfisUsuarios_IdPerfilUtilizarPDV",
                table: "PontosVendas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PerfisUsuarios",
                table: "PerfisUsuarios");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PerfisUsuarios",
                table: "PerfisUsuarios",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "CategoriasPrecos",
                keyColumn: "Id",
                keyValue: new Guid("5533b87c-72d5-4033-85c4-ae44f5a3210c"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 4, 15, 17, 43, 262, DateTimeKind.Local).AddTicks(8829), new DateTime(2024, 5, 4, 15, 17, 43, 262, DateTimeKind.Local).AddTicks(8833) });

            migrationBuilder.UpdateData(
                table: "CategoriasPrecos",
                keyColumn: "Id",
                keyValue: new Guid("710bd8dd-1853-43a1-8708-ca1f259d71ad"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 4, 15, 17, 43, 262, DateTimeKind.Local).AddTicks(8791), new DateTime(2024, 5, 4, 15, 17, 43, 262, DateTimeKind.Local).AddTicks(8827) });

            migrationBuilder.UpdateData(
                table: "CategoriasPrecos",
                keyColumn: "Id",
                keyValue: new Guid("ed65a4e3-a0b0-40a7-b7ae-3397a965d924"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 4, 15, 17, 43, 262, DateTimeKind.Local).AddTicks(8834), new DateTime(2024, 5, 4, 15, 17, 43, 262, DateTimeKind.Local).AddTicks(8839) });

            migrationBuilder.UpdateData(
                table: "CategoriasProdutos",
                keyColumn: "Id",
                keyValue: new Guid("a9b05f16-71f0-4f77-a653-52c1a15b36bc"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 4, 18, 17, 43, 261, DateTimeKind.Utc).AddTicks(228), new DateTime(2024, 5, 4, 18, 17, 43, 261, DateTimeKind.Utc).AddTicks(223) });

            migrationBuilder.UpdateData(
                table: "CategoriasProdutos",
                keyColumn: "Id",
                keyValue: new Guid("d9d229c4-9a64-4836-af41-2f111f229c46"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 4, 18, 17, 43, 261, DateTimeKind.Utc).AddTicks(254), new DateTime(2024, 5, 4, 18, 17, 43, 261, DateTimeKind.Utc).AddTicks(253) });

            migrationBuilder.UpdateData(
                table: "FormasPagamentos",
                keyColumn: "Id",
                keyValue: new Guid("92008957-f185-4563-9d9e-7b71f4ea2691"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 4, 15, 17, 43, 269, DateTimeKind.Local).AddTicks(6346), new DateTime(2024, 5, 4, 15, 17, 43, 269, DateTimeKind.Local).AddTicks(6385) });

            migrationBuilder.UpdateData(
                table: "PeriodosPontosVendas",
                keyColumn: "Id",
                keyValue: new Guid("567906bb-6eb4-42e9-b890-10e6da214766"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 4, 15, 17, 43, 262, DateTimeKind.Local).AddTicks(5555), new DateTime(2024, 5, 4, 15, 17, 43, 262, DateTimeKind.Local).AddTicks(5566) });

            migrationBuilder.UpdateData(
                table: "PeriodosPontosVendas",
                keyColumn: "Id",
                keyValue: new Guid("7e107de8-c97a-435b-9976-7a689ca28bb7"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 4, 15, 17, 43, 262, DateTimeKind.Local).AddTicks(5581), new DateTime(2024, 5, 4, 15, 17, 43, 262, DateTimeKind.Local).AddTicks(5582) });

            migrationBuilder.UpdateData(
                table: "PeriodosPontosVendas",
                keyColumn: "Id",
                keyValue: new Guid("f14c83df-1fa4-4a83-8070-b16ecb19aa77"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 4, 15, 17, 43, 262, DateTimeKind.Local).AddTicks(5577), new DateTime(2024, 5, 4, 15, 17, 43, 262, DateTimeKind.Local).AddTicks(5578) });

            migrationBuilder.UpdateData(
                table: "PeriodosPontosVendas",
                keyColumn: "Id",
                keyValue: new Guid("fc6a5d67-8356-4270-b9e6-7749b553dcf3"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 4, 15, 17, 43, 262, DateTimeKind.Local).AddTicks(5570), new DateTime(2024, 5, 4, 15, 17, 43, 262, DateTimeKind.Local).AddTicks(5571) });

            migrationBuilder.UpdateData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: new Guid("f0e75a80-0b64-4b2b-9f53-f3dce3f6d126"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 4, 15, 17, 43, 262, DateTimeKind.Local).AddTicks(4164), new DateTime(2024, 5, 4, 15, 17, 43, 262, DateTimeKind.Local).AddTicks(4181) });

            migrationBuilder.UpdateData(
                table: "ProdutosMedidas",
                keyColumn: "Id",
                keyValue: new Guid("2f943e86-f06f-4f7d-babf-48d0d2d8f3ac"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 4, 18, 17, 43, 261, DateTimeKind.Utc).AddTicks(3452), new DateTime(2024, 5, 4, 18, 17, 43, 261, DateTimeKind.Utc).AddTicks(3451) });

            migrationBuilder.UpdateData(
                table: "ProdutosMedidas",
                keyColumn: "Id",
                keyValue: new Guid("414a646f-1146-4b6d-bbfc-39a26e74a091"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 4, 18, 17, 43, 261, DateTimeKind.Utc).AddTicks(3441), new DateTime(2024, 5, 4, 18, 17, 43, 261, DateTimeKind.Utc).AddTicks(3440) });

            migrationBuilder.UpdateData(
                table: "SituacoesPedidos",
                keyColumn: "Id",
                keyValue: new Guid("11b17cc5-c8b1-48f9-b9fd-886339441328"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 4, 15, 17, 43, 269, DateTimeKind.Local).AddTicks(7431), new DateTime(2024, 5, 4, 15, 17, 43, 269, DateTimeKind.Local).AddTicks(7432) });

            migrationBuilder.UpdateData(
                table: "SituacoesPedidos",
                keyColumn: "Id",
                keyValue: new Guid("185b07da-7e82-43d1-b61f-912d8b29a34c"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 4, 15, 17, 43, 269, DateTimeKind.Local).AddTicks(7426), new DateTime(2024, 5, 4, 15, 17, 43, 269, DateTimeKind.Local).AddTicks(7427) });

            migrationBuilder.UpdateData(
                table: "SituacoesPedidos",
                keyColumn: "Id",
                keyValue: new Guid("abc0f0f9-3295-439c-a468-795b071b7f22"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 4, 15, 17, 43, 269, DateTimeKind.Local).AddTicks(7411), new DateTime(2024, 5, 4, 15, 17, 43, 269, DateTimeKind.Local).AddTicks(7422) });

            migrationBuilder.UpdateData(
                table: "TiposProdutos",
                keyColumn: "Id",
                keyValue: new Guid("1e11b25a-8bf5-4d57-80b7-396d09cbfcf1"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 4, 18, 17, 43, 261, DateTimeKind.Utc).AddTicks(1866), new DateTime(2024, 5, 4, 18, 17, 43, 261, DateTimeKind.Utc).AddTicks(1870) });

            migrationBuilder.UpdateData(
                table: "TiposProdutos",
                keyColumn: "Id",
                keyValue: new Guid("edddccfa-a4af-4831-b9ee-29bdd5f755af"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 4, 18, 17, 43, 261, DateTimeKind.Utc).AddTicks(1853), new DateTime(2024, 5, 4, 18, 17, 43, 261, DateTimeKind.Utc).AddTicks(1864) });

            migrationBuilder.AddForeignKey(
                name: "FK_PontosVendas_PerfisUsuarios_IdPerfilAbriuPDV",
                table: "PontosVendas",
                column: "IdPerfilAbriuPDV",
                principalTable: "PerfisUsuarios",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PontosVendas_PerfisUsuarios_IdPerfilUtilizarPDV",
                table: "PontosVendas",
                column: "IdPerfilUtilizarPDV",
                principalTable: "PerfisUsuarios",
                principalColumn: "Id");
        }
    }
}
