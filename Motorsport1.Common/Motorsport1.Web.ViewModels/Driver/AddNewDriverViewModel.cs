namespace Motorsport1.Web.ViewModels.Driver
{
    using Microsoft.VisualBasic;
    using System.ComponentModel.DataAnnotations;
    using static Common.EntityValidationConstants.Driver;
    public class AddNewDriverViewModel : AddOldDriverViewModel
    {
        [Required]
        [Display(Name = "Birth Date")]
        public string BirthDate { get; set; } = null!;

        [Required]
        [Range(typeof(decimal), PriceMinValue, PriceMaxValue)]
        public decimal Price { get; set; }

        [Required]
        [Range(typeof(int), NumberMinValue, NumberMaxValue)]
        public int Number { get; set; }
    }
}
