using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LXxUS.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class updatePhoneNumber : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Phone_Number",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Phone_Number",
                table: "AspNetUsers");
        }
    }
}
