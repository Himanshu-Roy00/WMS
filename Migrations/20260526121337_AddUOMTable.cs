using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WMS.Migrations
{
    /// <inheritdoc />
    public partial class AddUOMTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UOMId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "UOMs",
                columns: table => new
                {
                    UOMId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UOMName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShortName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UOMs", x => x.UOMId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_UOMId",
                table: "Products",
                column: "UOMId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_UOMs_UOMId",
                table: "Products",
                column: "UOMId",
                principalTable: "UOMs",
                principalColumn: "UOMId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_UOMs_UOMId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "UOMs");

            migrationBuilder.DropIndex(
                name: "IX_Products_UOMId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "UOMId",
                table: "Products");
        }
    }
}
