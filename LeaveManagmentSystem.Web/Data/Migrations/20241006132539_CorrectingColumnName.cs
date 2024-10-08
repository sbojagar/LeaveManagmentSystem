using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagmentSystem.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class CorrectingColumnName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LeaveTypeNamw",
                table: "LeaveTypes",
                newName: "LeaveTypeName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LeaveTypeName",
                table: "LeaveTypes",
                newName: "LeaveTypeNamw");
        }
    }
}
