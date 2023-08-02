using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Motorsport1.Data.Migrations
{
    public partial class AddSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Very Important" },
                    { 2, "News" },
                    { 3, "Race Report" },
                    { 4, "Press Conference" }
                });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "BestResult", "BestResultCount", "Championships", "ImageUrl", "LastYearStanding", "Name", "Podiums", "Points", "PolePositions", "Price", "TotalPoints", "Wins" },
                values: new object[,]
                {
                    { 1, 1, 10, 5, "https://media.formula1.com/content/dam/fom-website/2018-redesign-assets/team%20logos/red%20bull.jpg", 1, "Oracle Red Bull Racing", 249, 411.0, 91, 93m, 6799.0, 102 },
                    { 2, 2, 2, 8, "https://media.formula1.com/content/dam/fom-website/2018-redesign-assets/team%20logos/mercedes.jpg", 3, "Mercedes-AMG PETRONAS F1 Team", 286, 203.0, 128, 77m, 7155.6400000000003, 116 }
                });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "BestResult", "BestResultCount", "ImageUrl", "LastYearStanding", "Name", "Podiums", "Points", "Price", "TotalPoints" },
                values: new object[] { 3, 2, 2, "https://media.formula1.com/content/dam/fom-website/2018-redesign-assets/team%20logos/aston%20martin.jpg", 7, "Aston Martin Aramco Cognizant F1 Team", 7, 181.0, 75m, 313.0 });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "BestResult", "BestResultCount", "Championships", "ImageUrl", "LastYearStanding", "Name", "Podiums", "Points", "PolePositions", "Price", "TotalPoints", "Wins" },
                values: new object[,]
                {
                    { 4, 2, 1, 16, "https://media.formula1.com/content/dam/fom-website/teams/Ferrari/logo-ferrari-18%20.jpg", 2, "Scuderia Ferrari", 811, 157.0, 244, 71m, 10315.77, 243 },
                    { 5, 2, 1, 8, "https://media.formula1.com/content/dam/fom-website/2018-redesign-assets/team%20logos/mclaren.jpg", 5, "McLaren F1 Team", 495, 59.0, 156, 37m, 6366.5, 183 }
                });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "BestResult", "BestResultCount", "ImageUrl", "LastYearStanding", "Name", "Podiums", "Points", "Price", "TotalPoints", "Wins" },
                values: new object[] { 6, 3, 1, "https://media.formula1.com/content/dam/fom-website/2018-redesign-assets/team%20logos/alpine.jpg", 4, "BWT Alpine F1 Team", 3, 47.0, 35m, 375.0, 1 });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "BestResult", "BestResultCount", "Championships", "ImageUrl", "LastYearStanding", "Name", "Podiums", "Points", "PolePositions", "Price", "TotalPoints", "Wins" },
                values: new object[] { 7, 7, 1, 9, "https://media.formula1.com/content/dam/fom-website/2018-redesign-assets/team%20logos/williams.jpg", 10, "Williams Racing", 313, 11.0, 128, 14m, 3609.0, 114 });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "BestResult", "BestResultCount", "ImageUrl", "LastYearStanding", "Name", "Points", "Price", "TotalPoints" },
                values: new object[] { 8, 7, 1, "https://media.formula1.com/content/dam/fom-website/2018-redesign-assets/team%20logos/haas.jpg", 8, "MoneyGram Haas F1 Team", 11.0, 14m, 248.0 });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "BestResult", "BestResultCount", "Championships", "ImageUrl", "LastYearStanding", "Name", "Podiums", "Points", "PolePositions", "Price", "TotalPoints", "Wins" },
                values: new object[] { 9, 8, 1, 2, "https://media.formula1.com/content/dam/fom-website/2018-redesign-assets/team%20logos/alfa%20romeo.jpg", 6, "Alfa Romeo F1 Team Stake", 28, 9.0, 12, 13m, 356.0, 11 });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "BestResult", "BestResultCount", "ImageUrl", "LastYearStanding", "Name", "Podiums", "Points", "Price", "TotalPoints", "Wins" },
                values: new object[] { 10, 10, 2, "https://media.formula1.com/content/dam/fom-website/2018-redesign-assets/team%20logos/alphatauri.jpg", 9, "Scuderia AlphaTauri", 2, 2.0, 9m, 286.0, 1 });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "ImageUrl", "Information", "IsActive", "Likes", "PublisherId", "ReadCount", "Title" },
                values: new object[,]
                {
                    { 1, 2, "https://media.formula1.com/image/upload/f_auto/q_auto/v1688394388/fom-website/2023/Austria/albon-austria-2023-2.png.transform/9col/image.png", "Alex Albon believes the chance was there for Williams to score more points during the Austrian Grand Prix Sprint weekend but, while disappointed to ultimately miss out on a reward, he drew optimism from the team’s level of performance.\r\n\r\nAlbon and Williams arrived at the Red Bull Ring after the Thai-British driver’s fine run to seventh in Canada, giving the Grove outfit their second points finish of the season and lifting them above AlphaTauri at the foot of the F1 standings.\r\n\r\nWith the FW45’s straight-line strengths also suited to the Spielberg venue, Albon was in the top-10 mix throughout the weekend, battling to score points in both the Sprint and full Grand Prix.", true, 0, new Guid("56b03886-bcb8-4775-ba5f-ade84e6b7a4f"), 0, "‘We should have come away with points’ – Albon feels Williams missed an opportunity in Austria as he pinpoints ‘next chance’ to score" },
                    { 2, 3, "https://www.topgear.com/sites/default/files/news-listicle/image/2023/07/0-Austrian-GP.jpg", "Max Verstappen secured his fifth race win in a row in Austria with an exemplary performance – including bagging an extra point for fastest lap – as he extended his lead at the top of the drivers’ standings.\r\n\r\nThe Red Bull man was dominant once more as he led home Ferrari’s Charles Leclerc and team mate Sergio Perez, who had an impressive drive of his own as he worked his way up from a P15 start to the podium.\r\n\r\nMcLaren’s Lando Norris was another who had much to celebrate at the Red Bull Ring, as he earned the Driver of the Day award for a stellar performance to take P5 in his upgraded car, one place behind his former team mate Carlos Sainz.\r\n\r\nIt was a less positive day for the likes of Mercedes, with Lewis Hamilton on the receiving end of a stern radio message from team boss Toto Wolff, while there was also a smattering of time penalties dished out to drivers for track limit violations.\r\n\r\nWatch the highlights from a frantic race in Austria by clicking on the video above.", true, 0, new Guid("56b03886-bcb8-4775-ba5f-ade84e6b7a4f"), 0, "Exhilarating race in Austria as Verstappen takes victory and Norris shines" },
                    { 3, 4, "https://media.formula1.com/image/upload/t_16by9Centre/f_auto/q_auto/v1687120328/trackside-images/2023/F1_Grand_Prix_of_Canada/1499543157.jpg.transform/9col/image.jpg", "Q: Congratulations, Max yet another victory from the lights to the flag. How are you feeling?\r\n\r\nMax VERSTAPPEN: Yeah, of course I'm very happy right now. It was not a very straightforward race because the tyres were not really getting in their window. It was very cold today compared to Friday and we were sliding around quite a bit. But yeah, we made it work and yeah to win again, today to win the 100th Grand Prix for the team, that's incredible.\r\n\r\nQ: Yeah, you must have a pretty special feeling about that. You've worked with this team for many years. Hundredth win, how does that feel to take that for the team here?\r\n\r\nMV: It’s amazing. I mean, I never expected to be on these kinds of numbers myself as well, you know. So, yeah, we keep enjoying, we keep working hard. But today has been a great day again.\r\n\r\nQ: Did you expect a bigger challenge from Aston or Mercedes here? Or is this is pretty much what you expected here in Montréal?\r\n\r\nMV: Firstly, I expected more or less what we had today, but it was, like I said, really difficult to just keep the grip, the temperature into the tyres, because the grip was disappearing very quickly. That's why maybe the gap was not that big. But yeah, we had a few Safety Cars here and there. But yeah, overall, we won, that's the most important.\r\n\r\nQ: And lastly, this is always a very special race to come to. A lot of fans here for the sport. They've been through a lot this weekend with the weather. Have you got a message for them?\r\n\r\nMV: Yeah, I mean, they're so passionate about the sport. Also, yesterday with the rain, they were just hanging in there, so that was great to see. And yeah, we love coming here. And hopefully we can do this for a long time.\r\n\r\nQ: You’ve got a few fans here, Fernando. Was that the race you expected?\r\n\r\nFernando ALONSO: Probably yes. I think we were hoping to challenge a little more the Red Bull. But we lost a place at the start with Lewis and then yeah, it was a battle with the Mercedes and Lewis was pushing all the race, so I didn't have one lap where I could relax a little bit. So it was an amazing battle.\r\n\r\nQ: It was lovely watching three multiple World Champions going at it. And you had a good little tussle with Lewis out there as well.\r\n\r\nFA: I mean, at the beginning, I had a little bit more pace. At the end I think Lewis had a bit more pace. Yeah, it was tough. It was a very demanding race, you know, all 70 laps of qualifying today.\r\n\r\nQ: We heard you had a few issues. You had to do a little bit of lift and coast. It's always frustrating because you want to push to the maximum. Was that a fuel issue? Or was that a rear brake issue?\r\n\r\nFA: I don't really know. They didn't tell me so maybe it was not to make me worry too much. But I don't know. I felt the car was OK. But I was just following the instructions. So yeah, hopefully that means that we have a little bit more pace. So next one, putting more pressure on Max.", true, 0, new Guid("56b03886-bcb8-4775-ba5f-ade84e6b7a4f"), 0, "Canada post-race press conference" }
                });

            migrationBuilder.InsertData(
                table: "Drivers",
                columns: new[] { "Id", "BestResult", "BestResultCount", "BirthDate", "Championships", "ImageUrl", "IsCurrentChampion", "LastYearStanding", "Name", "Number", "Podiums", "Points", "PolePositions", "Price", "TeamId", "TotalPoints", "Wins" },
                values: new object[] { 1, 1, 8, new DateTime(1997, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://media.formula1.com/content/dam/fom-website/drivers/2023Drivers/verstappen.jpg.img.1920.medium.jpg/1677069646195.jpg", true, 1, "Max Verstappen", 1, 87, 255.0, 27, 81m, 1, 2266.5, 43 });

            migrationBuilder.InsertData(
                table: "Drivers",
                columns: new[] { "Id", "BestResult", "BestResultCount", "BirthDate", "ImageUrl", "LastYearStanding", "Name", "Number", "Podiums", "Points", "PolePositions", "Price", "TeamId", "TotalPoints", "Wins" },
                values: new object[] { 2, 1, 2, new DateTime(1990, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://media.formula1.com/content/dam/fom-website/drivers/2023Drivers/perez.jpg.img.1920.medium.jpg/1677069773437.jpg", 3, "Sergio Perez", 11, 31, 156.0, 3, 68m, 1, 1357.0, 6 });

            migrationBuilder.InsertData(
                table: "Drivers",
                columns: new[] { "Id", "BestResult", "BestResultCount", "BirthDate", "Championships", "ImageUrl", "LastYearStanding", "Name", "Number", "Podiums", "Points", "PolePositions", "Price", "TeamId", "TotalPoints", "Wins" },
                values: new object[,]
                {
                    { 3, 2, 2, new DateTime(1981, 7, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://media.formula1.com/content/dam/fom-website/drivers/2023Drivers/alonso.jpg.img.1920.medium.jpg/1677244577162.jpg", 9, "Fernando Alonso", 14, 104, 137.0, 22, 62m, 3, 2198.0, 32 },
                    { 4, 2, 2, new DateTime(1985, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, "https://media.formula1.com/content/dam/fom-website/drivers/2023Drivers/hamilton.jpg.img.1920.medium.jpg/1677069594164.jpg", 6, "Lewis Hamilton", 44, 195, 121.0, 103, 58m, 2, 4526.5, 103 }
                });

            migrationBuilder.InsertData(
                table: "Drivers",
                columns: new[] { "Id", "BestResult", "BestResultCount", "BirthDate", "ImageUrl", "LastYearStanding", "Name", "Number", "Podiums", "Points", "PolePositions", "Price", "TeamId", "TotalPoints", "Wins" },
                values: new object[,]
                {
                    { 5, 4, 1, new DateTime(1994, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://media.formula1.com/content/dam/fom-website/drivers/2023Drivers/sainz.jpg.img.1920.medium.jpg/1677069189406.jpg", 5, "Carlos Sainz", 55, 15, 83.0, 3, 48m, 4, 865.5, 1 },
                    { 6, 3, 1, new DateTime(1998, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://media.formula1.com/content/dam/fom-website/drivers/2023Drivers/russell.jpg.img.1920.medium.jpg/1677069334466.jpg", 4, "George Russell", 63, 10, 82.0, 2, 47m, 2, 376.0, 1 },
                    { 7, 2, 1, new DateTime(1997, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://media.formula1.com/content/dam/fom-website/drivers/2023Drivers/leclerc.jpg.img.1920.medium.jpg/1677069223130.jpg", 2, "Charles Leclerc", 16, 26, 74.0, 19, 42m, 4, 942.0, 5 }
                });

            migrationBuilder.InsertData(
                table: "Drivers",
                columns: new[] { "Id", "BestResult", "BestResultCount", "BirthDate", "ImageUrl", "LastYearStanding", "Name", "Number", "Podiums", "Points", "PolePositions", "Price", "TeamId", "TotalPoints" },
                values: new object[,]
                {
                    { 8, 4, 1, new DateTime(1998, 10, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://media.formula1.com/content/dam/fom-website/drivers/2023Drivers/stroll.jpg.img.1920.medium.jpg/1677069453013.jpg", 15, "Lance Stroll", 18, 3, 44.0, 1, 31m, 3, 238.0 },
                    { 9, 2, 1, new DateTime(1999, 11, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://media.formula1.com/content/dam/fom-website/drivers/2023Drivers/norris.jpg.img.1920.medium.jpg/1677069505471.jpg", 7, "Lando Norris", 4, 7, 42.0, 1, 30m, 5, 470.0 }
                });

            migrationBuilder.InsertData(
                table: "Drivers",
                columns: new[] { "Id", "BestResult", "BestResultCount", "BirthDate", "ImageUrl", "LastYearStanding", "Name", "Number", "Podiums", "Points", "Price", "TeamId", "TotalPoints", "Wins" },
                values: new object[] { 10, 3, 1, new DateTime(1996, 9, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://media.formula1.com/content/dam/fom-website/drivers/2023Drivers/ocon.jpg.img.1920.medium.jpg/1677069269007.jpg", 8, "Esteban Ocon", 31, 3, 31.0, 24m, 6, 395.0, 1 });

            migrationBuilder.InsertData(
                table: "Drivers",
                columns: new[] { "Id", "BestResult", "BestResultCount", "BirthDate", "ImageUrl", "LastYearStanding", "Name", "Number", "Points", "Price", "TeamId", "TotalPoints" },
                values: new object[] { 11, 4, 1, new DateTime(2001, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://media.formula1.com/content/dam/fom-website/drivers/2023Drivers/piastri.jpg.img.1920.medium.jpg/1676983075734.jpg", null, "Oscar Piastri", 81, 17.0, 17m, 5, 17.0 });

            migrationBuilder.InsertData(
                table: "Drivers",
                columns: new[] { "Id", "BestResult", "BestResultCount", "BirthDate", "ImageUrl", "LastYearStanding", "Name", "Number", "Podiums", "Points", "Price", "TeamId", "TotalPoints", "Wins" },
                values: new object[] { 12, 7, 1, new DateTime(1996, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://media.formula1.com/content/dam/fom-website/drivers/2023Drivers/gasly.jpg.img.1920.medium.jpg/1676983081984.jpg", 14, "Pierre Gasly", 10, 3, 16.0, 16m, 6, 348.0, 1 });

            migrationBuilder.InsertData(
                table: "Drivers",
                columns: new[] { "Id", "BestResult", "BestResultCount", "BirthDate", "ImageUrl", "LastYearStanding", "Name", "Number", "Podiums", "Points", "Price", "TeamId", "TotalPoints" },
                values: new object[] { 13, 7, 1, new DateTime(1996, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://media.formula1.com/content/dam/fom-website/drivers/2023Drivers/albon.jpg.img.1920.medium.jpg/1677068770293.jpg", 19, "Alexander Albon", 23, 2, 11.0, 14m, 7, 212.0 });

            migrationBuilder.InsertData(
                table: "Drivers",
                columns: new[] { "Id", "BestResult", "BestResultCount", "BirthDate", "ImageUrl", "LastYearStanding", "Name", "Number", "Points", "PolePositions", "Price", "TeamId", "TotalPoints" },
                values: new object[] { 14, 7, 1, new DateTime(1987, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://media.formula1.com/content/dam/fom-website/drivers/2023Drivers/hulkenberg.jpg.img.1920.medium.jpg/1676983071882.jpg", 22, "Nico Hulkenberg", 27, 9.0, 1, 13m, 8, 530.0 });

            migrationBuilder.InsertData(
                table: "Drivers",
                columns: new[] { "Id", "BestResult", "BestResultCount", "BirthDate", "ImageUrl", "LastYearStanding", "Name", "Number", "Podiums", "Points", "PolePositions", "Price", "TeamId", "TotalPoints", "Wins" },
                values: new object[] { 15, 8, 1, new DateTime(1989, 8, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://media.formula1.com/content/dam/fom-website/drivers/2023Drivers/bottas.jpg.img.1920.medium.jpg/1677069810695.jpg", 10, "Valtteri Bottas", 77, 67, 5.0, 20, 10m, 9, 1792.0, 10 });

            migrationBuilder.InsertData(
                table: "Drivers",
                columns: new[] { "Id", "BestResult", "BestResultCount", "BirthDate", "ImageUrl", "LastYearStanding", "Name", "Number", "Points", "Price", "TeamId", "TotalPoints" },
                values: new object[,]
                {
                    { 16, 9, 2, new DateTime(1999, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://media.formula1.com/content/dam/fom-website/drivers/2023Drivers/zhou.jpg.img.1920.medium.jpg/1677069909295.jpg", 18, "Zhou Guanyu", 24, 4.0, 9m, 9, 10.0 },
                    { 17, 10, 2, new DateTime(2000, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://media.formula1.com/content/dam/fom-website/drivers/2023Drivers/tsunoda.jpg.img.1920.medium.jpg/1677069846213.jpg", 17, "Yuki Tsunoda", 22, 2.0, 7m, 10, 46.0 }
                });

            migrationBuilder.InsertData(
                table: "Drivers",
                columns: new[] { "Id", "BestResult", "BestResultCount", "BirthDate", "ImageUrl", "LastYearStanding", "Name", "Number", "Podiums", "Points", "Price", "TeamId", "TotalPoints" },
                values: new object[] { 18, 10, 2, new DateTime(1992, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://media.formula1.com/content/dam/fom-website/drivers/2023Drivers/magnussen.jpg.img.1920.medium.jpg/1677069387823.jpg", 13, "Kevin Magnussen", 20, 1, 2.0, 7m, 8, 185.0 });

            migrationBuilder.InsertData(
                table: "Drivers",
                columns: new[] { "Id", "BestResult", "BestResultCount", "BirthDate", "ImageUrl", "LastYearStanding", "Name", "Number", "Price", "TeamId" },
                values: new object[] { 19, 11, 1, new DateTime(2000, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://media.formula1.com/content/dam/fom-website/drivers/2023Drivers/sargeant.jpg.img.1920.medium.jpg/1676983079144.jpg", null, "Logan Sargeant", 2, 5m, 7 });

            migrationBuilder.InsertData(
                table: "Drivers",
                columns: new[] { "Id", "BestResult", "BestResultCount", "BirthDate", "ImageUrl", "LastYearStanding", "Name", "Number", "Price", "TeamId", "TotalPoints" },
                values: new object[] { 20, 12, 1, new DateTime(1995, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://media.formula1.com/content/dam/fom-website/drivers/2023Drivers/devries.jpg.img.1920.medium.jpg/1676983081637.jpg", 21, "Nyck De Vries", 21, 5m, 10, 2.0 });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "ArticleId", "Content", "IsActive", "PublisherId" },
                values: new object[] { 1, 1, "Albon really deserve a better car!", true, new Guid("56b03886-bcb8-4775-ba5f-ade84e6b7a4f") });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "ArticleId", "Content", "IsActive", "PublisherId" },
                values: new object[] { 2, 2, "It was a great race!", true, new Guid("56b03886-bcb8-4775-ba5f-ade84e6b7a4f") });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "ArticleId", "Content", "IsActive", "PublisherId" },
                values: new object[] { 3, 2, "Ferrari is back in the game!", true, new Guid("56b03886-bcb8-4775-ba5f-ade84e6b7a4f") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3);

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
                table: "Articles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

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

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
