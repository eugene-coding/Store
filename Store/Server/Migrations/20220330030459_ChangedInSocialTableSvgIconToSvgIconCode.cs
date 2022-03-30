using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Store.Server.Migrations
{
    public partial class ChangedInSocialTableSvgIconToSvgIconCode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SvgCode",
                table: "Socials",
                newName: "SvgIconCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SvgIconCode",
                table: "Socials",
                newName: "SvgCode");
        }
    }
}
