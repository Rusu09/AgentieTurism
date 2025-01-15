using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgentieTurism.Migrations
{
    /// <inheritdoc />
    public partial class Location : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LocationID",
                table: "Vacation",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vacation_LocationID",
                table: "Vacation",
                column: "LocationID");

            migrationBuilder.AddForeignKey(
                name: "FK_Vacation_Location_LocationID",
                table: "Vacation",
                column: "LocationID",
                principalTable: "Location",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vacation_Location_LocationID",
                table: "Vacation");

            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DropIndex(
                name: "IX_Vacation_LocationID",
                table: "Vacation");

            migrationBuilder.DropColumn(
                name: "LocationID",
                table: "Vacation");
        }
    }
}
