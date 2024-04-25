using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class PeriodoPontoVendaEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CategoriasProdutos",
                keyColumn: "Id",
                keyValue: new Guid("1c8dd23e-47df-4c61-896c-8f8edca9d644"));

            migrationBuilder.DeleteData(
                table: "CategoriasProdutos",
                keyColumn: "Id",
                keyValue: new Guid("2d4f8523-e39e-4238-8b64-812bec73b76b"));

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

            migrationBuilder.UpdateData(
                table: "CategoriasProdutos",
                keyColumn: "Id",
                keyValue: new Guid("6fb282e9-6ee8-44d9-a049-994f68bd0b27"),
                column: "CreateAt",
                value: new DateTime(2024, 4, 25, 11, 41, 33, 608, DateTimeKind.Local).AddTicks(4011));

            migrationBuilder.InsertData(
                table: "CategoriasProdutos",
                columns: new[] { "Id", "CreateAt", "DescricaoCategoria", "Habilitado", "UpdateAt" },
                values: new object[,]
                {
                    { new Guid("092e837f-9cec-453f-9625-699466b59854"), new DateTime(2024, 4, 25, 11, 41, 33, 608, DateTimeKind.Local).AddTicks(4020), "Promoções", true, null },
                    { new Guid("c1b6478c-a47d-4962-971a-c65228d128b3"), new DateTime(2024, 4, 25, 11, 41, 33, 608, DateTimeKind.Local).AddTicks(4052), "Executivos", true, null }
                });

            migrationBuilder.UpdateData(
                table: "FormasPagamentos",
                keyColumn: "Id",
                keyValue: new Guid("18e68a14-54b5-44b6-87ed-e8b0258d9c1d"),
                column: "CreateAt",
                value: new DateTime(2024, 4, 25, 11, 41, 33, 608, DateTimeKind.Local).AddTicks(4177));

            migrationBuilder.UpdateData(
                table: "FormasPagamentos",
                keyColumn: "Id",
                keyValue: new Guid("249c0c31-ee8e-487b-b4c9-1f14ced84553"),
                column: "CreateAt",
                value: new DateTime(2024, 4, 25, 11, 41, 33, 608, DateTimeKind.Local).AddTicks(4172));

            migrationBuilder.UpdateData(
                table: "FormasPagamentos",
                keyColumn: "Id",
                keyValue: new Guid("46152359-216e-4b2e-827c-411092ecc423"),
                column: "CreateAt",
                value: new DateTime(2024, 4, 25, 11, 41, 33, 608, DateTimeKind.Local).AddTicks(4188));

            migrationBuilder.UpdateData(
                table: "FormasPagamentos",
                keyColumn: "Id",
                keyValue: new Guid("7aaecde9-7290-48e7-bf31-f8dab886381f"),
                column: "CreateAt",
                value: new DateTime(2024, 4, 25, 11, 41, 33, 608, DateTimeKind.Local).AddTicks(4200));

            migrationBuilder.UpdateData(
                table: "FormasPagamentos",
                keyColumn: "Id",
                keyValue: new Guid("935f9721-bcc2-4239-88a1-2e0c9b1a75f6"),
                column: "CreateAt",
                value: new DateTime(2024, 4, 25, 11, 41, 33, 608, DateTimeKind.Local).AddTicks(4193));

            migrationBuilder.UpdateData(
                table: "FormasPagamentos",
                keyColumn: "Id",
                keyValue: new Guid("ac336bfb-39eb-4da0-9b04-c159f0068676"),
                column: "CreateAt",
                value: new DateTime(2024, 4, 25, 11, 41, 33, 608, DateTimeKind.Local).AddTicks(4180));

            migrationBuilder.UpdateData(
                table: "FormasPagamentos",
                keyColumn: "Id",
                keyValue: new Guid("cdd1b70b-5c96-472e-a983-3abdcc318c53"),
                column: "CreateAt",
                value: new DateTime(2024, 4, 25, 11, 41, 33, 608, DateTimeKind.Local).AddTicks(4191));

            migrationBuilder.UpdateData(
                table: "FormasPagamentos",
                keyColumn: "Id",
                keyValue: new Guid("d276bcd0-e552-46d4-af7a-390a3af0eb37"),
                column: "CreateAt",
                value: new DateTime(2024, 4, 25, 11, 41, 33, 608, DateTimeKind.Local).AddTicks(4185));

            migrationBuilder.UpdateData(
                table: "FormasPagamentos",
                keyColumn: "Id",
                keyValue: new Guid("e93ceba1-40f8-4420-8dc3-bb1b3ee6ee9f"),
                column: "CreateAt",
                value: new DateTime(2024, 4, 25, 11, 41, 33, 608, DateTimeKind.Local).AddTicks(4197));

            migrationBuilder.InsertData(
                table: "PeriodosPontosVendas",
                columns: new[] { "Id", "CreateAt", "DescricaoPeriodo", "Habilitado", "UpdateAt" },
                values: new object[,]
                {
                    { new Guid("567906bb-6eb4-42e9-b890-10e6da214766"), new DateTime(2024, 4, 25, 11, 41, 33, 608, DateTimeKind.Local).AddTicks(3539), "Almoço", true, new DateTime(2024, 4, 25, 11, 41, 33, 608, DateTimeKind.Local).AddTicks(3553) },
                    { new Guid("7e107de8-c97a-435b-9976-7a689ca28bb7"), new DateTime(2024, 4, 25, 11, 41, 33, 608, DateTimeKind.Local).AddTicks(3568), "Noturno", true, new DateTime(2024, 4, 25, 11, 41, 33, 608, DateTimeKind.Local).AddTicks(3569) },
                    { new Guid("f14c83df-1fa4-4a83-8070-b16ecb19aa77"), new DateTime(2024, 4, 25, 11, 41, 33, 608, DateTimeKind.Local).AddTicks(3564), "Dia Todo", true, new DateTime(2024, 4, 25, 11, 41, 33, 608, DateTimeKind.Local).AddTicks(3565) },
                    { new Guid("fc6a5d67-8356-4270-b9e6-7749b553dcf3"), new DateTime(2024, 4, 25, 11, 41, 33, 608, DateTimeKind.Local).AddTicks(3559), "Janta", true, new DateTime(2024, 4, 25, 11, 41, 33, 608, DateTimeKind.Local).AddTicks(3561) }
                });

            migrationBuilder.UpdateData(
                table: "PessoasTipos",
                keyColumn: "Id",
                keyValue: new Guid("2cc73259-4063-4f20-9c21-34ff2a9cbd58"),
                column: "CreateAt",
                value: new DateTime(2024, 4, 25, 11, 41, 33, 608, DateTimeKind.Local).AddTicks(4249));

            migrationBuilder.UpdateData(
                table: "PessoasTipos",
                keyColumn: "Id",
                keyValue: new Guid("a58b678c-07d4-417b-929b-600dc63858ea"),
                column: "CreateAt",
                value: new DateTime(2024, 4, 25, 11, 41, 33, 608, DateTimeKind.Local).AddTicks(4246));

            migrationBuilder.UpdateData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: new Guid("d2a0c172-e742-4e54-a806-938ddaaf8edb"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 25, 11, 41, 33, 608, DateTimeKind.Local).AddTicks(4131), new DateTime(2024, 4, 25, 11, 41, 33, 608, DateTimeKind.Local).AddTicks(4140) });

            migrationBuilder.UpdateData(
                table: "ProdutosMedidas",
                keyColumn: "Id",
                keyValue: new Guid("05b3382d-0940-446a-8c2c-3e27293cf77d"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 25, 11, 41, 33, 608, DateTimeKind.Local).AddTicks(4293), new DateTime(2024, 4, 25, 11, 41, 33, 608, DateTimeKind.Local).AddTicks(4295) });

            migrationBuilder.UpdateData(
                table: "ProdutosMedidas",
                keyColumn: "Id",
                keyValue: new Guid("9bbe9cc9-ba40-4bb3-9b71-74a8234133a5"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 25, 11, 41, 33, 608, DateTimeKind.Local).AddTicks(4290), new DateTime(2024, 4, 25, 11, 41, 33, 608, DateTimeKind.Local).AddTicks(4291) });

            migrationBuilder.UpdateData(
                table: "ProdutosMedidas",
                keyColumn: "Id",
                keyValue: new Guid("cc8119c5-7651-4708-bba4-8f350726bdac"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 25, 11, 41, 33, 608, DateTimeKind.Local).AddTicks(4285), new DateTime(2024, 4, 25, 11, 41, 33, 608, DateTimeKind.Local).AddTicks(4286) });

            migrationBuilder.UpdateData(
                table: "TiposProdutos",
                keyColumn: "Id",
                keyValue: new Guid("2491c7e2-10ec-48a4-8898-44e24814f23d"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 25, 11, 41, 33, 608, DateTimeKind.Local).AddTicks(4329), new DateTime(2024, 4, 25, 11, 41, 33, 608, DateTimeKind.Local).AddTicks(4330) });

            migrationBuilder.UpdateData(
                table: "TiposProdutos",
                keyColumn: "Id",
                keyValue: new Guid("3cca7caf-8a98-40b2-9f20-3f864f59e1c5"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 25, 11, 41, 33, 608, DateTimeKind.Local).AddTicks(4334), new DateTime(2024, 4, 25, 11, 41, 33, 608, DateTimeKind.Local).AddTicks(4335) });

            migrationBuilder.UpdateData(
                table: "TiposProdutos",
                keyColumn: "Id",
                keyValue: new Guid("59de4011-1ca7-4a52-833c-9672a03320ac"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 25, 11, 41, 33, 608, DateTimeKind.Local).AddTicks(4338), new DateTime(2024, 4, 25, 11, 41, 33, 608, DateTimeKind.Local).AddTicks(4339) });

            migrationBuilder.CreateIndex(
                name: "IX_PeriodosPontosVendas_DescricaoPeriodo",
                table: "PeriodosPontosVendas",
                column: "DescricaoPeriodo",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PeriodosPontosVendas");

            migrationBuilder.DeleteData(
                table: "CategoriasProdutos",
                keyColumn: "Id",
                keyValue: new Guid("092e837f-9cec-453f-9625-699466b59854"));

            migrationBuilder.DeleteData(
                table: "CategoriasProdutos",
                keyColumn: "Id",
                keyValue: new Guid("c1b6478c-a47d-4962-971a-c65228d128b3"));

            migrationBuilder.UpdateData(
                table: "CategoriasProdutos",
                keyColumn: "Id",
                keyValue: new Guid("6fb282e9-6ee8-44d9-a049-994f68bd0b27"),
                column: "CreateAt",
                value: new DateTime(2024, 4, 22, 19, 18, 50, 380, DateTimeKind.Local).AddTicks(8312));

            migrationBuilder.InsertData(
                table: "CategoriasProdutos",
                columns: new[] { "Id", "CreateAt", "DescricaoCategoria", "Habilitado", "UpdateAt" },
                values: new object[,]
                {
                    { new Guid("1c8dd23e-47df-4c61-896c-8f8edca9d644"), new DateTime(2024, 4, 22, 19, 18, 50, 380, DateTimeKind.Local).AddTicks(8391), "Executivos", true, null },
                    { new Guid("2d4f8523-e39e-4238-8b64-812bec73b76b"), new DateTime(2024, 4, 22, 19, 18, 50, 380, DateTimeKind.Local).AddTicks(8357), "Promoções", true, null }
                });

            migrationBuilder.UpdateData(
                table: "FormasPagamentos",
                keyColumn: "Id",
                keyValue: new Guid("18e68a14-54b5-44b6-87ed-e8b0258d9c1d"),
                column: "CreateAt",
                value: new DateTime(2024, 4, 22, 19, 18, 50, 380, DateTimeKind.Local).AddTicks(8921));

            migrationBuilder.UpdateData(
                table: "FormasPagamentos",
                keyColumn: "Id",
                keyValue: new Guid("249c0c31-ee8e-487b-b4c9-1f14ced84553"),
                column: "CreateAt",
                value: new DateTime(2024, 4, 22, 19, 18, 50, 380, DateTimeKind.Local).AddTicks(8911));

            migrationBuilder.UpdateData(
                table: "FormasPagamentos",
                keyColumn: "Id",
                keyValue: new Guid("46152359-216e-4b2e-827c-411092ecc423"),
                column: "CreateAt",
                value: new DateTime(2024, 4, 22, 19, 18, 50, 380, DateTimeKind.Local).AddTicks(8930));

            migrationBuilder.UpdateData(
                table: "FormasPagamentos",
                keyColumn: "Id",
                keyValue: new Guid("7aaecde9-7290-48e7-bf31-f8dab886381f"),
                column: "CreateAt",
                value: new DateTime(2024, 4, 22, 19, 18, 50, 380, DateTimeKind.Local).AddTicks(8953));

            migrationBuilder.UpdateData(
                table: "FormasPagamentos",
                keyColumn: "Id",
                keyValue: new Guid("935f9721-bcc2-4239-88a1-2e0c9b1a75f6"),
                column: "CreateAt",
                value: new DateTime(2024, 4, 22, 19, 18, 50, 380, DateTimeKind.Local).AddTicks(8936));

            migrationBuilder.UpdateData(
                table: "FormasPagamentos",
                keyColumn: "Id",
                keyValue: new Guid("ac336bfb-39eb-4da0-9b04-c159f0068676"),
                column: "CreateAt",
                value: new DateTime(2024, 4, 22, 19, 18, 50, 380, DateTimeKind.Local).AddTicks(8924));

            migrationBuilder.UpdateData(
                table: "FormasPagamentos",
                keyColumn: "Id",
                keyValue: new Guid("cdd1b70b-5c96-472e-a983-3abdcc318c53"),
                column: "CreateAt",
                value: new DateTime(2024, 4, 22, 19, 18, 50, 380, DateTimeKind.Local).AddTicks(8933));

            migrationBuilder.UpdateData(
                table: "FormasPagamentos",
                keyColumn: "Id",
                keyValue: new Guid("d276bcd0-e552-46d4-af7a-390a3af0eb37"),
                column: "CreateAt",
                value: new DateTime(2024, 4, 22, 19, 18, 50, 380, DateTimeKind.Local).AddTicks(8927));

            migrationBuilder.UpdateData(
                table: "FormasPagamentos",
                keyColumn: "Id",
                keyValue: new Guid("e93ceba1-40f8-4420-8dc3-bb1b3ee6ee9f"),
                column: "CreateAt",
                value: new DateTime(2024, 4, 22, 19, 18, 50, 380, DateTimeKind.Local).AddTicks(8939));

            migrationBuilder.UpdateData(
                table: "PessoasTipos",
                keyColumn: "Id",
                keyValue: new Guid("2cc73259-4063-4f20-9c21-34ff2a9cbd58"),
                column: "CreateAt",
                value: new DateTime(2024, 4, 22, 19, 18, 50, 380, DateTimeKind.Local).AddTicks(9016));

            migrationBuilder.UpdateData(
                table: "PessoasTipos",
                keyColumn: "Id",
                keyValue: new Guid("a58b678c-07d4-417b-929b-600dc63858ea"),
                column: "CreateAt",
                value: new DateTime(2024, 4, 22, 19, 18, 50, 380, DateTimeKind.Local).AddTicks(9012));

            migrationBuilder.UpdateData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: new Guid("d2a0c172-e742-4e54-a806-938ddaaf8edb"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 22, 19, 18, 50, 380, DateTimeKind.Local).AddTicks(8854), new DateTime(2024, 4, 22, 19, 18, 50, 380, DateTimeKind.Local).AddTicks(8864) });

            migrationBuilder.UpdateData(
                table: "ProdutosMedidas",
                keyColumn: "Id",
                keyValue: new Guid("05b3382d-0940-446a-8c2c-3e27293cf77d"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 22, 19, 18, 50, 380, DateTimeKind.Local).AddTicks(9062), new DateTime(2024, 4, 22, 19, 18, 50, 380, DateTimeKind.Local).AddTicks(9063) });

            migrationBuilder.UpdateData(
                table: "ProdutosMedidas",
                keyColumn: "Id",
                keyValue: new Guid("9bbe9cc9-ba40-4bb3-9b71-74a8234133a5"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 22, 19, 18, 50, 380, DateTimeKind.Local).AddTicks(9058), new DateTime(2024, 4, 22, 19, 18, 50, 380, DateTimeKind.Local).AddTicks(9059) });

            migrationBuilder.UpdateData(
                table: "ProdutosMedidas",
                keyColumn: "Id",
                keyValue: new Guid("cc8119c5-7651-4708-bba4-8f350726bdac"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 22, 19, 18, 50, 380, DateTimeKind.Local).AddTicks(9050), new DateTime(2024, 4, 22, 19, 18, 50, 380, DateTimeKind.Local).AddTicks(9051) });

            migrationBuilder.UpdateData(
                table: "TiposProdutos",
                keyColumn: "Id",
                keyValue: new Guid("2491c7e2-10ec-48a4-8898-44e24814f23d"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 22, 19, 18, 50, 380, DateTimeKind.Local).AddTicks(9098), new DateTime(2024, 4, 22, 19, 18, 50, 380, DateTimeKind.Local).AddTicks(9099) });

            migrationBuilder.UpdateData(
                table: "TiposProdutos",
                keyColumn: "Id",
                keyValue: new Guid("3cca7caf-8a98-40b2-9f20-3f864f59e1c5"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 22, 19, 18, 50, 380, DateTimeKind.Local).AddTicks(9103), new DateTime(2024, 4, 22, 19, 18, 50, 380, DateTimeKind.Local).AddTicks(9104) });

            migrationBuilder.UpdateData(
                table: "TiposProdutos",
                keyColumn: "Id",
                keyValue: new Guid("59de4011-1ca7-4a52-833c-9672a03320ac"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 22, 19, 18, 50, 380, DateTimeKind.Local).AddTicks(9107), new DateTime(2024, 4, 22, 19, 18, 50, 380, DateTimeKind.Local).AddTicks(9108) });
        }
    }
}
