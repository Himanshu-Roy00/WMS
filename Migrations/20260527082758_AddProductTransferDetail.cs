using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WMS.Migrations
{
    /// <inheritdoc />
    public partial class AddProductTransferDetail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductTransferDetails",
                columns: table => new
                {
                    DetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductTransferId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTransferDetails", x => x.DetailId);
                    table.ForeignKey(
                        name: "FK_ProductTransferDetails_ProductTransfers_ProductTransferId",
                        column: x => x.ProductTransferId,
                        principalTable: "ProductTransfers",
                        principalColumn: "ProductTransferId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductTransferDetails_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductTransferDetails_ProductId",
                table: "ProductTransferDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductTransferDetails_ProductTransferId",
                table: "ProductTransferDetails",
                column: "ProductTransferId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductTransferDetails");
        }
    }
}
