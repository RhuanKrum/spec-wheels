using Microsoft.AspNet.Identity.EntityFramework;
using SpecWheels.Models.BodyType;
using SpecWheels.Models.Color;
using SpecWheels.Models.DriveType;
using SpecWheels.Models.Engine;
using SpecWheels.Models.Suspension;
using SpecWheels.Models.Tire;
using SpecWheels.Models.Wheel;
using System;
using System.ComponentModel.DataAnnotations;

namespace SpecWheels.Models.Car
{

    public class CarModel
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
        [MaxLength(10)]
        [Display(Name = "Weight")]
        public decimal Weight { get; set; }

        [Required]
        [MaxLength(10)]
        [Display(Name = "Width")]
        public decimal Width { get; set; }

        [Required]
        [MaxLength(10)]
        [Display(Name = "Height")]
        public decimal Height { get; set; }

        [Required]
        [MaxLength(10)]
        [Display(Name = "Lenght")]
        public decimal Lenght { get; set; }



        [Display(Name = "ImageData")]
        public byte [] ImageData { get; set; }

        
        [Display(Name = "Image Name")]
        public string ImageName { get; set; }

        [Required]
        [Display(Name = "Color")]
        public ColorModel Color { get; set; }

        [Required]
        [Display(Name = "Body Type")]
        public BodyTypeModel BodyType { get; set; }

        [Required]
        [Display(Name = "Engine")]
        public EngineModel Engine { get; set; }

        [Required]
        [Display(Name = "Suspension")]
        public SuspensionModel Suspension { get; set; }

        [Required]
        [Display(Name = "DriveType")]
        public DriveTypeModel DriveType { get; set; }

        [Required]
        [Display(Name = "Tire")]
        public TireModel Tire { get; set; }

        [Required]
        [Display(Name = "Wheel")]
        public WheelModel Wheel { get; set; }
    }
}