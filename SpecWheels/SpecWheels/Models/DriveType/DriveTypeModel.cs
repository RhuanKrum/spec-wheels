using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.ComponentModel.DataAnnotations;

namespace SpecWheels.Models.DriveType
{

 
    public class DriveTypeModel
    {
        [Required]
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Required]
        [MaxLength(48)]
        [Display(Name = "Name")]
        public string Name { get; set; }

    }
}