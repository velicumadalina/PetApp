using WebApi_PetApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_PetApp.Models
{
    public interface IShelterRepository
    {
        IEnumerable<Shelter> GetShelter();
        Shelter GetShelter(int id);
        Shelter EditShelter(int id, Shelter shelter);
        Shelter AddShelter(Shelter shelter);
        Shelter DeleteShelter(int Id);
        bool ShelterExists(int id);
    }
}
