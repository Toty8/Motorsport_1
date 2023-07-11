namespace Motorsport1.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using static Common.EntityValidationConstants.Driver;

    public class Driver
    {
        public Driver()
        {
            DraftUsers = new HashSet<ApplicationUser>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        public DateTime BirthDate { get; set; }

        [Required]
        public bool IsCurrentChampion { get; set; }

        [Required]
        [MaxLength(ImageUrlMaxLength)]
        public string ImageUrl { get; set; } = null!;

        public decimal Price { get; set; }

        public int Championships { get; set; }

        public double Points { get; set; }

        public int Wins { get; set; }

        public int Podiums { get; set; }

        public int PolePositions { get; set; }

        public double TotalPoints { get; set; }

        public int Number { get; set; }

        public int TeamId { get; set; }

        public virtual Team? Team { get; set; }

        public virtual ICollection<ApplicationUser> DraftUsers { get; set; }
    }
}
