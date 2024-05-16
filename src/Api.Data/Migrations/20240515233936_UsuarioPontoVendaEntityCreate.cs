using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class UsuarioPontoVendaEntityCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UsuariosPontoVendas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    CreateAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    Habilitado = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuariosPontoVendas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsuariosPontoVendas_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

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

            migrationBuilder.CreateIndex(
                name: "IX_UsuariosPontoVendas_UserId",
                table: "UsuariosPontoVendas",
                column: "UserId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsuariosPontoVendas");

            migrationBuilder.UpdateData(
                table: "CategoriasPrecos",
                keyColumn: "Id",
                keyValue: new Guid("5533b87c-72d5-4033-85c4-ae44f5a3210c"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 12, 13, 15, 3, 312, DateTimeKind.Local).AddTicks(526), new DateTime(2024, 5, 12, 13, 15, 3, 312, DateTimeKind.Local).AddTicks(529) });

            migrationBuilder.UpdateData(
                table: "CategoriasPrecos",
                keyColumn: "Id",
                keyValue: new Guid("710bd8dd-1853-43a1-8708-ca1f259d71ad"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 12, 13, 15, 3, 312, DateTimeKind.Local).AddTicks(507), new DateTime(2024, 5, 12, 13, 15, 3, 312, DateTimeKind.Local).AddTicks(524) });

            migrationBuilder.UpdateData(
                table: "CategoriasPrecos",
                keyColumn: "Id",
                keyValue: new Guid("ed65a4e3-a0b0-40a7-b7ae-3397a965d924"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 12, 13, 15, 3, 312, DateTimeKind.Local).AddTicks(546), new DateTime(2024, 5, 12, 13, 15, 3, 312, DateTimeKind.Local).AddTicks(548) });

            migrationBuilder.UpdateData(
                table: "CategoriasProdutos",
                keyColumn: "Id",
                keyValue: new Guid("a9b05f16-71f0-4f77-a653-52c1a15b36bc"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 12, 16, 15, 3, 309, DateTimeKind.Utc).AddTicks(9934), new DateTime(2024, 5, 12, 16, 15, 3, 309, DateTimeKind.Utc).AddTicks(9930) });

            migrationBuilder.UpdateData(
                table: "CategoriasProdutos",
                keyColumn: "Id",
                keyValue: new Guid("d9d229c4-9a64-4836-af41-2f111f229c46"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 12, 16, 15, 3, 309, DateTimeKind.Utc).AddTicks(9955), new DateTime(2024, 5, 12, 16, 15, 3, 309, DateTimeKind.Utc).AddTicks(9954) });

            migrationBuilder.UpdateData(
                table: "FormasPagamentos",
                keyColumn: "Id",
                keyValue: new Guid("92008957-f185-4563-9d9e-7b71f4ea2691"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 12, 13, 15, 3, 320, DateTimeKind.Local).AddTicks(4188), new DateTime(2024, 5, 12, 13, 15, 3, 320, DateTimeKind.Local).AddTicks(4225) });

            migrationBuilder.UpdateData(
                table: "PeriodosPontosVendas",
                keyColumn: "Id",
                keyValue: new Guid("567906bb-6eb4-42e9-b890-10e6da214766"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 12, 13, 15, 3, 311, DateTimeKind.Local).AddTicks(8525), new DateTime(2024, 5, 12, 13, 15, 3, 311, DateTimeKind.Local).AddTicks(8532) });

            migrationBuilder.UpdateData(
                table: "PeriodosPontosVendas",
                keyColumn: "Id",
                keyValue: new Guid("7e107de8-c97a-435b-9976-7a689ca28bb7"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 12, 13, 15, 3, 311, DateTimeKind.Local).AddTicks(8545), new DateTime(2024, 5, 12, 13, 15, 3, 311, DateTimeKind.Local).AddTicks(8546) });

            migrationBuilder.UpdateData(
                table: "PeriodosPontosVendas",
                keyColumn: "Id",
                keyValue: new Guid("f14c83df-1fa4-4a83-8070-b16ecb19aa77"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 12, 13, 15, 3, 311, DateTimeKind.Local).AddTicks(8541), new DateTime(2024, 5, 12, 13, 15, 3, 311, DateTimeKind.Local).AddTicks(8542) });

            migrationBuilder.UpdateData(
                table: "PeriodosPontosVendas",
                keyColumn: "Id",
                keyValue: new Guid("fc6a5d67-8356-4270-b9e6-7749b553dcf3"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 12, 13, 15, 3, 311, DateTimeKind.Local).AddTicks(8536), new DateTime(2024, 5, 12, 13, 15, 3, 311, DateTimeKind.Local).AddTicks(8538) });

            migrationBuilder.UpdateData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: new Guid("f0e75a80-0b64-4b2b-9f53-f3dce3f6d126"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 12, 13, 15, 3, 311, DateTimeKind.Local).AddTicks(6424), new DateTime(2024, 5, 12, 13, 15, 3, 311, DateTimeKind.Local).AddTicks(6458) });

            migrationBuilder.UpdateData(
                table: "ProdutosMedidas",
                keyColumn: "Id",
                keyValue: new Guid("2f943e86-f06f-4f7d-babf-48d0d2d8f3ac"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 12, 16, 15, 3, 310, DateTimeKind.Utc).AddTicks(3707), new DateTime(2024, 5, 12, 16, 15, 3, 310, DateTimeKind.Utc).AddTicks(3706) });

            migrationBuilder.UpdateData(
                table: "ProdutosMedidas",
                keyColumn: "Id",
                keyValue: new Guid("414a646f-1146-4b6d-bbfc-39a26e74a091"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 12, 16, 15, 3, 310, DateTimeKind.Utc).AddTicks(3696), new DateTime(2024, 5, 12, 16, 15, 3, 310, DateTimeKind.Utc).AddTicks(3695) });

            migrationBuilder.UpdateData(
                table: "SituacoesPedidos",
                keyColumn: "Id",
                keyValue: new Guid("11b17cc5-c8b1-48f9-b9fd-886339441328"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 12, 13, 15, 3, 320, DateTimeKind.Local).AddTicks(5615), new DateTime(2024, 5, 12, 13, 15, 3, 320, DateTimeKind.Local).AddTicks(5617) });

            migrationBuilder.UpdateData(
                table: "SituacoesPedidos",
                keyColumn: "Id",
                keyValue: new Guid("185b07da-7e82-43d1-b61f-912d8b29a34c"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 12, 13, 15, 3, 320, DateTimeKind.Local).AddTicks(5607), new DateTime(2024, 5, 12, 13, 15, 3, 320, DateTimeKind.Local).AddTicks(5610) });

            migrationBuilder.UpdateData(
                table: "SituacoesPedidos",
                keyColumn: "Id",
                keyValue: new Guid("abc0f0f9-3295-439c-a468-795b071b7f22"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 12, 13, 15, 3, 320, DateTimeKind.Local).AddTicks(5594), new DateTime(2024, 5, 12, 13, 15, 3, 320, DateTimeKind.Local).AddTicks(5600) });

            migrationBuilder.UpdateData(
                table: "TiposProdutos",
                keyColumn: "Id",
                keyValue: new Guid("1e11b25a-8bf5-4d57-80b7-396d09cbfcf1"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 12, 16, 15, 3, 310, DateTimeKind.Utc).AddTicks(1895), new DateTime(2024, 5, 12, 16, 15, 3, 310, DateTimeKind.Utc).AddTicks(1898) });

            migrationBuilder.UpdateData(
                table: "TiposProdutos",
                keyColumn: "Id",
                keyValue: new Guid("edddccfa-a4af-4831-b9ee-29bdd5f755af"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 12, 16, 15, 3, 310, DateTimeKind.Utc).AddTicks(1863), new DateTime(2024, 5, 12, 16, 15, 3, 310, DateTimeKind.Utc).AddTicks(1892) });
        }
    }
}
