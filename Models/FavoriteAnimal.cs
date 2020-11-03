using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetApp.Models
{
    public class FavoriteAnimal
    {
        public int Id { get; set; }
        public int AnimalId { get; set; }
        public string AnimalName { get; set; }
        public string AnimalImage { get; set; }
        public int UserId { get; set; }
    }
}
