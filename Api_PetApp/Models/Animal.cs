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
        public string Color { get; set; }
    }
}