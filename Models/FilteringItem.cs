using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetApp.Models
{
    public class FilteringItem
    {
        public int Id { get; set; }
        public string[] Type { get; set; }
        public string[] Breed { get; set; }
        public string[] Age { get; set; }
        public string[] EnergyLevel { get; set; }
        public string[] Size { get; set; }
        public string[] Gender { get; set; }
        public string[] FriendlyWithDogs { get; set; }
        public string[] FriendlyWithCats { get; set; }
        public string[] FriendlyWithKids { get; set; }
        public string[] SpecialNeeds { get; set; }

    }
}
