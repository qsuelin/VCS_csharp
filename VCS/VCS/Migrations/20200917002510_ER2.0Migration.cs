using Microsoft.EntityFrameworkCore.Migrations;

namespace VCS.Migrations
{
    public partial class ER20Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Resolution",
                table: "Videos");

            migrationBuilder.AlterColumn<int>(
                name: "Size",
                table: "Videos",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Duration",
                table: "Videos",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Dir",
                table: "Videos",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Height",
                table: "Videos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Width",
                table: "Videos",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Dir",
                table: "Videos");

            migrationBuilder.DropColumn(
                name: "Height",
                table: "Videos");

            migrationBuilder.DropColumn(
                name: "Width",
                table: "Videos");

            migrationBuilder.AlterColumn<string>(
                name: "Size",
                table: "Videos",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "Duration",
                table: "Videos",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "Resolution",
                table: "Videos",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);
        }
    }
}
