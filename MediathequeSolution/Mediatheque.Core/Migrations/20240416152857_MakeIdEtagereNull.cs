using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mediatheque.Core.Migrations
{
    /// <inheritdoc />
    public partial class MakeIdEtagereNull : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CDs_Etageres_EtagereId",
                table: "CDs");

            migrationBuilder.AlterColumn<int>(
                name: "EtagereId",
                table: "CDs",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_CDs_Etageres_EtagereId",
                table: "CDs",
                column: "EtagereId",
                principalTable: "Etageres",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CDs_Etageres_EtagereId",
                table: "CDs");

            migrationBuilder.AlterColumn<int>(
                name: "EtagereId",
                table: "CDs",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CDs_Etageres_EtagereId",
                table: "CDs",
                column: "EtagereId",
                principalTable: "Etageres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
