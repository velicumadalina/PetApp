using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PetApp.Models
{
    public class UserShelterRelation
    {
        public int Id { get; set; }

        [ForeignKey("Shelter")]
        public int ShelterId { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
    }
}
