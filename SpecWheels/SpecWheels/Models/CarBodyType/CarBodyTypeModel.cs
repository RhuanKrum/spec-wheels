using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.ComponentModel.DataAnnotations;

namespace SpecWheels.Models.CarBodyType
{

 
    public class CarBodyTypeModel
    {
        [Required]
        [Display(Name = "BodyTypeId")]
        public int BodyTypeId { get; set; }

        [Required]
        [Display(Name = "CarId")]
        public int CarId { get; set; }


    }
}