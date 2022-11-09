using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FairBankApi.Migrations
{
    public partial class AddedPassword : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordHash",
                table: "User",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordSalt",
                table: "User",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 147, 80, 160, 149, 28, 130, 94, 244, 96, 25, 122, 40, 43, 143, 240, 78, 32, 26, 29, 205, 175, 252, 131, 173, 35, 218, 104, 197, 200, 159, 57, 40, 255, 186, 254, 90, 189, 166, 42, 218, 72, 218, 95, 168, 117, 38, 17, 97, 231, 136, 185, 111, 165, 32, 78, 45, 223, 166, 185, 51, 190, 96, 54, 36 }, new byte[] { 244, 240, 163, 22, 249, 191, 217, 117, 114, 141, 190, 221, 54, 167, 56, 232, 45, 77, 84, 61, 49, 117, 58, 190, 152, 93, 81, 110, 124, 99, 59, 123, 68, 27, 18, 5, 64, 99, 17, 27, 111, 137, 68, 48, 59, 160, 197, 4, 244, 228, 86, 54, 81, 228, 135, 205, 77, 62, 221, 39, 180, 0, 162, 81, 193, 246, 133, 34, 129, 45, 194, 195, 86, 245, 240, 55, 136, 43, 245, 110, 103, 25, 143, 95, 64, 214, 192, 20, 227, 208, 7, 204, 155, 72, 79, 230, 27, 255, 111, 213, 153, 104, 187, 104, 90, 5, 226, 197, 186, 225, 158, 231, 11, 202, 45, 134, 210, 65, 229, 238, 236, 18, 151, 0, 190, 171, 197, 32 } });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "User");

            migrationBuilder.DropColumn(
                name: "PasswordSalt",
                table: "User");
        }
    }
}
