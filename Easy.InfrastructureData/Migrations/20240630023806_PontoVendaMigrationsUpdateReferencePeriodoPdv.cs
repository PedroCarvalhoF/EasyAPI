using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Easy.InfrastructureData.Migrations
{
    /// <inheritdoc />
    public partial class PontoVendaMigrationsUpdateReferencePeriodoPdv : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PontosVendas_PeriodosPdvs_PeriodoPdvId",
                table: "PontosVendas");

            migrationBuilder.AddForeignKey(
                name: "FK_PontosVendas_PeriodosPdvs_PeriodoPdvId",
                table: "PontosVendas",
                column: "PeriodoPdvId",
                principalTable: "PeriodosPdvs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PontosVendas_PeriodosPdvs_PeriodoPdvId",
                table: "PontosVendas");

            migrationBuilder.AddForeignKey(
                name: "FK_PontosVendas_PeriodosPdvs_PeriodoPdvId",
                table: "PontosVendas",
                column: "PeriodoPdvId",
                principalTable: "PeriodosPdvs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
