using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class UserMasterUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UsuariosMasterUsers",
                columns: table => new
                {
                    UserMasterClienteIdentityId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuariosMasterUsers", x => new { x.UserId, x.UserMasterClienteIdentityId });
                    table.ForeignKey(
                        name: "FK_UsuariosMasterUsers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsuariosMasterUsers_UsuariosMasterClientes_UserMasterCliente~",
                        column: x => x.UserMasterClienteIdentityId,
                        principalTable: "UsuariosMasterClientes",
                        principalColumn: "UserMasterId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "CategoriasPrecos",
                keyColumn: "Id",
                keyValue: new Guid("5533b87c-72d5-4033-85c4-ae44f5a3210c"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 13, 0, 7, 32, 225, DateTimeKind.Local).AddTicks(5500), new DateTime(2024, 6, 13, 0, 7, 32, 225, DateTimeKind.Local).AddTicks(5502) });

            migrationBuilder.UpdateData(
                table: "CategoriasPrecos",
                keyColumn: "Id",
                keyValue: new Guid("710bd8dd-1853-43a1-8708-ca1f259d71ad"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 13, 0, 7, 32, 225, DateTimeKind.Local).AddTicks(5484), new DateTime(2024, 6, 13, 0, 7, 32, 225, DateTimeKind.Local).AddTicks(5495) });

            migrationBuilder.UpdateData(
                table: "CategoriasPrecos",
                keyColumn: "Id",
                keyValue: new Guid("ed65a4e3-a0b0-40a7-b7ae-3397a965d924"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 13, 0, 7, 32, 225, DateTimeKind.Local).AddTicks(5503), new DateTime(2024, 6, 13, 0, 7, 32, 225, DateTimeKind.Local).AddTicks(5505) });

            migrationBuilder.UpdateData(
                table: "FormasPagamentos",
                keyColumn: "Id",
                keyValue: new Guid("92008957-f185-4563-9d9e-7b71f4ea2691"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 13, 0, 7, 32, 231, DateTimeKind.Local).AddTicks(7080), new DateTime(2024, 6, 13, 0, 7, 32, 231, DateTimeKind.Local).AddTicks(7118) });

            migrationBuilder.UpdateData(
                table: "PeriodosPontosVendas",
                keyColumn: "Id",
                keyValue: new Guid("567906bb-6eb4-42e9-b890-10e6da214766"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 13, 0, 7, 32, 225, DateTimeKind.Local).AddTicks(4226), new DateTime(2024, 6, 13, 0, 7, 32, 225, DateTimeKind.Local).AddTicks(4242) });

            migrationBuilder.UpdateData(
                table: "PeriodosPontosVendas",
                keyColumn: "Id",
                keyValue: new Guid("7e107de8-c97a-435b-9976-7a689ca28bb7"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 13, 0, 7, 32, 225, DateTimeKind.Local).AddTicks(4253), new DateTime(2024, 6, 13, 0, 7, 32, 225, DateTimeKind.Local).AddTicks(4255) });

            migrationBuilder.UpdateData(
                table: "PeriodosPontosVendas",
                keyColumn: "Id",
                keyValue: new Guid("f14c83df-1fa4-4a83-8070-b16ecb19aa77"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 13, 0, 7, 32, 225, DateTimeKind.Local).AddTicks(4251), new DateTime(2024, 6, 13, 0, 7, 32, 225, DateTimeKind.Local).AddTicks(4252) });

            migrationBuilder.UpdateData(
                table: "PeriodosPontosVendas",
                keyColumn: "Id",
                keyValue: new Guid("fc6a5d67-8356-4270-b9e6-7749b553dcf3"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 13, 0, 7, 32, 225, DateTimeKind.Local).AddTicks(4246), new DateTime(2024, 6, 13, 0, 7, 32, 225, DateTimeKind.Local).AddTicks(4247) });

            migrationBuilder.UpdateData(
                table: "ProdutosMedidas",
                keyColumn: "Id",
                keyValue: new Guid("2f943e86-f06f-4f7d-babf-48d0d2d8f3ac"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 13, 3, 7, 32, 224, DateTimeKind.Utc).AddTicks(4989), new DateTime(2024, 6, 13, 3, 7, 32, 224, DateTimeKind.Utc).AddTicks(4988) });

            migrationBuilder.UpdateData(
                table: "ProdutosMedidas",
                keyColumn: "Id",
                keyValue: new Guid("414a646f-1146-4b6d-bbfc-39a26e74a091"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 13, 3, 7, 32, 224, DateTimeKind.Utc).AddTicks(4980), new DateTime(2024, 6, 13, 3, 7, 32, 224, DateTimeKind.Utc).AddTicks(4978) });

            migrationBuilder.UpdateData(
                table: "SituacoesPedidos",
                keyColumn: "Id",
                keyValue: new Guid("11b17cc5-c8b1-48f9-b9fd-886339441328"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 13, 0, 7, 32, 231, DateTimeKind.Local).AddTicks(8497), new DateTime(2024, 6, 13, 0, 7, 32, 231, DateTimeKind.Local).AddTicks(8498) });

            migrationBuilder.UpdateData(
                table: "SituacoesPedidos",
                keyColumn: "Id",
                keyValue: new Guid("185b07da-7e82-43d1-b61f-912d8b29a34c"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 13, 0, 7, 32, 231, DateTimeKind.Local).AddTicks(8491), new DateTime(2024, 6, 13, 0, 7, 32, 231, DateTimeKind.Local).AddTicks(8492) });

            migrationBuilder.UpdateData(
                table: "SituacoesPedidos",
                keyColumn: "Id",
                keyValue: new Guid("abc0f0f9-3295-439c-a468-795b071b7f22"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 13, 0, 7, 32, 231, DateTimeKind.Local).AddTicks(8480), new DateTime(2024, 6, 13, 0, 7, 32, 231, DateTimeKind.Local).AddTicks(8485) });

            migrationBuilder.UpdateData(
                table: "TiposProdutos",
                keyColumn: "Id",
                keyValue: new Guid("1e11b25a-8bf5-4d57-80b7-396d09cbfcf1"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 13, 3, 7, 32, 224, DateTimeKind.Utc).AddTicks(3612), new DateTime(2024, 6, 13, 3, 7, 32, 224, DateTimeKind.Utc).AddTicks(3615) });

            migrationBuilder.UpdateData(
                table: "TiposProdutos",
                keyColumn: "Id",
                keyValue: new Guid("edddccfa-a4af-4831-b9ee-29bdd5f755af"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 13, 3, 7, 32, 224, DateTimeKind.Utc).AddTicks(3580), new DateTime(2024, 6, 13, 3, 7, 32, 224, DateTimeKind.Utc).AddTicks(3610) });

            migrationBuilder.CreateIndex(
                name: "IX_UsuariosMasterUsers_UserMasterClienteIdentityId",
                table: "UsuariosMasterUsers",
                column: "UserMasterClienteIdentityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsuariosMasterUsers");

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
    }
}
