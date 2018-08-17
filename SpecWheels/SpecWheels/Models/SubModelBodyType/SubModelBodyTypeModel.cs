using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.ComponentModel.DataAnnotations;

namespace SpecWheels.Models.Break
{

 
    public class BreakMoSubModelBodyTypeModeldel
    {
        [Required]
        [Display(Name = "BodyTypeId")]
        public int BodyTypeId { get; set; }

        [Required]
        [Display(Name = "SubModelId")]
        public int SubModelId { get; set; }


    }
}