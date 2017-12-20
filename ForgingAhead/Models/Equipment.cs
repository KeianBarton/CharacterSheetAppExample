using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ForgingAhead.Models
{
    public class Equipment
    {
        [Key]
        [HiddenInput]
        [Range(1, int.MaxValue)]
        [Required]
        public int Id { get; private set; }

        [MinLength(3)]
        [Required]
        public string Name { get; set; }

        [Range(1, 99)]
        [Required]
        public int Attack { get; set; }

        [Range(1, 99)]
        [Required]
        public int Defense { get; set; }
    }
}
