using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PetApp.Models
{
    public class Shelter
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Animals
        {
            get
            {
                return "https://api/animals?shelter=" + Id;
            }
            set { }
        }

        public string Image { get; set; }
        public string URL { get; set; }
        public string Email { get; set; }
        public int Capacity { get; set; }
        public string City { get; set; }
    }
}
