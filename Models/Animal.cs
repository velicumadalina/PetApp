using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetApp.Models
{
    public class Animal
    {
       public int Id { get; set; }
        public string Species { get; set; }
        public string[] Breeds { get; set; }
        public string[] Colors { get; set; }
        public string Age { get; set; }
        public string Gender { get; set; }
        public string Size { get; set; }
        public string Coat { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Photo { get; set; }
        public RestSharp.JsonArray Photos { get; set; }
        public string Status { get; set; }
        public string[] Attributes { get; set; }
        public string[] Tags { get; set; }
        public string[] ContactInfo { get; set; }





    }
}
