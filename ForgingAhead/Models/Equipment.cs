using System.ComponentModel.DataAnnotations;

namespace ForgingAhead.Models
{
    public class Equipment
    {
        [Key]
        public int Id { get; private set; }

        public string Name { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
    }
}
