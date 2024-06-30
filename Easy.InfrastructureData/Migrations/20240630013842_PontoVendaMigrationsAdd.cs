using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Easy.InfrastructureData.Migrations
{
    /// <inheritdoc />
    public partial class PontoVendaMigrationsAdd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PontoVendaEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    UsuarioGerentePdvId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    UsuarioPdvId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Aberto = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    PeriodoPdvId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    CreateAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Habilitado = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    UserMasterClienteIdentityId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PontoVendaEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PontoVendaEntity_PeriodosPdvs_PeriodoPdvId",
                        column: x => x.PeriodoPdvId,
                        principalTable: "PeriodosPdvs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PontoVendaEntity_UsuariosPdvs_UsuarioGerentePdvId",
                        column: x => x.UsuarioGerentePdvId,
                        principalTable: "UsuariosPdvs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PontoVendaEntity_UsuariosPdvs_UsuarioPdvId",
                        column: x => x.UsuarioPdvId,
                        principalTable: "UsuariosPdvs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_PontoVendaEntity_PeriodoPdvId",
                table: "PontoVendaEntity",
                column: "PeriodoPdvId");

            migrationBuilder.CreateIndex(
                name: "IX_PontoVendaEntity_UsuarioGerentePdvId",
                table: "PontoVendaEntity",
                column: "UsuarioGerentePdvId");

            migrationBuilder.CreateIndex(
                name: "IX_PontoVendaEntity_UsuarioPdvId",
                table: "PontoVendaEntity",
                column: "UsuarioPdvId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PontoVendaEntity");
        }
    }
}
