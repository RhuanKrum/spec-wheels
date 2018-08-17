using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.ComponentModel.DataAnnotations;

namespace SpecWheels.Models.Break
{

 
    public class EngineModel
    {
        [Required]    
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Required]
        [MaxLength(48)]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [MaxLength(48)]
        [Display(Name = "Band")]
        public string Brand { get; set; }

        [MaxLength(40)]
        [Display(Name = "HorsePowser")]
        public string HorsePower { get; set; }

    }
}