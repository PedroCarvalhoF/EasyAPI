using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class PontoVendaAlteracao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PontosVendas_AspNetUsers_UserPdvCreateId",
                table: "PontosVendas");

            migrationBuilder.DropForeignKey(
                name: "FK_PontosVendas_AspNetUsers_UserPdvUsingId",
                table: "PontosVendas");

            migrationBuilder.UpdateData(
                table: "CategoriasPrecos",
                keyColumn: "Id",
                keyValue: new Guid("5533b87c-72d5-4033-85c4-ae44f5a3210c"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 15, 21, 29, 42, 73, DateTimeKind.Local).AddTicks(9285), new DateTime(2024, 5, 15, 21, 29, 42, 73, DateTimeKind.Local).AddTicks(9288) });

            migrationBuilder.UpdateData(
                table: "CategoriasPrecos",
                keyColumn: "Id",
                keyValue: new Guid("710bd8dd-1853-43a1-8708-ca1f259d71ad"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 15, 21, 29, 42, 73, DateTimeKind.Local).AddTicks(9268), new DateTime(2024, 5, 15, 21, 29, 42, 73, DateTimeKind.Local).AddTicks(9279) });

            migrationBuilder.UpdateData(
                table: "CategoriasPrecos",
                keyColumn: "Id",
                keyValue: new Guid("ed65a4e3-a0b0-40a7-b7ae-3397a965d924"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 15, 21, 29, 42, 73, DateTimeKind.Local).AddTicks(9289), new DateTime(2024, 5, 15, 21, 29, 42, 73, DateTimeKind.Local).AddTicks(9292) });

            migrationBuilder.UpdateData(
                table: "CategoriasProdutos",
                keyColumn: "Id",
                keyValue: new Guid("a9b05f16-71f0-4f77-a653-52c1a15b36bc"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 16, 0, 29, 42, 71, DateTimeKind.Utc).AddTicks(1526), new DateTime(2024, 5, 16, 0, 29, 42, 71, DateTimeKind.Utc).AddTicks(1517) });

            migrationBuilder.UpdateData(
                table: "CategoriasProdutos",
                keyColumn: "Id",
                keyValue: new Guid("d9d229c4-9a64-4836-af41-2f111f229c46"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 16, 0, 29, 42, 71, DateTimeKind.Utc).AddTicks(1551), new DateTime(2024, 5, 16, 0, 29, 42, 71, DateTimeKind.Utc).AddTicks(1550) });

            migrationBuilder.UpdateData(
                table: "FormasPagamentos",
                keyColumn: "Id",
                keyValue: new Guid("92008957-f185-4563-9d9e-7b71f4ea2691"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 15, 21, 29, 42, 82, DateTimeKind.Local).AddTicks(72), new DateTime(2024, 5, 15, 21, 29, 42, 82, DateTimeKind.Local).AddTicks(114) });

            migrationBuilder.UpdateData(
                table: "PeriodosPontosVendas",
                keyColumn: "Id",
                keyValue: new Guid("567906bb-6eb4-42e9-b890-10e6da214766"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 15, 21, 29, 42, 73, DateTimeKind.Local).AddTicks(7106), new DateTime(2024, 5, 15, 21, 29, 42, 73, DateTimeKind.Local).AddTicks(7120) });

            migrationBuilder.UpdateData(
                table: "PeriodosPontosVendas",
                keyColumn: "Id",
                keyValue: new Guid("7e107de8-c97a-435b-9976-7a689ca28bb7"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 15, 21, 29, 42, 73, DateTimeKind.Local).AddTicks(7133), new DateTime(2024, 5, 15, 21, 29, 42, 73, DateTimeKind.Local).AddTicks(7135) });

            migrationBuilder.UpdateData(
                table: "PeriodosPontosVendas",
                keyColumn: "Id",
                keyValue: new Guid("f14c83df-1fa4-4a83-8070-b16ecb19aa77"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 15, 21, 29, 42, 73, DateTimeKind.Local).AddTicks(7128), new DateTime(2024, 5, 15, 21, 29, 42, 73, DateTimeKind.Local).AddTicks(7129) });

            migrationBuilder.UpdateData(
                table: "PeriodosPontosVendas",
                keyColumn: "Id",
                keyValue: new Guid("fc6a5d67-8356-4270-b9e6-7749b553dcf3"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 15, 21, 29, 42, 73, DateTimeKind.Local).AddTicks(7124), new DateTime(2024, 5, 15, 21, 29, 42, 73, DateTimeKind.Local).AddTicks(7126) });

            migrationBuilder.UpdateData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: new Guid("f0e75a80-0b64-4b2b-9f53-f3dce3f6d126"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 15, 21, 29, 42, 73, DateTimeKind.Local).AddTicks(3909), new DateTime(2024, 5, 15, 21, 29, 42, 73, DateTimeKind.Local).AddTicks(3924) });

            migrationBuilder.UpdateData(
                table: "ProdutosMedidas",
                keyColumn: "Id",
                keyValue: new Guid("2f943e86-f06f-4f7d-babf-48d0d2d8f3ac"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 16, 0, 29, 42, 71, DateTimeKind.Utc).AddTicks(5297), new DateTime(2024, 5, 16, 0, 29, 42, 71, DateTimeKind.Utc).AddTicks(5297) });

            migrationBuilder.UpdateData(
                table: "ProdutosMedidas",
                keyColumn: "Id",
                keyValue: new Guid("414a646f-1146-4b6d-bbfc-39a26e74a091"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 16, 0, 29, 42, 71, DateTimeKind.Utc).AddTicks(5283), new DateTime(2024, 5, 16, 0, 29, 42, 71, DateTimeKind.Utc).AddTicks(5281) });

            migrationBuilder.UpdateData(
                table: "SituacoesPedidos",
                keyColumn: "Id",
                keyValue: new Guid("11b17cc5-c8b1-48f9-b9fd-886339441328"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 15, 21, 29, 42, 82, DateTimeKind.Local).AddTicks(1742), new DateTime(2024, 5, 15, 21, 29, 42, 82, DateTimeKind.Local).AddTicks(1743) });

            migrationBuilder.UpdateData(
                table: "SituacoesPedidos",
                keyColumn: "Id",
                keyValue: new Guid("185b07da-7e82-43d1-b61f-912d8b29a34c"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 15, 21, 29, 42, 82, DateTimeKind.Local).AddTicks(1736), new DateTime(2024, 5, 15, 21, 29, 42, 82, DateTimeKind.Local).AddTicks(1737) });

            migrationBuilder.UpdateData(
                table: "SituacoesPedidos",
                keyColumn: "Id",
                keyValue: new Guid("abc0f0f9-3295-439c-a468-795b071b7f22"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 15, 21, 29, 42, 82, DateTimeKind.Local).AddTicks(1723), new DateTime(2024, 5, 15, 21, 29, 42, 82, DateTimeKind.Local).AddTicks(1730) });

            migrationBuilder.UpdateData(
                table: "TiposProdutos",
                keyColumn: "Id",
                keyValue: new Guid("1e11b25a-8bf5-4d57-80b7-396d09cbfcf1"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 16, 0, 29, 42, 71, DateTimeKind.Utc).AddTicks(3356), new DateTime(2024, 5, 16, 0, 29, 42, 71, DateTimeKind.Utc).AddTicks(3357) });

            migrationBuilder.UpdateData(
                table: "TiposProdutos",
                keyColumn: "Id",
                keyValue: new Guid("edddccfa-a4af-4831-b9ee-29bdd5f755af"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 16, 0, 29, 42, 71, DateTimeKind.Utc).AddTicks(3346), new DateTime(2024, 5, 16, 0, 29, 42, 71, DateTimeKind.Utc).AddTicks(3354) });

            migrationBuilder.AddForeignKey(
                name: "FK_PontosVendas_UsuariosPontoVendas_UserPdvCreateId",
                table: "PontosVendas",
                column: "UserPdvCreateId",
                principalTable: "UsuariosPontoVendas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PontosVendas_UsuariosPontoVendas_UserPdvUsingId",
                table: "PontosVendas",
                column: "UserPdvUsingId",
                principalTable: "UsuariosPontoVendas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PontosVendas_UsuariosPontoVendas_UserPdvCreateId",
                table: "PontosVendas");

            migrationBuilder.DropForeignKey(
                name: "FK_PontosVendas_UsuariosPontoVendas_UserPdvUsingId",
                table: "PontosVendas");

            migrationBuilder.UpdateData(
                table: "CategoriasPrecos",
                keyColumn: "Id",
                keyValue: new Guid("5533b87c-72d5-4033-85c4-ae44f5a3210c"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 15, 20, 39, 36, 114, DateTimeKind.Local).AddTicks(6343), new DateTime(2024, 5, 15, 20, 39, 36, 114, DateTimeKind.Local).AddTicks(6346) });

            migrationBuilder.UpdateData(
                table: "CategoriasPrecos",
                keyColumn: "Id",
                keyValue: new Guid("710bd8dd-1853-43a1-8708-ca1f259d71ad"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 15, 20, 39, 36, 114, DateTimeKind.Local).AddTicks(6328), new DateTime(2024, 5, 15, 20, 39, 36, 114, DateTimeKind.Local).AddTicks(6341) });

            migrationBuilder.UpdateData(
                table: "CategoriasPrecos",
                keyColumn: "Id",
                keyValue: new Guid("ed65a4e3-a0b0-40a7-b7ae-3397a965d924"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 15, 20, 39, 36, 114, DateTimeKind.Local).AddTicks(6348), new DateTime(2024, 5, 15, 20, 39, 36, 114, DateTimeKind.Local).AddTicks(6352) });

            migrationBuilder.UpdateData(
                table: "CategoriasProdutos",
                keyColumn: "Id",
                keyValue: new Guid("a9b05f16-71f0-4f77-a653-52c1a15b36bc"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 15, 23, 39, 36, 113, DateTimeKind.Utc).AddTicks(731), new DateTime(2024, 5, 15, 23, 39, 36, 113, DateTimeKind.Utc).AddTicks(726) });

            migrationBuilder.UpdateData(
                table: "CategoriasProdutos",
                keyColumn: "Id",
                keyValue: new Guid("d9d229c4-9a64-4836-af41-2f111f229c46"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 15, 23, 39, 36, 113, DateTimeKind.Utc).AddTicks(759), new DateTime(2024, 5, 15, 23, 39, 36, 113, DateTimeKind.Utc).AddTicks(758) });

            migrationBuilder.UpdateData(
                table: "FormasPagamentos",
                keyColumn: "Id",
                keyValue: new Guid("92008957-f185-4563-9d9e-7b71f4ea2691"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 15, 20, 39, 36, 120, DateTimeKind.Local).AddTicks(1592), new DateTime(2024, 5, 15, 20, 39, 36, 120, DateTimeKind.Local).AddTicks(1637) });

            migrationBuilder.UpdateData(
                table: "PeriodosPontosVendas",
                keyColumn: "Id",
                keyValue: new Guid("567906bb-6eb4-42e9-b890-10e6da214766"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 15, 20, 39, 36, 114, DateTimeKind.Local).AddTicks(4691), new DateTime(2024, 5, 15, 20, 39, 36, 114, DateTimeKind.Local).AddTicks(4700) });

            migrationBuilder.UpdateData(
                table: "PeriodosPontosVendas",
                keyColumn: "Id",
                keyValue: new Guid("7e107de8-c97a-435b-9976-7a689ca28bb7"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 15, 20, 39, 36, 114, DateTimeKind.Local).AddTicks(4714), new DateTime(2024, 5, 15, 20, 39, 36, 114, DateTimeKind.Local).AddTicks(4716) });

            migrationBuilder.UpdateData(
                table: "PeriodosPontosVendas",
                keyColumn: "Id",
                keyValue: new Guid("f14c83df-1fa4-4a83-8070-b16ecb19aa77"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 15, 20, 39, 36, 114, DateTimeKind.Local).AddTicks(4709), new DateTime(2024, 5, 15, 20, 39, 36, 114, DateTimeKind.Local).AddTicks(4712) });

            migrationBuilder.UpdateData(
                table: "PeriodosPontosVendas",
                keyColumn: "Id",
                keyValue: new Guid("fc6a5d67-8356-4270-b9e6-7749b553dcf3"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 15, 20, 39, 36, 114, DateTimeKind.Local).AddTicks(4705), new DateTime(2024, 5, 15, 20, 39, 36, 114, DateTimeKind.Local).AddTicks(4706) });

            migrationBuilder.UpdateData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: new Guid("f0e75a80-0b64-4b2b-9f53-f3dce3f6d126"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 15, 20, 39, 36, 114, DateTimeKind.Local).AddTicks(2862), new DateTime(2024, 5, 15, 20, 39, 36, 114, DateTimeKind.Local).AddTicks(2877) });

            migrationBuilder.UpdateData(
                table: "ProdutosMedidas",
                keyColumn: "Id",
                keyValue: new Guid("2f943e86-f06f-4f7d-babf-48d0d2d8f3ac"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 15, 23, 39, 36, 113, DateTimeKind.Utc).AddTicks(3769), new DateTime(2024, 5, 15, 23, 39, 36, 113, DateTimeKind.Utc).AddTicks(3768) });

            migrationBuilder.UpdateData(
                table: "ProdutosMedidas",
                keyColumn: "Id",
                keyValue: new Guid("414a646f-1146-4b6d-bbfc-39a26e74a091"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 15, 23, 39, 36, 113, DateTimeKind.Utc).AddTicks(3757), new DateTime(2024, 5, 15, 23, 39, 36, 113, DateTimeKind.Utc).AddTicks(3756) });

            migrationBuilder.UpdateData(
                table: "SituacoesPedidos",
                keyColumn: "Id",
                keyValue: new Guid("11b17cc5-c8b1-48f9-b9fd-886339441328"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 15, 20, 39, 36, 120, DateTimeKind.Local).AddTicks(2625), new DateTime(2024, 5, 15, 20, 39, 36, 120, DateTimeKind.Local).AddTicks(2626) });

            migrationBuilder.UpdateData(
                table: "SituacoesPedidos",
                keyColumn: "Id",
                keyValue: new Guid("185b07da-7e82-43d1-b61f-912d8b29a34c"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 15, 20, 39, 36, 120, DateTimeKind.Local).AddTicks(2623), new DateTime(2024, 5, 15, 20, 39, 36, 120, DateTimeKind.Local).AddTicks(2623) });

            migrationBuilder.UpdateData(
                table: "SituacoesPedidos",
                keyColumn: "Id",
                keyValue: new Guid("abc0f0f9-3295-439c-a468-795b071b7f22"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 15, 20, 39, 36, 120, DateTimeKind.Local).AddTicks(2613), new DateTime(2024, 5, 15, 20, 39, 36, 120, DateTimeKind.Local).AddTicks(2619) });

            migrationBuilder.UpdateData(
                table: "TiposProdutos",
                keyColumn: "Id",
                keyValue: new Guid("1e11b25a-8bf5-4d57-80b7-396d09cbfcf1"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 15, 23, 39, 36, 113, DateTimeKind.Utc).AddTicks(2207), new DateTime(2024, 5, 15, 23, 39, 36, 113, DateTimeKind.Utc).AddTicks(2210) });

            migrationBuilder.UpdateData(
                table: "TiposProdutos",
                keyColumn: "Id",
                keyValue: new Guid("edddccfa-a4af-4831-b9ee-29bdd5f755af"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 15, 23, 39, 36, 113, DateTimeKind.Utc).AddTicks(2188), new DateTime(2024, 5, 15, 23, 39, 36, 113, DateTimeKind.Utc).AddTicks(2199) });

            migrationBuilder.AddForeignKey(
                name: "FK_PontosVendas_AspNetUsers_UserPdvCreateId",
                table: "PontosVendas",
                column: "UserPdvCreateId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PontosVendas_AspNetUsers_UserPdvUsingId",
                table: "PontosVendas",
                column: "UserPdvUsingId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
