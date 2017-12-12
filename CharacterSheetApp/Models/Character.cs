using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CharacterSheetApp.Models
{
    public class Character
    {
        public string Name { get; private set; }

        public Character(string name)
        {
            Name = name;
        }
    }
}
