using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PetApp.Models
{
    public class Shelter
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Animal> Animals
        {
            get;set;
        }

        public string Image { get; set; }
        public string URL { get; set; }
        public string Email { get; set; }
        public int Capacity { get; set; }
        public string City { get; set; }
    }
}
