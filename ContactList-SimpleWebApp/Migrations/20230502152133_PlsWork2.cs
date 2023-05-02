using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContactList_SimpleWebApp.Migrations
{
    /// <inheritdoc />
    public partial class PlsWork2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_Categories_MainCategoryCategory",
                table: "Contacts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Contacts",
                table: "Contacts");

            migrationBuilder.RenameTable(
                name: "Contacts",
                newName: "Contact");

            migrationBuilder.RenameIndex(
                name: "IX_Contacts_MainCategoryCategory",
                table: "Contact",
                newName: "IX_Contact_MainCategoryCategory");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Contact",
                table: "Contact",
                column: "Email");

            migrationBuilder.AddForeignKey(
                name: "FK_Contact_Categories_MainCategoryCategory",
                table: "Contact",
                column: "MainCategoryCategory",
                principalTable: "Categories",
                principalColumn: "Category");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contact_Categories_MainCategoryCategory",
                table: "Contact");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Contact",
                table: "Contact");

            migrationBuilder.RenameTable(
                name: "Contact",
                newName: "Contacts");

            migrationBuilder.RenameIndex(
                name: "IX_Contact_MainCategoryCategory",
                table: "Contacts",
                newName: "IX_Contacts_MainCategoryCategory");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Contacts",
                table: "Contacts",
                column: "Email");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_Categories_MainCategoryCategory",
                table: "Contacts",
                column: "MainCategoryCategory",
                principalTable: "Categories",
                principalColumn: "Category");
        }
    }
}
