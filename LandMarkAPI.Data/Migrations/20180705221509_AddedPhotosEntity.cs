using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LandMarkAPI.Data.Migrations
{
    public partial class AddedPhotosEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Photos",
                columns: table => new
                {
                    PhotoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    id = table.Column<long>(nullable: false),
                    owner = table.Column<string>(nullable: true),
                    secret = table.Column<string>(nullable: true),
                    server = table.Column<int>(nullable: false),
                    farm = table.Column<int>(nullable: false),
                    title = table.Column<string>(nullable: true),
                    ispublic = table.Column<bool>(nullable: false),
                    isfriend = table.Column<bool>(nullable: false),
                    isfamily = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photos", x => x.PhotoId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Photos");
        }
    }
}
