using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MarketAPI.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mg5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderProduct_Orders_OrdersId",
                table: "OrderProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderProduct_Products_ProductsId",
                table: "OrderProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Customers_CustomerId",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orders",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customers",
                table: "Customers");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "Productss");

            migrationBuilder.RenameTable(
                name: "Orders",
                newName: "Orderss");

            migrationBuilder.RenameTable(
                name: "Customers",
                newName: "Customerss");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_CustomerId",
                table: "Orderss",
                newName: "IX_Orderss_CustomerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Productss",
                table: "Productss",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orderss",
                table: "Orderss",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customerss",
                table: "Customerss",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProduct_Orderss_OrdersId",
                table: "OrderProduct",
                column: "OrdersId",
                principalTable: "Orderss",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProduct_Productss_ProductsId",
                table: "OrderProduct",
                column: "ProductsId",
                principalTable: "Productss",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orderss_Customerss_CustomerId",
                table: "Orderss",
                column: "CustomerId",
                principalTable: "Customerss",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderProduct_Orderss_OrdersId",
                table: "OrderProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderProduct_Productss_ProductsId",
                table: "OrderProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_Orderss_Customerss_CustomerId",
                table: "Orderss");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Productss",
                table: "Productss");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orderss",
                table: "Orderss");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customerss",
                table: "Customerss");

            migrationBuilder.RenameTable(
                name: "Productss",
                newName: "Products");

            migrationBuilder.RenameTable(
                name: "Orderss",
                newName: "Orders");

            migrationBuilder.RenameTable(
                name: "Customerss",
                newName: "Customers");

            migrationBuilder.RenameIndex(
                name: "IX_Orderss_CustomerId",
                table: "Orders",
                newName: "IX_Orders_CustomerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orders",
                table: "Orders",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customers",
                table: "Customers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProduct_Orders_OrdersId",
                table: "OrderProduct",
                column: "OrdersId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProduct_Products_ProductsId",
                table: "OrderProduct",
                column: "ProductsId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Customers_CustomerId",
                table: "Orders",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
