using System.ComponentModel.DataAnnotations;

namespace MishMashExamASP.NET.Models
{
    public class FormInputModel
    {
        [Required]
        public string Search { get; set; }
    }
}