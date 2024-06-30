using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Easy.InfrastructureData.Migrations
{
    /// <inheritdoc />
    public partial class PontoVendaMigrationsUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PontoVendaEntity_PeriodosPdvs_PeriodoPdvId",
                table: "PontoVendaEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_PontoVendaEntity_UsuariosPdvs_UsuarioGerentePdvId",
                table: "PontoVendaEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_PontoVendaEntity_UsuariosPdvs_UsuarioPdvId",
                table: "PontoVendaEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PontoVendaEntity",
                table: "PontoVendaEntity");

            migrationBuilder.RenameTable(
                name: "PontoVendaEntity",
                newName: "PontosVendas");

            migrationBuilder.RenameIndex(
                name: "IX_PontoVendaEntity_UsuarioPdvId",
                table: "PontosVendas",
                newName: "IX_PontosVendas_UsuarioPdvId");

            migrationBuilder.RenameIndex(
                name: "IX_PontoVendaEntity_UsuarioGerentePdvId",
                table: "PontosVendas",
                newName: "IX_PontosVendas_UsuarioGerentePdvId");

            migrationBuilder.RenameIndex(
                name: "IX_PontoVendaEntity_PeriodoPdvId",
                table: "PontosVendas",
                newName: "IX_PontosVendas_PeriodoPdvId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateAt",
                table: "PontosVendas",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateAt",
                table: "PontosVendas",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PontosVendas",
                table: "PontosVendas",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PontosVendas_PeriodosPdvs_PeriodoPdvId",
                table: "PontosVendas",
                column: "PeriodoPdvId",
                principalTable: "PeriodosPdvs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PontosVendas_UsuariosPdvs_UsuarioGerentePdvId",
                table: "PontosVendas",
                column: "UsuarioGerentePdvId",
                principalTable: "UsuariosPdvs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PontosVendas_UsuariosPdvs_UsuarioPdvId",
                table: "PontosVendas",
                column: "UsuarioPdvId",
                principalTable: "UsuariosPdvs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PontosVendas_PeriodosPdvs_PeriodoPdvId",
                table: "PontosVendas");

            migrationBuilder.DropForeignKey(
                name: "FK_PontosVendas_UsuariosPdvs_UsuarioGerentePdvId",
                table: "PontosVendas");

            migrationBuilder.DropForeignKey(
                name: "FK_PontosVendas_UsuariosPdvs_UsuarioPdvId",
                table: "PontosVendas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PontosVendas",
                table: "PontosVendas");

            migrationBuilder.RenameTable(
                name: "PontosVendas",
                newName: "PontoVendaEntity");

            migrationBuilder.RenameIndex(
                name: "IX_PontosVendas_UsuarioPdvId",
                table: "PontoVendaEntity",
                newName: "IX_PontoVendaEntity_UsuarioPdvId");

            migrationBuilder.RenameIndex(
                name: "IX_PontosVendas_UsuarioGerentePdvId",
                table: "PontoVendaEntity",
                newName: "IX_PontoVendaEntity_UsuarioGerentePdvId");

            migrationBuilder.RenameIndex(
                name: "IX_PontosVendas_PeriodoPdvId",
                table: "PontoVendaEntity",
                newName: "IX_PontoVendaEntity_PeriodoPdvId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateAt",
                table: "PontoVendaEntity",
                type: "datetime(6)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateAt",
                table: "PontoVendaEntity",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PontoVendaEntity",
                table: "PontoVendaEntity",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PontoVendaEntity_PeriodosPdvs_PeriodoPdvId",
                table: "PontoVendaEntity",
                column: "PeriodoPdvId",
                principalTable: "PeriodosPdvs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PontoVendaEntity_UsuariosPdvs_UsuarioGerentePdvId",
                table: "PontoVendaEntity",
                column: "UsuarioGerentePdvId",
                principalTable: "UsuariosPdvs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PontoVendaEntity_UsuariosPdvs_UsuarioPdvId",
                table: "PontoVendaEntity",
                column: "UsuarioPdvId",
                principalTable: "UsuariosPdvs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
