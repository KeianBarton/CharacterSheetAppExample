using System.Collections.Generic;

namespace ForgingAhead.Models
{
    public class CharacterEditViewModel
    {
        public Character Character { get; set; }
        public Dictionary<string, bool> SelectedEquipment { get; set; }
    }
}
