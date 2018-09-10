using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.ComponentModel.DataAnnotations;

namespace SpecWheels.Models.Engine
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
        [Display(Name = "Brand")]
        public string Brand { get; set; }

        [MaxLength(40)]
        [Display(Name = "HorsePower")]
        public string HorsePower { get; set; }

    }
}