using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Motorsport1.Data.Migrations
{
    public partial class SeedingTeamsAndDrivers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Drivers");

            migrationBuilder.AddColumn<int>(
                name: "Championships",
                table: "Teams",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Teams",
                type: "nvarchar(2048)",
                maxLength: 2048,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "PolePositions",
                table: "Teams",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<bool>(
                name: "IsCurrentChampion",
                table: "Drivers",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<int>(
                name: "Championships",
                table: "Drivers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Drivers",
                type: "nvarchar(2048)",
                maxLength: 2048,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "PolePositions",
                table: "Drivers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "PublishedDateTime",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 11, 17, 30, 49, 927, DateTimeKind.Utc).AddTicks(2385),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 11, 12, 1, 34, 799, DateTimeKind.Utc).AddTicks(8061));

            migrationBuilder.AlterColumn<DateTime>(
                name: "PublishedDateTime",
                table: "Articles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 11, 17, 30, 49, 927, DateTimeKind.Utc).AddTicks(1285),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 11, 12, 1, 34, 799, DateTimeKind.Utc).AddTicks(6783));

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Articles",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "Championships", "ImageUrl", "Name", "Podiums", "Points", "PolePositions", "Price", "TotalPoints", "Wins" },
                values: new object[,]
                {
                    { 1, 5, "https://media.formula1.com/content/dam/fom-website/2018-redesign-assets/team%20logos/red%20bull.jpg", "Oracle Red Bull Racing", 249, 411.0, 91, 93m, 6799.0, 102 },
                    { 2, 8, "https://media.formula1.com/content/dam/fom-website/2018-redesign-assets/team%20logos/mercedes.jpg", "Mercedes-AMG PETRONAS F1 Team", 286, 203.0, 128, 77m, 7155.6400000000003, 116 },
                    { 3, 0, "https://media.formula1.com/content/dam/fom-website/2018-redesign-assets/team%20logos/aston%20martin.jpg", "Aston Martin Aramco Cognizant F1 Team", 7, 181.0, 0, 75m, 313.0, 0 },
                    { 4, 16, "https://media.formula1.com/content/dam/fom-website/teams/Ferrari/logo-ferrari-18%20.jpg", "Scuderia Ferrari", 811, 157.0, 244, 71m, 10315.77, 243 },
                    { 5, 8, "https://media.formula1.com/content/dam/fom-website/2018-redesign-assets/team%20logos/mclaren.jpg", "McLaren F1 Team", 495, 59.0, 156, 37m, 6366.5, 183 },
                    { 6, 0, "https://media.formula1.com/content/dam/fom-website/2018-redesign-assets/team%20logos/alpine.jpg", "BWT Alpine F1 Team", 3, 47.0, 0, 35m, 375.0, 1 },
                    { 7, 9, "https://media.formula1.com/content/dam/fom-website/2018-redesign-assets/team%20logos/williams.jpg", "Williams Racing", 313, 11.0, 128, 14m, 3609.0, 114 },
                    { 8, 0, "https://media.formula1.com/content/dam/fom-website/2018-redesign-assets/team%20logos/haas.jpg", "MoneyGram Haas F1 Team", 0, 11.0, 0, 14m, 248.0, 0 },
                    { 9, 2, "https://media.formula1.com/content/dam/fom-website/2018-redesign-assets/team%20logos/alfa%20romeo.jpg", "Alfa Romeo F1 Team Stake", 28, 9.0, 12, 13m, 356.0, 11 },
                    { 10, 0, "https://media.formula1.com/content/dam/fom-website/2018-redesign-assets/team%20logos/alphatauri.jpg", "Scuderia AlphaTauri", 2, 2.0, 0, 9m, 286.0, 1 }
                });

            migrationBuilder.InsertData(
                table: "Drivers",
                columns: new[] { "Id", "BirthDate", "Championships", "ImageUrl", "IsCurrentChampion", "Name", "Number", "Podiums", "Points", "PolePositions", "Price", "TeamId", "TotalPoints", "Wins" },
                values: new object[] { 1, new DateTime(1997, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://media.formula1.com/content/dam/fom-website/drivers/2023Drivers/verstappen.jpg.img.1920.medium.jpg/1677069646195.jpg", true, "Max Verstappen", 1, 87, 255.0, 27, 81m, 1, 2266.5, 43 });

            migrationBuilder.InsertData(
                table: "Drivers",
                columns: new[] { "Id", "BirthDate", "Championships", "ImageUrl", "Name", "Number", "Podiums", "Points", "PolePositions", "Price", "TeamId", "TotalPoints", "Wins" },
                values: new object[,]
                {
                    { 2, new DateTime(1990, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "https://media.formula1.com/content/dam/fom-website/drivers/2023Drivers/perez.jpg.img.1920.medium.jpg/1677069773437.jpg", "Sergio Perez", 11, 31, 156.0, 3, 68m, 1, 1357.0, 6 },
                    { 3, new DateTime(1981, 7, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://media.formula1.com/content/dam/fom-website/drivers/2023Drivers/alonso.jpg.img.1920.medium.jpg/1677244577162.jpg", "Fernando Alonso", 14, 104, 137.0, 22, 62m, 3, 2198.0, 32 },
                    { 4, new DateTime(1985, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, "https://media.formula1.com/content/dam/fom-website/drivers/2023Drivers/hamilton.jpg.img.1920.medium.jpg/1677069594164.jpg", "Lewis Hamilton", 44, 195, 121.0, 103, 58m, 2, 4526.5, 103 },
                    { 5, new DateTime(1994, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "https://media.formula1.com/content/dam/fom-website/drivers/2023Drivers/sainz.jpg.img.1920.medium.jpg/1677069189406.jpg", "Carlos Sainz", 55, 15, 83.0, 3, 48m, 4, 865.5, 1 },
                    { 6, new DateTime(1998, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "https://media.formula1.com/content/dam/fom-website/drivers/2023Drivers/russell.jpg.img.1920.medium.jpg/1677069334466.jpg", "George Russell", 63, 10, 82.0, 2, 47m, 2, 376.0, 1 },
                    { 7, new DateTime(1997, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "https://media.formula1.com/content/dam/fom-website/drivers/2023Drivers/leclerc.jpg.img.1920.medium.jpg/1677069223130.jpg", "Charles Leclerc", 16, 26, 74.0, 19, 42m, 4, 942.0, 5 },
                    { 8, new DateTime(1998, 10, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "https://media.formula1.com/content/dam/fom-website/drivers/2023Drivers/stroll.jpg.img.1920.medium.jpg/1677069453013.jpg", "Lance Stroll", 18, 3, 44.0, 1, 31m, 3, 238.0, 0 },
                    { 9, new DateTime(1999, 11, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "https://media.formula1.com/content/dam/fom-website/drivers/2023Drivers/norris.jpg.img.1920.medium.jpg/1677069505471.jpg", "Lando Norris", 4, 7, 42.0, 1, 30m, 5, 470.0, 0 },
                    { 10, new DateTime(1996, 9, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "https://media.formula1.com/content/dam/fom-website/drivers/2023Drivers/ocon.jpg.img.1920.medium.jpg/1677069269007.jpg", "Esteban Ocon", 31, 3, 31.0, 0, 24m, 6, 395.0, 1 },
                    { 11, new DateTime(2001, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "https://media.formula1.com/content/dam/fom-website/drivers/2023Drivers/piastri.jpg.img.1920.medium.jpg/1676983075734.jpg", "Oscar Piastri", 81, 0, 17.0, 0, 17m, 5, 17.0, 0 },
                    { 12, new DateTime(1996, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "https://media.formula1.com/content/dam/fom-website/drivers/2023Drivers/gasly.jpg.img.1920.medium.jpg/1676983081984.jpg", "Pierre Gasly", 10, 3, 16.0, 0, 16m, 6, 348.0, 1 },
                    { 13, new DateTime(1996, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "https://media.formula1.com/content/dam/fom-website/drivers/2023Drivers/albon.jpg.img.1920.medium.jpg/1677068770293.jpg", "Alexander Albon", 23, 2, 11.0, 0, 14m, 7, 212.0, 0 },
                    { 14, new DateTime(1987, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "https://media.formula1.com/content/dam/fom-website/drivers/2023Drivers/hulkenberg.jpg.img.1920.medium.jpg/1676983071882.jpg", "Nico Hulkenberg", 27, 0, 9.0, 1, 13m, 8, 530.0, 0 },
                    { 15, new DateTime(1989, 8, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "https://media.formula1.com/content/dam/fom-website/drivers/2023Drivers/bottas.jpg.img.1920.medium.jpg/1677069810695.jpg", "Valtteri Bottas", 77, 67, 5.0, 20, 10m, 9, 1792.0, 10 },
                    { 16, new DateTime(1999, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "https://media.formula1.com/content/dam/fom-website/drivers/2023Drivers/zhou.jpg.img.1920.medium.jpg/1677069909295.jpg", "Zhou Guanyu", 24, 0, 4.0, 0, 9m, 9, 10.0, 0 },
                    { 17, new DateTime(2000, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "https://media.formula1.com/content/dam/fom-website/drivers/2023Drivers/tsunoda.jpg.img.1920.medium.jpg/1677069846213.jpg", "Yuki Tsunoda", 22, 0, 2.0, 0, 7m, 10, 46.0, 0 },
                    { 18, new DateTime(1992, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "https://media.formula1.com/content/dam/fom-website/drivers/2023Drivers/magnussen.jpg.img.1920.medium.jpg/1677069387823.jpg", "Kevin Magnussen", 20, 1, 2.0, 0, 7m, 8, 185.0, 0 },
                    { 19, new DateTime(2000, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "https://media.formula1.com/content/dam/fom-website/drivers/2023Drivers/sargeant.jpg.img.1920.medium.jpg/1676983079144.jpg", "Logan Sargeant", 2, 0, 0.0, 0, 5m, 7, 0.0, 0 },
                    { 20, new DateTime(1995, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "https://media.formula1.com/content/dam/fom-website/drivers/2023Drivers/devries.jpg.img.1920.medium.jpg/1676983081637.jpg", "Nyck De Vries", 21, 0, 0.0, 0, 5m, 10, 2.0, 0 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DropColumn(
                name: "Championships",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "PolePositions",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "Championships",
                table: "Drivers");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Drivers");

            migrationBuilder.DropColumn(
                name: "PolePositions",
                table: "Drivers");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Teams",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "IsCurrentChampion",
                table: "Drivers",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Drivers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "PublishedDateTime",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 11, 12, 1, 34, 799, DateTimeKind.Utc).AddTicks(8061),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 11, 17, 30, 49, 927, DateTimeKind.Utc).AddTicks(2385));

            migrationBuilder.AlterColumn<DateTime>(
                name: "PublishedDateTime",
                table: "Articles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 11, 12, 1, 34, 799, DateTimeKind.Utc).AddTicks(6783),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 11, 17, 30, 49, 927, DateTimeKind.Utc).AddTicks(1285));

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Articles",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true);
        }
    }
}
