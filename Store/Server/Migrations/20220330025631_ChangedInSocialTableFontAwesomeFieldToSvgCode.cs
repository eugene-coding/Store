using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Store.Server.Migrations
{
    public partial class ChangedInSocialTableFontAwesomeFieldToSvgCode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FontAwesomeClass",
                table: "Socials",
                newName: "SvgCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SvgCode",
                table: "Socials",
                newName: "FontAwesomeClass");
        }
    }
}
