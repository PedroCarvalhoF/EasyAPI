using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Easy.InfrastructureData.Migrations
{
    /// <inheritdoc />
    public partial class PedidoMigraitonsAlterFiel_Cancelado : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "Cancelado",
                table: "Pedidos",
                type: "tinyint(1)",
                nullable: false,
                oldClrType: typeof(ulong),
                oldType: "bit");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<ulong>(
                name: "Cancelado",
                table: "Pedidos",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)");
        }
    }
}
