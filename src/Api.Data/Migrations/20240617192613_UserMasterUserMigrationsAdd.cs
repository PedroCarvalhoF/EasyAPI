using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class UserMasterUserMigrationsAdd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserMasterUserEntity",
                columns: table => new
                {
                    UserClienteId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    UserMasterUserId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserMasterUserEntity", x => new { x.UserClienteId, x.UserMasterUserId });
                    table.ForeignKey(
                        name: "FK_UserMasterUserEntity_AspNetUsers_UserMasterUserId",
                        column: x => x.UserMasterUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserMasterUserEntity_UserMasterClienteEntity_UserClienteId",
                        column: x => x.UserClienteId,
                        principalTable: "UserMasterClienteEntity",
                        principalColumn: "UserMasterId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_UserMasterUserEntity_UserMasterUserId",
                table: "UserMasterUserEntity",
                column: "UserMasterUserId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserMasterUserEntity");
        }
    }
}
