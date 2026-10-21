using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WMS.Migrations
{
    /// <inheritdoc />
    public partial class AddWarehouseTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventory_Warehouse_WarehouseId",
                table: "Inventory");

            migrationBuilder.DropForeignKey(
                name: "FK_StockIns_Warehouse_WarehouseId",
                table: "StockIns");

            migrationBuilder.DropForeignKey(
                name: "FK_StockOuts_Warehouse_WarehouseId",
                table: "StockOuts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Warehouse",
                table: "Warehouse");

            migrationBuilder.RenameTable(
                name: "Warehouse",
                newName: "Warehouses");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Warehouses",
                table: "Warehouses",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventory_Warehouses_WarehouseId",
                table: "Inventory",
                column: "WarehouseId",
                principalTable: "Warehouses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StockIns_Warehouses_WarehouseId",
                table: "StockIns",
                column: "WarehouseId",
                principalTable: "Warehouses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StockOuts_Warehouses_WarehouseId",
                table: "StockOuts",
                column: "WarehouseId",
                principalTable: "Warehouses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventory_Warehouses_WarehouseId",
                table: "Inventory");

            migrationBuilder.DropForeignKey(
                name: "FK_StockIns_Warehouses_WarehouseId",
                table: "StockIns");

            migrationBuilder.DropForeignKey(
                name: "FK_StockOuts_Warehouses_WarehouseId",
                table: "StockOuts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Warehouses",
                table: "Warehouses");

            migrationBuilder.RenameTable(
                name: "Warehouses",
                newName: "Warehouse");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Warehouse",
                table: "Warehouse",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventory_Warehouse_WarehouseId",
                table: "Inventory",
                column: "WarehouseId",
                principalTable: "Warehouse",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StockIns_Warehouse_WarehouseId",
                table: "StockIns",
                column: "WarehouseId",
                principalTable: "Warehouse",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StockOuts_Warehouse_WarehouseId",
                table: "StockOuts",
                column: "WarehouseId",
                principalTable: "Warehouse",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
