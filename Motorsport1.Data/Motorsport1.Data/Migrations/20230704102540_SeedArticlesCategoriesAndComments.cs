using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Motorsport1.Data.Migrations
{
    public partial class SeedArticlesCategoriesAndComments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SeenBy",
                table: "Articles",
                newName: "ReadCount");

            migrationBuilder.AddColumn<DateTime>(
                name: "PublishedDateTime",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "Information",
                table: "Articles",
                type: "nvarchar(max)",
                maxLength: 100000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(2500)",
                oldMaxLength: 2500);

            migrationBuilder.AddColumn<DateTime>(
                name: "PublishedDateTime",
                table: "Articles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

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
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "ImageUrl", "Information", "Likes", "PublishedDateTime", "PublisherId", "ReadCount", "Title" },
                values: new object[] { 1, 2, "https://media.formula1.com/image/upload/f_auto/q_auto/v1688394388/fom-website/2023/Austria/albon-austria-2023-2.png.transform/9col/image.png", "Alex Albon believes the chance was there for Williams to score more points during the Austrian Grand Prix Sprint weekend but, while disappointed to ultimately miss out on a reward, he drew optimism from the team’s level of performance.\r\n\r\nAlbon and Williams arrived at the Red Bull Ring after the Thai-British driver’s fine run to seventh in Canada, giving the Grove outfit their second points finish of the season and lifting them above AlphaTauri at the foot of the F1 standings.\r\n\r\nWith the FW45’s straight-line strengths also suited to the Spielberg venue, Albon was in the top-10 mix throughout the weekend, battling to score points in both the Sprint and full Grand Prix.", 0, new DateTime(2023, 7, 4, 10, 25, 40, 264, DateTimeKind.Utc).AddTicks(6410), new Guid("56b03886-bcb8-4775-ba5f-ade84e6b7a4f"), 0, "‘We should have come away with points’ – Albon feels Williams missed an opportunity in Austria as he pinpoints ‘next chance’ to score" });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "ImageUrl", "Information", "Likes", "PublishedDateTime", "PublisherId", "ReadCount", "Title" },
                values: new object[] { 2, 3, "https://www.topgear.com/sites/default/files/news-listicle/image/2023/07/0-Austrian-GP.jpg", "Max Verstappen secured his fifth race win in a row in Austria with an exemplary performance – including bagging an extra point for fastest lap – as he extended his lead at the top of the drivers’ standings.\r\n\r\nThe Red Bull man was dominant once more as he led home Ferrari’s Charles Leclerc and team mate Sergio Perez, who had an impressive drive of his own as he worked his way up from a P15 start to the podium.\r\n\r\nMcLaren’s Lando Norris was another who had much to celebrate at the Red Bull Ring, as he earned the Driver of the Day award for a stellar performance to take P5 in his upgraded car, one place behind his former team mate Carlos Sainz.\r\n\r\nIt was a less positive day for the likes of Mercedes, with Lewis Hamilton on the receiving end of a stern radio message from team boss Toto Wolff, while there was also a smattering of time penalties dished out to drivers for track limit violations.\r\n\r\nWatch the highlights from a frantic race in Austria by clicking on the video above.", 0, new DateTime(2023, 7, 4, 10, 25, 40, 264, DateTimeKind.Utc).AddTicks(6435), new Guid("56b03886-bcb8-4775-ba5f-ade84e6b7a4f"), 0, "Exhilarating race in Austria as Verstappen takes victory and Norris shines" });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "ImageUrl", "Information", "Likes", "PublishedDateTime", "PublisherId", "ReadCount", "Title" },
                values: new object[] { 3, 4, "https://www.topgear.com/sites/default/files/news-listicle/image/2023/07/0-Austrian-GP.jpg", "Q: Congratulations, Max yet another victory from the lights to the flag. How are you feeling?\r\n\r\nMax VERSTAPPEN: Yeah, of course I'm very happy right now. It was not a very straightforward race because the tyres were not really getting in their window. It was very cold today compared to Friday and we were sliding around quite a bit. But yeah, we made it work and yeah to win again, today to win the 100th Grand Prix for the team, that's incredible.\r\n\r\nQ: Yeah, you must have a pretty special feeling about that. You've worked with this team for many years. Hundredth win, how does that feel to take that for the team here?\r\n\r\nMV: It’s amazing. I mean, I never expected to be on these kinds of numbers myself as well, you know. So, yeah, we keep enjoying, we keep working hard. But today has been a great day again.\r\n\r\nQ: Did you expect a bigger challenge from Aston or Mercedes here? Or is this is pretty much what you expected here in Montréal?\r\n\r\nMV: Firstly, I expected more or less what we had today, but it was, like I said, really difficult to just keep the grip, the temperature into the tyres, because the grip was disappearing very quickly. That's why maybe the gap was not that big. But yeah, we had a few Safety Cars here and there. But yeah, overall, we won, that's the most important.\r\n\r\nQ: And lastly, this is always a very special race to come to. A lot of fans here for the sport. They've been through a lot this weekend with the weather. Have you got a message for them?\r\n\r\nMV: Yeah, I mean, they're so passionate about the sport. Also, yesterday with the rain, they were just hanging in there, so that was great to see. And yeah, we love coming here. And hopefully we can do this for a long time.\r\n\r\nQ: You’ve got a few fans here, Fernando. Was that the race you expected?\r\n\r\nFernando ALONSO: Probably yes. I think we were hoping to challenge a little more the Red Bull. But we lost a place at the start with Lewis and then yeah, it was a battle with the Mercedes and Lewis was pushing all the race, so I didn't have one lap where I could relax a little bit. So it was an amazing battle.\r\n\r\nQ: It was lovely watching three multiple World Champions going at it. And you had a good little tussle with Lewis out there as well.\r\n\r\nFA: I mean, at the beginning, I had a little bit more pace. At the end I think Lewis had a bit more pace. Yeah, it was tough. It was a very demanding race, you know, all 70 laps of qualifying today.\r\n\r\nQ: We heard you had a few issues. You had to do a little bit of lift and coast. It's always frustrating because you want to push to the maximum. Was that a fuel issue? Or was that a rear brake issue?\r\n\r\nFA: I don't really know. They didn't tell me so maybe it was not to make me worry too much. But I don't know. I felt the car was OK. But I was just following the instructions. So yeah, hopefully that means that we have a little bit more pace. So next one, putting more pressure on Max.", 0, new DateTime(2023, 7, 4, 10, 25, 40, 264, DateTimeKind.Utc).AddTicks(6438), new Guid("56b03886-bcb8-4775-ba5f-ade84e6b7a4f"), 0, "Exhilarating race in Austria as Verstappen takes victory and Norris shines" });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "ArticleId", "Content", "PublishedDateTime" },
                values: new object[] { 1, 1, "Albon really deserve a better car!", new DateTime(2023, 7, 4, 10, 25, 40, 264, DateTimeKind.Utc).AddTicks(7157) });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "ArticleId", "Content", "PublishedDateTime" },
                values: new object[] { 2, 2, "It was a great race!", new DateTime(2023, 7, 4, 10, 25, 40, 264, DateTimeKind.Utc).AddTicks(7161) });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "ArticleId", "Content", "PublishedDateTime" },
                values: new object[] { 3, 2, "Ferrari is back in the game!", new DateTime(2023, 7, 4, 10, 25, 40, 264, DateTimeKind.Utc).AddTicks(7163) });
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
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "PublishedDateTime",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "PublishedDateTime",
                table: "Articles");

            migrationBuilder.RenameColumn(
                name: "ReadCount",
                table: "Articles",
                newName: "SeenBy");

            migrationBuilder.AlterColumn<string>(
                name: "Information",
                table: "Articles",
                type: "nvarchar(2500)",
                maxLength: 2500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldMaxLength: 100000);
        }
    }
}
