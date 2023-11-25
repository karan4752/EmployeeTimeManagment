using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ETM.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddTimeSheetAndDataSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TimeSheet_Employees_EmployeeID",
                table: "TimeSheet");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TimeSheet",
                table: "TimeSheet");

            migrationBuilder.RenameTable(
                name: "TimeSheet",
                newName: "TimeSheets");

            migrationBuilder.RenameIndex(
                name: "IX_TimeSheet_EmployeeID",
                table: "TimeSheets",
                newName: "IX_TimeSheets_EmployeeID");

            migrationBuilder.AlterColumn<string>(
                name: "ProjectName",
                table: "Projects",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TimeSheets",
                table: "TimeSheets",
                column: "TimeSheetID");

            migrationBuilder.AddForeignKey(
                name: "FK_TimeSheets_Employees_EmployeeID",
                table: "TimeSheets",
                column: "EmployeeID",
                principalTable: "Employees",
                principalColumn: "EmployeeID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TimeSheets_Employees_EmployeeID",
                table: "TimeSheets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TimeSheets",
                table: "TimeSheets");

            migrationBuilder.RenameTable(
                name: "TimeSheets",
                newName: "TimeSheet");

            migrationBuilder.RenameIndex(
                name: "IX_TimeSheets_EmployeeID",
                table: "TimeSheet",
                newName: "IX_TimeSheet_EmployeeID");

            migrationBuilder.AlterColumn<int>(
                name: "ProjectName",
                table: "Projects",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TimeSheet",
                table: "TimeSheet",
                column: "TimeSheetID");

            migrationBuilder.AddForeignKey(
                name: "FK_TimeSheet_Employees_EmployeeID",
                table: "TimeSheet",
                column: "EmployeeID",
                principalTable: "Employees",
                principalColumn: "EmployeeID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
