using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.ComponentModel.DataAnnotations;

namespace SpecWheels.Models.CarColor
{

 
    public class CarColorModel
    {
        [Required]
        [Display(Name = "ColorId")]
        public int ColorId { get; set; }

        [Required]
        [Display(Name = "CarId")]
        public int CarId { get; set; }
    }
}