using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MishMashExamASP.NET.ModelBinders;
using MishMashExamASP.NET.ValidationAttributes;

namespace MishMashExamASP.NET.Models.CarAd
{
    public class CarBrandAndModel
    {
        [Required]
        public string Brand { get; set; }

        [Required]
        public string Model { get; set; }
    }
    public class CreateInputModel : IValidatableObject
    {
        [Range(1,4)]
        public CarType Type { get; set; }

        [Required]
        public CarBrandAndModel Car { get; set; }

        [DataType(DataType.Date)] 
        [BeforeCurrentYear(1900)]
        public int Year { get; set; }

        [Display(Name = "Long Description")]
        [DataType(DataType.MultilineText)]
        [MinLength(20)]
        public string LongDescription { get; set; }

        [Range(0.01,double.MaxValue)]
        public decimal Price { get; set; }

        public byte[] Image { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (this.Car.Brand == "Audi" && !this.Car.Model.StartsWith("Q") && !this.Car.Model.StartsWith("A"))
            {
                yield return new ValidationResult("Invalid Audi Model");
            }

        }
    }

    public enum CarType
    {
        Sedan = 1,
        SUV = 2,
        Cabrio = 3,
        Combi = 4
    }
}
