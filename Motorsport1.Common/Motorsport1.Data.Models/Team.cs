namespace Motorsport1.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using static Common.EntityValidationConstants.Team;

    public class Team
    {
        public Team()
        {
            this.DraftUsers = new HashSet<ApplicationUser>();
            this.Drivers = new HashSet<Driver>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        public bool IsActive { get; set; }

        public decimal Price { get; set; }

        public double Points { get; set; }

        public int Wins { get; set; }

        public int Podiums { get; set; }

        public double TotalPoints { get; set; }

        public virtual ICollection<Driver> Drivers { get; set; }

        public virtual ICollection<ApplicationUser> DraftUsers { get; set; }
    }
}