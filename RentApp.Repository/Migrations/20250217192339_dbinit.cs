using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentApp.Repository.Migrations
{
    /// <inheritdoc />
    public partial class dbinit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Bookid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Uid = table.Column<int>(type: "int", nullable: false),
                    Cid = table.Column<int>(type: "int", nullable: false),
                    Customertype = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Engine = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Bookid);
                });

            migrationBuilder.CreateTable(
                name: "Ridecars",
                columns: table => new
                {
                    Carid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CarName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CarPrice = table.Column<int>(type: "int", nullable: false),
                    CarEngine = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ridecars", x => x.Carid);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Ridecars");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
