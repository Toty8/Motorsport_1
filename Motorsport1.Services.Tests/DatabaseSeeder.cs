using Motorsport1.Data;
using Motorsport1.Data.Models;
using System;
using System.Diagnostics;

namespace Motorsport1.Services.Tests
{
    public static class DatabaseSeeder
    {


        public static ICollection<Driver> drivers;
        public static ICollection<Team> teams;
        public static Team OracleRedBullRacing;
        public static Team MercedesAMGPETRONASF1Team;
        public static Team AstonMartinAramcoCognizantF1Team;
        public static Team ScuderiaFerrari;
        public static Team BWTAlpineF1Team;
        public static Team McLarenF1Team;
        public static Team WilliamsRacing;
        public static Team MoneyGramHaasF1Team;
        public static Team AlfaRomeoF1TeamStake;
        public static Team ScuderiaAlphaTauri;
        public static Driver MaxVerstappen;
        public static Driver SergioPerez;
        public static Driver FernandoAlonso;
        public static Driver LewisHamilton;
        public static Driver CarlosSainz;
        public static Driver GeorgeRussell;
        public static Driver CharlesLeclerc;
        public static Driver LanceStroll;
        public static Driver LandoNorris;
        public static Driver EstebanOcon;
        public static Driver OscarPiastri;
        public static Driver PierreGasly;
        public static Driver AlexanderAlbon;
        public static Driver NicoHulkenberg;
        public static Driver ValtteriBottas;
        public static Driver ZhouGuanyu;
        public static Driver YukiTsunoda;
        public static Driver KevinMagnussen;
        public static Driver LoganSargeant;
        public static Driver NyckDeVries;


        public static void SeedDatabase(Motorsport1DbContext dbContext)
        {

            teams = new HashSet<Team>();

            OracleRedBullRacing = new Team()
            {
                Id = 11,
                Name = "Oracle Red Bull Racing",
                ImageUrl = "https://media.formula1.com/content/dam/fom-website/2018-redesign-assets/team%20logos/red%20bull.jpg",
                Price = 93,
                Championships = 5,
                Points = 411,
                Wins = 102,
                PolePositions = 91,
                Podiums = 249,
                TotalPoints = 6799,
                BestResult = 1,
                BestResultCount = 10,
                LastYearStanding = 1,
            };

            teams.Add(OracleRedBullRacing);


            MercedesAMGPETRONASF1Team = new Team()
            {
                Id = 12,
                Name = "Mercedes-AMG PETRONAS F1 Team",
                ImageUrl = "https://media.formula1.com/content/dam/fom-website/2018-redesign-assets/team%20logos/mercedes.jpg",
                Price = 77,
                Championships = 8,
                Points = 203,
                Wins = 116,
                PolePositions = 128,
                Podiums = 286,
                TotalPoints = 7155.64,
                BestResult = 2,
                BestResultCount = 2,
                LastYearStanding = 3,
            };

            teams.Add(MercedesAMGPETRONASF1Team);


            AstonMartinAramcoCognizantF1Team = new Team()
            {
                Id = 13,
                Name = "Aston Martin Aramco Cognizant F1 Team",
                ImageUrl = "https://media.formula1.com/content/dam/fom-website/2018-redesign-assets/team%20logos/aston%20martin.jpg",
                Price = 75,
                Championships = 0,
                Points = 181,
                Wins = 0,
                PolePositions = 0,
                Podiums = 7,
                TotalPoints = 313,
                BestResult = 2,
                BestResultCount = 2,
                LastYearStanding = 7,
            };

            teams.Add(AstonMartinAramcoCognizantF1Team);

            ScuderiaFerrari = new Team()
            {
                Id = 14,
                Name = "Scuderia Ferrari",
                ImageUrl = "https://media.formula1.com/content/dam/fom-website/teams/Ferrari/logo-ferrari-18%20.jpg",
                Price = 71,
                Championships = 16,
                Points = 157,
                Wins = 243,
                PolePositions = 244,
                Podiums = 811,
                TotalPoints = 10315.77,
                BestResult = 2,
                BestResultCount = 1,
                LastYearStanding = 2,
            };

            teams.Add(ScuderiaFerrari);

            McLarenF1Team = new Team()
            {
                Id = 15,
                Name = "McLaren F1 Team",
                ImageUrl = "https://media.formula1.com/content/dam/fom-website/2018-redesign-assets/team%20logos/mclaren.jpg",
                Price = 37,
                Championships = 8,
                Points = 59,
                Wins = 183,
                PolePositions = 156,
                Podiums = 495,
                TotalPoints = 6366.5,
                BestResult = 2,
                BestResultCount = 1,
                LastYearStanding = 5,
            };

            teams.Add(McLarenF1Team);

            BWTAlpineF1Team = new Team()
            {
                Id = 16,
                Name = "BWT Alpine F1 Team",
                ImageUrl = "https://media.formula1.com/content/dam/fom-website/2018-redesign-assets/team%20logos/alpine.jpg",
                Price = 35,
                Championships = 0,
                Points = 47,
                Wins = 1,
                PolePositions = 0,
                Podiums = 3,
                TotalPoints = 375,
                BestResult = 3,
                BestResultCount = 1,
                LastYearStanding = 4,
            };

            teams.Add(BWTAlpineF1Team);

            WilliamsRacing = new Team()
            {
                Id = 17,
                Name = "Williams Racing",
                ImageUrl = "https://media.formula1.com/content/dam/fom-website/2018-redesign-assets/team%20logos/williams.jpg",
                Price = 14,
                Championships = 9,
                Points = 11,
                Wins = 114,
                PolePositions = 128,
                Podiums = 313,
                TotalPoints = 3609,
                BestResult = 7,
                BestResultCount = 1,
                LastYearStanding = 10,
            };

            teams.Add(WilliamsRacing);

            MoneyGramHaasF1Team = new Team()
            {
                Id = 18,
                Name = "MoneyGram Haas F1 Team",
                ImageUrl = "https://media.formula1.com/content/dam/fom-website/2018-redesign-assets/team%20logos/haas.jpg",
                Price = 14,
                Championships = 0,
                Points = 11,
                Wins = 0,
                PolePositions = 0,
                Podiums = 0,
                TotalPoints = 248,
                BestResult = 7,
                BestResultCount = 1,
                LastYearStanding = 8,
            };

            teams.Add(MoneyGramHaasF1Team);

            AlfaRomeoF1TeamStake = new Team()
            {
                Id = 19,
                Name = "Alfa Romeo F1 Team Stake",
                ImageUrl = "https://media.formula1.com/content/dam/fom-website/2018-redesign-assets/team%20logos/alfa%20romeo.jpg",
                Price = 13,
                Championships = 2,
                Points = 9,
                Wins = 11,
                PolePositions = 12,
                Podiums = 28,
                TotalPoints = 356,
                BestResult = 8,
                BestResultCount = 1,
                LastYearStanding = 6,
            };

            teams.Add(AlfaRomeoF1TeamStake);

            ScuderiaAlphaTauri = new Team()
            {
                Id = 20,
                Name = "Scuderia AlphaTauri",
                ImageUrl = "https://media.formula1.com/content/dam/fom-website/2018-redesign-assets/team%20logos/alphatauri.jpg",
                Price = 9,
                Championships = 0,
                Points = 2,
                Wins = 1,
                PolePositions = 0,
                Podiums = 2,
                TotalPoints = 286,
                BestResult = 10,
                BestResultCount = 2,
                LastYearStanding = 9,
            };

            teams.Add(ScuderiaAlphaTauri);

            dbContext.Teams.AddRange(teams);

            drivers = new HashSet<Driver>();

            MaxVerstappen = new Driver()
            {
                Id = 31,
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
                BestResult = 1,
                BestResultCount = 8,
                LastYearStanding = 1,
                Number = 1,
                TeamId = 11
            };

            drivers.Add(MaxVerstappen);

            SergioPerez = new Driver()
            {
                Id = 32,
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
                BestResult = 1,
                BestResultCount = 2,
                LastYearStanding = 3,
                Number = 11,
                TeamId = 11
            };

            drivers.Add(SergioPerez);

            FernandoAlonso = new Driver()
            {
                Id = 33,
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
                BestResult = 2,
                BestResultCount = 2,
                LastYearStanding = 9,
                Number = 14,
                TeamId = 13
            };

            drivers.Add(FernandoAlonso);

            LewisHamilton = new Driver()
            {
                Id = 34,
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
                BestResult = 2,
                BestResultCount = 2,
                LastYearStanding = 6,
                Number = 44,
                TeamId = 12
            };

            drivers.Add(LewisHamilton);

            CarlosSainz = new Driver()
            {
                Id = 35,
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
                BestResult = 4,
                BestResultCount = 1,
                LastYearStanding = 5,
                Number = 55,
                TeamId = 14
            };

            drivers.Add(CarlosSainz);

            GeorgeRussell = new Driver()
            {
                Id = 36,
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
                BestResult = 3,
                BestResultCount = 1,
                LastYearStanding = 4,
                Number = 63,
                TeamId = 12
            };
            drivers.Add(GeorgeRussell);

            CharlesLeclerc = new Driver()
            {
                Id = 37,
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
                BestResult = 2,
                BestResultCount = 1,
                LastYearStanding = 2,
                Number = 16,
                TeamId = 14
            };

            drivers.Add(CharlesLeclerc);

            LanceStroll = new Driver()
            {
                Id = 38,
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
                BestResult = 4,
                BestResultCount = 1,
                LastYearStanding = 15,
                Number = 18,
                TeamId = 13
            };

            drivers.Add(LanceStroll);

            LandoNorris = new Driver()
            {
                Id = 39,
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
                BestResult = 2,
                BestResultCount = 1,
                LastYearStanding = 7,
                Number = 4,
                TeamId = 15
            };

            drivers.Add(LandoNorris);

            EstebanOcon = new Driver()
            {
                Id = 40,
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
                BestResult = 3,
                BestResultCount = 1,
                LastYearStanding = 8,
                Number = 31,
                TeamId = 16
            };

            drivers.Add(EstebanOcon);

            OscarPiastri = new Driver()
            {
                Id = 41,
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
                BestResult = 4,
                BestResultCount = 1,
                LastYearStanding = null,
                Number = 81,
                TeamId = 15
            };

            drivers.Add(OscarPiastri);

            PierreGasly = new Driver()
            {
                Id = 42,
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
                BestResult = 7,
                BestResultCount = 1,
                LastYearStanding = 14,
                Number = 10,
                TeamId = 16
            };

            drivers.Add(PierreGasly);

            AlexanderAlbon = new Driver()
            {
                Id = 43,
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
                BestResult = 7,
                BestResultCount = 1,
                LastYearStanding = 19,
                Number = 23,
                TeamId = 17
            };

            drivers.Add(AlexanderAlbon);

            NicoHulkenberg = new Driver()
            {
                Id = 44,
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
                BestResult = 7,
                BestResultCount = 1,
                LastYearStanding = 22,
                Number = 27,
                TeamId = 18
            };

            drivers.Add(NicoHulkenberg);

            ValtteriBottas = new Driver()
            {
                Id = 45,
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
                BestResult = 8,
                BestResultCount = 1,
                LastYearStanding = 10,
                Number = 77,
                TeamId = 19
            };

            drivers.Add(ValtteriBottas);

            ZhouGuanyu = new Driver()
            {
                Id = 46,
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
                BestResult = 9,
                BestResultCount = 2,
                LastYearStanding = 18,
                Number = 24,
                TeamId = 19
            };

            drivers.Add(ZhouGuanyu);

            YukiTsunoda = new Driver()
            {
                Id = 47,
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
                BestResult = 10,
                BestResultCount = 2,
                LastYearStanding = 17,
                Number = 22,
                TeamId = 20
            };

            drivers.Add(YukiTsunoda);

            KevinMagnussen = new Driver()
            {
                Id = 48,
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
                BestResult = 10,
                BestResultCount = 2,
                LastYearStanding = 13,
                Number = 20,
                TeamId = 18
            };

            drivers.Add(KevinMagnussen);

            LoganSargeant = new Driver()
            {
                Id = 49,
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
                BestResult = 11,
                BestResultCount = 1,
                LastYearStanding = null,
                Number = 2,
                TeamId = 17
            };

            drivers.Add(LoganSargeant);

            NyckDeVries = new Driver()
            {
                Id = 50,
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
                BestResult = 12,
                BestResultCount = 1,
                LastYearStanding = null,
                Number = 21,
                TeamId = null
            };
            drivers.Add(NyckDeVries);

            dbContext.Drivers.AddRange(drivers);

            dbContext.SaveChanges();
        }
    }
}
