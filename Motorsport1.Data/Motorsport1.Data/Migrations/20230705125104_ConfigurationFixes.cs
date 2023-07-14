using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Motorsport1.Data.Migrations
{
    public partial class ConfigurationFixes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "PublishedDateTime",
                table: "Articles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 5, 12, 51, 3, 970, DateTimeKind.Utc).AddTicks(8787),
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 1,
                column: "PublishedDateTime",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 2,
                column: "PublishedDateTime",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ImageUrl", "PublishedDateTime", "Title" },
                values: new object[] { "https://media.formula1.com/image/upload/t_16by9Centre/f_auto/q_auto/v1687120328/trackside-images/2023/F1_Grand_Prix_of_Canada/1499543157.jpg.transform/9col/image.jpg", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Canada post-race press conference" });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "PublishedDateTime",
                value: new DateTime(2023, 7, 5, 12, 51, 3, 971, DateTimeKind.Utc).AddTicks(541));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "PublishedDateTime",
                value: new DateTime(2023, 7, 5, 12, 51, 3, 971, DateTimeKind.Utc).AddTicks(544));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3,
                column: "PublishedDateTime",
                value: new DateTime(2023, 7, 5, 12, 51, 3, 971, DateTimeKind.Utc).AddTicks(545));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "PublishedDateTime",
                table: "Articles",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 5, 12, 51, 3, 970, DateTimeKind.Utc).AddTicks(8787));

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 1,
                column: "PublishedDateTime",
                value: new DateTime(2023, 7, 4, 10, 25, 40, 264, DateTimeKind.Utc).AddTicks(6410));

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 2,
                column: "PublishedDateTime",
                value: new DateTime(2023, 7, 4, 10, 25, 40, 264, DateTimeKind.Utc).AddTicks(6435));

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ImageUrl", "PublishedDateTime", "Title" },
                values: new object[] { "https://www.topgear.com/sites/default/files/news-listicle/image/2023/07/0-Austrian-GP.jpg", new DateTime(2023, 7, 4, 10, 25, 40, 264, DateTimeKind.Utc).AddTicks(6438), "Exhilarating race in Austria as Verstappen takes victory and Norris shines" });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "PublishedDateTime",
                value: new DateTime(2023, 7, 4, 10, 25, 40, 264, DateTimeKind.Utc).AddTicks(7157));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "PublishedDateTime",
                value: new DateTime(2023, 7, 4, 10, 25, 40, 264, DateTimeKind.Utc).AddTicks(7161));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3,
                column: "PublishedDateTime",
                value: new DateTime(2023, 7, 4, 10, 25, 40, 264, DateTimeKind.Utc).AddTicks(7163));
        }
    }
}
