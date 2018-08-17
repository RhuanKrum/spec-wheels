using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.ComponentModel.DataAnnotations;

namespace SpecWheels.Models.Break
{

 
    public class SubModelModel
    {
        [Required]
        
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Required]
        [MaxLength(48)]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Start Year")]
        public int YearStart { get; set; }

        [Required]
        [Display(Name = "End Year")]
        public int EndStart { get; set; }

        [Required]
        [Display(Name = "EngineId")]
        public int EngineId { get; set; }

        [Required]
        [Display(Name = "SuspensionId")]
        public int SuspensionId { get; set; }

        [Required]
        [Display(Name = "DriveTypeId")]
        public int DriveTypeId { get; set; }

        [Required]
        [Display(Name = "TireId")]
        public int TireId { get; set; }

        [Required]
        [Display(Name = "WheelId")]
        public int WheelId { get; set; }
    }
}