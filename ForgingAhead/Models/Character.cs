using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ForgingAhead.Models
{
    public class Character
    {
        [Key]
        [MinLength(3, ErrorMessage = "The \"Name\" field must be at least 3 characters long.")]
        [MaxLength(70, ErrorMessage = "The \"Name\" field must be no more than 70 characters long.")]
        [Required(ErrorMessage = "The \"Name\" field is required.")]
        public string Name { get; set; }

        [Display(Name = "Is Active")]
        [Required(ErrorMessage = "The \"Is Active\" field is required.")]
        public bool IsActive { get; set; }
            = true;

        [Range(1, 99, ErrorMessage = "The \"Level\" field must be in the range 1 to 99 inclusive.")]
        [Required(ErrorMessage = "The \"Level\" field is required.")]
        public int? Level { get; set; }
            = null;

        [Range(1, 99, ErrorMessage = "The \"Strength\" field must be in the range 1 to 99 inclusive.")]
        [Required(ErrorMessage = "The \"Strength\" field is required.")]
        public int? Strength { get; set; }
            = null;

        [Range(1, 99, ErrorMessage = "The \"Dexterity\" field must be in the range 1 to 99 inclusive.")]
        [Required(ErrorMessage = "The \"Dexterity\" field is required.")]
        public int? Dexterity { get; set; }
            = null;

        [Range(1, 99, ErrorMessage = "The \"Intelligence\" field must be in the range 1 to 99 inclusive.")]
        [Required(ErrorMessage = "The \"Intelligence\" field is required.")]
        public int? Intelligence { get; set; }
            = null;

        public List<Equipment> Equipment { get; set; }
            = new List<Equipment>();
    }
}
