using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class RenomeacaoTabelas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemPedidoEntities_Pedidos_PedidoEntityId",
                table: "ItemPedidoEntities");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemPedidoEntities_Produtos_ProdutoEntityId",
                table: "ItemPedidoEntities");

            migrationBuilder.DropForeignKey(
                name: "FK_PagamentoPedidoEntities_FormaPagamentoEntities_FormaPagament~",
                table: "PagamentoPedidoEntities");

            migrationBuilder.DropForeignKey(
                name: "FK_PagamentoPedidoEntities_Pedidos_PedidoEntityId",
                table: "PagamentoPedidoEntities");

            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_PontoVendaEntities_PontoVendaEntityId",
                table: "Pedidos");

            migrationBuilder.DropForeignKey(
                name: "FK_PessoaEntities_PessoaTipoEntities_PessoaTipoEntityId",
                table: "PessoaEntities");

            migrationBuilder.DropForeignKey(
                name: "FK_PrecoProdutoEntities_CategoriasPrecos_CategoriaPrecoEntityId",
                table: "PrecoProdutoEntities");

            migrationBuilder.DropForeignKey(
                name: "FK_PrecoProdutoEntities_Produtos_ProdutoEntityId",
                table: "PrecoProdutoEntities");

            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_ProdutoMedidasEntities_ProdutoMedidaEntityId",
                table: "Produtos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProdutoMedidasEntities",
                table: "ProdutoMedidasEntities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PrecoProdutoEntities",
                table: "PrecoProdutoEntities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PontoVendaEntities",
                table: "PontoVendaEntities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PessoaTipoEntities",
                table: "PessoaTipoEntities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PessoaEntities",
                table: "PessoaEntities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PagamentoPedidoEntities",
                table: "PagamentoPedidoEntities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemPedidoEntities",
                table: "ItemPedidoEntities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FormaPagamentoEntities",
                table: "FormaPagamentoEntities");

            migrationBuilder.DeleteData(
                table: "CategoriasProdutos",
                keyColumn: "Id",
                keyValue: new Guid("060645d4-f4e3-4163-995c-98869d974aa9"));

            migrationBuilder.DeleteData(
                table: "CategoriasProdutos",
                keyColumn: "Id",
                keyValue: new Guid("9fb6ab8f-5aa1-4d93-a07c-ae0dcc60bdd3"));

            migrationBuilder.RenameTable(
                name: "ProdutoMedidasEntities",
                newName: "ProdutoMedidas");

            migrationBuilder.RenameTable(
                name: "PrecoProdutoEntities",
                newName: "PrecosProdutos");

            migrationBuilder.RenameTable(
                name: "PontoVendaEntities",
                newName: "PontosVendas");

            migrationBuilder.RenameTable(
                name: "PessoaTipoEntities",
                newName: "PessoasTipos");

            migrationBuilder.RenameTable(
                name: "PessoaEntities",
                newName: "Pessoas");

            migrationBuilder.RenameTable(
                name: "PagamentoPedidoEntities",
                newName: "PagamentosPedidos");

            migrationBuilder.RenameTable(
                name: "ItemPedidoEntities",
                newName: "ItensPedidos");

            migrationBuilder.RenameTable(
                name: "FormaPagamentoEntities",
                newName: "FormasPagamentos");

            migrationBuilder.RenameIndex(
                name: "IX_PrecoProdutoEntities_ProdutoEntityId",
                table: "PrecosProdutos",
                newName: "IX_PrecosProdutos_ProdutoEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_PrecoProdutoEntities_CategoriaPrecoEntityId",
                table: "PrecosProdutos",
                newName: "IX_PrecosProdutos_CategoriaPrecoEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_PessoaEntities_PessoaTipoEntityId",
                table: "Pessoas",
                newName: "IX_Pessoas_PessoaTipoEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_PagamentoPedidoEntities_PedidoEntityId",
                table: "PagamentosPedidos",
                newName: "IX_PagamentosPedidos_PedidoEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_PagamentoPedidoEntities_FormaPagamentoEntityId",
                table: "PagamentosPedidos",
                newName: "IX_PagamentosPedidos_FormaPagamentoEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_ItemPedidoEntities_ProdutoEntityId",
                table: "ItensPedidos",
                newName: "IX_ItensPedidos_ProdutoEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_ItemPedidoEntities_PedidoEntityId",
                table: "ItensPedidos",
                newName: "IX_ItensPedidos_PedidoEntityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProdutoMedidas",
                table: "ProdutoMedidas",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PrecosProdutos",
                table: "PrecosProdutos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PontosVendas",
                table: "PontosVendas",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PessoasTipos",
                table: "PessoasTipos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pessoas",
                table: "Pessoas",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PagamentosPedidos",
                table: "PagamentosPedidos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItensPedidos",
                table: "ItensPedidos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FormasPagamentos",
                table: "FormasPagamentos",
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
                name: "FK_ItensPedidos_Pedidos_PedidoEntityId",
                table: "ItensPedidos",
                column: "PedidoEntityId",
                principalTable: "Pedidos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ItensPedidos_Produtos_ProdutoEntityId",
                table: "ItensPedidos",
                column: "ProdutoEntityId",
                principalTable: "Produtos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PagamentosPedidos_FormasPagamentos_FormaPagamentoEntityId",
                table: "PagamentosPedidos",
                column: "FormaPagamentoEntityId",
                principalTable: "FormasPagamentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PagamentosPedidos_Pedidos_PedidoEntityId",
                table: "PagamentosPedidos",
                column: "PedidoEntityId",
                principalTable: "Pedidos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_PontosVendas_PontoVendaEntityId",
                table: "Pedidos",
                column: "PontoVendaEntityId",
                principalTable: "PontosVendas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pessoas_PessoasTipos_PessoaTipoEntityId",
                table: "Pessoas",
                column: "PessoaTipoEntityId",
                principalTable: "PessoasTipos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PrecosProdutos_CategoriasPrecos_CategoriaPrecoEntityId",
                table: "PrecosProdutos",
                column: "CategoriaPrecoEntityId",
                principalTable: "CategoriasPrecos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PrecosProdutos_Produtos_ProdutoEntityId",
                table: "PrecosProdutos",
                column: "ProdutoEntityId",
                principalTable: "Produtos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_ProdutoMedidas_ProdutoMedidaEntityId",
                table: "Produtos",
                column: "ProdutoMedidaEntityId",
                principalTable: "ProdutoMedidas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItensPedidos_Pedidos_PedidoEntityId",
                table: "ItensPedidos");

            migrationBuilder.DropForeignKey(
                name: "FK_ItensPedidos_Produtos_ProdutoEntityId",
                table: "ItensPedidos");

            migrationBuilder.DropForeignKey(
                name: "FK_PagamentosPedidos_FormasPagamentos_FormaPagamentoEntityId",
                table: "PagamentosPedidos");

            migrationBuilder.DropForeignKey(
                name: "FK_PagamentosPedidos_Pedidos_PedidoEntityId",
                table: "PagamentosPedidos");

            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_PontosVendas_PontoVendaEntityId",
                table: "Pedidos");

            migrationBuilder.DropForeignKey(
                name: "FK_Pessoas_PessoasTipos_PessoaTipoEntityId",
                table: "Pessoas");

            migrationBuilder.DropForeignKey(
                name: "FK_PrecosProdutos_CategoriasPrecos_CategoriaPrecoEntityId",
                table: "PrecosProdutos");

            migrationBuilder.DropForeignKey(
                name: "FK_PrecosProdutos_Produtos_ProdutoEntityId",
                table: "PrecosProdutos");

            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_ProdutoMedidas_ProdutoMedidaEntityId",
                table: "Produtos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProdutoMedidas",
                table: "ProdutoMedidas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PrecosProdutos",
                table: "PrecosProdutos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PontosVendas",
                table: "PontosVendas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PessoasTipos",
                table: "PessoasTipos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pessoas",
                table: "Pessoas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PagamentosPedidos",
                table: "PagamentosPedidos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ItensPedidos",
                table: "ItensPedidos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FormasPagamentos",
                table: "FormasPagamentos");

            migrationBuilder.DeleteData(
                table: "CategoriasProdutos",
                keyColumn: "Id",
                keyValue: new Guid("8666313b-bb19-462a-9659-79d6b5c7059e"));

            migrationBuilder.DeleteData(
                table: "CategoriasProdutos",
                keyColumn: "Id",
                keyValue: new Guid("89d8c87f-b473-485e-90a3-d193dcac7e16"));

            migrationBuilder.RenameTable(
                name: "ProdutoMedidas",
                newName: "ProdutoMedidasEntities");

            migrationBuilder.RenameTable(
                name: "PrecosProdutos",
                newName: "PrecoProdutoEntities");

            migrationBuilder.RenameTable(
                name: "PontosVendas",
                newName: "PontoVendaEntities");

            migrationBuilder.RenameTable(
                name: "PessoasTipos",
                newName: "PessoaTipoEntities");

            migrationBuilder.RenameTable(
                name: "Pessoas",
                newName: "PessoaEntities");

            migrationBuilder.RenameTable(
                name: "PagamentosPedidos",
                newName: "PagamentoPedidoEntities");

            migrationBuilder.RenameTable(
                name: "ItensPedidos",
                newName: "ItemPedidoEntities");

            migrationBuilder.RenameTable(
                name: "FormasPagamentos",
                newName: "FormaPagamentoEntities");

            migrationBuilder.RenameIndex(
                name: "IX_PrecosProdutos_ProdutoEntityId",
                table: "PrecoProdutoEntities",
                newName: "IX_PrecoProdutoEntities_ProdutoEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_PrecosProdutos_CategoriaPrecoEntityId",
                table: "PrecoProdutoEntities",
                newName: "IX_PrecoProdutoEntities_CategoriaPrecoEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_Pessoas_PessoaTipoEntityId",
                table: "PessoaEntities",
                newName: "IX_PessoaEntities_PessoaTipoEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_PagamentosPedidos_PedidoEntityId",
                table: "PagamentoPedidoEntities",
                newName: "IX_PagamentoPedidoEntities_PedidoEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_PagamentosPedidos_FormaPagamentoEntityId",
                table: "PagamentoPedidoEntities",
                newName: "IX_PagamentoPedidoEntities_FormaPagamentoEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_ItensPedidos_ProdutoEntityId",
                table: "ItemPedidoEntities",
                newName: "IX_ItemPedidoEntities_ProdutoEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_ItensPedidos_PedidoEntityId",
                table: "ItemPedidoEntities",
                newName: "IX_ItemPedidoEntities_PedidoEntityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProdutoMedidasEntities",
                table: "ProdutoMedidasEntities",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PrecoProdutoEntities",
                table: "PrecoProdutoEntities",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PontoVendaEntities",
                table: "PontoVendaEntities",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PessoaTipoEntities",
                table: "PessoaTipoEntities",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PessoaEntities",
                table: "PessoaEntities",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PagamentoPedidoEntities",
                table: "PagamentoPedidoEntities",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemPedidoEntities",
                table: "ItemPedidoEntities",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FormaPagamentoEntities",
                table: "FormaPagamentoEntities",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "CategoriasProdutos",
                keyColumn: "Id",
                keyValue: new Guid("6fb282e9-6ee8-44d9-a049-994f68bd0b27"),
                column: "CreateAt",
                value: new DateTime(2024, 4, 20, 13, 47, 49, 932, DateTimeKind.Local).AddTicks(9838));

            migrationBuilder.InsertData(
                table: "CategoriasProdutos",
                columns: new[] { "Id", "CreateAt", "DescricaoCategoria", "Habilitado", "UpdateAt" },
                values: new object[,]
                {
                    { new Guid("060645d4-f4e3-4163-995c-98869d974aa9"), new DateTime(2024, 4, 20, 13, 47, 49, 932, DateTimeKind.Local).AddTicks(9921), "Executivos", true, null },
                    { new Guid("9fb6ab8f-5aa1-4d93-a07c-ae0dcc60bdd3"), new DateTime(2024, 4, 20, 13, 47, 49, 932, DateTimeKind.Local).AddTicks(9886), "Promoções", true, null }
                });

            migrationBuilder.UpdateData(
                table: "FormaPagamentoEntities",
                keyColumn: "Id",
                keyValue: new Guid("18e68a14-54b5-44b6-87ed-e8b0258d9c1d"),
                column: "CreateAt",
                value: new DateTime(2024, 4, 20, 13, 47, 49, 933, DateTimeKind.Local).AddTicks(513));

            migrationBuilder.UpdateData(
                table: "FormaPagamentoEntities",
                keyColumn: "Id",
                keyValue: new Guid("249c0c31-ee8e-487b-b4c9-1f14ced84553"),
                column: "CreateAt",
                value: new DateTime(2024, 4, 20, 13, 47, 49, 933, DateTimeKind.Local).AddTicks(509));

            migrationBuilder.UpdateData(
                table: "FormaPagamentoEntities",
                keyColumn: "Id",
                keyValue: new Guid("46152359-216e-4b2e-827c-411092ecc423"),
                column: "CreateAt",
                value: new DateTime(2024, 4, 20, 13, 47, 49, 933, DateTimeKind.Local).AddTicks(524));

            migrationBuilder.UpdateData(
                table: "FormaPagamentoEntities",
                keyColumn: "Id",
                keyValue: new Guid("7aaecde9-7290-48e7-bf31-f8dab886381f"),
                column: "CreateAt",
                value: new DateTime(2024, 4, 20, 13, 47, 49, 933, DateTimeKind.Local).AddTicks(535));

            migrationBuilder.UpdateData(
                table: "FormaPagamentoEntities",
                keyColumn: "Id",
                keyValue: new Guid("935f9721-bcc2-4239-88a1-2e0c9b1a75f6"),
                column: "CreateAt",
                value: new DateTime(2024, 4, 20, 13, 47, 49, 933, DateTimeKind.Local).AddTicks(529));

            migrationBuilder.UpdateData(
                table: "FormaPagamentoEntities",
                keyColumn: "Id",
                keyValue: new Guid("ac336bfb-39eb-4da0-9b04-c159f0068676"),
                column: "CreateAt",
                value: new DateTime(2024, 4, 20, 13, 47, 49, 933, DateTimeKind.Local).AddTicks(518));

            migrationBuilder.UpdateData(
                table: "FormaPagamentoEntities",
                keyColumn: "Id",
                keyValue: new Guid("cdd1b70b-5c96-472e-a983-3abdcc318c53"),
                column: "CreateAt",
                value: new DateTime(2024, 4, 20, 13, 47, 49, 933, DateTimeKind.Local).AddTicks(527));

            migrationBuilder.UpdateData(
                table: "FormaPagamentoEntities",
                keyColumn: "Id",
                keyValue: new Guid("d276bcd0-e552-46d4-af7a-390a3af0eb37"),
                column: "CreateAt",
                value: new DateTime(2024, 4, 20, 13, 47, 49, 933, DateTimeKind.Local).AddTicks(521));

            migrationBuilder.UpdateData(
                table: "FormaPagamentoEntities",
                keyColumn: "Id",
                keyValue: new Guid("e93ceba1-40f8-4420-8dc3-bb1b3ee6ee9f"),
                column: "CreateAt",
                value: new DateTime(2024, 4, 20, 13, 47, 49, 933, DateTimeKind.Local).AddTicks(532));

            migrationBuilder.UpdateData(
                table: "PessoaTipoEntities",
                keyColumn: "Id",
                keyValue: new Guid("2cc73259-4063-4f20-9c21-34ff2a9cbd58"),
                column: "CreateAt",
                value: new DateTime(2024, 4, 20, 13, 47, 49, 933, DateTimeKind.Local).AddTicks(600));

            migrationBuilder.UpdateData(
                table: "PessoaTipoEntities",
                keyColumn: "Id",
                keyValue: new Guid("a58b678c-07d4-417b-929b-600dc63858ea"),
                column: "CreateAt",
                value: new DateTime(2024, 4, 20, 13, 47, 49, 933, DateTimeKind.Local).AddTicks(592));

            migrationBuilder.UpdateData(
                table: "ProdutoMedidasEntities",
                keyColumn: "Id",
                keyValue: new Guid("05b3382d-0940-446a-8c2c-3e27293cf77d"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 20, 13, 47, 49, 933, DateTimeKind.Local).AddTicks(646), new DateTime(2024, 4, 20, 13, 47, 49, 933, DateTimeKind.Local).AddTicks(647) });

            migrationBuilder.UpdateData(
                table: "ProdutoMedidasEntities",
                keyColumn: "Id",
                keyValue: new Guid("9bbe9cc9-ba40-4bb3-9b71-74a8234133a5"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 20, 13, 47, 49, 933, DateTimeKind.Local).AddTicks(643), new DateTime(2024, 4, 20, 13, 47, 49, 933, DateTimeKind.Local).AddTicks(643) });

            migrationBuilder.UpdateData(
                table: "ProdutoMedidasEntities",
                keyColumn: "Id",
                keyValue: new Guid("cc8119c5-7651-4708-bba4-8f350726bdac"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 20, 13, 47, 49, 933, DateTimeKind.Local).AddTicks(638), new DateTime(2024, 4, 20, 13, 47, 49, 933, DateTimeKind.Local).AddTicks(639) });

            migrationBuilder.UpdateData(
                table: "ProdutoTipoEntity",
                keyColumn: "Id",
                keyValue: new Guid("2491c7e2-10ec-48a4-8898-44e24814f23d"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 20, 13, 47, 49, 933, DateTimeKind.Local).AddTicks(690), new DateTime(2024, 4, 20, 13, 47, 49, 933, DateTimeKind.Local).AddTicks(691) });

            migrationBuilder.UpdateData(
                table: "ProdutoTipoEntity",
                keyColumn: "Id",
                keyValue: new Guid("3cca7caf-8a98-40b2-9f20-3f864f59e1c5"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 20, 13, 47, 49, 933, DateTimeKind.Local).AddTicks(696), new DateTime(2024, 4, 20, 13, 47, 49, 933, DateTimeKind.Local).AddTicks(696) });

            migrationBuilder.UpdateData(
                table: "ProdutoTipoEntity",
                keyColumn: "Id",
                keyValue: new Guid("59de4011-1ca7-4a52-833c-9672a03320ac"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 20, 13, 47, 49, 933, DateTimeKind.Local).AddTicks(700), new DateTime(2024, 4, 20, 13, 47, 49, 933, DateTimeKind.Local).AddTicks(700) });

            migrationBuilder.UpdateData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: new Guid("d2a0c172-e742-4e54-a806-938ddaaf8edb"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 20, 13, 47, 49, 933, DateTimeKind.Local).AddTicks(445), new DateTime(2024, 4, 20, 13, 47, 49, 933, DateTimeKind.Local).AddTicks(462) });

            migrationBuilder.AddForeignKey(
                name: "FK_ItemPedidoEntities_Pedidos_PedidoEntityId",
                table: "ItemPedidoEntities",
                column: "PedidoEntityId",
                principalTable: "Pedidos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemPedidoEntities_Produtos_ProdutoEntityId",
                table: "ItemPedidoEntities",
                column: "ProdutoEntityId",
                principalTable: "Produtos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PagamentoPedidoEntities_FormaPagamentoEntities_FormaPagament~",
                table: "PagamentoPedidoEntities",
                column: "FormaPagamentoEntityId",
                principalTable: "FormaPagamentoEntities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PagamentoPedidoEntities_Pedidos_PedidoEntityId",
                table: "PagamentoPedidoEntities",
                column: "PedidoEntityId",
                principalTable: "Pedidos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_PontoVendaEntities_PontoVendaEntityId",
                table: "Pedidos",
                column: "PontoVendaEntityId",
                principalTable: "PontoVendaEntities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PessoaEntities_PessoaTipoEntities_PessoaTipoEntityId",
                table: "PessoaEntities",
                column: "PessoaTipoEntityId",
                principalTable: "PessoaTipoEntities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PrecoProdutoEntities_CategoriasPrecos_CategoriaPrecoEntityId",
                table: "PrecoProdutoEntities",
                column: "CategoriaPrecoEntityId",
                principalTable: "CategoriasPrecos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PrecoProdutoEntities_Produtos_ProdutoEntityId",
                table: "PrecoProdutoEntities",
                column: "ProdutoEntityId",
                principalTable: "Produtos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_ProdutoMedidasEntities_ProdutoMedidaEntityId",
                table: "Produtos",
                column: "ProdutoMedidaEntityId",
                principalTable: "ProdutoMedidasEntities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
