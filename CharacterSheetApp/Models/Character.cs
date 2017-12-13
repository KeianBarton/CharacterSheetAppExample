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
            // Capitalize first letter
            Name = char.ToUpper(name[0]) + name.Substring(1);

            GlobalVariables.Characters.Add(this);
        }

        public static List<Character> GetAll()
        {
            return GlobalVariables.Characters;
        }
    }
}
