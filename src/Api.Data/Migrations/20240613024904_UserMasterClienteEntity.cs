using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class UserMasterClienteEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItensPedidos_AspNetUsers_UserId",
                table: "ItensPedidos");

            migrationBuilder.DropIndex(
                name: "IX_ItensPedidos_UserId",
                table: "ItensPedidos");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ItensPedidos");

            migrationBuilder.CreateTable(
                name: "UsuariosMasterClientes",
                columns: table => new
                {
                    UserMasterId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuariosMasterClientes", x => x.UserMasterId);
                    table.ForeignKey(
                        name: "FK_UsuariosMasterClientes_AspNetUsers_UserMasterId",
                        column: x => x.UserMasterId,
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
                values: new object[] { new DateTime(2024, 6, 12, 23, 49, 3, 665, DateTimeKind.Local).AddTicks(3074), new DateTime(2024, 6, 12, 23, 49, 3, 665, DateTimeKind.Local).AddTicks(3078) });

            migrationBuilder.UpdateData(
                table: "CategoriasPrecos",
                keyColumn: "Id",
                keyValue: new Guid("710bd8dd-1853-43a1-8708-ca1f259d71ad"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 12, 23, 49, 3, 665, DateTimeKind.Local).AddTicks(3060), new DateTime(2024, 6, 12, 23, 49, 3, 665, DateTimeKind.Local).AddTicks(3071) });

            migrationBuilder.UpdateData(
                table: "CategoriasPrecos",
                keyColumn: "Id",
                keyValue: new Guid("ed65a4e3-a0b0-40a7-b7ae-3397a965d924"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 12, 23, 49, 3, 665, DateTimeKind.Local).AddTicks(3086), new DateTime(2024, 6, 12, 23, 49, 3, 665, DateTimeKind.Local).AddTicks(3087) });

            migrationBuilder.UpdateData(
                table: "FormasPagamentos",
                keyColumn: "Id",
                keyValue: new Guid("92008957-f185-4563-9d9e-7b71f4ea2691"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 12, 23, 49, 3, 668, DateTimeKind.Local).AddTicks(6485), new DateTime(2024, 6, 12, 23, 49, 3, 668, DateTimeKind.Local).AddTicks(6520) });

            migrationBuilder.UpdateData(
                table: "PeriodosPontosVendas",
                keyColumn: "Id",
                keyValue: new Guid("567906bb-6eb4-42e9-b890-10e6da214766"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 12, 23, 49, 3, 665, DateTimeKind.Local).AddTicks(2057), new DateTime(2024, 6, 12, 23, 49, 3, 665, DateTimeKind.Local).AddTicks(2071) });

            migrationBuilder.UpdateData(
                table: "PeriodosPontosVendas",
                keyColumn: "Id",
                keyValue: new Guid("7e107de8-c97a-435b-9976-7a689ca28bb7"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 12, 23, 49, 3, 665, DateTimeKind.Local).AddTicks(2093), new DateTime(2024, 6, 12, 23, 49, 3, 665, DateTimeKind.Local).AddTicks(2095) });

            migrationBuilder.UpdateData(
                table: "PeriodosPontosVendas",
                keyColumn: "Id",
                keyValue: new Guid("f14c83df-1fa4-4a83-8070-b16ecb19aa77"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 12, 23, 49, 3, 665, DateTimeKind.Local).AddTicks(2088), new DateTime(2024, 6, 12, 23, 49, 3, 665, DateTimeKind.Local).AddTicks(2090) });

            migrationBuilder.UpdateData(
                table: "PeriodosPontosVendas",
                keyColumn: "Id",
                keyValue: new Guid("fc6a5d67-8356-4270-b9e6-7749b553dcf3"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 12, 23, 49, 3, 665, DateTimeKind.Local).AddTicks(2074), new DateTime(2024, 6, 12, 23, 49, 3, 665, DateTimeKind.Local).AddTicks(2075) });

            migrationBuilder.UpdateData(
                table: "ProdutosMedidas",
                keyColumn: "Id",
                keyValue: new Guid("2f943e86-f06f-4f7d-babf-48d0d2d8f3ac"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 13, 2, 49, 3, 664, DateTimeKind.Utc).AddTicks(3428), new DateTime(2024, 6, 13, 2, 49, 3, 664, DateTimeKind.Utc).AddTicks(3427) });

            migrationBuilder.UpdateData(
                table: "ProdutosMedidas",
                keyColumn: "Id",
                keyValue: new Guid("414a646f-1146-4b6d-bbfc-39a26e74a091"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 13, 2, 49, 3, 664, DateTimeKind.Utc).AddTicks(3420), new DateTime(2024, 6, 13, 2, 49, 3, 664, DateTimeKind.Utc).AddTicks(3419) });

            migrationBuilder.UpdateData(
                table: "SituacoesPedidos",
                keyColumn: "Id",
                keyValue: new Guid("11b17cc5-c8b1-48f9-b9fd-886339441328"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 12, 23, 49, 3, 668, DateTimeKind.Local).AddTicks(7119), new DateTime(2024, 6, 12, 23, 49, 3, 668, DateTimeKind.Local).AddTicks(7120) });

            migrationBuilder.UpdateData(
                table: "SituacoesPedidos",
                keyColumn: "Id",
                keyValue: new Guid("185b07da-7e82-43d1-b61f-912d8b29a34c"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 12, 23, 49, 3, 668, DateTimeKind.Local).AddTicks(7113), new DateTime(2024, 6, 12, 23, 49, 3, 668, DateTimeKind.Local).AddTicks(7114) });

            migrationBuilder.UpdateData(
                table: "SituacoesPedidos",
                keyColumn: "Id",
                keyValue: new Guid("abc0f0f9-3295-439c-a468-795b071b7f22"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 12, 23, 49, 3, 668, DateTimeKind.Local).AddTicks(7105), new DateTime(2024, 6, 12, 23, 49, 3, 668, DateTimeKind.Local).AddTicks(7109) });

            migrationBuilder.UpdateData(
                table: "TiposProdutos",
                keyColumn: "Id",
                keyValue: new Guid("1e11b25a-8bf5-4d57-80b7-396d09cbfcf1"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 13, 2, 49, 3, 664, DateTimeKind.Utc).AddTicks(1945), new DateTime(2024, 6, 13, 2, 49, 3, 664, DateTimeKind.Utc).AddTicks(1952) });

            migrationBuilder.UpdateData(
                table: "TiposProdutos",
                keyColumn: "Id",
                keyValue: new Guid("edddccfa-a4af-4831-b9ee-29bdd5f755af"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 13, 2, 49, 3, 664, DateTimeKind.Utc).AddTicks(1920), new DateTime(2024, 6, 13, 2, 49, 3, 664, DateTimeKind.Utc).AddTicks(1944) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsuariosMasterClientes");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "ItensPedidos",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.UpdateData(
                table: "CategoriasPrecos",
                keyColumn: "Id",
                keyValue: new Guid("5533b87c-72d5-4033-85c4-ae44f5a3210c"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 12, 20, 55, 48, 375, DateTimeKind.Local).AddTicks(6504), new DateTime(2024, 6, 12, 20, 55, 48, 375, DateTimeKind.Local).AddTicks(6505) });

            migrationBuilder.UpdateData(
                table: "CategoriasPrecos",
                keyColumn: "Id",
                keyValue: new Guid("710bd8dd-1853-43a1-8708-ca1f259d71ad"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 12, 20, 55, 48, 375, DateTimeKind.Local).AddTicks(6493), new DateTime(2024, 6, 12, 20, 55, 48, 375, DateTimeKind.Local).AddTicks(6502) });

            migrationBuilder.UpdateData(
                table: "CategoriasPrecos",
                keyColumn: "Id",
                keyValue: new Guid("ed65a4e3-a0b0-40a7-b7ae-3397a965d924"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 12, 20, 55, 48, 375, DateTimeKind.Local).AddTicks(6507), new DateTime(2024, 6, 12, 20, 55, 48, 375, DateTimeKind.Local).AddTicks(6508) });

            migrationBuilder.UpdateData(
                table: "FormasPagamentos",
                keyColumn: "Id",
                keyValue: new Guid("92008957-f185-4563-9d9e-7b71f4ea2691"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 12, 20, 55, 48, 382, DateTimeKind.Local).AddTicks(2694), new DateTime(2024, 6, 12, 20, 55, 48, 382, DateTimeKind.Local).AddTicks(2728) });

            migrationBuilder.UpdateData(
                table: "PeriodosPontosVendas",
                keyColumn: "Id",
                keyValue: new Guid("567906bb-6eb4-42e9-b890-10e6da214766"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 12, 20, 55, 48, 375, DateTimeKind.Local).AddTicks(5735), new DateTime(2024, 6, 12, 20, 55, 48, 375, DateTimeKind.Local).AddTicks(5746) });

            migrationBuilder.UpdateData(
                table: "PeriodosPontosVendas",
                keyColumn: "Id",
                keyValue: new Guid("7e107de8-c97a-435b-9976-7a689ca28bb7"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 12, 20, 55, 48, 375, DateTimeKind.Local).AddTicks(5760), new DateTime(2024, 6, 12, 20, 55, 48, 375, DateTimeKind.Local).AddTicks(5761) });

            migrationBuilder.UpdateData(
                table: "PeriodosPontosVendas",
                keyColumn: "Id",
                keyValue: new Guid("f14c83df-1fa4-4a83-8070-b16ecb19aa77"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 12, 20, 55, 48, 375, DateTimeKind.Local).AddTicks(5758), new DateTime(2024, 6, 12, 20, 55, 48, 375, DateTimeKind.Local).AddTicks(5759) });

            migrationBuilder.UpdateData(
                table: "PeriodosPontosVendas",
                keyColumn: "Id",
                keyValue: new Guid("fc6a5d67-8356-4270-b9e6-7749b553dcf3"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 12, 20, 55, 48, 375, DateTimeKind.Local).AddTicks(5749), new DateTime(2024, 6, 12, 20, 55, 48, 375, DateTimeKind.Local).AddTicks(5750) });

            migrationBuilder.UpdateData(
                table: "ProdutosMedidas",
                keyColumn: "Id",
                keyValue: new Guid("2f943e86-f06f-4f7d-babf-48d0d2d8f3ac"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 12, 23, 55, 48, 374, DateTimeKind.Utc).AddTicks(8997), new DateTime(2024, 6, 12, 23, 55, 48, 374, DateTimeKind.Utc).AddTicks(8996) });

            migrationBuilder.UpdateData(
                table: "ProdutosMedidas",
                keyColumn: "Id",
                keyValue: new Guid("414a646f-1146-4b6d-bbfc-39a26e74a091"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 12, 23, 55, 48, 374, DateTimeKind.Utc).AddTicks(8991), new DateTime(2024, 6, 12, 23, 55, 48, 374, DateTimeKind.Utc).AddTicks(8989) });

            migrationBuilder.UpdateData(
                table: "SituacoesPedidos",
                keyColumn: "Id",
                keyValue: new Guid("11b17cc5-c8b1-48f9-b9fd-886339441328"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 12, 20, 55, 48, 382, DateTimeKind.Local).AddTicks(3451), new DateTime(2024, 6, 12, 20, 55, 48, 382, DateTimeKind.Local).AddTicks(3451) });

            migrationBuilder.UpdateData(
                table: "SituacoesPedidos",
                keyColumn: "Id",
                keyValue: new Guid("185b07da-7e82-43d1-b61f-912d8b29a34c"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 12, 20, 55, 48, 382, DateTimeKind.Local).AddTicks(3447), new DateTime(2024, 6, 12, 20, 55, 48, 382, DateTimeKind.Local).AddTicks(3448) });

            migrationBuilder.UpdateData(
                table: "SituacoesPedidos",
                keyColumn: "Id",
                keyValue: new Guid("abc0f0f9-3295-439c-a468-795b071b7f22"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 12, 20, 55, 48, 382, DateTimeKind.Local).AddTicks(3439), new DateTime(2024, 6, 12, 20, 55, 48, 382, DateTimeKind.Local).AddTicks(3444) });

            migrationBuilder.UpdateData(
                table: "TiposProdutos",
                keyColumn: "Id",
                keyValue: new Guid("1e11b25a-8bf5-4d57-80b7-396d09cbfcf1"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 12, 23, 55, 48, 374, DateTimeKind.Utc).AddTicks(7823), new DateTime(2024, 6, 12, 23, 55, 48, 374, DateTimeKind.Utc).AddTicks(7826) });

            migrationBuilder.UpdateData(
                table: "TiposProdutos",
                keyColumn: "Id",
                keyValue: new Guid("edddccfa-a4af-4831-b9ee-29bdd5f755af"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 12, 23, 55, 48, 374, DateTimeKind.Utc).AddTicks(7798), new DateTime(2024, 6, 12, 23, 55, 48, 374, DateTimeKind.Utc).AddTicks(7822) });

            migrationBuilder.CreateIndex(
                name: "IX_ItensPedidos_UserId",
                table: "ItensPedidos",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItensPedidos_AspNetUsers_UserId",
                table: "ItensPedidos",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
