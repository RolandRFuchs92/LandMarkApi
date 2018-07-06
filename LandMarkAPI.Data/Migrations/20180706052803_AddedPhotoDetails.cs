using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LandMarkAPI.Data.Migrations
{
    public partial class AddedPhotoDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PhotoDetails",
                columns: table => new
                {
                    PhotoDetailId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FlickrPhotoId = table.Column<long>(nullable: false),
                    Secret = table.Column<string>(nullable: true),
                    Server = table.Column<int>(nullable: false),
                    Farm = table.Column<int>(nullable: false),
                    DateUploaded = table.Column<DateTime>(nullable: true),
                    IsFavorite = table.Column<bool>(nullable: false),
                    License = table.Column<int>(nullable: false),
                    Rotation = table.Column<int>(nullable: false),
                    OriginalSecret = table.Column<string>(nullable: true),
                    OriginalFormat = table.Column<string>(nullable: true),
                    Views = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Decription = table.Column<string>(nullable: true),
                    Media = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhotoDetails", x => x.PhotoDetailId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PhotoDetails");
        }
    }
}
