using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForgingAhead.Models
{
    public class Character
    {
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public int Level { get; set; }
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Intelligence { get; set; }
    }
}
