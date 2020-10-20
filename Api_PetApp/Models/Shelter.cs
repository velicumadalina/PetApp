using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi_PetApp.Models
{
    public class Shelter
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Image { get; set; }
        public string URL { get; set; }
        public string Email { get; set; }
        public string Capacity { get; set; }
        public string City { get; set; }
    }
}