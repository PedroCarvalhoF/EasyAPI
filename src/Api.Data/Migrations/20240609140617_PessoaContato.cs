using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class PessoaContato : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Complemento",
                table: "Enderecos",
                type: "varchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldMaxLength: 100)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Contatos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    TipoContatoEnum = table.Column<int>(type: "int", nullable: false),
                    Numero = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreateAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    UpdateAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Habilitado = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contatos", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PessoaContatos",
                columns: table => new
                {
                    PessoaEntityId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ContatoEntityId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PessoaContatos", x => new { x.PessoaEntityId, x.ContatoEntityId });
                    table.ForeignKey(
                        name: "FK_PessoaContatos_Contatos_ContatoEntityId",
                        column: x => x.ContatoEntityId,
                        principalTable: "Contatos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PessoaContatos_Pessoas_PessoaEntityId",
                        column: x => x.PessoaEntityId,
                        principalTable: "Pessoas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "CategoriasPrecos",
                keyColumn: "Id",
                keyValue: new Guid("5533b87c-72d5-4033-85c4-ae44f5a3210c"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 9, 11, 6, 16, 668, DateTimeKind.Local).AddTicks(2783), new DateTime(2024, 6, 9, 11, 6, 16, 668, DateTimeKind.Local).AddTicks(2786) });

            migrationBuilder.UpdateData(
                table: "CategoriasPrecos",
                keyColumn: "Id",
                keyValue: new Guid("710bd8dd-1853-43a1-8708-ca1f259d71ad"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 9, 11, 6, 16, 668, DateTimeKind.Local).AddTicks(2748), new DateTime(2024, 6, 9, 11, 6, 16, 668, DateTimeKind.Local).AddTicks(2781) });

            migrationBuilder.UpdateData(
                table: "CategoriasPrecos",
                keyColumn: "Id",
                keyValue: new Guid("ed65a4e3-a0b0-40a7-b7ae-3397a965d924"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 9, 11, 6, 16, 668, DateTimeKind.Local).AddTicks(2788), new DateTime(2024, 6, 9, 11, 6, 16, 668, DateTimeKind.Local).AddTicks(2790) });

            migrationBuilder.UpdateData(
                table: "CategoriasProdutos",
                keyColumn: "Id",
                keyValue: new Guid("a9b05f16-71f0-4f77-a653-52c1a15b36bc"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 9, 14, 6, 16, 665, DateTimeKind.Utc).AddTicks(2976), new DateTime(2024, 6, 9, 14, 6, 16, 665, DateTimeKind.Utc).AddTicks(2970) });

            migrationBuilder.UpdateData(
                table: "CategoriasProdutos",
                keyColumn: "Id",
                keyValue: new Guid("d9d229c4-9a64-4836-af41-2f111f229c46"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 9, 14, 6, 16, 665, DateTimeKind.Utc).AddTicks(3007), new DateTime(2024, 6, 9, 14, 6, 16, 665, DateTimeKind.Utc).AddTicks(3006) });

            migrationBuilder.UpdateData(
                table: "FormasPagamentos",
                keyColumn: "Id",
                keyValue: new Guid("92008957-f185-4563-9d9e-7b71f4ea2691"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 9, 11, 6, 16, 676, DateTimeKind.Local).AddTicks(9590), new DateTime(2024, 6, 9, 11, 6, 16, 676, DateTimeKind.Local).AddTicks(9654) });

            migrationBuilder.UpdateData(
                table: "PeriodosPontosVendas",
                keyColumn: "Id",
                keyValue: new Guid("567906bb-6eb4-42e9-b890-10e6da214766"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 9, 11, 6, 16, 667, DateTimeKind.Local).AddTicks(9721), new DateTime(2024, 6, 9, 11, 6, 16, 667, DateTimeKind.Local).AddTicks(9738) });

            migrationBuilder.UpdateData(
                table: "PeriodosPontosVendas",
                keyColumn: "Id",
                keyValue: new Guid("7e107de8-c97a-435b-9976-7a689ca28bb7"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 9, 11, 6, 16, 667, DateTimeKind.Local).AddTicks(9753), new DateTime(2024, 6, 9, 11, 6, 16, 667, DateTimeKind.Local).AddTicks(9754) });

            migrationBuilder.UpdateData(
                table: "PeriodosPontosVendas",
                keyColumn: "Id",
                keyValue: new Guid("f14c83df-1fa4-4a83-8070-b16ecb19aa77"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 9, 11, 6, 16, 667, DateTimeKind.Local).AddTicks(9746), new DateTime(2024, 6, 9, 11, 6, 16, 667, DateTimeKind.Local).AddTicks(9747) });

            migrationBuilder.UpdateData(
                table: "PeriodosPontosVendas",
                keyColumn: "Id",
                keyValue: new Guid("fc6a5d67-8356-4270-b9e6-7749b553dcf3"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 9, 11, 6, 16, 667, DateTimeKind.Local).AddTicks(9742), new DateTime(2024, 6, 9, 11, 6, 16, 667, DateTimeKind.Local).AddTicks(9744) });

            migrationBuilder.UpdateData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: new Guid("f0e75a80-0b64-4b2b-9f53-f3dce3f6d126"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 9, 11, 6, 16, 667, DateTimeKind.Local).AddTicks(5666), new DateTime(2024, 6, 9, 11, 6, 16, 667, DateTimeKind.Local).AddTicks(5694) });

            migrationBuilder.UpdateData(
                table: "ProdutosMedidas",
                keyColumn: "Id",
                keyValue: new Guid("2f943e86-f06f-4f7d-babf-48d0d2d8f3ac"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 9, 14, 6, 16, 665, DateTimeKind.Utc).AddTicks(9098), new DateTime(2024, 6, 9, 14, 6, 16, 665, DateTimeKind.Utc).AddTicks(9097) });

            migrationBuilder.UpdateData(
                table: "ProdutosMedidas",
                keyColumn: "Id",
                keyValue: new Guid("414a646f-1146-4b6d-bbfc-39a26e74a091"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 9, 14, 6, 16, 665, DateTimeKind.Utc).AddTicks(9080), new DateTime(2024, 6, 9, 14, 6, 16, 665, DateTimeKind.Utc).AddTicks(9075) });

            migrationBuilder.UpdateData(
                table: "SituacoesPedidos",
                keyColumn: "Id",
                keyValue: new Guid("11b17cc5-c8b1-48f9-b9fd-886339441328"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 9, 11, 6, 16, 677, DateTimeKind.Local).AddTicks(1182), new DateTime(2024, 6, 9, 11, 6, 16, 677, DateTimeKind.Local).AddTicks(1183) });

            migrationBuilder.UpdateData(
                table: "SituacoesPedidos",
                keyColumn: "Id",
                keyValue: new Guid("185b07da-7e82-43d1-b61f-912d8b29a34c"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 9, 11, 6, 16, 677, DateTimeKind.Local).AddTicks(1174), new DateTime(2024, 6, 9, 11, 6, 16, 677, DateTimeKind.Local).AddTicks(1176) });

            migrationBuilder.UpdateData(
                table: "SituacoesPedidos",
                keyColumn: "Id",
                keyValue: new Guid("abc0f0f9-3295-439c-a468-795b071b7f22"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 9, 11, 6, 16, 677, DateTimeKind.Local).AddTicks(1161), new DateTime(2024, 6, 9, 11, 6, 16, 677, DateTimeKind.Local).AddTicks(1169) });

            migrationBuilder.UpdateData(
                table: "TiposProdutos",
                keyColumn: "Id",
                keyValue: new Guid("1e11b25a-8bf5-4d57-80b7-396d09cbfcf1"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 9, 14, 6, 16, 665, DateTimeKind.Utc).AddTicks(6890), new DateTime(2024, 6, 9, 14, 6, 16, 665, DateTimeKind.Utc).AddTicks(6893) });

            migrationBuilder.UpdateData(
                table: "TiposProdutos",
                keyColumn: "Id",
                keyValue: new Guid("edddccfa-a4af-4831-b9ee-29bdd5f755af"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 9, 14, 6, 16, 665, DateTimeKind.Utc).AddTicks(6856), new DateTime(2024, 6, 9, 14, 6, 16, 665, DateTimeKind.Utc).AddTicks(6888) });

            migrationBuilder.CreateIndex(
                name: "IX_PessoaContatos_ContatoEntityId",
                table: "PessoaContatos",
                column: "ContatoEntityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PessoaContatos");

            migrationBuilder.DropTable(
                name: "Contatos");

            migrationBuilder.UpdateData(
                table: "Enderecos",
                keyColumn: "Complemento",
                keyValue: null,
                column: "Complemento",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Complemento",
                table: "Enderecos",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldMaxLength: 100,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "CategoriasPrecos",
                keyColumn: "Id",
                keyValue: new Guid("5533b87c-72d5-4033-85c4-ae44f5a3210c"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 8, 17, 47, 3, 859, DateTimeKind.Local).AddTicks(3287), new DateTime(2024, 6, 8, 17, 47, 3, 859, DateTimeKind.Local).AddTicks(3288) });

            migrationBuilder.UpdateData(
                table: "CategoriasPrecos",
                keyColumn: "Id",
                keyValue: new Guid("710bd8dd-1853-43a1-8708-ca1f259d71ad"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 8, 17, 47, 3, 859, DateTimeKind.Local).AddTicks(3278), new DateTime(2024, 6, 8, 17, 47, 3, 859, DateTimeKind.Local).AddTicks(3285) });

            migrationBuilder.UpdateData(
                table: "CategoriasPrecos",
                keyColumn: "Id",
                keyValue: new Guid("ed65a4e3-a0b0-40a7-b7ae-3397a965d924"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 8, 17, 47, 3, 859, DateTimeKind.Local).AddTicks(3290), new DateTime(2024, 6, 8, 17, 47, 3, 859, DateTimeKind.Local).AddTicks(3291) });

            migrationBuilder.UpdateData(
                table: "CategoriasProdutos",
                keyColumn: "Id",
                keyValue: new Guid("a9b05f16-71f0-4f77-a653-52c1a15b36bc"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 8, 20, 47, 3, 858, DateTimeKind.Utc).AddTicks(3304), new DateTime(2024, 6, 8, 20, 47, 3, 858, DateTimeKind.Utc).AddTicks(3299) });

            migrationBuilder.UpdateData(
                table: "CategoriasProdutos",
                keyColumn: "Id",
                keyValue: new Guid("d9d229c4-9a64-4836-af41-2f111f229c46"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 8, 20, 47, 3, 858, DateTimeKind.Utc).AddTicks(3327), new DateTime(2024, 6, 8, 20, 47, 3, 858, DateTimeKind.Utc).AddTicks(3327) });

            migrationBuilder.UpdateData(
                table: "FormasPagamentos",
                keyColumn: "Id",
                keyValue: new Guid("92008957-f185-4563-9d9e-7b71f4ea2691"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 8, 17, 47, 3, 862, DateTimeKind.Local).AddTicks(4034), new DateTime(2024, 6, 8, 17, 47, 3, 862, DateTimeKind.Local).AddTicks(4065) });

            migrationBuilder.UpdateData(
                table: "PeriodosPontosVendas",
                keyColumn: "Id",
                keyValue: new Guid("567906bb-6eb4-42e9-b890-10e6da214766"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 8, 17, 47, 3, 859, DateTimeKind.Local).AddTicks(2355), new DateTime(2024, 6, 8, 17, 47, 3, 859, DateTimeKind.Local).AddTicks(2359) });

            migrationBuilder.UpdateData(
                table: "PeriodosPontosVendas",
                keyColumn: "Id",
                keyValue: new Guid("7e107de8-c97a-435b-9976-7a689ca28bb7"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 8, 17, 47, 3, 859, DateTimeKind.Local).AddTicks(2367), new DateTime(2024, 6, 8, 17, 47, 3, 859, DateTimeKind.Local).AddTicks(2368) });

            migrationBuilder.UpdateData(
                table: "PeriodosPontosVendas",
                keyColumn: "Id",
                keyValue: new Guid("f14c83df-1fa4-4a83-8070-b16ecb19aa77"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 8, 17, 47, 3, 859, DateTimeKind.Local).AddTicks(2364), new DateTime(2024, 6, 8, 17, 47, 3, 859, DateTimeKind.Local).AddTicks(2365) });

            migrationBuilder.UpdateData(
                table: "PeriodosPontosVendas",
                keyColumn: "Id",
                keyValue: new Guid("fc6a5d67-8356-4270-b9e6-7749b553dcf3"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 8, 17, 47, 3, 859, DateTimeKind.Local).AddTicks(2362), new DateTime(2024, 6, 8, 17, 47, 3, 859, DateTimeKind.Local).AddTicks(2362) });

            migrationBuilder.UpdateData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: new Guid("f0e75a80-0b64-4b2b-9f53-f3dce3f6d126"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 8, 17, 47, 3, 859, DateTimeKind.Local).AddTicks(1094), new DateTime(2024, 6, 8, 17, 47, 3, 859, DateTimeKind.Local).AddTicks(1106) });

            migrationBuilder.UpdateData(
                table: "ProdutosMedidas",
                keyColumn: "Id",
                keyValue: new Guid("2f943e86-f06f-4f7d-babf-48d0d2d8f3ac"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 8, 20, 47, 3, 858, DateTimeKind.Utc).AddTicks(5249), new DateTime(2024, 6, 8, 20, 47, 3, 858, DateTimeKind.Utc).AddTicks(5248) });

            migrationBuilder.UpdateData(
                table: "ProdutosMedidas",
                keyColumn: "Id",
                keyValue: new Guid("414a646f-1146-4b6d-bbfc-39a26e74a091"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 8, 20, 47, 3, 858, DateTimeKind.Utc).AddTicks(5243), new DateTime(2024, 6, 8, 20, 47, 3, 858, DateTimeKind.Utc).AddTicks(5241) });

            migrationBuilder.UpdateData(
                table: "SituacoesPedidos",
                keyColumn: "Id",
                keyValue: new Guid("11b17cc5-c8b1-48f9-b9fd-886339441328"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 8, 17, 47, 3, 862, DateTimeKind.Local).AddTicks(4853), new DateTime(2024, 6, 8, 17, 47, 3, 862, DateTimeKind.Local).AddTicks(4854) });

            migrationBuilder.UpdateData(
                table: "SituacoesPedidos",
                keyColumn: "Id",
                keyValue: new Guid("185b07da-7e82-43d1-b61f-912d8b29a34c"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 8, 17, 47, 3, 862, DateTimeKind.Local).AddTicks(4850), new DateTime(2024, 6, 8, 17, 47, 3, 862, DateTimeKind.Local).AddTicks(4851) });

            migrationBuilder.UpdateData(
                table: "SituacoesPedidos",
                keyColumn: "Id",
                keyValue: new Guid("abc0f0f9-3295-439c-a468-795b071b7f22"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 8, 17, 47, 3, 862, DateTimeKind.Local).AddTicks(4844), new DateTime(2024, 6, 8, 17, 47, 3, 862, DateTimeKind.Local).AddTicks(4848) });

            migrationBuilder.UpdateData(
                table: "TiposProdutos",
                keyColumn: "Id",
                keyValue: new Guid("1e11b25a-8bf5-4d57-80b7-396d09cbfcf1"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 8, 20, 47, 3, 858, DateTimeKind.Utc).AddTicks(4337), new DateTime(2024, 6, 8, 20, 47, 3, 858, DateTimeKind.Utc).AddTicks(4339) });

            migrationBuilder.UpdateData(
                table: "TiposProdutos",
                keyColumn: "Id",
                keyValue: new Guid("edddccfa-a4af-4831-b9ee-29bdd5f755af"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 8, 20, 47, 3, 858, DateTimeKind.Utc).AddTicks(4330), new DateTime(2024, 6, 8, 20, 47, 3, 858, DateTimeKind.Utc).AddTicks(4336) });
        }
    }
}
