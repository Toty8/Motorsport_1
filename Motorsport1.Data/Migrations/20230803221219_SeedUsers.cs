using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Motorsport1.Data.Migrations
{
    public partial class SeedUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DriverId", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TeamId", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("0de4c685-3ea5-4f74-b54b-8464457a7e02"), 0, "39464cde-3908-4716-b347-b77659425a49", null, "Publisher@publisher.com", false, "Publisher", "Publisher", false, null, "PUBLISHER@PUBLISHER.COM", "PUBLISHER@PUBLISHER.COM", "AQAAAAEAACcQAAAAEI1HrzaSgjU6BQ6+HZrZ2N+nfqriS+Tm9lmyPxeSv9gMl2aZ+oFAH9HUems86G4TLg==", null, false, null, null, false, "Publisher@publisher.com" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DriverId", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TeamId", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("e15aea71-c074-4164-bf8a-01b9f3dbb497"), 0, "34321301-3dce-427b-924f-0e97a37c56b9", null, "Admin@admin.com", false, "Admin", "Admin", false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAENPjk4mn/S/7esY/MQ8oj6m++Ltdvj0P4pm3AD9lf85vRVLINLEg6FLV499W3yWl/A==", null, false, null, null, false, "Admin@admin.com" });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 1,
                column: "PublisherId",
                value: new Guid("e15aea71-c074-4164-bf8a-01b9f3dbb497"));

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 2,
                column: "PublisherId",
                value: new Guid("e15aea71-c074-4164-bf8a-01b9f3dbb497"));

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 3,
                column: "PublisherId",
                value: new Guid("e15aea71-c074-4164-bf8a-01b9f3dbb497"));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "PublisherId",
                value: new Guid("e15aea71-c074-4164-bf8a-01b9f3dbb497"));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "PublisherId",
                value: new Guid("e15aea71-c074-4164-bf8a-01b9f3dbb497"));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3,
                column: "PublisherId",
                value: new Guid("e15aea71-c074-4164-bf8a-01b9f3dbb497"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("0de4c685-3ea5-4f74-b54b-8464457a7e02"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e15aea71-c074-4164-bf8a-01b9f3dbb497"));

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 1,
                column: "PublisherId",
                value: new Guid("56b03886-bcb8-4775-ba5f-ade84e6b7a4f"));

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 2,
                column: "PublisherId",
                value: new Guid("56b03886-bcb8-4775-ba5f-ade84e6b7a4f"));

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 3,
                column: "PublisherId",
                value: new Guid("56b03886-bcb8-4775-ba5f-ade84e6b7a4f"));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "PublisherId",
                value: new Guid("56b03886-bcb8-4775-ba5f-ade84e6b7a4f"));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "PublisherId",
                value: new Guid("56b03886-bcb8-4775-ba5f-ade84e6b7a4f"));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3,
                column: "PublisherId",
                value: new Guid("56b03886-bcb8-4775-ba5f-ade84e6b7a4f"));
        }
    }
}
