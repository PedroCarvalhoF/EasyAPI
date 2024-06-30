using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Easy.InfrastructureData.Migrations
{
    /// <inheritdoc />
    public partial class UsuarioPdvUpdateFK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PontosVendas_UsuariosPdvs_UsuarioGerentePdvId",
                table: "PontosVendas");

            migrationBuilder.DropForeignKey(
                name: "FK_PontosVendas_UsuariosPdvs_UsuarioPdvId",
                table: "PontosVendas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsuariosPdvs",
                table: "UsuariosPdvs");

            migrationBuilder.DropIndex(
                name: "IX_UsuariosPdvs_UserPdvId",
                table: "UsuariosPdvs");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsuariosPdvs",
                table: "UsuariosPdvs",
                column: "UserPdvId");

            migrationBuilder.AddForeignKey(
                name: "FK_PontosVendas_UsuariosPdvs_UsuarioGerentePdvId",
                table: "PontosVendas",
                column: "UsuarioGerentePdvId",
                principalTable: "UsuariosPdvs",
                principalColumn: "UserPdvId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PontosVendas_UsuariosPdvs_UsuarioPdvId",
                table: "PontosVendas",
                column: "UsuarioPdvId",
                principalTable: "UsuariosPdvs",
                principalColumn: "UserPdvId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PontosVendas_UsuariosPdvs_UsuarioGerentePdvId",
                table: "PontosVendas");

            migrationBuilder.DropForeignKey(
                name: "FK_PontosVendas_UsuariosPdvs_UsuarioPdvId",
                table: "PontosVendas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsuariosPdvs",
                table: "UsuariosPdvs");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsuariosPdvs",
                table: "UsuariosPdvs",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_UsuariosPdvs_UserPdvId",
                table: "UsuariosPdvs",
                column: "UserPdvId",
                unique: true);

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
    }
}
