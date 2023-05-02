using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContactList_SimpleWebApp.Migrations
{
    /// <inheritdoc />
    public partial class PlsWork1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_Categories_Category1",
                table: "Contacts");

            migrationBuilder.RenameColumn(
                name: "Category1",
                table: "Contacts",
                newName: "MainCategoryCategory");

            migrationBuilder.RenameIndex(
                name: "IX_Contacts_Category1",
                table: "Contacts",
                newName: "IX_Contacts_MainCategoryCategory");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_Categories_MainCategoryCategory",
                table: "Contacts",
                column: "MainCategoryCategory",
                principalTable: "Categories",
                principalColumn: "Category");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_Categories_MainCategoryCategory",
                table: "Contacts");

            migrationBuilder.RenameColumn(
                name: "MainCategoryCategory",
                table: "Contacts",
                newName: "Category1");

            migrationBuilder.RenameIndex(
                name: "IX_Contacts_MainCategoryCategory",
                table: "Contacts",
                newName: "IX_Contacts_Category1");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_Categories_Category1",
                table: "Contacts",
                column: "Category1",
                principalTable: "Categories",
                principalColumn: "Category");
        }
    }
}
