using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi_PetApp.Models
{
    public class Animal
    {
        public int Id { get; set; }
        public string ShelterId { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Breed { get; set; }
        public string Gender { get; set; }
        public string[] Characteristics { get; set; }
        public string EnergyLevel { get; set; }
        public string Age { get; set; }
        public string Size { get; set; }
        public string Type { get; set; }
        public string Hair { get; set; }
        public string Description { get; set; }
        public bool FriendlyWithDogs{ get; set; }
        public bool FriendlyWithCats { get; set; }
        public bool FriendlyWithKids { get; set; }
        public bool SpecialNeeds { get; set; }



    }
}