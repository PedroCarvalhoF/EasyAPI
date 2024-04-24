using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class SituacaoPedido : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_SituacaoPedidoEntity_SituacaoPedidoEntityId",
                table: "Pedidos");

            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_ProdutoMedidas_ProdutoMedidaEntityId",
                table: "Produtos");

            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_ProdutoTipoEntity_ProdutoTipoEntityId",
                table: "Produtos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SituacaoPedidoEntity",
                table: "SituacaoPedidoEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProdutoTipoEntity",
                table: "ProdutoTipoEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProdutoMedidas",
                table: "ProdutoMedidas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Filias",
                table: "Filias");

            migrationBuilder.DeleteData(
                table: "CategoriasProdutos",
                keyColumn: "Id",
                keyValue: new Guid("8666313b-bb19-462a-9659-79d6b5c7059e"));

            migrationBuilder.DeleteData(
                table: "CategoriasProdutos",
                keyColumn: "Id",
                keyValue: new Guid("89d8c87f-b473-485e-90a3-d193dcac7e16"));

            migrationBuilder.RenameTable(
                name: "SituacaoPedidoEntity",
                newName: "SituacoesPedidos");

            migrationBuilder.RenameTable(
                name: "ProdutoTipoEntity",
                newName: "TiposProdutos");

            migrationBuilder.RenameTable(
                name: "ProdutoMedidas",
                newName: "ProdutosMedidas");

            migrationBuilder.RenameTable(
                name: "Filias",
                newName: "Filiais");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SituacoesPedidos",
                table: "SituacoesPedidos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TiposProdutos",
                table: "TiposProdutos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProdutosMedidas",
                table: "ProdutosMedidas",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Filiais",
                table: "Filiais",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "CategoriasProdutos",
                keyColumn: "Id",
                keyValue: new Guid("6fb282e9-6ee8-44d9-a049-994f68bd0b27"),
                column: "CreateAt",
                value: new DateTime(2024, 4, 20, 13, 56, 58, 451, DateTimeKind.Local).AddTicks(6266));

            migrationBuilder.InsertData(
                table: "CategoriasProdutos",
                columns: new[] { "Id", "CreateAt", "DescricaoCategoria", "Habilitado", "UpdateAt" },
                values: new object[,]
                {
                    { new Guid("45fda62b-ca78-4cc5-bf07-660b2feeae9a"), new DateTime(2024, 4, 20, 13, 56, 58, 451, DateTimeKind.Local).AddTicks(6348), "Executivos", true, null },
                    { new Guid("9ec82e6b-d699-4cfc-bba0-354dcfd6ed6e"), new DateTime(2024, 4, 20, 13, 56, 58, 451, DateTimeKind.Local).AddTicks(6307), "Promoções", true, null }
                });

            migrationBuilder.UpdateData(
                table: "FormasPagamentos",
                keyColumn: "Id",
                keyValue: new Guid("18e68a14-54b5-44b6-87ed-e8b0258d9c1d"),
                column: "CreateAt",
                value: new DateTime(2024, 4, 20, 13, 56, 58, 451, DateTimeKind.Local).AddTicks(6604));

            migrationBuilder.UpdateData(
                table: "FormasPagamentos",
                keyColumn: "Id",
                keyValue: new Guid("249c0c31-ee8e-487b-b4c9-1f14ced84553"),
                column: "CreateAt",
                value: new DateTime(2024, 4, 20, 13, 56, 58, 451, DateTimeKind.Local).AddTicks(6601));

            migrationBuilder.UpdateData(
                table: "FormasPagamentos",
                keyColumn: "Id",
                keyValue: new Guid("46152359-216e-4b2e-827c-411092ecc423"),
                column: "CreateAt",
                value: new DateTime(2024, 4, 20, 13, 56, 58, 451, DateTimeKind.Local).AddTicks(6611));

            migrationBuilder.UpdateData(
                table: "FormasPagamentos",
                keyColumn: "Id",
                keyValue: new Guid("7aaecde9-7290-48e7-bf31-f8dab886381f"),
                column: "CreateAt",
                value: new DateTime(2024, 4, 20, 13, 56, 58, 451, DateTimeKind.Local).AddTicks(6620));

            migrationBuilder.UpdateData(
                table: "FormasPagamentos",
                keyColumn: "Id",
                keyValue: new Guid("935f9721-bcc2-4239-88a1-2e0c9b1a75f6"),
                column: "CreateAt",
                value: new DateTime(2024, 4, 20, 13, 56, 58, 451, DateTimeKind.Local).AddTicks(6616));

            migrationBuilder.UpdateData(
                table: "FormasPagamentos",
                keyColumn: "Id",
                keyValue: new Guid("ac336bfb-39eb-4da0-9b04-c159f0068676"),
                column: "CreateAt",
                value: new DateTime(2024, 4, 20, 13, 56, 58, 451, DateTimeKind.Local).AddTicks(6607));

            migrationBuilder.UpdateData(
                table: "FormasPagamentos",
                keyColumn: "Id",
                keyValue: new Guid("cdd1b70b-5c96-472e-a983-3abdcc318c53"),
                column: "CreateAt",
                value: new DateTime(2024, 4, 20, 13, 56, 58, 451, DateTimeKind.Local).AddTicks(6613));

            migrationBuilder.UpdateData(
                table: "FormasPagamentos",
                keyColumn: "Id",
                keyValue: new Guid("d276bcd0-e552-46d4-af7a-390a3af0eb37"),
                column: "CreateAt",
                value: new DateTime(2024, 4, 20, 13, 56, 58, 451, DateTimeKind.Local).AddTicks(6609));

            migrationBuilder.UpdateData(
                table: "FormasPagamentos",
                keyColumn: "Id",
                keyValue: new Guid("e93ceba1-40f8-4420-8dc3-bb1b3ee6ee9f"),
                column: "CreateAt",
                value: new DateTime(2024, 4, 20, 13, 56, 58, 451, DateTimeKind.Local).AddTicks(6618));

            migrationBuilder.UpdateData(
                table: "PessoasTipos",
                keyColumn: "Id",
                keyValue: new Guid("2cc73259-4063-4f20-9c21-34ff2a9cbd58"),
                column: "CreateAt",
                value: new DateTime(2024, 4, 20, 13, 56, 58, 451, DateTimeKind.Local).AddTicks(6652));

            migrationBuilder.UpdateData(
                table: "PessoasTipos",
                keyColumn: "Id",
                keyValue: new Guid("a58b678c-07d4-417b-929b-600dc63858ea"),
                column: "CreateAt",
                value: new DateTime(2024, 4, 20, 13, 56, 58, 451, DateTimeKind.Local).AddTicks(6650));

            migrationBuilder.UpdateData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: new Guid("d2a0c172-e742-4e54-a806-938ddaaf8edb"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 20, 13, 56, 58, 451, DateTimeKind.Local).AddTicks(6568), new DateTime(2024, 4, 20, 13, 56, 58, 451, DateTimeKind.Local).AddTicks(6576) });

            migrationBuilder.UpdateData(
                table: "ProdutosMedidas",
                keyColumn: "Id",
                keyValue: new Guid("05b3382d-0940-446a-8c2c-3e27293cf77d"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 20, 13, 56, 58, 451, DateTimeKind.Local).AddTicks(6694), new DateTime(2024, 4, 20, 13, 56, 58, 451, DateTimeKind.Local).AddTicks(6695) });

            migrationBuilder.UpdateData(
                table: "ProdutosMedidas",
                keyColumn: "Id",
                keyValue: new Guid("9bbe9cc9-ba40-4bb3-9b71-74a8234133a5"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 20, 13, 56, 58, 451, DateTimeKind.Local).AddTicks(6692), new DateTime(2024, 4, 20, 13, 56, 58, 451, DateTimeKind.Local).AddTicks(6692) });

            migrationBuilder.UpdateData(
                table: "ProdutosMedidas",
                keyColumn: "Id",
                keyValue: new Guid("cc8119c5-7651-4708-bba4-8f350726bdac"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 20, 13, 56, 58, 451, DateTimeKind.Local).AddTicks(6687), new DateTime(2024, 4, 20, 13, 56, 58, 451, DateTimeKind.Local).AddTicks(6688) });

            migrationBuilder.UpdateData(
                table: "TiposProdutos",
                keyColumn: "Id",
                keyValue: new Guid("2491c7e2-10ec-48a4-8898-44e24814f23d"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 20, 13, 56, 58, 451, DateTimeKind.Local).AddTicks(6721), new DateTime(2024, 4, 20, 13, 56, 58, 451, DateTimeKind.Local).AddTicks(6722) });

            migrationBuilder.UpdateData(
                table: "TiposProdutos",
                keyColumn: "Id",
                keyValue: new Guid("3cca7caf-8a98-40b2-9f20-3f864f59e1c5"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 20, 13, 56, 58, 451, DateTimeKind.Local).AddTicks(6725), new DateTime(2024, 4, 20, 13, 56, 58, 451, DateTimeKind.Local).AddTicks(6725) });

            migrationBuilder.UpdateData(
                table: "TiposProdutos",
                keyColumn: "Id",
                keyValue: new Guid("59de4011-1ca7-4a52-833c-9672a03320ac"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 20, 13, 56, 58, 451, DateTimeKind.Local).AddTicks(6727), new DateTime(2024, 4, 20, 13, 56, 58, 451, DateTimeKind.Local).AddTicks(6728) });

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_SituacoesPedidos_SituacaoPedidoEntityId",
                table: "Pedidos",
                column: "SituacaoPedidoEntityId",
                principalTable: "SituacoesPedidos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_ProdutosMedidas_ProdutoMedidaEntityId",
                table: "Produtos",
                column: "ProdutoMedidaEntityId",
                principalTable: "ProdutosMedidas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_TiposProdutos_ProdutoTipoEntityId",
                table: "Produtos",
                column: "ProdutoTipoEntityId",
                principalTable: "TiposProdutos",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_SituacoesPedidos_SituacaoPedidoEntityId",
                table: "Pedidos");

            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_ProdutosMedidas_ProdutoMedidaEntityId",
                table: "Produtos");

            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_TiposProdutos_ProdutoTipoEntityId",
                table: "Produtos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TiposProdutos",
                table: "TiposProdutos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SituacoesPedidos",
                table: "SituacoesPedidos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProdutosMedidas",
                table: "ProdutosMedidas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Filiais",
                table: "Filiais");

            migrationBuilder.DeleteData(
                table: "CategoriasProdutos",
                keyColumn: "Id",
                keyValue: new Guid("45fda62b-ca78-4cc5-bf07-660b2feeae9a"));

            migrationBuilder.DeleteData(
                table: "CategoriasProdutos",
                keyColumn: "Id",
                keyValue: new Guid("9ec82e6b-d699-4cfc-bba0-354dcfd6ed6e"));

            migrationBuilder.RenameTable(
                name: "TiposProdutos",
                newName: "ProdutoTipoEntity");

            migrationBuilder.RenameTable(
                name: "SituacoesPedidos",
                newName: "SituacaoPedidoEntity");

            migrationBuilder.RenameTable(
                name: "ProdutosMedidas",
                newName: "ProdutoMedidas");

            migrationBuilder.RenameTable(
                name: "Filiais",
                newName: "Filias");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProdutoTipoEntity",
                table: "ProdutoTipoEntity",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SituacaoPedidoEntity",
                table: "SituacaoPedidoEntity",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProdutoMedidas",
                table: "ProdutoMedidas",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Filias",
                table: "Filias",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "CategoriasProdutos",
                keyColumn: "Id",
                keyValue: new Guid("6fb282e9-6ee8-44d9-a049-994f68bd0b27"),
                column: "CreateAt",
                value: new DateTime(2024, 4, 20, 13, 51, 57, 174, DateTimeKind.Local).AddTicks(3271));

            migrationBuilder.InsertData(
                table: "CategoriasProdutos",
                columns: new[] { "Id", "CreateAt", "DescricaoCategoria", "Habilitado", "UpdateAt" },
                values: new object[,]
                {
                    { new Guid("8666313b-bb19-462a-9659-79d6b5c7059e"), new DateTime(2024, 4, 20, 13, 51, 57, 174, DateTimeKind.Local).AddTicks(3351), "Executivos", true, null },
                    { new Guid("89d8c87f-b473-485e-90a3-d193dcac7e16"), new DateTime(2024, 4, 20, 13, 51, 57, 174, DateTimeKind.Local).AddTicks(3321), "Promoções", true, null }
                });

            migrationBuilder.UpdateData(
                table: "FormasPagamentos",
                keyColumn: "Id",
                keyValue: new Guid("18e68a14-54b5-44b6-87ed-e8b0258d9c1d"),
                column: "CreateAt",
                value: new DateTime(2024, 4, 20, 13, 51, 57, 174, DateTimeKind.Local).AddTicks(3955));

            migrationBuilder.UpdateData(
                table: "FormasPagamentos",
                keyColumn: "Id",
                keyValue: new Guid("249c0c31-ee8e-487b-b4c9-1f14ced84553"),
                column: "CreateAt",
                value: new DateTime(2024, 4, 20, 13, 51, 57, 174, DateTimeKind.Local).AddTicks(3951));

            migrationBuilder.UpdateData(
                table: "FormasPagamentos",
                keyColumn: "Id",
                keyValue: new Guid("46152359-216e-4b2e-827c-411092ecc423"),
                column: "CreateAt",
                value: new DateTime(2024, 4, 20, 13, 51, 57, 174, DateTimeKind.Local).AddTicks(3963));

            migrationBuilder.UpdateData(
                table: "FormasPagamentos",
                keyColumn: "Id",
                keyValue: new Guid("7aaecde9-7290-48e7-bf31-f8dab886381f"),
                column: "CreateAt",
                value: new DateTime(2024, 4, 20, 13, 51, 57, 174, DateTimeKind.Local).AddTicks(3974));

            migrationBuilder.UpdateData(
                table: "FormasPagamentos",
                keyColumn: "Id",
                keyValue: new Guid("935f9721-bcc2-4239-88a1-2e0c9b1a75f6"),
                column: "CreateAt",
                value: new DateTime(2024, 4, 20, 13, 51, 57, 174, DateTimeKind.Local).AddTicks(3968));

            migrationBuilder.UpdateData(
                table: "FormasPagamentos",
                keyColumn: "Id",
                keyValue: new Guid("ac336bfb-39eb-4da0-9b04-c159f0068676"),
                column: "CreateAt",
                value: new DateTime(2024, 4, 20, 13, 51, 57, 174, DateTimeKind.Local).AddTicks(3958));

            migrationBuilder.UpdateData(
                table: "FormasPagamentos",
                keyColumn: "Id",
                keyValue: new Guid("cdd1b70b-5c96-472e-a983-3abdcc318c53"),
                column: "CreateAt",
                value: new DateTime(2024, 4, 20, 13, 51, 57, 174, DateTimeKind.Local).AddTicks(3966));

            migrationBuilder.UpdateData(
                table: "FormasPagamentos",
                keyColumn: "Id",
                keyValue: new Guid("d276bcd0-e552-46d4-af7a-390a3af0eb37"),
                column: "CreateAt",
                value: new DateTime(2024, 4, 20, 13, 51, 57, 174, DateTimeKind.Local).AddTicks(3960));

            migrationBuilder.UpdateData(
                table: "FormasPagamentos",
                keyColumn: "Id",
                keyValue: new Guid("e93ceba1-40f8-4420-8dc3-bb1b3ee6ee9f"),
                column: "CreateAt",
                value: new DateTime(2024, 4, 20, 13, 51, 57, 174, DateTimeKind.Local).AddTicks(3971));

            migrationBuilder.UpdateData(
                table: "PessoasTipos",
                keyColumn: "Id",
                keyValue: new Guid("2cc73259-4063-4f20-9c21-34ff2a9cbd58"),
                column: "CreateAt",
                value: new DateTime(2024, 4, 20, 13, 51, 57, 174, DateTimeKind.Local).AddTicks(4067));

            migrationBuilder.UpdateData(
                table: "PessoasTipos",
                keyColumn: "Id",
                keyValue: new Guid("a58b678c-07d4-417b-929b-600dc63858ea"),
                column: "CreateAt",
                value: new DateTime(2024, 4, 20, 13, 51, 57, 174, DateTimeKind.Local).AddTicks(4063));

            migrationBuilder.UpdateData(
                table: "ProdutoMedidas",
                keyColumn: "Id",
                keyValue: new Guid("05b3382d-0940-446a-8c2c-3e27293cf77d"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 20, 13, 51, 57, 174, DateTimeKind.Local).AddTicks(4144), new DateTime(2024, 4, 20, 13, 51, 57, 174, DateTimeKind.Local).AddTicks(4145) });

            migrationBuilder.UpdateData(
                table: "ProdutoMedidas",
                keyColumn: "Id",
                keyValue: new Guid("9bbe9cc9-ba40-4bb3-9b71-74a8234133a5"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 20, 13, 51, 57, 174, DateTimeKind.Local).AddTicks(4139), new DateTime(2024, 4, 20, 13, 51, 57, 174, DateTimeKind.Local).AddTicks(4140) });

            migrationBuilder.UpdateData(
                table: "ProdutoMedidas",
                keyColumn: "Id",
                keyValue: new Guid("cc8119c5-7651-4708-bba4-8f350726bdac"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 20, 13, 51, 57, 174, DateTimeKind.Local).AddTicks(4134), new DateTime(2024, 4, 20, 13, 51, 57, 174, DateTimeKind.Local).AddTicks(4136) });

            migrationBuilder.UpdateData(
                table: "ProdutoTipoEntity",
                keyColumn: "Id",
                keyValue: new Guid("2491c7e2-10ec-48a4-8898-44e24814f23d"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 20, 13, 51, 57, 174, DateTimeKind.Local).AddTicks(4197), new DateTime(2024, 4, 20, 13, 51, 57, 174, DateTimeKind.Local).AddTicks(4199) });

            migrationBuilder.UpdateData(
                table: "ProdutoTipoEntity",
                keyColumn: "Id",
                keyValue: new Guid("3cca7caf-8a98-40b2-9f20-3f864f59e1c5"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 20, 13, 51, 57, 174, DateTimeKind.Local).AddTicks(4203), new DateTime(2024, 4, 20, 13, 51, 57, 174, DateTimeKind.Local).AddTicks(4204) });

            migrationBuilder.UpdateData(
                table: "ProdutoTipoEntity",
                keyColumn: "Id",
                keyValue: new Guid("59de4011-1ca7-4a52-833c-9672a03320ac"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 20, 13, 51, 57, 174, DateTimeKind.Local).AddTicks(4207), new DateTime(2024, 4, 20, 13, 51, 57, 174, DateTimeKind.Local).AddTicks(4209) });

            migrationBuilder.UpdateData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: new Guid("d2a0c172-e742-4e54-a806-938ddaaf8edb"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 20, 13, 51, 57, 174, DateTimeKind.Local).AddTicks(3866), new DateTime(2024, 4, 20, 13, 51, 57, 174, DateTimeKind.Local).AddTicks(3882) });

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_SituacaoPedidoEntity_SituacaoPedidoEntityId",
                table: "Pedidos",
                column: "SituacaoPedidoEntityId",
                principalTable: "SituacaoPedidoEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_ProdutoMedidas_ProdutoMedidaEntityId",
                table: "Produtos",
                column: "ProdutoMedidaEntityId",
                principalTable: "ProdutoMedidas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_ProdutoTipoEntity_ProdutoTipoEntityId",
                table: "Produtos",
                column: "ProdutoTipoEntityId",
                principalTable: "ProdutoTipoEntity",
                principalColumn: "Id");
        }
    }
}
