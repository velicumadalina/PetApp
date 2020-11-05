using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PetApp.Models
{
    public class AdoptionRequest
    {
        public int Id { get; set; }
        public int AnimalId { get; set; }
        public string AnimalName { get; set; }
        public string AnimalImage { get; set; }
        public int ShelterId { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string AdoptionMessasge { get; set; }
        public string AdoptionStatus { get; set; }

    }
}
