using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderSystem.Migrations
{
    /// <inheritdoc />
    public partial class AddCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "bigCategory",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "midCategory",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "midCategoryId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "BigCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BigCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MidCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BigCategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MidCategory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MidCategory_BigCategory_BigCategoryId",
                        column: x => x.BigCategoryId,
                        principalTable: "BigCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_midCategoryId",
                table: "Products",
                column: "midCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_MidCategory_BigCategoryId",
                table: "MidCategory",
                column: "BigCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_MidCategory_midCategoryId",
                table: "Products",
                column: "midCategoryId",
                principalTable: "MidCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_MidCategory_midCategoryId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "MidCategory");

            migrationBuilder.DropTable(
                name: "BigCategory");

            migrationBuilder.DropIndex(
                name: "IX_Products_midCategoryId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "midCategoryId",
                table: "Products");

            migrationBuilder.AddColumn<string>(
                name: "bigCategory",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "midCategory",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
