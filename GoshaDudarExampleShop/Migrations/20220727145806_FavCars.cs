using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoshaDudarExampleShop.Migrations
{
    public partial class FavCars : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ShopCartId",
                table: "ShopCartItem",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Price",
                table: "Car",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.CreateTable(
                name: "ShopCart",
                columns: table => new
                {
                    ShopCartId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopCart", x => x.ShopCartId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShopCartItem_ShopCartId",
                table: "ShopCartItem",
                column: "ShopCartId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShopCartItem_ShopCart_ShopCartId",
                table: "ShopCartItem",
                column: "ShopCartId",
                principalTable: "ShopCart",
                principalColumn: "ShopCartId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShopCartItem_ShopCart_ShopCartId",
                table: "ShopCartItem");

            migrationBuilder.DropTable(
                name: "ShopCart");

            migrationBuilder.DropIndex(
                name: "IX_ShopCartItem_ShopCartId",
                table: "ShopCartItem");

            migrationBuilder.AlterColumn<string>(
                name: "ShopCartId",
                table: "ShopCartItem",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "Price",
                table: "Car",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
