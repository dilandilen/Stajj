using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class orders : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Not",
                table: "Orders",
                newName: "Phone");

            migrationBuilder.RenameColumn(
                name: "Emaill",
                table: "Orders",
                newName: "OrderNote");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "Total",
                table: "Orders",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Total",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "Orders",
                newName: "Not");

            migrationBuilder.RenameColumn(
                name: "OrderNote",
                table: "Orders",
                newName: "Emaill");
        }
    }
}
