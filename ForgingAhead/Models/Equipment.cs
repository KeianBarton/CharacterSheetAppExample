using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ForgingAhead.Models
{
    public class Equipment
    {
        [Key]
        [MinLength(3, ErrorMessage = "The \"Name\" field must be at least 3 characters long.")]
        [MaxLength(70, ErrorMessage = "The \"Name\" field must be no more than 70 characters long.")]
        [Required(ErrorMessage = "The \"Name\" field is required.")]
        public string Name { get; set; }

        [Range(1, 99, ErrorMessage = "The \"Attack\" field must be in the range 1 to 99 inclusive.")]
        [Required(ErrorMessage = "The \"Attack\" field is required.")]
        public int Attack { get; set; }

        [Range(1, 99, ErrorMessage = "The \"Defense\" field must be in the range 1 to 99 inclusive.")]
        [Required(ErrorMessage = "The \"Defense\" field is required.")]
        public int Defense { get; set; }
    }
}
