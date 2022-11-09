using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FairBankApi.Migrations
{
    public partial class AddedBank2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bank",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Swift = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserAdminId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bank", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bank_User_UserAdminId",
                        column: x => x.UserAdminId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Bank",
                columns: new[] { "Id", "Address", "Name", "Swift", "UserAdminId" },
                values: new object[] { 1, "Unska 3, 10000 Zagreb", "Fair Bank", "SQB129I", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Bank_UserAdminId",
                table: "Bank",
                column: "UserAdminId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bank");
        }
    }
}
