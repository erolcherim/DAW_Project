using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAW_Project.Migrations
{
    public partial class fixedattirbutes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BrachId",
                table: "Branch",
                newName: "BranchId");

            migrationBuilder.AddColumn<int>(
                name: "value",
                table: "Sale",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "NumberOfEmployees",
                table: "Branch",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "value",
                table: "Sale");

            migrationBuilder.RenameColumn(
                name: "BranchId",
                table: "Branch",
                newName: "BrachId");

            migrationBuilder.AlterColumn<int>(
                name: "NumberOfEmployees",
                table: "Branch",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
