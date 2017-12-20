using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ForgingAhead.Models
{
    public class Character
    {
        [Key]
        [HiddenInput]
        [Range(1, int.MaxValue)]
        [Required]
        public int Id { get; private set; }

        [MinLength(3)]
        [Required]
        public string Name { get; set; }

        [Display(Name = "Is Active")]
        [Required]
        public bool IsActive { get; set; }

        [Range(1, 99)]
        [Required]
        public int Level { get; set; }

        [Range(1, 99)]
        [Required]
        public int Strength { get; set; }

        [Range(1, 99)]
        [Required]
        public int Dexterity { get; set; }

        [Range(1, 99)]
        [Required]
        public int Intelligence { get; set; }

        public List<Equipment> Equipment { get; set; }
    }
}
