using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Motorsport1.Data.Models;

namespace Motorsport1.Data.Configurations
{
    public class TeamEntityConfiguration : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder.Property(d => d.BestResult)
                .HasDefaultValue(null);

            builder.Property(d => d.BestResultCount)
                .HasDefaultValue(null);

            builder.Property(d => d.LastYearStanding)
                .HasDefaultValue(null);

            builder.Property(d => d.TotalPoints)
                .HasDefaultValue(0);

            builder.Property(d => d.Points)
                .HasDefaultValue(0);

            builder.Property(d => d.Wins)
                .HasDefaultValue(0);

            builder.Property(d => d.Podiums)
                .HasDefaultValue(0);

            builder.Property(d => d.PolePositions)
                .HasDefaultValue(0);

            builder.Property(d => d.Championships)
                .HasDefaultValue(0);

            builder.HasData(this.GenerateTeams());
        }

        private Team[] GenerateTeams()
        {
            ICollection<Team> teams = new HashSet<Team>();

            Team team;

            team = new Team()
            {
                Id = 1,
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

            teams.Add(team);


            team = new Team()
            {
                Id = 2,
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

            teams.Add(team);


            team = new Team()
            {
                Id = 3,
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

            teams.Add(team);

            team = new Team()
            {
                Id = 4,
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

            teams.Add(team);

            team = new Team()
            {
                Id = 5,
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

            teams.Add(team);

            team = new Team()
            {
                Id = 6,
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

            teams.Add(team);

            team = new Team()
            {
                Id = 7,
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

            teams.Add(team);

            team = new Team()
            {
                Id = 8,
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

            teams.Add(team);

            team = new Team()
            {
                Id = 9,
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

            teams.Add(team);

            team = new Team()
            {
                Id = 10,
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

            teams.Add(team);

            return teams.ToArray();
        }
    }
}
