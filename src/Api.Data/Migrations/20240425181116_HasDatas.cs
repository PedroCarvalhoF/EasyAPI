using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class HasDatas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CategoriasPrecos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    DescricaoCategoria = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreateAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    UpdateAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Habilitado = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriasPrecos", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CategoriasProdutos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    DescricaoCategoria = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreateAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    UpdateAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Habilitado = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriasProdutos", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PeriodosPontosVendas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    DescricaoPeriodo = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreateAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    UpdateAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Habilitado = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeriodosPontosVendas", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ProdutosMedidas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Descricao = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreateAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    UpdateAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Habilitado = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdutosMedidas", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TiposProdutos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    DescricaoTipoProduto = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreateAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    UpdateAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Habilitado = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposProdutos", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    NomeProduto = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CodigoBarrasPersonalizado = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Descricao = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Observacoes = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CategoriaProdutoEntityId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ProdutoMedidaEntityId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ProdutoTipoEntityId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ImgUrl = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreateAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    UpdateAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Habilitado = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Produtos_CategoriasProdutos_CategoriaProdutoEntityId",
                        column: x => x.CategoriaProdutoEntityId,
                        principalTable: "CategoriasProdutos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Produtos_ProdutosMedidas_ProdutoMedidaEntityId",
                        column: x => x.ProdutoMedidaEntityId,
                        principalTable: "ProdutosMedidas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Produtos_TiposProdutos_ProdutoTipoEntityId",
                        column: x => x.ProdutoTipoEntityId,
                        principalTable: "TiposProdutos",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "CategoriasPrecos",
                columns: new[] { "Id", "CreateAt", "DescricaoCategoria", "Habilitado", "UpdateAt" },
                values: new object[,]
                {
                    { new Guid("5533b87c-72d5-4033-85c4-ae44f5a3210c"), new DateTime(2024, 4, 25, 15, 11, 16, 175, DateTimeKind.Local).AddTicks(386), "IFood", true, new DateTime(2024, 4, 25, 15, 11, 16, 175, DateTimeKind.Local).AddTicks(388) },
                    { new Guid("710bd8dd-1853-43a1-8708-ca1f259d71ad"), new DateTime(2024, 4, 25, 15, 11, 16, 175, DateTimeKind.Local).AddTicks(375), "Balcão", true, new DateTime(2024, 4, 25, 15, 11, 16, 175, DateTimeKind.Local).AddTicks(384) },
                    { new Guid("ed65a4e3-a0b0-40a7-b7ae-3397a965d924"), new DateTime(2024, 4, 25, 15, 11, 16, 175, DateTimeKind.Local).AddTicks(389), "Lojista", true, new DateTime(2024, 4, 25, 15, 11, 16, 175, DateTimeKind.Local).AddTicks(391) }
                });

            migrationBuilder.InsertData(
                table: "CategoriasProdutos",
                columns: new[] { "Id", "CreateAt", "DescricaoCategoria", "Habilitado", "UpdateAt" },
                values: new object[,]
                {
                    { new Guid("a9b05f16-71f0-4f77-a653-52c1a15b36bc"), new DateTime(2024, 4, 25, 18, 11, 16, 174, DateTimeKind.Utc).AddTicks(1363), "Executivos", true, new DateTime(2024, 4, 25, 18, 11, 16, 174, DateTimeKind.Utc).AddTicks(1359) },
                    { new Guid("d9d229c4-9a64-4836-af41-2f111f229c46"), new DateTime(2024, 4, 25, 18, 11, 16, 174, DateTimeKind.Utc).AddTicks(1382), "Bebidas", true, new DateTime(2024, 4, 25, 18, 11, 16, 174, DateTimeKind.Utc).AddTicks(1381) }
                });

            migrationBuilder.InsertData(
                table: "PeriodosPontosVendas",
                columns: new[] { "Id", "CreateAt", "DescricaoPeriodo", "Habilitado", "UpdateAt" },
                values: new object[,]
                {
                    { new Guid("567906bb-6eb4-42e9-b890-10e6da214766"), new DateTime(2024, 4, 25, 15, 11, 16, 174, DateTimeKind.Local).AddTicks(9495), "Almoço", true, new DateTime(2024, 4, 25, 15, 11, 16, 174, DateTimeKind.Local).AddTicks(9499) },
                    { new Guid("7e107de8-c97a-435b-9976-7a689ca28bb7"), new DateTime(2024, 4, 25, 15, 11, 16, 174, DateTimeKind.Local).AddTicks(9508), "Noturno", true, new DateTime(2024, 4, 25, 15, 11, 16, 174, DateTimeKind.Local).AddTicks(9510) },
                    { new Guid("f14c83df-1fa4-4a83-8070-b16ecb19aa77"), new DateTime(2024, 4, 25, 15, 11, 16, 174, DateTimeKind.Local).AddTicks(9506), "Dia Todo", true, new DateTime(2024, 4, 25, 15, 11, 16, 174, DateTimeKind.Local).AddTicks(9507) },
                    { new Guid("fc6a5d67-8356-4270-b9e6-7749b553dcf3"), new DateTime(2024, 4, 25, 15, 11, 16, 174, DateTimeKind.Local).AddTicks(9503), "Janta", true, new DateTime(2024, 4, 25, 15, 11, 16, 174, DateTimeKind.Local).AddTicks(9504) }
                });

            migrationBuilder.InsertData(
                table: "ProdutosMedidas",
                columns: new[] { "Id", "CreateAt", "Descricao", "Habilitado", "UpdateAt" },
                values: new object[,]
                {
                    { new Guid("2f943e86-f06f-4f7d-babf-48d0d2d8f3ac"), new DateTime(2024, 4, 25, 18, 11, 16, 174, DateTimeKind.Utc).AddTicks(2961), "Caixa", true, new DateTime(2024, 4, 25, 18, 11, 16, 174, DateTimeKind.Utc).AddTicks(2960) },
                    { new Guid("414a646f-1146-4b6d-bbfc-39a26e74a091"), new DateTime(2024, 4, 25, 18, 11, 16, 174, DateTimeKind.Utc).AddTicks(2954), "Unidade", true, new DateTime(2024, 4, 25, 18, 11, 16, 174, DateTimeKind.Utc).AddTicks(2953) }
                });

            migrationBuilder.InsertData(
                table: "TiposProdutos",
                columns: new[] { "Id", "CreateAt", "DescricaoTipoProduto", "Habilitado", "UpdateAt" },
                values: new object[,]
                {
                    { new Guid("1e11b25a-8bf5-4d57-80b7-396d09cbfcf1"), new DateTime(2024, 4, 25, 18, 11, 16, 174, DateTimeKind.Utc).AddTicks(2254), "Materia Prima", true, new DateTime(2024, 4, 25, 18, 11, 16, 174, DateTimeKind.Utc).AddTicks(2256) },
                    { new Guid("edddccfa-a4af-4831-b9ee-29bdd5f755af"), new DateTime(2024, 4, 25, 18, 11, 16, 174, DateTimeKind.Utc).AddTicks(2247), "Venda", true, new DateTime(2024, 4, 25, 18, 11, 16, 174, DateTimeKind.Utc).AddTicks(2253) }
                });

            migrationBuilder.InsertData(
                table: "Produtos",
                columns: new[] { "Id", "CategoriaProdutoEntityId", "CodigoBarrasPersonalizado", "CreateAt", "Descricao", "Habilitado", "ImgUrl", "NomeProduto", "Observacoes", "ProdutoMedidaEntityId", "ProdutoTipoEntityId", "UpdateAt" },
                values: new object[] { new Guid("f0e75a80-0b64-4b2b-9f53-f3dce3f6d126"), new Guid("a9b05f16-71f0-4f77-a653-52c1a15b36bc"), "01", new DateTime(2024, 4, 25, 15, 11, 16, 174, DateTimeKind.Local).AddTicks(8726), "", true, "", "Agua sem gas", "", new Guid("414a646f-1146-4b6d-bbfc-39a26e74a091"), new Guid("edddccfa-a4af-4831-b9ee-29bdd5f755af"), new DateTime(2024, 4, 25, 15, 11, 16, 174, DateTimeKind.Local).AddTicks(8742) });

            migrationBuilder.CreateIndex(
                name: "IX_CategoriasPrecos_DescricaoCategoria",
                table: "CategoriasPrecos",
                column: "DescricaoCategoria",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CategoriasProdutos_DescricaoCategoria",
                table: "CategoriasProdutos",
                column: "DescricaoCategoria",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PeriodosPontosVendas_DescricaoPeriodo",
                table: "PeriodosPontosVendas",
                column: "DescricaoPeriodo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_CategoriaProdutoEntityId",
                table: "Produtos",
                column: "CategoriaProdutoEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_CodigoBarrasPersonalizado",
                table: "Produtos",
                column: "CodigoBarrasPersonalizado",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_NomeProduto",
                table: "Produtos",
                column: "NomeProduto",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_ProdutoMedidaEntityId",
                table: "Produtos",
                column: "ProdutoMedidaEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_ProdutoTipoEntityId",
                table: "Produtos",
                column: "ProdutoTipoEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_ProdutosMedidas_Descricao",
                table: "ProdutosMedidas",
                column: "Descricao",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TiposProdutos_DescricaoTipoProduto",
                table: "TiposProdutos",
                column: "DescricaoTipoProduto",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoriasPrecos");

            migrationBuilder.DropTable(
                name: "PeriodosPontosVendas");

            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.DropTable(
                name: "CategoriasProdutos");

            migrationBuilder.DropTable(
                name: "ProdutosMedidas");

            migrationBuilder.DropTable(
                name: "TiposProdutos");
        }
    }
}
