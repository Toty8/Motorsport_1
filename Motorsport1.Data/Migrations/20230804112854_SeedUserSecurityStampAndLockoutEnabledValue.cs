using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Motorsport1.Data.Migrations
{
    public partial class SeedUserSecurityStampAndLockoutEnabledValue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("0de4c685-3ea5-4f74-b54b-8464457a7e02"),
                columns: new[] { "ConcurrencyStamp", "LockoutEnabled", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5a1e8bb2-d2ef-479d-a31f-4e126cf87b85", true, "AQAAAAEAACcQAAAAEHEBRkgp4T6RoRewdZHg3Z2IDjz7opblSsKGNYBJP+R9odRJIpHauCY2oKHZEKhULg==", "2fdbcd92-6b6d-42b9-8003-d991ff6a867c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e15aea71-c074-4164-bf8a-01b9f3dbb497"),
                columns: new[] { "ConcurrencyStamp", "LockoutEnabled", "PasswordHash", "SecurityStamp" },
                values: new object[] { "57e2a6f7-f767-4344-840c-62bcc6270de2", true, "AQAAAAEAACcQAAAAEO35J/lFMZVzmZTTPTulZUkfgLsb7D1STtFIsfY25nk123GDnJoJse++2GlAhCgpbg==", "b34ce806-b120-4199-af5e-c41854f96c44" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("0de4c685-3ea5-4f74-b54b-8464457a7e02"),
                columns: new[] { "ConcurrencyStamp", "LockoutEnabled", "PasswordHash", "SecurityStamp" },
                values: new object[] { "39464cde-3908-4716-b347-b77659425a49", false, "AQAAAAEAACcQAAAAEI1HrzaSgjU6BQ6+HZrZ2N+nfqriS+Tm9lmyPxeSv9gMl2aZ+oFAH9HUems86G4TLg==", null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e15aea71-c074-4164-bf8a-01b9f3dbb497"),
                columns: new[] { "ConcurrencyStamp", "LockoutEnabled", "PasswordHash", "SecurityStamp" },
                values: new object[] { "34321301-3dce-427b-924f-0e97a37c56b9", false, "AQAAAAEAACcQAAAAENPjk4mn/S/7esY/MQ8oj6m++Ltdvj0P4pm3AD9lf85vRVLINLEg6FLV499W3yWl/A==", null });
        }
    }
}
