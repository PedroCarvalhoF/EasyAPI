using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Easy.InfrastructureData.Migrations
{
    /// <inheritdoc />
    public partial class PagamentoPedidoMigrationsAddApplyConfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PagamentosPedidos_FormasPagamentos_FormaPagamentoId",
                table: "PagamentosPedidos");

            migrationBuilder.DropForeignKey(
                name: "FK_PagamentosPedidos_Pedidos_PedidoId",
                table: "PagamentosPedidos");

            migrationBuilder.AlterColumn<decimal>(
                name: "ValorPago",
                table: "PagamentosPedidos",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(65,30)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateAt",
                table: "PagamentosPedidos",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateAt",
                table: "PagamentosPedidos",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AddForeignKey(
                name: "FK_PagamentosPedidos_FormasPagamentos_FormaPagamentoId",
                table: "PagamentosPedidos",
                column: "FormaPagamentoId",
                principalTable: "FormasPagamentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PagamentosPedidos_Pedidos_PedidoId",
                table: "PagamentosPedidos",
                column: "PedidoId",
                principalTable: "Pedidos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PagamentosPedidos_FormasPagamentos_FormaPagamentoId",
                table: "PagamentosPedidos");

            migrationBuilder.DropForeignKey(
                name: "FK_PagamentosPedidos_Pedidos_PedidoId",
                table: "PagamentosPedidos");

            migrationBuilder.AlterColumn<decimal>(
                name: "ValorPago",
                table: "PagamentosPedidos",
                type: "decimal(65,30)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateAt",
                table: "PagamentosPedidos",
                type: "datetime(6)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateAt",
                table: "PagamentosPedidos",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AddForeignKey(
                name: "FK_PagamentosPedidos_FormasPagamentos_FormaPagamentoId",
                table: "PagamentosPedidos",
                column: "FormaPagamentoId",
                principalTable: "FormasPagamentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PagamentosPedidos_Pedidos_PedidoId",
                table: "PagamentosPedidos",
                column: "PedidoId",
                principalTable: "Pedidos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
