using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContactList_SimpleWebApp.Migrations
{
    /// <inheritdoc />
    public partial class ContactCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contact_Categories_MainCategoryCategory",
                table: "Contact");

            migrationBuilder.DropIndex(
                name: "IX_Contact_MainCategoryCategory",
                table: "Contact");

            migrationBuilder.DropColumn(
                name: "MainCategoryCategory",
                table: "Contact");

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Contact",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "Contact");

            migrationBuilder.AddColumn<string>(
                name: "MainCategoryCategory",
                table: "Contact",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contact_MainCategoryCategory",
                table: "Contact",
                column: "MainCategoryCategory");

            migrationBuilder.AddForeignKey(
                name: "FK_Contact_Categories_MainCategoryCategory",
                table: "Contact",
                column: "MainCategoryCategory",
                principalTable: "Categories",
                principalColumn: "Category");
        }
    }
}
