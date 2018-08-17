using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.ComponentModel.DataAnnotations;

namespace SpecWheels.Models.Break
{

 
    public class BodyTypeModel
    {
        [Required]
        
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }

    }
}