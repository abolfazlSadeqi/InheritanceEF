using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication2.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence(
                name: "BaseEntityTPCSequence");

            migrationBuilder.CreateTable(
                name: "BaseEntityTPH",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    IdentityCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NationalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Family = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseEntityTPH", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BaseEntityTPT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseEntityTPT", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CompanyTPC",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR [BaseEntityTPCSequence]"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdentityCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyTPC", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PersonTPC",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR [BaseEntityTPCSequence]"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NationalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Family = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonTPC", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CompanyTPT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    IdentityCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyTPT", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanyTPT_BaseEntityTPT_Id",
                        column: x => x.Id,
                        principalTable: "BaseEntityTPT",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonTPT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    NationalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Family = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonTPT", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonTPT_BaseEntityTPT_Id",
                        column: x => x.Id,
                        principalTable: "BaseEntityTPT",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BaseEntityTPH");

            migrationBuilder.DropTable(
                name: "CompanyTPC");

            migrationBuilder.DropTable(
                name: "CompanyTPT");

            migrationBuilder.DropTable(
                name: "PersonTPC");

            migrationBuilder.DropTable(
                name: "PersonTPT");

            migrationBuilder.DropTable(
                name: "BaseEntityTPT");

            migrationBuilder.DropSequence(
                name: "BaseEntityTPCSequence");
        }
    }
}
