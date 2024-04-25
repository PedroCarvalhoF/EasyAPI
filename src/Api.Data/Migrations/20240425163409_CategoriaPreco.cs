using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class CategoriaPreco : Migration
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
                    Descricao = table.Column<string>(type: "longtext", nullable: true)
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
                values: new object[] { new Guid("710bd8dd-1853-43a1-8708-ca1f259d71ad"), new DateTime(2024, 4, 25, 13, 34, 9, 623, DateTimeKind.Local).AddTicks(6693), "Balcão", true, new DateTime(2024, 4, 25, 13, 34, 9, 623, DateTimeKind.Local).AddTicks(6701) });

            migrationBuilder.InsertData(
                table: "CategoriasProdutos",
                columns: new[] { "Id", "CreateAt", "DescricaoCategoria", "Habilitado", "UpdateAt" },
                values: new object[,]
                {
                    { new Guid("a9b05f16-71f0-4f77-a653-52c1a15b36bc"), new DateTime(2024, 4, 25, 16, 34, 9, 622, DateTimeKind.Utc).AddTicks(8610), "Executivos", true, new DateTime(2024, 4, 25, 16, 34, 9, 622, DateTimeKind.Utc).AddTicks(8605) },
                    { new Guid("d9d229c4-9a64-4836-af41-2f111f229c46"), new DateTime(2024, 4, 25, 16, 34, 9, 622, DateTimeKind.Utc).AddTicks(8629), "Bebidas", true, new DateTime(2024, 4, 25, 16, 34, 9, 622, DateTimeKind.Utc).AddTicks(8629) }
                });

            migrationBuilder.InsertData(
                table: "PeriodosPontosVendas",
                columns: new[] { "Id", "CreateAt", "DescricaoPeriodo", "Habilitado", "UpdateAt" },
                values: new object[,]
                {
                    { new Guid("567906bb-6eb4-42e9-b890-10e6da214766"), new DateTime(2024, 4, 25, 13, 34, 9, 623, DateTimeKind.Local).AddTicks(5679), "Almoço", true, new DateTime(2024, 4, 25, 13, 34, 9, 623, DateTimeKind.Local).AddTicks(5695) },
                    { new Guid("7e107de8-c97a-435b-9976-7a689ca28bb7"), new DateTime(2024, 4, 25, 13, 34, 9, 623, DateTimeKind.Local).AddTicks(5707), "Noturno", true, new DateTime(2024, 4, 25, 13, 34, 9, 623, DateTimeKind.Local).AddTicks(5708) },
                    { new Guid("f14c83df-1fa4-4a83-8070-b16ecb19aa77"), new DateTime(2024, 4, 25, 13, 34, 9, 623, DateTimeKind.Local).AddTicks(5704), "Dia Todo", true, new DateTime(2024, 4, 25, 13, 34, 9, 623, DateTimeKind.Local).AddTicks(5705) },
                    { new Guid("fc6a5d67-8356-4270-b9e6-7749b553dcf3"), new DateTime(2024, 4, 25, 13, 34, 9, 623, DateTimeKind.Local).AddTicks(5699), "Janta", true, new DateTime(2024, 4, 25, 13, 34, 9, 623, DateTimeKind.Local).AddTicks(5700) }
                });

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
