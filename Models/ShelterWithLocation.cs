using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetApp.Models
{
    public class ShelterWithLocation
    {
        public List<Animal> Animals { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public string ShelterName { get; set; }
    }
}
