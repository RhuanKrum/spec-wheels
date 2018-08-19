using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.ComponentModel.DataAnnotations;

namespace SpecWheels.Models.Tire
{

 
    public class TireModel
    {
        [Required]
        [Display(Name = "Id")]
        public int Id { get; set; }


        [Required]
        [MaxLength(48)]
        [Display(Name = "Brand")]
        public string Brand { get; set; }

        [Required]
        [MaxLength(48)]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [MaxLength(48)]
        [Display(Name = "Size")]
        public string Size { get; set; }

    }
}