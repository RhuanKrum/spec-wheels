using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.ComponentModel.DataAnnotations;

namespace SpecWheels.Models.Break
{

 
    public class SubModelColorModel
    {
        [Required]
        [Display(Name = "ColorId")]
        public int ColorId { get; set; }

        [Required]
        [Display(Name = "SubModelId")]
        public int SubModelId { get; set; }
    }
}