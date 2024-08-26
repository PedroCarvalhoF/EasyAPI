using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Easy.InfrastructureData.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePedidoField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Finalizado",
                table: "Pedidos",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Finalizado",
                table: "Pedidos");
        }
    }
}
