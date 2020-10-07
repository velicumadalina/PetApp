using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetApp.Models
{
    public class Animal
    {
        private List<string> _getsAlong = new List<string>();
       public int Id { get; set; }
        public string Species { get; set; }
        public Dictionary<string, string> Breeds { get; set; }
        public Dictionary<string, string> Colors { get; set; }
        public string Age { get; set; }
        public string Gender { get; set; }
        public string Size { get; set; }
        public string Coat { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Photo { get; set; }
        public RestSharp.JsonArray Photos { get; set; }
        public string Status { get; set; }
        public Dictionary<string, string> Attributes { get; set; }
        public Dictionary<string, string> Environment { get; set; }
        public RestSharp.JsonArray Tags { get; set; }
        public Dictionary<string, string> ContactInfo { get; set; }
        public List<String> GetsAlongWith 
        {
            get 
            {
                foreach (KeyValuePair<string, string> pair in Environment)
                {
                    if (pair.Value == "true")
                    {
                        _getsAlong.Add(pair.Key);
                    }
                }
                return _getsAlong;
            }
             }



    }
}
