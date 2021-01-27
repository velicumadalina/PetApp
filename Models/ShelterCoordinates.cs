using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetApp.Models
{
    public class ShelterCoordinates
    {
        public string ShelterName { get; set; }
        public int ShelterId { get; set; }

        public float Latitude { get; set; }
        public float Longitude { get; set; }
    }
}
