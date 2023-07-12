using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Motorsport1.Data.Models;

namespace Motorsport1.Data.Configurations
{
    public class DriverEntityConfiguration : IEntityTypeConfiguration<Driver>
    {
        public void Configure(EntityTypeBuilder<Driver> builder)
        {
            builder
                .HasOne(d => d.Team)
                .WithMany(t => t.Drivers)
                .HasForeignKey(d => d.TeamId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(d => d.IsCurrentChampion)
                .HasDefaultValue(false);

            builder.HasData(this.GenerateDrivers());
        }

        private Driver[] GenerateDrivers()
        {
            ICollection<Driver> drivers = new HashSet<Driver>();

            Driver driver;

            driver = new Driver()
            {
                Id = 1,
                Name = "Max Verstappen",
                ImageUrl = "https://media.formula1.com/content/dam/fom-website/drivers/2023Drivers/verstappen.jpg.img.1920.medium.jpg/1677069646195.jpg",
                IsCurrentChampion = true,
                BirthDate = new DateTime(1997, 9, 30),
                Price = 81,
                Championships = 2,
                Points = 255,
                Wins = 43,
                PolePositions = 27,
                Podiums = 87,
                TotalPoints = 2266.5,
                Number = 1,
                TeamId = 1
            };

            drivers.Add(driver);

            driver = new Driver()
            {
                Id = 2,
                Name = "Sergio Perez",
                ImageUrl = "https://media.formula1.com/content/dam/fom-website/drivers/2023Drivers/perez.jpg.img.1920.medium.jpg/1677069773437.jpg",
                BirthDate = new DateTime(1990, 1, 26),
                Price = 68,
                Championships = 0,
                Points = 156,
                Wins = 6,
                PolePositions = 3,
                Podiums = 31,
                TotalPoints = 1357,
                Number = 11,
                TeamId = 1
            };

            drivers.Add(driver);

            driver = new Driver()
            {
                Id = 3,
                Name = "Fernando Alonso",
                ImageUrl = "https://media.formula1.com/content/dam/fom-website/drivers/2023Drivers/alonso.jpg.img.1920.medium.jpg/1677244577162.jpg",
                BirthDate = new DateTime(1981, 7, 29),
                Price = 62,
                Championships = 2,
                Points = 137,
                Wins = 32,
                PolePositions = 22,
                Podiums = 104,
                TotalPoints = 2198,
                Number = 14,
                TeamId = 3
            };

            drivers.Add(driver);

            driver = new Driver()
            {
                Id = 4,
                Name = "Lewis Hamilton",
                ImageUrl = "https://media.formula1.com/content/dam/fom-website/drivers/2023Drivers/hamilton.jpg.img.1920.medium.jpg/1677069594164.jpg",
                BirthDate = new DateTime(1985, 1, 7),
                Price = 58,
                Championships = 7,
                Points = 121,
                Wins = 103,
                PolePositions = 103,
                Podiums = 195,
                TotalPoints = 4526.5,
                Number = 44,
                TeamId = 2
            };

            drivers.Add(driver);

            driver = new Driver()
            {
                Id = 5,
                Name = "Carlos Sainz",
                ImageUrl = "https://media.formula1.com/content/dam/fom-website/drivers/2023Drivers/sainz.jpg.img.1920.medium.jpg/1677069189406.jpg",
                BirthDate = new DateTime(1994, 9, 1),
                Price = 48,
                Championships = 0,
                Points = 83,
                Wins = 1,
                PolePositions = 3,
                Podiums = 15,
                TotalPoints = 865.5,
                Number = 55,
                TeamId = 4
            };

            drivers.Add(driver);

            driver = new Driver()
            {
                Id = 6,
                Name = "George Russell",
                ImageUrl = "https://media.formula1.com/content/dam/fom-website/drivers/2023Drivers/russell.jpg.img.1920.medium.jpg/1677069334466.jpg",
                BirthDate = new DateTime(1998, 2, 15),
                Price = 47,
                Championships = 0,
                Points = 82,
                Wins = 1,
                PolePositions = 2,
                Podiums = 10,
                TotalPoints = 376,
                Number = 63,
                TeamId = 2
            };

            drivers.Add(driver);

            driver = new Driver()
            {
                Id = 7,
                Name = "Charles Leclerc",
                ImageUrl = "https://media.formula1.com/content/dam/fom-website/drivers/2023Drivers/leclerc.jpg.img.1920.medium.jpg/1677069223130.jpg",
                BirthDate = new DateTime(1997, 10, 16),
                Price = 42,
                Championships = 0,
                Points = 74,
                Wins = 5,
                PolePositions = 19,
                Podiums = 26,
                TotalPoints = 942,
                Number = 16,
                TeamId = 4
            };

            drivers.Add(driver);

            driver = new Driver()
            {
                Id = 8,
                Name = "Lance Stroll",
                ImageUrl = "https://media.formula1.com/content/dam/fom-website/drivers/2023Drivers/stroll.jpg.img.1920.medium.jpg/1677069453013.jpg",
                BirthDate = new DateTime(1998, 10, 29),
                Price = 31,
                Championships = 0,
                Points = 44,
                Wins = 0,
                PolePositions = 1,
                Podiums = 3,
                TotalPoints = 238,
                Number = 18,
                TeamId = 3
            };

            drivers.Add(driver);

            driver = new Driver()
            {
                Id = 9,
                Name = "Lando Norris",
                ImageUrl = "https://media.formula1.com/content/dam/fom-website/drivers/2023Drivers/norris.jpg.img.1920.medium.jpg/1677069505471.jpg",
                BirthDate = new DateTime(1999, 11, 13),
                Price = 30,
                Championships = 0,
                Points = 42,
                Wins = 0,
                PolePositions = 1,
                Podiums = 7,
                TotalPoints = 470,
                Number = 4,
                TeamId = 5
            };

            drivers.Add(driver);

            driver = new Driver()
            {
                Id = 10,
                Name = "Esteban Ocon",
                ImageUrl = "https://media.formula1.com/content/dam/fom-website/drivers/2023Drivers/ocon.jpg.img.1920.medium.jpg/1677069269007.jpg",
                BirthDate = new DateTime(1996, 9, 17),
                Price = 24,
                Championships = 0,
                Points = 31,
                Wins = 1,
                PolePositions = 0,
                Podiums = 3,
                TotalPoints = 395,
                Number = 31,
                TeamId = 6
            };

            drivers.Add(driver);

            driver = new Driver()
            {
                Id = 11,
                Name = "Oscar Piastri",
                ImageUrl = "https://media.formula1.com/content/dam/fom-website/drivers/2023Drivers/piastri.jpg.img.1920.medium.jpg/1676983075734.jpg",
                BirthDate = new DateTime(2001, 4, 6),
                Price = 17,
                Championships = 0,
                Points = 17,
                Wins = 0,
                PolePositions = 0,
                Podiums = 0,
                TotalPoints = 17,
                Number = 81,
                TeamId = 5
            };

            drivers.Add(driver);

            driver = new Driver()
            {
                Id = 12,
                Name = "Pierre Gasly",
                ImageUrl = "https://media.formula1.com/content/dam/fom-website/drivers/2023Drivers/gasly.jpg.img.1920.medium.jpg/1676983081984.jpg",
                BirthDate = new DateTime(1996, 2, 7),
                Price = 16,
                Championships = 0,
                Points = 16,
                Wins = 1,
                PolePositions = 0,
                Podiums = 3,
                TotalPoints = 348,
                Number = 10,
                TeamId = 6
            };

            drivers.Add(driver);

            driver = new Driver()
            {
                Id = 13,
                Name = "Alexander Albon",
                ImageUrl = "https://media.formula1.com/content/dam/fom-website/drivers/2023Drivers/albon.jpg.img.1920.medium.jpg/1677068770293.jpg",
                BirthDate = new DateTime(1996, 3, 23),
                Price = 14,
                Championships = 0,
                Points = 11,
                Wins = 0,
                PolePositions = 0,
                Podiums = 2,
                TotalPoints = 212,
                Number = 23,
                TeamId = 7
            };

            drivers.Add(driver);

            driver = new Driver()
            {
                Id = 14,
                Name = "Nico Hulkenberg",
                ImageUrl = "https://media.formula1.com/content/dam/fom-website/drivers/2023Drivers/hulkenberg.jpg.img.1920.medium.jpg/1676983071882.jpg",
                BirthDate = new DateTime(1987, 8, 19),
                Price = 13,
                Championships = 0,
                Points = 9,
                Wins = 0,
                PolePositions = 1,
                Podiums = 0,
                TotalPoints = 530,
                Number = 27,
                TeamId = 8
            };

            drivers.Add(driver);

            driver = new Driver()
            {
                Id = 15,
                Name = "Valtteri Bottas",
                ImageUrl = "https://media.formula1.com/content/dam/fom-website/drivers/2023Drivers/bottas.jpg.img.1920.medium.jpg/1677069810695.jpg",
                BirthDate = new DateTime(1989, 8, 28),
                Price = 10,
                Championships = 0,
                Points = 5,
                Wins = 10,
                PolePositions = 20,
                Podiums = 67,
                TotalPoints = 1792,
                Number = 77,
                TeamId = 9
            };

            drivers.Add(driver);

            driver = new Driver()
            {
                Id = 16,
                Name = "Zhou Guanyu",
                ImageUrl = "https://media.formula1.com/content/dam/fom-website/drivers/2023Drivers/zhou.jpg.img.1920.medium.jpg/1677069909295.jpg",
                BirthDate = new DateTime(1999, 5, 30),
                Price = 9,
                Championships = 0,
                Points = 4,
                Wins = 0,
                PolePositions = 0,
                Podiums = 0,
                TotalPoints = 10,
                Number = 24,
                TeamId = 9
            };

            drivers.Add(driver);

            driver = new Driver()
            {
                Id = 17,
                Name = "Yuki Tsunoda",
                ImageUrl = "https://media.formula1.com/content/dam/fom-website/drivers/2023Drivers/tsunoda.jpg.img.1920.medium.jpg/1677069846213.jpg",
                BirthDate = new DateTime(2000, 5, 11),
                Price = 7,
                Championships = 0,
                Points = 2,
                Wins = 0,
                PolePositions = 0,
                Podiums = 0,
                TotalPoints = 46,
                Number = 22,
                TeamId = 10
            };

            drivers.Add(driver);

            driver = new Driver()
            {
                Id = 18,
                Name = "Kevin Magnussen",
                ImageUrl = "https://media.formula1.com/content/dam/fom-website/drivers/2023Drivers/magnussen.jpg.img.1920.medium.jpg/1677069387823.jpg",
                BirthDate = new DateTime(1992, 10, 5),
                Price = 7,
                Championships = 0,
                Points = 2,
                Wins = 0,
                PolePositions = 0,
                Podiums = 1,
                TotalPoints = 185,
                Number = 20,
                TeamId = 8
            };

            drivers.Add(driver);

            driver = new Driver()
            {
                Id = 19,
                Name = "Logan Sargeant",
                ImageUrl = "https://media.formula1.com/content/dam/fom-website/drivers/2023Drivers/sargeant.jpg.img.1920.medium.jpg/1676983079144.jpg",
                BirthDate = new DateTime(2000, 12, 31),
                Price = 5,
                Championships = 0,
                Points = 0,
                Wins = 0,
                PolePositions = 0,
                Podiums = 0,
                TotalPoints = 0,
                Number = 2,
                TeamId = 7
            };

            drivers.Add(driver);

            driver = new Driver()
            {
                Id = 20,
                Name = "Nyck De Vries",
                ImageUrl = "https://media.formula1.com/content/dam/fom-website/drivers/2023Drivers/devries.jpg.img.1920.medium.jpg/1676983081637.jpg",
                BirthDate = new DateTime(1995, 2, 6),
                Price = 5,
                Championships = 0,
                Points = 0,
                Wins = 0,
                PolePositions = 0,
                Podiums = 0,
                TotalPoints = 2,
                Number = 21,
                TeamId = 10
            };

            drivers.Add(driver);

            return drivers.ToArray();
        }
    }
}
