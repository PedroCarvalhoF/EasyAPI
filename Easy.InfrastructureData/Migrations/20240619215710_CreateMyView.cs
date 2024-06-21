using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Easy.InfrastructureData.Migrations
{
    /// <inheritdoc />
    public partial class CreateMyView : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
            CREATE VIEW MyView AS
            SELECT 
                o.UserMasterId, 
                c.Id AS UserId, 
                c.Nome, 
                c.SobreNome, 
                c.Email, 
                c.UserName 
            FROM 
                desenvolvimento.usermastercliente o 
            INNER JOIN 
                desenvolvimento.aspnetusers c ON o.UserMasterId = c.Id
        ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP VIEW IF EXISTS MyView");
        }
    }
}
