using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Store.Server.Migrations
{
    public partial class AddedHeightAndWidthColumn2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<ushort>(
                name: "Width",
                table: "Socials",
                type: "smallint unsigned",
                nullable: false,
                defaultValue: (ushort)0,
                oldClrType: typeof(ushort),
                oldType: "smallint unsigned",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Socials",
                keyColumn: "Icon",
                keyValue: null,
                column: "Icon",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Icon",
                table: "Socials",
                type: "varchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldMaxLength: 255,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<ushort>(
                name: "Height",
                table: "Socials",
                type: "smallint unsigned",
                nullable: false,
                defaultValue: (ushort)0,
                oldClrType: typeof(ushort),
                oldType: "smallint unsigned",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Image",
                table: "Badges",
                type: "varchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<ushort>(
                name: "Height",
                table: "Badges",
                type: "smallint unsigned",
                nullable: false,
                defaultValue: (ushort)0);

            migrationBuilder.AddColumn<ushort>(
                name: "Width",
                table: "Badges",
                type: "smallint unsigned",
                nullable: false,
                defaultValue: (ushort)0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Height",
                table: "Badges");

            migrationBuilder.DropColumn(
                name: "Width",
                table: "Badges");

            migrationBuilder.AlterColumn<ushort>(
                name: "Width",
                table: "Socials",
                type: "smallint unsigned",
                nullable: true,
                oldClrType: typeof(ushort),
                oldType: "smallint unsigned");

            migrationBuilder.AlterColumn<string>(
                name: "Icon",
                table: "Socials",
                type: "varchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldMaxLength: 255)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<ushort>(
                name: "Height",
                table: "Socials",
                type: "smallint unsigned",
                nullable: true,
                oldClrType: typeof(ushort),
                oldType: "smallint unsigned");

            migrationBuilder.AlterColumn<string>(
                name: "Image",
                table: "Badges",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldMaxLength: 255)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }
    }
}
