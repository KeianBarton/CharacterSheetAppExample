using CharacterSheetApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CharacterSheetApp
{
    public sealed class GlobalVariables
    {
        // Singleton
        private static readonly GlobalVariables instance = new GlobalVariables();
        private GlobalVariables() { }

        public static GlobalVariables Instance { get { return instance; } }

        // Data
        public static List<Character> Characters { get; set; }
            = new List<Character>();
    }
}