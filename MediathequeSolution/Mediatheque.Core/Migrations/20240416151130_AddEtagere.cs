using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mediatheque.Core.Migrations
{
    /// <inheritdoc />
    public partial class AddEtagere : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EtagereId",
                table: "CDs",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Etageres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Emplacement = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Etageres", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_CDs_EtagereId",
                table: "CDs",
                column: "EtagereId");

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

            migrationBuilder.DropTable(
                name: "Etageres");

            migrationBuilder.DropIndex(
                name: "IX_CDs_EtagereId",
                table: "CDs");

            migrationBuilder.DropColumn(
                name: "EtagereId",
                table: "CDs");
        }
    }
}
