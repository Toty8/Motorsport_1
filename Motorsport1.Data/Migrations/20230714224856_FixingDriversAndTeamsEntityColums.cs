using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Motorsport1.Data.Migrations
{
    public partial class FixingDriversAndTeamsEntityColums : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BestResult",
                table: "Teams",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BestResultCount",
                table: "Teams",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LastYearStanding",
                table: "Teams",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BestResult",
                table: "Drivers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BestResultCount",
                table: "Drivers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LastYearStanding",
                table: "Drivers",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BestResult", "BestResultCount", "LastYearStanding" },
                values: new object[] { 1, 8, 1 });

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BestResult", "BestResultCount", "LastYearStanding" },
                values: new object[] { 1, 2, 3 });

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "BestResult", "BestResultCount", "LastYearStanding" },
                values: new object[] { 2, 2, 9 });

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "BestResult", "BestResultCount", "LastYearStanding" },
                values: new object[] { 2, 2, 6 });

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "BestResult", "BestResultCount", "LastYearStanding" },
                values: new object[] { 4, 1, 5 });

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "BestResult", "BestResultCount", "LastYearStanding" },
                values: new object[] { 3, 1, 4 });

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "BestResult", "BestResultCount", "LastYearStanding" },
                values: new object[] { 2, 1, 2 });

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "BestResult", "BestResultCount", "LastYearStanding" },
                values: new object[] { 4, 1, 15 });

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "BestResult", "BestResultCount", "LastYearStanding" },
                values: new object[] { 2, 1, 7 });

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "BestResult", "BestResultCount", "LastYearStanding" },
                values: new object[] { 3, 1, 8 });

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "BestResult", "BestResultCount" },
                values: new object[] { 4, 1 });

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "BestResult", "BestResultCount", "LastYearStanding" },
                values: new object[] { 7, 1, 14 });

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "BestResult", "BestResultCount", "LastYearStanding" },
                values: new object[] { 7, 1, 19 });

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "BestResult", "BestResultCount", "LastYearStanding" },
                values: new object[] { 7, 1, 22 });

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "BestResult", "BestResultCount", "LastYearStanding" },
                values: new object[] { 8, 1, 10 });

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "BestResult", "BestResultCount", "LastYearStanding" },
                values: new object[] { 9, 2, 18 });

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "BestResult", "BestResultCount", "LastYearStanding" },
                values: new object[] { 10, 2, 17 });

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "BestResult", "BestResultCount", "LastYearStanding" },
                values: new object[] { 10, 2, 13 });

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "BestResult", "BestResultCount" },
                values: new object[] { 11, 1 });

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "BestResult", "BestResultCount", "LastYearStanding" },
                values: new object[] { 12, 1, 21 });

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BestResult", "BestResultCount", "LastYearStanding" },
                values: new object[] { 1, 10, 1 });

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BestResult", "BestResultCount", "LastYearStanding" },
                values: new object[] { 2, 2, 3 });

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "BestResult", "BestResultCount", "LastYearStanding" },
                values: new object[] { 2, 2, 7 });

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "BestResult", "BestResultCount", "LastYearStanding" },
                values: new object[] { 2, 1, 2 });

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "BestResult", "BestResultCount", "LastYearStanding" },
                values: new object[] { 2, 1, 5 });

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "BestResult", "BestResultCount", "LastYearStanding" },
                values: new object[] { 3, 1, 4 });

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "BestResult", "BestResultCount", "LastYearStanding" },
                values: new object[] { 7, 1, 10 });

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "BestResult", "BestResultCount", "LastYearStanding" },
                values: new object[] { 7, 1, 8 });

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "BestResult", "BestResultCount", "LastYearStanding" },
                values: new object[] { 8, 1, 6 });

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "BestResult", "BestResultCount", "LastYearStanding" },
                values: new object[] { 10, 2, 9 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BestResult",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "BestResultCount",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "LastYearStanding",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "BestResult",
                table: "Drivers");

            migrationBuilder.DropColumn(
                name: "BestResultCount",
                table: "Drivers");

            migrationBuilder.DropColumn(
                name: "LastYearStanding",
                table: "Drivers");
        }
    }
}
