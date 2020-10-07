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

        public string Email { get; set; }

        public string URL { get; set; }

        public RestSharp.JsonArray Photos { get; set; }

        public string Photo { get; set; }
    }
}
