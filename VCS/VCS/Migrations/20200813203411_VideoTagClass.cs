using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VCS.Migrations
{
    public partial class VideoTagClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VidioTags_Tags_TagId",
                table: "VidioTags");

            migrationBuilder.DropForeignKey(
                name: "FK_VidioTags_Videos_VideoId",
                table: "VidioTags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VidioTags",
                table: "VidioTags");

            migrationBuilder.RenameTable(
                name: "VidioTags",
                newName: "VideoTags");

            migrationBuilder.RenameIndex(
                name: "IX_VidioTags_TagId",
                table: "VideoTags",
                newName: "IX_VideoTags_TagId");

            migrationBuilder.AddColumn<string>(
                name: "Audio_Codec",
                table: "Videos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Channel",
                table: "Videos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Container",
                table: "Videos",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Videos",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Duration",
                table: "Videos",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Resolution",
                table: "Videos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Size",
                table: "Videos",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TagId",
                table: "Videos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Video_Codec",
                table: "Videos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Video_bitrate",
                table: "Videos",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Tags",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_VideoTags",
                table: "VideoTags",
                columns: new[] { "VideoId", "TagId" });

            migrationBuilder.CreateIndex(
                name: "IX_Videos_TagId",
                table: "Videos",
                column: "TagId");

            migrationBuilder.AddForeignKey(
                name: "FK_Videos_Tags_TagId",
                table: "Videos",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_VideoTags_Tags_TagId",
                table: "VideoTags",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VideoTags_Videos_VideoId",
                table: "VideoTags",
                column: "VideoId",
                principalTable: "Videos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Videos_Tags_TagId",
                table: "Videos");

            migrationBuilder.DropForeignKey(
                name: "FK_VideoTags_Tags_TagId",
                table: "VideoTags");

            migrationBuilder.DropForeignKey(
                name: "FK_VideoTags_Videos_VideoId",
                table: "VideoTags");

            migrationBuilder.DropIndex(
                name: "IX_Videos_TagId",
                table: "Videos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VideoTags",
                table: "VideoTags");

            migrationBuilder.DropColumn(
                name: "Audio_Codec",
                table: "Videos");

            migrationBuilder.DropColumn(
                name: "Channel",
                table: "Videos");

            migrationBuilder.DropColumn(
                name: "Container",
                table: "Videos");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Videos");

            migrationBuilder.DropColumn(
                name: "Duration",
                table: "Videos");

            migrationBuilder.DropColumn(
                name: "Resolution",
                table: "Videos");

            migrationBuilder.DropColumn(
                name: "Size",
                table: "Videos");

            migrationBuilder.DropColumn(
                name: "TagId",
                table: "Videos");

            migrationBuilder.DropColumn(
                name: "Video_Codec",
                table: "Videos");

            migrationBuilder.DropColumn(
                name: "Video_bitrate",
                table: "Videos");

            migrationBuilder.RenameTable(
                name: "VideoTags",
                newName: "VidioTags");

            migrationBuilder.RenameIndex(
                name: "IX_VideoTags_TagId",
                table: "VidioTags",
                newName: "IX_VidioTags_TagId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Tags",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AddPrimaryKey(
                name: "PK_VidioTags",
                table: "VidioTags",
                columns: new[] { "VideoId", "TagId" });

            migrationBuilder.AddForeignKey(
                name: "FK_VidioTags_Tags_TagId",
                table: "VidioTags",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VidioTags_Videos_VideoId",
                table: "VidioTags",
                column: "VideoId",
                principalTable: "Videos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
